using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class MallDbModel
    {
        public Guid MallDbModelId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }

        private readonly List<StoreDbModel> _storeDbModels;
        public IReadOnlyCollection<StoreDbModel> StoreDbModels => _storeDbModels.AsReadOnly();


        public MallDbModel(Guid mallDbModelId, string name, string location)
        {
            CustomValidator.ValidateId(mallDbModelId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            MallDbModelId = mallDbModelId;
            Name = name;
            Location = location;
            _storeDbModels = new List<StoreDbModel>();
        }
    }
}