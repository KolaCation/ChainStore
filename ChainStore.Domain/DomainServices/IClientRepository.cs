using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IClientRepository
    {
        IReadOnlyCollection<Client> GetAllClients();
        Client GetClient(Guid clientId);
        void AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Guid clientId);
        double GetTotalSumOfClient(Guid clientId);
    }
}