﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.ApplicationServices;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using ChainStore.Infrastructure.InfrastructureData;

namespace ChainStore.Infrastructure.InfrastructureBusiness
{
    public class PurchaseOperation : IPurchaseOperation
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;
        private readonly PropertyGetter<int> _intGetter;
        private readonly PropertyGetter<double> _doubleGetter;

        public PurchaseOperation(IClientRepository clientRepository, IProductRepository productRepository,
            IPurchaseRepository purchaseRepository, IStoreRepository storeRepository, IBookRepository bookRepository,
            PropertyGetter<int> intGetter, PropertyGetter<double> doubleGetter)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
            _intGetter = intGetter;
            _doubleGetter = doubleGetter;
        }

        public void Perform(Guid clientId, Guid productId, bool useCashBack, bool usePoints)
        {
            if (clientId.Equals(Guid.Empty) || productId.Equals(Guid.Empty)) throw new ArgumentException();
            var client = _clientRepository.GetClient(clientId);
            var product = _productRepository.GetProduct(productId);
            if (client != null && product != null)
            {
                var books = _bookRepository.GetClientBooks(client.ClientId);
                var bookToDel = books.FirstOrDefault(b => b.ProductId.Equals(product.ProductId));
                if (product.ProductStatus.Equals(ProductStatus.Booked) && bookToDel != null)
                    _bookRepository.DeleteBook(bookToDel.BookId);
                var priceToCompareWith = product.Price -
                                         product.Price *
                                         _intGetter.GetProperty(client.ClientId, "DiscountPercent") / 100;
                var clientCashBack = _doubleGetter.GetProperty(client.ClientId, "CashBack");

                if (usePoints)
                {
                    priceToCompareWith = 0;
                    client.Pay(product.Price, false, true);
                }

                else if (useCashBack)
                {
                    if (clientCashBack > priceToCompareWith) priceToCompareWith = 0;
                    if (clientCashBack < priceToCompareWith) priceToCompareWith -= clientCashBack;
                    client.Pay(product.Price, true, false);
                }
                else
                {
                    client.Pay(product.Price, false, false);
                }

                product.Category.Store.Earn(priceToCompareWith);
                product.ChangeStatus(ProductStatus.Purchased);
                var purchase = new Purchase(clientId, productId);
                _clientRepository.UpdateClient(client);
                _storeRepository.UpdateStore(product.Category.Store);
                _productRepository.UpdateProduct(product);
                _purchaseRepository.AddPurchase(purchase);
            }
        }
    }
}