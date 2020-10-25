using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Product
    {
        public Guid Id { get; }
        public string Name { get; }
        public double PriceInUAH { get; }
        public ProductStatus ProductStatus { get; private set; }
        public Guid CategoryId { get; }

        public Product(Guid id, string name, double priceInUAH, ProductStatus productStatus, Guid categoryId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(categoryId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(priceInUAH, 0, 100_000_000);
            Id = id;
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