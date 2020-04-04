using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Category
    {
        public Guid CategoryId { get; }
        public CategoryNames CategoryName { get; }
        public Guid? StoreId { get; }

        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

        public Category(Guid categoryId, CategoryNames categoryName, Guid? storeId)
        {
            CustomValidator.ValidateId(categoryId);
            CategoryId = categoryId;
            CategoryName = categoryName;
            StoreId = storeId;
        }

        public Category(List<Product> products, Guid categoryId, CategoryNames categoryName, Guid? storeId) : this(categoryId, categoryName, storeId)
        {
            CustomValidator.ValidateObject(products);
            _products = products;
        }
    }
}