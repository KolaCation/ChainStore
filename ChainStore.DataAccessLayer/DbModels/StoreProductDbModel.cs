using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class StoreProductDbModel
{
    public StoreProductDbModel(Guid storeDbModelId, Guid productDbModelId)
    {
        CustomValidator.ValidateId(storeDbModelId);
        CustomValidator.ValidateId(productDbModelId);
        StoreDbModelId = storeDbModelId;
        ProductDbModelId = productDbModelId;
    }

    public Guid StoreDbModelId { get; private set; }
    public StoreDbModel StoreDbModel { get; private set; }
    public Guid ProductDbModelId { get; private set; }
    public ProductDbModel ProductDbModel { get; private set; }
}