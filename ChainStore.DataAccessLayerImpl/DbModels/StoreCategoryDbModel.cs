using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreCategoryDbModel
    {
        public Guid Store2Id { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid CategoryId { get; private set; }
        public CategoryDbModel CategoryDbModel { get; private set; }

        public StoreCategoryDbModel(Guid store2Id, Guid categoryId)
        {
            CustomValidator.ValidateId(store2Id);
            CustomValidator.ValidateId(categoryId);
            Store2Id = store2Id;
            CategoryId = categoryId;
        }
    }
}
