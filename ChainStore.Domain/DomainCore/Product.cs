using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Product
    {
        public Guid ProductId { get; }
        public string Name { get; }
        public double PriceInUAH { get; }
        public ProductStatus ProductStatus { get; private set; }
        public Guid CategoryId { get; }

        public Product(Guid productId, string name, double priceInUAH, ProductStatus productStatus, Guid categoryId)
        {
            CustomValidator.ValidateId(productId);
            CustomValidator.ValidateId(categoryId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(priceInUAH, 0, 1000000);
            ProductId = productId;
            Name = name;
            PriceInUAH = priceInUAH;
            ProductStatus = productStatus;
            CategoryId = categoryId;
        }

        public void ChangeStatus(ProductStatus productStatus)
        {
            ProductStatus = productStatus;
        }
    }
}