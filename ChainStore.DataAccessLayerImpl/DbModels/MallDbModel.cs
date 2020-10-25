using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class MallDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        private readonly List<StoreDbModel> _storeDbModels;
        public IReadOnlyCollection<StoreDbModel> StoreDbModels => _storeDbModels.AsReadOnly();


        public MallDbModel(Guid id, string name, string location)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            Id = id;
            Name = name;
            Location = location;
            _storeDbModels = new List<StoreDbModel>();
        }
    }
}