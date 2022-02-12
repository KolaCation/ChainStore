using System;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly PropertyGetter _propertyGetter;
    private readonly IPurchaseRepository _purchaseRepository;

    public CustomerService(ICustomerRepository customerRepository, IPurchaseRepository purchaseRepository,
        IProductRepository productRepository, IConfiguration config)
    {
        _customerRepository = customerRepository;
        _purchaseRepository = purchaseRepository;
        _productRepository = productRepository;
        _propertyGetter = new PropertyGetter(config.GetConnectionString("ChainStoreDBVer2"));
    }

    public bool TryUpdateCustomerStatus(Guid customerId, int daysInApplication)
    {
        CustomValidator.ValidateId(customerId);
        if (daysInApplication < 0) throw new ArgumentException();
        var customer = _customerRepository.GetOne(customerId);
        if (customer != null)
        {
            double sum = 0;
            var purchaseList = _purchaseRepository.GetCustomerPurchases(customer.Id);
            if (purchaseList.Count != 0)
            {
                var purchasedProducts =
                    (from purchase in purchaseList
                        where _productRepository.Exists(purchase.ProductId)
                        select _productRepository.GetOne(purchase.ProductId))
                    .ToList();
                sum = purchasedProducts.Sum(pr => pr.PriceInUAH);
            }

            var checkCashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
                nameof(VipCustomer.CashBackPercent),
                EntityNames.CustomerId, customer.Id);
            var checkDiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Customer,
                nameof(VipCustomer.DiscountPercent),
                EntityNames.CustomerId, customer.Id);

            if (daysInApplication > 60 && checkCashBackPercent == 0)
            {
                _customerRepository.DeleteOne(customer.Id);
                var reliable = new ReliableCustomer(customer.Id, customer.Name, customer.Balance, 0, 5);
                _customerRepository.AddReliableCustomer(reliable);
            }

            if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent != 0)
            {
                var currentReliableCustomer = (ReliableCustomer) customer;
                _customerRepository.DeleteOne(currentReliableCustomer.Id);
                var vip = new VipCustomer
                (
                    currentReliableCustomer.Id,
                    currentReliableCustomer.Name,
                    currentReliableCustomer.Balance,
                    currentReliableCustomer.CashBack,
                    10, 0
                );
                _customerRepository.AddReliableCustomer(vip);
            }

            if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent == 0)
            {
                _customerRepository.DeleteOne(customer.Id);
                var vip = new VipCustomer(customer.Id, customer.Name, customer.Balance, 0, 10, 0);
                _customerRepository.AddVipCustomer(vip);
            }

            return true;
        }

        return false;
    }
}