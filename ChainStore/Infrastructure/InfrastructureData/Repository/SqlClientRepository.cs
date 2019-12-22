using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlClientRepository : IClientRepository
    {
        private readonly MyDbContext _context;

        public SqlClientRepository(MyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Client> GetAllClients()
        {
            var clientsToReturn = _context.Clients.ToList();
            return new ReadOnlyCollection<Client>(clientsToReturn);
        }

        public Client GetClient(Guid clientId)
        {
            if (clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            var clientToReturn = _context.Clients.Find(clientId);
            return clientToReturn;
        }

        public void AddClient(Client client)
        {
            if (client == null) return;
            var checkForDuplicate = _context.Clients.Find(client.ClientId);
            if (checkForDuplicate != null) return;
            var enState = _context.Clients.Add(client);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateClient(Client client)
        {
            if (client == null) return;
            var checkForNull = _context.Clients.Find(client.ClientId);
            if (checkForNull == null) return;
            var enState = _context.Clients.Update(client);
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteClient(Guid clientId)
        {
            if (clientId.Equals(Guid.Empty)) return;
            var clientToRemove = _context.Clients.Find(clientId);
            if (clientToRemove == null) return;
            var enState = _context.Clients.Remove(clientToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}