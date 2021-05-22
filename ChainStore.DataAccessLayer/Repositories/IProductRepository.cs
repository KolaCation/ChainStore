using ChainStore.Domain.DomainCore;
using System;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Store GetStoreOfSpecificProduct(Guid productId);
        void AddProductToStore(Product product, Guid storeId);
        void DeleteProductFromStore(Product product, Guid storeId);
    }
}
