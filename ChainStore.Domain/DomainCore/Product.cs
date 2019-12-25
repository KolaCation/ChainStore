using System;
using ChainStore.Domain.Util;

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
            Validator.CheckId(categoryId);
            ProductId = Guid.NewGuid();
            Validator.CheckName(name);
            Validator.CheckPrice(price);
            Name = name;
            Price = price;
            ProductStatus = productStatus;
            CategoryId = categoryId;
            //lala
        }

        public void ChangeStatus(ProductStatus productStatus)
        {
            ProductStatus = productStatus;
        }
    }
}