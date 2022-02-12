using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public sealed class StoreProductRelation
{
    public StoreProductRelation(Guid storeId, Guid productId)
    {
        CustomValidator.ValidateId(storeId);
        CustomValidator.ValidateId(productId);
        StoreId = storeId;
        ProductId = productId;
    }

    public Guid StoreId { get; }
    public Guid ProductId { get; }
}