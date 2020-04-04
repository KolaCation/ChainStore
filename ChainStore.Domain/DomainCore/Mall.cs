using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Mall
    {
        public Guid MallId { get; }
        public string Name { get; }
        public string Location { get; }

        private readonly List<Store> _stores;
        public IReadOnlyCollection<Store> Stores => _stores.AsReadOnly();


        public Mall(Guid mallId, string name, string location)
        {
            CustomValidator.ValidateId(mallId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            MallId = mallId;
            Name = name;
            Location = location;
            _stores = new List<Store>();
        }
        public Mall(List<Store> stores, Guid mallId, string name, string location) : this(mallId, name, location)
        {
            CustomValidator.ValidateObject(stores);
            _stores = stores;
        }
    }
}
