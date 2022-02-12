using System;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl;

public class PurchaseService : IPurchaseService
{
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly PropertyGetter _propertyGetter;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IStoreRepository _storeRepository;

    public PurchaseService(ICustomerRepository customerRepository, IProductRepository productRepository,
        IPurchaseRepository purchaseRepository, IStoreRepository storeRepository,
        IBookRepository bookRepository, IConfiguration configuration)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _purchaseRepository = purchaseRepository;
        _storeRepository = storeRepository;
        _bookRepository = bookRepository;
        _propertyGetter = new PropertyGetter(configuration.GetConnectionString("ChainStoreDBVer2"));
    }

    public void HandleOperation(Guid customerId, Guid productId, bool useCashBack, bool usePoints)
    {
        CustomValidator.ValidateId(customerId);
        CustomValidator.ValidateId(productId);
        var customer = _customerRepository.GetOne(customerId);
        var product = _productRepository.GetOne(productId);
        if (customer == null || product == null) return;
        var books = _bookRepository.GetCustomerBooks(customer.Id);
        var bookToDel = books.FirstOrDefault(b => b.ProductId.Equals(product.Id));
        if (product.ProductStatus.Equals(ProductStatus.Booked) && bookToDel != null)
            _bookRepository.DeleteOne(bookToDel.Id);
        var priceToCompareWith = product.PriceInUAH - product.PriceInUAH *
            _propertyGetter.GetProperty<int>(EntityNames.Customer, nameof(VipCustomer.DiscountPercent),
                EntityNames.CustomerId, customer.Id) / 100;
        var customerCashBack = _propertyGetter.GetProperty<double>(EntityNames.Customer,
            nameof(VipCustomer.CashBack), EntityNames.CustomerId, customer.Id);
        bool res;
        if (usePoints)
        {
            priceToCompareWith = 0;
            res = customer.Charge(product.PriceInUAH, false, true);
        }

        else if (useCashBack)
        {
            if (customerCashBack > priceToCompareWith) priceToCompareWith = 0;
            if (customerCashBack < priceToCompareWith) priceToCompareWith -= customerCashBack;
            res = customer.Charge(product.PriceInUAH, true, false);
        }
        else
        {
            res = customer.Charge(product.PriceInUAH, false, false);
        }

        if (!res) return;
        var store = _productRepository.GetStoreOfSpecificProduct(product.Id);
        store.GetProfit(priceToCompareWith);
        product.ChangeStatus(ProductStatus.Purchased);
        var purchase = new Purchase(Guid.NewGuid(), customerId, productId, priceToCompareWith);
        _customerRepository.UpdateOne(customer);
        _storeRepository.UpdateOne(store);
        _productRepository.UpdateOne(product);
        _purchaseRepository.AddOne(purchase);
    }
}