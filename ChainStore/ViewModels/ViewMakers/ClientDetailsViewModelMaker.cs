using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.DataAccessLayerImpl.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using ChainStore.ViewModels.ViewMakers.DetailedInfo;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ViewModels.ViewMakers
{
    public class ClientDetailsViewModelMaker
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IConfiguration _configuration;
        private readonly PropertyGetter _propertyGetter;

        public ClientDetailsViewModelMaker(IClientRepository clientRepository, IProductRepository productRepository, IPurchaseRepository purchaseRepository,
            IBookRepository bookRepository, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _bookRepository = bookRepository;
            _configuration = configuration;
            _propertyGetter = new PropertyGetter(ConnectionStringProvider.ConnectionString);
        }

        public ClientDetailsViewModel MakeClientDetailsViewModel(Guid clientId)
        {
            if (clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            var exists = _clientRepository.Exists(clientId);
            if (!exists) return null;
            var body = _clientRepository.GetOne(clientId);
            var purchases = (from product in _productRepository.GetAll()
                    join purchase in _purchaseRepository.GetClientPurchases(clientId) on product.ProductId equals purchase.ProductId
                    select new PurchaseDetailedInfo(product, purchase.ClientId, purchase.CreationTime))
                .ToList();

            var books = (from product in _productRepository.GetAll()
                    join book in _bookRepository.GetClientBooks(clientId) on product.ProductId equals book.ProductId
                    select new BookDetailedInfo(product, book.ClientId, book.CreationTime, book.ExpirationTime))
                .ToList();

            var client = new List<Client> {body};
            var clCashBack =  _propertyGetter.GetProperty<double>( EntityNames.Client, "CashBack", EntityNames.ClientId, body.ClientId);
            var clCashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Client, "CashBackPercent", EntityNames.ClientId, body.ClientId);
            var clDiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Client,"DiscountPercent", EntityNames.ClientId, body.ClientId);
            var clPoints = _propertyGetter.GetProperty<double>(EntityNames.Client, "Points", EntityNames.ClientId, body.ClientId);

            var clientDetailedInfo = (from cl in client
                join purchase in purchases on cl.ClientId equals purchase.ClientId into purchasesList
                join book in books on cl.ClientId equals book.ClientId into booksList
                select new ClientDetailsViewModel(purchasesList, booksList, cl.ClientId, cl.Name,
                    cl.Balance, clCashBack, clCashBackPercent, clDiscountPercent, clPoints)).First();
            return clientDetailedInfo;
        }
    }
}