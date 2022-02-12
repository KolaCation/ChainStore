using ChainStore.DataAccessLayer.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.Mappers;

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
        return new Product(item.Id, item.Name, item.PriceInUAH, item.ProductStatus, item.CategoryId);
    }
}