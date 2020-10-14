using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Category
    {
        public Guid CategoryId { get; }
        public string Name { get; }

        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(Guid categoryId, string name)
        {
            CustomValidator.ValidateId(categoryId);
            CustomValidator.ValidateString(name, 2, 40);
            CategoryId = categoryId;
            Name = name;
        }

        public Category(List<Product> products, Guid categoryId, string name) : this(categoryId, name)
        {
            CustomValidator.ValidateObject(products);
            _products = products;
        }
    }
}