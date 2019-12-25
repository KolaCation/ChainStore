using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;
using ChainStore.Infrastructure.InfrastructureData;

namespace ChainStore.Infrastructure.InfrastructureBusiness
{
    public sealed class ClientUpdater
    {
        private readonly MyDbContext _context;
        private readonly PropertyGetter _propertyGetter;

        public ClientUpdater(MyDbContext context, PropertyGetter propertyGetter)
        {
            _context = context;
            _propertyGetter = propertyGetter;
        }

        public void UpdateClient(Guid clientId, int daysInApplication)
        {
            if (clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            if (daysInApplication < 0) throw new ArgumentException();
            var client = _context.Clients.Find(clientId);
            if (client != null)
            {
                double sum = 0;
                var purchaseList = _context.Purchases.Where(p => p.ClientId.Equals(clientId)).ToList();
                if (purchaseList.Count != 0)
                    sum = purchaseList.Sum(purchase => _context.Products.Find(purchase.ProductId).Price);
                var checkCashBackPercent = _propertyGetter.GetProperty<int>("dbo.Clients", "CashBackPercent", "ClientId", client.ClientId);
                var checkDiscountPercent = _propertyGetter.GetProperty<int>("dbo.Clients", "DiscountPercent", "ClientId", client.ClientId);
                if (daysInApplication > 60 && checkCashBackPercent == 0)
                {
                    _context.Clients.Remove(client);
                    _context.SaveChanges();
                    _context.ReliableClients.Add(new ReliableClient(client.ClientId, client.Name, client.Balance, 0,
                        5));
                    _context.SaveChanges();
                }
                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent != 0)
                {
                    var reliableClient = (ReliableClient) client;
                    _context.ReliableClients.Remove(reliableClient);
                    _context.SaveChanges();
                    _context.VipClients.Add(new VipClient(reliableClient.ClientId, reliableClient.Name,
                        reliableClient.Balance, reliableClient.CashBack, 10));
                    _context.SaveChanges();
                }

                if (daysInApplication > 60 && sum >= 200_000 && checkDiscountPercent == 0 && checkCashBackPercent == 0)
                {
                    _context.Clients.Remove(client);
                    _context.SaveChanges();
                    _context.VipClients.Add(new VipClient(client.ClientId, client.Name, client.Balance, 0,
                        10));
                    _context.SaveChanges();
                }
            }
        }
    }
}