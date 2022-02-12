using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class PurchaseDbModel
{
    public PurchaseDbModel(Guid id, Guid customerId, Guid productId, DateTimeOffset creationTime,
        double priceAtPurchaseMoment)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateId(customerId);
        CustomValidator.ValidateId(productId);
        CustomValidator.ValidateNumber(priceAtPurchaseMoment, 0, 100_000_000);
        Id = id;
        CustomerId = customerId;
        ProductId = productId;
        CreationTime = creationTime;
        PriceAtPurchaseMoment = priceAtPurchaseMoment;
    }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ProductId { get; private set; }
    public DateTimeOffset CreationTime { get; private set; }
    public double PriceAtPurchaseMoment { get; private set; }
}