using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public ProductStatus ProductStatus { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, double price, ProductStatus productStatus, Guid categoryId)
        {
            CustomValidator.ValidateId(categoryId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(price, 0, 1000000);
            ProductId = Guid.NewGuid();
            Name = name;
            Price = price;
            ProductStatus = productStatus;
            CategoryId = categoryId;
        }

        public void ChangeStatus(ProductStatus productStatus)
        {
            ProductStatus = productStatus;
        }
    }
}