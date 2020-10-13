using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreProductDbModel
    {
        public Guid Store1Id { get; private set; }
        public StoreDbModel StoreDbModel { get; private set; }
        public Guid ProductId { get; private set; }
        public ProductDbModel ProductDbModel { get; private set; }

        public StoreProductDbModel(Guid store1Id, Guid productId)
        {
            CustomValidator.ValidateId(store1Id);
            CustomValidator.ValidateId(productId);
            Store1Id = store1Id;
            ProductId = productId;
        }
    }
}
