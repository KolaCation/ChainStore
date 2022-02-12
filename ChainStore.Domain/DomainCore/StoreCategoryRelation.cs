using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public sealed class StoreCategoryRelation
{
    public StoreCategoryRelation(Guid storeId, Guid categoryId)
    {
        CustomValidator.ValidateId(storeId);
        CustomValidator.ValidateId(categoryId);
        StoreId = storeId;
        CategoryId = categoryId;
    }

    public Guid StoreId { get; }
    public Guid CategoryId { get; }
}