using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Mall
    {
        public Guid MallId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        private readonly List<Store> _stores;
        public IReadOnlyCollection<Store> Stores => _stores.AsReadOnly();

        public Mall(string name, string location)
        {
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            MallId = Guid.NewGuid();
            Name = name;
            Location = location;
            _stores = new List<Store>();
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
    }
}
