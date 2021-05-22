using ChainStore.Domain.DomainCore;
using System;
using System.Collections.Generic;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IPurchaseRepository : ICreateDeleteRepository<Purchase>
    {
        List<Purchase> GetClientPurchases(Guid clientId);
    }
}
