using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.DataAccessLayerImpl.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChainStore.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPurchaseService _purchaseService;
        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _config;
        private readonly PropertyGetter _propertyGetter;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public PurchaseController(IProductRepository productRepository,
            UserManager<ApplicationUser> userManager, IPurchaseService purchaseService,
            IClientRepository clientRepository, IConfiguration config)
        {
            _productRepository = productRepository;
            _userManager = userManager;
            _purchaseService = purchaseService;
            _clientRepository = clientRepository;
            _config = config;
            _propertyGetter = new PropertyGetter(_config.GetConnectionString("ChainStoreDBVer2"));
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseOperation(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var productToBuy = _productRepository.GetOne(id.Value);
            if (productToBuy == null) return View("ProductNotFound", id.Value);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return View("ClientNotFound");

            var client = _clientRepository.GetOne(user.ClientDbModelId);

            if (client != null)
            {
                var productClientViewModel = new ProductClientViewModel
                {
                    ClientId = client.ClientId,
                    Balance = client.Balance,
                    Product = productToBuy,
                    CashBack = _propertyGetter.GetProperty<double>(EntityNames.Client, nameof(VipClient.CashBack), EntityNames.ClientId,
                        client.ClientId),
                    CashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.CashBackPercent), EntityNames.ClientId,
                        client.ClientId),
                    DiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.DiscountPercent), EntityNames.ClientId,
                        client.ClientId),
                    Points = _propertyGetter.GetProperty<double>(EntityNames.Client, nameof(VipClient.Points), EntityNames.ClientId, client.ClientId)
                };
                return View(productClientViewModel);
            }

            return RedirectToAction(IndexAction, DefaultController);
        }

        [HttpPost]
        public IActionResult PurchaseOperation(ProductClientViewModel productClientViewModel)
        {
            var client = _clientRepository.GetOne(productClientViewModel.ClientId);
            if (client == null) return View("ClientNotFound", productClientViewModel.ClientId);
            var product = _productRepository.GetOne(productClientViewModel.ProductId);
            if (product == null) return View("ProductNotFound", productClientViewModel.ProductId);
            string message;
            var productDiscount =
                _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.DiscountPercent), EntityNames.ClientId, client.ClientId);

            var priceToCompareWith =
                product.PriceInUAH - product.PriceInUAH * productDiscount / 100;

            var clientPoints =
                _propertyGetter.GetProperty<double>(EntityNames.Client, nameof(VipClient.Points), EntityNames.ClientId, client.ClientId);

            var clientCashBack =
                _propertyGetter.GetProperty<double>(EntityNames.Client, nameof(VipClient.CashBack), EntityNames.ClientId, client.ClientId);

            var productClientViewModelToReturnIfNotSucceed = new ProductClientViewModel
            {
                ClientId = client.ClientId,
                Balance = client.Balance,
                Product = product,
                CashBack = clientCashBack,
                CashBackPercent =
                    _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.CashBackPercent), EntityNames.ClientId, client.ClientId),
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
                return View(productClientViewModelToReturnIfNotSucceed);
            }

            if (!productClientViewModel.UsePoints && !productClientViewModel.UseCashBack &&
                client.Balance < priceToCompareWith)
            {
                message = "Not Enough Money";
                ModelState.AddModelError(string.Empty, message);
                return View(productClientViewModelToReturnIfNotSucceed);
            }
            
            _purchaseService.HandleOperation(productClientViewModel.ClientId, productClientViewModel.ProductId,
                productClientViewModel.UseCashBack, productClientViewModel.UsePoints);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}