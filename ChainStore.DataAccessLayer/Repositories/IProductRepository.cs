using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Store GetStoreOfSpecificProduct(Guid productId);
    }
}
