using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IPurchaseRepository
    {
        void AddPurchase(Purchase purchase);
        void DeletePurchase(Guid purchaseId);
    }
}
