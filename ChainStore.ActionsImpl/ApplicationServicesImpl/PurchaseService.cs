using System;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.DataAccessLayerImpl.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly PropertyGetter _propertyGetter;

        public PurchaseService(IClientRepository clientRepository, IProductRepository productRepository,
            IPurchaseRepository purchaseRepository, IStoreRepository storeRepository,
            IBookRepository bookRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
            _propertyGetter = new PropertyGetter(configuration.GetConnectionString("ChainStoreDBVer2"));
        }

        public void HandleOperation(Guid clientId, Guid productId, bool useCashBack, bool usePoints)
        {
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            var client = _clientRepository.GetOne(clientId);
            var product = _productRepository.GetOne(productId);
            if (client != null && product != null)
            {
                var books = _bookRepository.GetClientBooks(client.Id);
                var bookToDel = books.FirstOrDefault(b => b.ProductId.Equals(product.Id));
                if (product.ProductStatus.Equals(ProductStatus.Booked) && bookToDel != null) _bookRepository.DeleteOne(bookToDel.Id);
                var priceToCompareWith = product.PriceInUAH - product.PriceInUAH * _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.DiscountPercent), EntityNames.ClientId, client.Id) / 100;
                var clientCashBack = _propertyGetter.GetProperty<double>(EntityNames.Client, nameof(VipClient.CashBack), EntityNames.ClientId, client.Id);
                bool res;
                if (usePoints)
                {
                    priceToCompareWith = 0;
                    res = client.Charge(product.PriceInUAH, false, true);
                }

                else if (useCashBack)
                {
                    if (clientCashBack > priceToCompareWith) priceToCompareWith = 0;
                    if (clientCashBack < priceToCompareWith) priceToCompareWith -= clientCashBack;
                    res = client.Charge(product.PriceInUAH, true, false);
                }
                else
                {
                    res = client.Charge(product.PriceInUAH, false, false);
                }

                if (!res) return;
                var store = _productRepository.GetStoreOfSpecificProduct(product.Id);
                store.GetProfit(priceToCompareWith);
                product.ChangeStatus(ProductStatus.Purchased);
                var purchase = new Purchase(Guid.NewGuid(), clientId, productId, priceToCompareWith);
                _clientRepository.UpdateOne(client);
                _storeRepository.UpdateOne(store);
                _productRepository.UpdateOne(product);
                _purchaseRepository.AddOne(purchase);
            }
        }
    }
}