using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.Domain.DomainCore
{
    public sealed class StoreProductRelation
    {
        public Guid StoreId { get; }
        public Guid ProductId { get; }

        public StoreProductRelation(Guid storeId, Guid productId)
        {
            CustomValidator.ValidateId(storeId);
            CustomValidator.ValidateId(productId);
            StoreId = storeId;
            ProductId = productId;
        }
    }
}
