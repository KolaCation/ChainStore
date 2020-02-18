using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IStoreRepository
    {
        IReadOnlyCollection<Store> GetSAllStores();
        Store GetStore(Guid storeId);
        void AddStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(Guid storeId);
    }
}
