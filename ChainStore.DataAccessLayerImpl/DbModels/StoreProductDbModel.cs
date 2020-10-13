using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreProductDbModel
    {
        public Guid StoreId { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid ProductId { get; private set; }
        public ProductDbModel ProductDbModel { get; private set; }

        public StoreProductDbModel(Guid storeId, Guid productId)
        {
            CustomValidator.ValidateId(storeId);
            CustomValidator.ValidateId(productId);
            StoreId = storeId;
            ProductId = productId;
        }
    }
}
