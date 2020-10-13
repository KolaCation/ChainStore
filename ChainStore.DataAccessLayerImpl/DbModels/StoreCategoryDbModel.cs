using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreCategoryDbModel
    {
        public Guid StoreId { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid CategoryId { get; private set; }
        public CategoryDbModel CategoryDbModel { get; private set; }

        public StoreCategoryDbModel(Guid storeId, Guid categoryId)
        {
            CustomValidator.ValidateId(storeId);
            CustomValidator.ValidateId(categoryId);
            StoreId = storeId;
            CategoryId = categoryId;
        }
    }
}
