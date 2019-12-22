using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ChainStore.Domain.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Category
    {
        public Guid CategoryId { get; private set; }
        public CategoryNames CategoryName { get; private set; }
        public Guid? StoreId { get; private set; }
        public Store Store { get; private set; }

        private readonly List<Product> _products;
        public IReadOnlyCollection<Product> Products => new ReadOnlyCollection<Product>(_products);

        public Category(CategoryNames categoryName, Guid? storeId)
        {
            if (storeId != null && storeId.Value.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(storeId));
            CategoryId = Guid.NewGuid();
            CategoryName = categoryName;
            StoreId = storeId;
            _products = new List<Product>();
        }

        public void RemoveFromStore()
        {
            StoreId = null;
        }
    }
}