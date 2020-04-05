using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class CategoryDbModel
    {
        public Guid CategoryDbModelId { get; private set; }
        public CategoryNames CategoryName { get; private set; }
        public Guid? StoreDbModelId { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }

        private readonly List<ProductDbModel> _productDbModels;
        public IReadOnlyCollection<ProductDbModel> ProductDbModels => _productDbModels.AsReadOnly();

        public CategoryDbModel(Guid categoryDbModelId, CategoryNames categoryName, Guid? storeDbModelId)
        {
            CustomValidator.ValidateId(categoryDbModelId);
            CustomValidator.ValidateId(storeDbModelId);
            CategoryDbModelId = categoryDbModelId;
            CategoryName = categoryName;
            StoreDbModelId = storeDbModelId;
            _productDbModels = new List<ProductDbModel>();
        }
    }
}