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
        private readonly PropertyGetter<int> _intGetter;
        private readonly PropertyGetter<double> _doubleGetter;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public PurchaseController(IProductRepository productRepository,
            UserManager<ApplicationUser> userManager, IPurchaseOperation purchaseOperation,
            IClientRepository clientRepository, PropertyGetter<int> intGetter, PropertyGetter<double> doubleGetter)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _purchaseOperation = purchaseOperation;
            _clientRepository = clientRepository;
            _intGetter = intGetter;
            _doubleGetter = doubleGetter;
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
                    CashBack = _doubleGetter.GetProperty(client.ClientId, "CashBack"),
                    CashBackPercent = _intGetter.GetProperty(client.ClientId, "CashBackPercent"),
                    DiscountPercent = _intGetter.GetProperty(client.ClientId, "DiscountPercent"),
                    Points = _doubleGetter.GetProperty(client.ClientId, "Points")
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
            var productDiscount = _intGetter.GetProperty(client.ClientId, "DiscountPercent");
            var priceToCompareWith = product.Price - product.Price * productDiscount / 100;
            var clientPoints = _doubleGetter.GetProperty(client.ClientId, "Points");
            var clientCashBack = _doubleGetter.GetProperty(client.ClientId, "CashBack");
            var productClientViewModelToReturnIfNotSucceed = new ProductClientViewModel
            {
                ClientId = client.ClientId,
                Balance = client.Balance,
                Product = product,
                CashBack = clientCashBack,
                CashBackPercent = _intGetter.GetProperty(client.ClientId, "CashBackPercent"),
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