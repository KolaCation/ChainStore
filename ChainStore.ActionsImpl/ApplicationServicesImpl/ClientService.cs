using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.Extensions.Configuration;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl
{
    public sealed class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly PropertyGetter _propertyGetter;

        public ClientService(IClientRepository clientRepository, IPurchaseRepository purchaseRepository,
            IProductRepository productRepository, IConfiguration config)
        {
            _clientRepository = clientRepository;
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _config = config;
            _propertyGetter = new PropertyGetter(_config.GetConnectionString("ChainStoreDBVer2"));
        }

        public bool TryUpdateClientStatus(Guid clientId, int daysInApplication)
        {
            CustomValidator.ValidateId(clientId);
            if (daysInApplication < 0) throw new ArgumentException();
            var client = _clientRepository.GetOne(clientId);
            if (client != null)
            {
                double sum = 0;
                var purchaseList = _purchaseRepository.GetClientPurchases(client.Id);
                if (purchaseList.Count != 0)
                {
                    var purchasedProducts =
                        (from purchase in purchaseList
                         where _productRepository.Exists(purchase.ProductId)
                         select _productRepository.GetOne(purchase.ProductId))
                        .ToList();
                    sum = purchasedProducts.Sum(pr => pr.PriceInUAH);
                }

                var checkCashBackPercent = _propertyGetter.GetProperty<int>(EntityNames.Client,
                    nameof(VipClient.CashBackPercent),
                    EntityNames.ClientId, client.Id);
                var checkDiscountPercent = _propertyGetter.GetProperty<int>(EntityNames.Client,
                    nameof(VipClient.DiscountPercent),
                    EntityNames.ClientId, client.Id);

                if (daysInApplication > 60 && checkCashBackPercent == 0)
                {
                    _clientRepository.DeleteOne(client.Id);
                    var reliable = new ReliableClient(client.Id, client.Name, client.Balance, 0, 5);
                    _clientRepository.AddReliableClient(reliable);
                }

                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent != 0)
                {
                    var currentReliableClient = (ReliableClient)client;
                    _clientRepository.DeleteOne(currentReliableClient.Id);
                    var vip = new VipClient
                    (
                        currentReliableClient.Id,
                        currentReliableClient.Name,
                        currentReliableClient.Balance,
                        currentReliableClient.CashBack,
                        10, 0
                    );
                    _clientRepository.AddReliableClient(vip);
                }

                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent == 0)
                {
                    _clientRepository.DeleteOne(client.Id);
                    var vip = new VipClient(client.Id, client.Name, client.Balance, 0, 10, 0);
                    _clientRepository.AddVipClient(vip);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}