using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        void AddReliableClient(ReliableClient client);
        void AddVipClient(VipClient client);
    }
}