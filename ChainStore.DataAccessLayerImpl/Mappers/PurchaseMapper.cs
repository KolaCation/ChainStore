using ChainStore.DataAccessLayer.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.Mappers;

internal sealed class PurchaseMapper : IMapper<Purchase, PurchaseDbModel>
{
    public PurchaseDbModel DomainToDb(Purchase item)
    {
        CustomValidator.ValidateObject(item);
        return new PurchaseDbModel(item.Id, item.CustomerId, item.ProductId, item.CreationTime,
            item.PriceAtPurchaseMoment);
    }

    public Purchase DbToDomain(PurchaseDbModel item)
    {
        CustomValidator.ValidateObject(item);
        return new Purchase(item.Id, item.CustomerId, item.ProductId, item.CreationTime, item.PriceAtPurchaseMoment);
    }
}