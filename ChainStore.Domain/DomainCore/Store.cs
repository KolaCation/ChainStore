using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;

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
        public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

        public double Profit { get; private set; }

        public Store(string name, string location, Guid? mallId)
        {
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            StoreId = Guid.NewGuid();
            MallId = mallId;
            Name = name;
            Location = location;
            Profit = 0;
            _categories = new List<Category>();
        }

        public void ChangeName(string newName)
        {
            CustomValidator.ValidateString(newName, 2, 40);
            Name = newName;
        }

        public void ChangeLocation(string newLocation)
        {
            CustomValidator.ValidateString(newLocation, 2, 40);
            Location = newLocation;
        }

        public void MoveToMall(Guid mallIId, string mallLocation)
        {
            CustomValidator.ValidateId(mallIId);
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
            CustomValidator.ValidateNumber(sum, 0, 1000000);
            Profit += sum;
        }
    }
}