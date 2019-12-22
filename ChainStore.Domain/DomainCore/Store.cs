using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Validator = ChainStore.Domain.Util.Validator;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Store
    {
        public Guid StoreId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public Guid? MallId{ get; private set; }
        public Mall Mall{ get; private set; }

        private readonly List<Category> _categories;
        public IReadOnlyCollection<Category> Categories => new ReadOnlyCollection<Category>(_categories);

        public double Profit { get; private set; }

        public Store(string name, string location, Guid? mallId)
        {
            StoreId = Guid.NewGuid();
            MallId = mallId;
            Validator.CheckName(name);
            Validator.CheckLocation(location);
            Name = name;
            Location = location;
            Profit = 0;
            _categories = new List<Category>();
        }

        public void ChangeName(string newName)
        {
            Validator.CheckName(newName);
            Name = newName;
        }

        public void ChangeLocation(string newLocation)
        {
            Validator.CheckLocation(newLocation);
            Location = newLocation;
        }

        public void MoveToMall(Guid mallIId, string mallLocation)
        {
            MallId = mallIId;
            ChangeLocation(mallLocation);
        }

        public void MoveFromMall(string newLocation)
        {
            MallId = null;
            ChangeLocation(newLocation);
        }

        public void Earn(double sum)
        {
            Validator.CheckProfit(sum);
            Profit += sum;
        }
    }
}