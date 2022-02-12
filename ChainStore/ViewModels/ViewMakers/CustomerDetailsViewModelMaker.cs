using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using ChainStore.ViewModels.ViewMakers.DetailedInfo;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ViewModels.ViewMakers;

public class CustomerDetailsViewModelMaker
{
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly PropertyGetter _propertyGetter;
    private readonly IPurchaseRepository _purchaseRepository;

    public CustomerDetailsViewModelMaker(ICustomerRepository customerRepository, IProductRepository productRepository,
        IPurchaseRepository purchaseRepository,
        IBookRepository bookRepository, IConfiguration config)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
        _purchaseRepository = purchaseRepository;
        _bookRepository = bookRepository;
        _propertyGetter = new PropertyGetter(config.GetConnectionString("ChainStoreDBVer2"));
    }

    public CustomerDetailsViewModel MakeCustomerDetailsViewModel(Guid customerId)
    {
        if (customerId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(customerId));
        var exists = _customerRepository.Exists(customerId);
        if (!exists) return null;
        var body = _customerRepository.GetOne(customerId);
        var purchases = (from product in _productRepository.GetAll()
                join purchase in _purchaseRepository.GetCustomerPurchases(customerId) on product.Id equals purchase
                    .ProductId
                select new PurchaseDetailedInfo(product, purchase.CustomerId, purchase.CreationTime))
            .ToList();

        var books = (from product in _productRepository.GetAll()
                join book in _bookRepository.GetCustomerBooks(customerId) on product.Id equals book.ProductId
                select new BookDetailedInfo(product, book.CustomerId, book.CreationTime, book.ExpirationTime))
            .ToList();

        var customer = new List<Customer> {body};
        var clCashBack = _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.CashBack),
            EntityNames.CustomerId, body.Id);
        var clCashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
            nameof(VipCustomer.CashBackPercent), EntityNames.CustomerId, body.Id);
        var clDiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
            nameof(VipCustomer.DiscountPercent), EntityNames.CustomerId, body.Id);
        var clPoints = _propertyGetter.GetProperty<double>(EntityNames.Customer, nameof(VipCustomer.Points),
            EntityNames.CustomerId, body.Id);

        var customerDetailedInfo = (from cl in customer
            join purchase in purchases on cl.Id equals purchase.CustomerId into purchasesList
            join book in books on cl.Id equals book.CustomerId into booksList
            select new CustomerDetailsViewModel(purchasesList, booksList, cl.Id, cl.Name,
                cl.Balance, clCashBack, clCashBackPercent, clDiscountPercent, clPoints)).First();
        return customerDetailedInfo;
    }
}