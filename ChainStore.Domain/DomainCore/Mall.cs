using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ChainStore.Domain.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Mall
    {
        public Guid MallId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        private readonly List<Store> _stores;
        public IReadOnlyCollection<Store> Stores => new ReadOnlyCollection<Store>(_stores);

        public Mall(string name, string location)
        {
            MallId = Guid.NewGuid();
            Validator.CheckName(name);
            Validator.CheckLocation(location);
            Name = name;
            Location = location;
            _stores = new List<Store>();
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
    }
}
