using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.DataAccessLayerImpl.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChainStore.DataAccessLayerImpl
{
    public sealed class ClientUpdater : IClientUpdater
    {
        private readonly MyDbContext _context;
        private readonly ClientMapper _clientMapper;

        public ClientUpdater(MyDbContext context)
        {
            _context = context;
            _clientMapper = new ClientMapper(new PropertyGetter(ConnectionStringProvider.ConnectionString));
        }

        public void UpdateClientStatus(Client client, ClientStatus clientStatus)
        {
            CustomValidator.ValidateObject(client);
            Detach(client.ClientId);
            switch (clientStatus)
            {
                case ClientStatus.DefaultToReliable:
                    _context.Clients.Remove(_clientMapper.DomainToDb(client));
                    _context.SaveChanges();
                    var reliable = new ReliableClientDbModel(client.ClientId, client.Name, client.Balance, 0, 5);
                    _context.ReliableClients.Add(reliable);
                    _context.SaveChanges();
                    break;
                case ClientStatus.ReliableToVip:
                    var currentReliableClientDbModel = (ReliableClientDbModel) _clientMapper.DomainToDb(client);
                    _context.ReliableClients.Remove(currentReliableClientDbModel);
                    _context.SaveChanges();
                    var vipClientDbModel = new VipClientDbModel
                    (
                        currentReliableClientDbModel.ClientDbModelId,
                        currentReliableClientDbModel.Name,
                        currentReliableClientDbModel.Balance,
                        currentReliableClientDbModel.CashBack,
                        10, 0
                    );
                    _context.VipClients.Add(vipClientDbModel);
                    _context.SaveChanges();
                    break;
                case ClientStatus.DefaultToVip:
                    _context.Clients.Remove(_clientMapper.DomainToDb(client));
                    _context.SaveChanges();
                    var vip = new VipClientDbModel(client.ClientId, client.Name, client.Balance, 0, 10, 0);
                    _context.ReliableClients.Add(vip);
                    _context.SaveChanges();
                    break;
            }
        }

        private void Detach(Guid id)
        {
            CustomValidator.ValidateId(id);
            var entity = _context.Clients.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}
