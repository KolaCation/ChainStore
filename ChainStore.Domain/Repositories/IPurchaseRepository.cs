using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.Repositories;

public interface IPurchaseRepository : ICreateDeleteRepository<Purchase>
{
    List<Purchase> GetCustomerPurchases(Guid customerId);
}