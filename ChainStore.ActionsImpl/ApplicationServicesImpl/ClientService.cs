using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;
using IClientUpdater = ChainStore.DataAccessLayer.Helpers.IClientUpdater;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl
{
    public sealed class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientUpdater _clientService;
        private readonly PropertyGetter _propertyGetter;
        private readonly IConfiguration _configuration;

        public ClientService(IClientRepository clientRepository, IPurchaseRepository purchaseRepository,
            IProductRepository productRepository, IClientUpdater clientService, IConfiguration configuration)
        {
            _clientRepository = clientRepository;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _clientService = clientService;
            _configuration = configuration;
            _propertyGetter = new PropertyGetter(ConnectionStringProvider.ConnectionString);
        }

        public void CheckForStatusUpdate(Guid clientId, int daysInApplication)
        {
            CustomValidator.ValidateId(clientId);
            if (daysInApplication < 0) throw new ArgumentException();
            var client = _clientRepository.GetOne(clientId);
            if (client != null)
            {
                double sum = 0;
                var purchaseList = _purchaseRepository.GetClientPurchases(client.ClientId);
                if (purchaseList.Count != 0)
                {
                    var purchasedProducts = 
                        (from purchase in purchaseList
                        where _productRepository.Exists(purchase.ProductId)
                        select _productRepository.GetOne(purchase.ProductId))
                        .ToList();
                    sum = purchasedProducts.Sum(pr => pr.PriceInUAH);
                }

                var checkCashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.CashBackPercent),
                    EntityNames.ClientId, client.ClientId);
                var checkDiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Client, nameof(VipClient.DiscountPercent),
                    EntityNames.ClientId, client.ClientId);

                if (daysInApplication > 60 && checkCashBackPercent == 0)
                {
                    _clientService.UpdateClientStatus(client, ClientStatus.DefaultToReliable);
                }

                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent != 0)
                {
                    _clientService.UpdateClientStatus(client, ClientStatus.ReliableToVip);
                }

                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent == 0)
                {
                    _clientService.UpdateClientStatus(client, ClientStatus.DefaultToVip);
                }
            }
        }
    }
}