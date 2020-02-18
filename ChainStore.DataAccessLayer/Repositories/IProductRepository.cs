using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IProductRepository
    {
        IReadOnlyCollection<Product> GetAllProducts();
        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Guid productId);
    }
}
