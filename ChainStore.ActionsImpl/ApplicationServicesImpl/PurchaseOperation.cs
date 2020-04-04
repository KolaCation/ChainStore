﻿using System;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl
{
    public class PurchaseOperation : IPurchaseOperation
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly PropertyGetter _propertyGetter;

        public PurchaseOperation(IClientRepository clientRepository, IProductRepository productRepository,
            IPurchaseRepository purchaseRepository, IStoreRepository storeRepository, IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _propertyGetter = new PropertyGetter(ConnectionStringProvider.ConnectionString);
        }

        public void Perform(Guid clientId, Guid productId, bool useCashBack, bool usePoints)
        {
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            var client = _clientRepository.GetOne(clientId);
            var product = _productRepository.GetOne(productId);
            if (client != null && product != null)
            {
                var books = _bookRepository.GetClientBooks(client.ClientId);
                var bookToDel = books.FirstOrDefault(b => b.ProductId.Equals(product.ProductId));
                if (product.ProductStatus.Equals(ProductStatus.Booked) && bookToDel != null) _bookRepository.DeleteOne(bookToDel.BookId);
                var priceToCompareWith = product.PriceInUAH - product.PriceInUAH * _propertyGetter.GetProperty<int>("ClientDbModel", "DiscountPercent", "ClientDbModelId", client.ClientId) / 100;
                var clientCashBack = _propertyGetter.GetProperty<double>("ClientDbModel", "CashBack", "ClientDbModelId", client.ClientId);
                bool res;
                if (usePoints)
                {
                    priceToCompareWith = 0;
                    res = client.Pay(product.PriceInUAH, false, true);
                }

                else if (useCashBack)
                {
                    if (clientCashBack > priceToCompareWith) priceToCompareWith = 0;
                    if (clientCashBack < priceToCompareWith) priceToCompareWith -= clientCashBack;
                    res = client.Pay(product.PriceInUAH, true, false);
                }
                else
                {
                    res = client.Pay(product.PriceInUAH, false, false);
                }

                if (!res) return;
                var category = _categoryRepository.GetOne(product.CategoryId);
                var store = _storeRepository.GetOne(category.StoreId.Value);
                store.Earn(priceToCompareWith);
                product.ChangeStatus(ProductStatus.Purchased);
                var purchase = new Purchase(Guid.NewGuid(), clientId, productId);
                _clientRepository.UpdateOne(client);
                _storeRepository.UpdateOne(store);
                _productRepository.UpdateOne(product);
                _purchaseRepository.AddOne(purchase);
            }
        }
    }
}