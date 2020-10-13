using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreProductDbModel
    {
        public Guid StoreDbModelId { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid ProductDbModelId { get; private set; }
        public ProductDbModel ProductDbModel { get; private set; }

        public StoreProductDbModel(Guid storeDbModelId, Guid productDbModelId)
        {
            CustomValidator.ValidateId(storeDbModelId);
            CustomValidator.ValidateId(productDbModelId);
            StoreDbModelId = storeDbModelId;
            ProductDbModelId = productDbModelId;
        }
    }
}
