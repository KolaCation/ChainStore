using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.ApplicationServices;
using ChainStore.Domain.DomainServices;
using ChainStore.Identity;
using ChainStore.Infrastructure.InfrastructureData;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPurchaseOperation _purchaseOperation;
        private readonly IClientRepository _clientRepository;
        private readonly PropertyGetter _propertyGetter;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public PurchaseController(IProductRepository productRepository,
            UserManager<ApplicationUser> userManager, IPurchaseOperation purchaseOperation,
            IClientRepository clientRepository, PropertyGetter propertyGetter)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _purchaseOperation = purchaseOperation;
            _clientRepository = clientRepository;
            _propertyGetter = propertyGetter;
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseOperation(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var productToBuy = _productRepository.GetProduct(id.Value);
            if (productToBuy == null) return RedirectToAction(IndexAction, DefaultController);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction(IndexAction, DefaultController);

            var client = _clientRepository.GetClient(user.ClientId);

            if (client != null)
            {
                var productClientViewModel = new ProductClientViewModel
                {
                    ClientId = client.ClientId,
                    Balance = client.Balance,
                    Product = productToBuy,
                    CashBack = _propertyGetter.GetProperty<double>("dbo.Clients", "CashBack", "ClientId", client.ClientId),
                    CashBackPercent = _propertyGetter.GetProperty<int>("dbo.Clients", "CashBackPercent", "ClientId", client.ClientId),
                    DiscountPercent = _propertyGetter.GetProperty<int>("dbo.Clients", "DiscountPercent", "ClientId", client.ClientId),
                    Points = _propertyGetter.GetProperty<double>("dbo.Clients", "Points",  "ClientId", client.ClientId)
                };
                return View(productClientViewModel);
            }

            return RedirectToAction(IndexAction, DefaultController);
        }

        [HttpPost]
        public IActionResult PurchaseOperation(ProductClientViewModel productClientViewModel)
        {
            var client = _clientRepository.GetClient(productClientViewModel.ClientId);
            var product = _productRepository.GetProduct(productClientViewModel.ProductId);
            if (client == null || product == null) return RedirectToAction(IndexAction, DefaultController);
            string message;
            var productDiscount = _propertyGetter.GetProperty<int>("dbo.Clients", "DiscountPercent", "ClientId", client.ClientId);
            var priceToCompareWith = product.Price - product.Price * productDiscount / 100;
            var clientPoints = _propertyGetter.GetProperty<double>("dbo.Clients", "Points", "ClientId", client.ClientId);
            var clientCashBack = _propertyGetter.GetProperty<double>("dbo.Clients", "CashBack", "ClientId", client.ClientId);
            var productClientViewModelToReturnIfNotSucceed = new ProductClientViewModel
            {
                ClientId = client.ClientId,
                Balance = client.Balance,
                Product = product,
                CashBack = clientCashBack,
                CashBackPercent = _propertyGetter.GetProperty<int>("dbo.Clients", "CashBackPercent", "ClientId", client.ClientId),
                DiscountPercent = productDiscount,
                Points = clientPoints,
                UseCashBack = productClientViewModel.UseCashBack,
                UsePoints = productClientViewModel.UsePoints
            };
            if (productClientViewModel.UsePoints && clientPoints < priceToCompareWith / 1000)
            {
                message = "Not Enough Points";
                ModelState.AddModelError(string.Empty, message);
                return View(productClientViewModelToReturnIfNotSucceed);
            }

            if (productClientViewModel.UseCashBack &&
                client.Balance + clientCashBack < priceToCompareWith)
            {
                message = "Not Enough Money & Cash Back";
                ModelState.AddModelError(string.Empty, message);
                _purchaseOperation.Perform(productClientViewModel.ClientId, productClientViewModel.ProductId,
                    productClientViewModel.UseCashBack, productClientViewModel.UsePoints);
                return View(productClientViewModelToReturnIfNotSucceed);
            }

            _purchaseOperation.Perform(productClientViewModel.ClientId, productClientViewModel.ProductId,
                productClientViewModel.UseCashBack, productClientViewModel.UsePoints);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}