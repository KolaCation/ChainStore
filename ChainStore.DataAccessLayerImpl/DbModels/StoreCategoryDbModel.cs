using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class StoreCategoryDbModel
{
    public StoreCategoryDbModel(Guid storeDbModelId, Guid categoryDbModelId)
    {
        CustomValidator.ValidateId(storeDbModelId);
        CustomValidator.ValidateId(categoryDbModelId);
        StoreDbModelId = storeDbModelId;
        CategoryDbModelId = categoryDbModelId;
    }

    public Guid StoreDbModelId { get; private set; }
    public StoreDbModel StoreDbModel { get; private set; }
    public Guid CategoryDbModelId { get; private set; }
    public CategoryDbModel CategoryDbModel { get; private set; }
}