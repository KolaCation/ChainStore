using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreDbModel
    {
        public Guid StoreDbModelId { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public Guid? MallDbModelId { get; private set; }
        public MallDbModel MallDbModel { get; private set; }

        private readonly List<CategoryDbModel> _categoryDbModels;
        public IReadOnlyCollection<CategoryDbModel> CategoryDbModels => _categoryDbModels.AsReadOnly();

        public double Profit { get; private set; }

        public StoreDbModel(Guid storeDbModelId, string name, string location, Guid? mallDbModelId, double profit)
        {
            CustomValidator.ValidateId(storeDbModelId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateString(location, 2, 40);
            CustomValidator.ValidateNumber(profit, 0, double.MaxValue);
            CustomValidator.ValidateId(mallDbModelId);
            StoreDbModelId = storeDbModelId;
            Name = name;
            Location = location;
            MallDbModelId = mallDbModelId;
            Profit = profit;
            _categoryDbModels = new List<CategoryDbModel>();
        }
    }
}
