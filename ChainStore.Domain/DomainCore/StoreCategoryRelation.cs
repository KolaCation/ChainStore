using ChainStore.Shared.Util;
using System;

namespace ChainStore.Domain.DomainCore
{
    public sealed class StoreCategoryRelation
    {
        public Guid StoreId { get; }
        public Guid CategoryId { get; }

        public StoreCategoryRelation(Guid storeId, Guid categoryId)
        {
            CustomValidator.ValidateId(storeId);
            CustomValidator.ValidateId(categoryId);
            StoreId = storeId;
            CategoryId = categoryId;
        }
    }
}
