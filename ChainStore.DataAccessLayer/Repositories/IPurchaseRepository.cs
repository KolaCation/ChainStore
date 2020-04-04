using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IPurchaseRepository : ICreateDeleteRepository<Purchase>
    {
        List<Purchase> GetClientPurchases(Guid clientId);
    }
}
