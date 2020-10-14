using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreCategoryDbModel
    {
        public Guid StoreDbModelId { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid CategoryDbModelId { get; private set; }
        public CategoryDbModel CategoryDbModel { get; private set; }

        public StoreCategoryDbModel(Guid storeDbModelId, Guid categoryDbModelId)
        {
            CustomValidator.ValidateId(storeDbModelId);
            CustomValidator.ValidateId(categoryDbModelId);
            StoreDbModelId = storeDbModelId;
            CategoryDbModelId = categoryDbModelId;
        }
    }
}
