using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Store GetStoreOfSpecificProduct(Guid productId);
    void AddProductToStore(Product product, Guid storeId);
    void DeleteProductFromStore(Product product, Guid storeId);
}