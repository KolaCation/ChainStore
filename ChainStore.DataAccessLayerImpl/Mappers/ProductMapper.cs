using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class ProductMapper : IMapper<Product, ProductDbModel>
    {
        public ProductDbModel DomainToDb(Product item)
        {
            CustomValidator.ValidateObject(item);
            return new ProductDbModel(item.Id, item.Name, item.PriceInUAH, item.ProductStatus, item.CategoryId);
        }

        public Product DbToDomain(ProductDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new Product(item.Id, item.Name, item.PriceInUAH, item.ProductStatus, item.Id);
        }
    }
}
