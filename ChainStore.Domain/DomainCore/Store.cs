using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Store
    {
        public Guid StoreId { get; }
        public string Name { get; }
        public string Location { get; }
        public Guid? MallId { get; }

        private readonly List<Category> _categories;
        public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

        public double Profit { get; private set; }

        public Store(Guid storeId, string name, string location, double profit, Guid? mallId)
        {
            CustomValidator.ValidateId(storeId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            CustomValidator.ValidateNumber(profit, 0, double.MaxValue);
            CustomValidator.ValidateId(mallId);
            StoreId = storeId;
            Name = name;
            Location = location;
            Profit = profit;
            MallId = mallId;
            _categories = new List<Category>();
        }

        public Store(List<Category> categories, Guid storeId, string name, string location, Guid? mallId, double profit) : this(storeId, name, location, profit, mallId)
        {
            CustomValidator.ValidateObject(categories);
            _categories = categories;
        }

        public void GetProfit(double sum)
        {
            CustomValidator.ValidateNumber(sum, 0, 100_000_000);
            Profit += sum;
        }
    }
}