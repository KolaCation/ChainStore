using System;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChainStore.Controllers;

[Authorize]
public class PurchaseController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly PropertyGetter _propertyGetter;
    private readonly IPurchaseService _purchaseService;
    private readonly UserManager<ApplicationUser> _userManager;

    public PurchaseController(IProductRepository productRepository,
        UserManager<ApplicationUser> userManager, IPurchaseService purchaseService,
        ICustomerRepository customerRepository, IConfiguration config)
    {
        _productRepository = productRepository;
        _userManager = userManager;
        _purchaseService = purchaseService;
        _customerRepository = customerRepository;
        _propertyGetter = new PropertyGetter(config.GetConnectionString("ChainStoreDBVer2"));
    }

    [HttpGet]
    public async Task<IActionResult> PurchaseOperation(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var productToBuy = _productRepository.GetOne(id.Value);
        if (productToBuy == null) return View("ProductNotFound", id.Value);

        var user = await _userManager.GetUserAsync(User);
        if (user == null) return View("CustomerNotFound");

        var customer = _customerRepository.GetOne(user.CustomerDbModelId);

        if (customer != null)
        {
            var productCustomerViewModel = new ProductCustomerViewModel
            {
                CustomerId = customer.Id,
                Balance = customer.Balance,
                Product = productToBuy,
                CashBack = _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.CashBack),
                    EntityNames.CustomerId,
                    customer.Id),
                CashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
                    nameof(VipCustomer.CashBackPercent), EntityNames.CustomerId,
                    customer.Id),
                DiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
                    nameof(VipCustomer.DiscountPercent), EntityNames.CustomerId,
                    customer.Id),
                Points = _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.Points),
                    EntityNames.CustomerId, customer.Id)
            };
            return View(productCustomerViewModel);
        }

        return RedirectToAction(IndexAction, DefaultController);
    }

    [HttpPost]
    public IActionResult PurchaseOperation(ProductCustomerViewModel productCustomerViewModel)
    {
        var customer = _customerRepository.GetOne(productCustomerViewModel.CustomerId);
        if (customer == null) return View("CustomerNotFound", productCustomerViewModel.CustomerId);
        var product = _productRepository.GetOne(productCustomerViewModel.ProductId);
        if (product == null) return View("ProductNotFound", productCustomerViewModel.ProductId);
        string message;
        var productDiscount =
            _propertyGetter.GetProperty<int>(EntityNames.Customer, nameof(VipCustomer.DiscountPercent),
                EntityNames.CustomerId, customer.Id);

        var priceToCompareWith =
            product.PriceInUAH - product.PriceInUAH * productDiscount / 100;

        var customerPoints =
            _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.Points),
                EntityNames.CustomerId, customer.Id);

        var customerCashBack =
            _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.CashBack),
                EntityNames.CustomerId, customer.Id);

        var productCustomerViewModelToReturnIfNotSucceed = new ProductCustomerViewModel
        {
            CustomerId = customer.Id,
            Balance = customer.Balance,
            Product = product,
            CashBack = customerCashBack,
            CashBackPercent =
                _propertyGetter.GetProperty<int>(EntityNames.Customer, nameof(VipCustomer.CashBackPercent),
                    EntityNames.CustomerId, customer.Id),
            DiscountPercent = productDiscount,
            Points = customerPoints,
            UseCashBack = productCustomerViewModel.UseCashBack,
            UsePoints = productCustomerViewModel.UsePoints
        };
        if (productCustomerViewModel.UsePoints && customerPoints < priceToCompareWith / 1000)
        {
            message = "Not Enough Points";
            ModelState.AddModelError(string.Empty, message);
            return View(productCustomerViewModelToReturnIfNotSucceed);
        }

        if (productCustomerViewModel.UseCashBack &&
            customer.Balance + customerCashBack < priceToCompareWith)
        {
            message = "Not Enough Money & Cash Back";
            ModelState.AddModelError(string.Empty, message);
            return View(productCustomerViewModelToReturnIfNotSucceed);
        }

        if (!productCustomerViewModel.UsePoints && !productCustomerViewModel.UseCashBack &&
            customer.Balance < priceToCompareWith)
        {
            message = "Not Enough Money";
            ModelState.AddModelError(string.Empty, message);
            return View(productCustomerViewModelToReturnIfNotSucceed);
        }

        _purchaseService.HandleOperation(productCustomerViewModel.CustomerId, productCustomerViewModel.ProductId,
            productCustomerViewModel.UseCashBack, productCustomerViewModel.UsePoints);
        return RedirectToAction(IndexAction, DefaultController);
    }
}