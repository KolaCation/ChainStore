using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public sealed class Purchase
{
    public Purchase(Guid id, Guid customerId, Guid productId, double priceAtPurchaseMoment)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateId(customerId);
        CustomValidator.ValidateId(productId);
        CustomValidator.ValidateNumber(priceAtPurchaseMoment, 0, 100_000_000);
        Id = id;
        CustomerId = customerId;
        ProductId = productId;
        CreationTime = DateTimeOffset.UtcNow;
    }

    public Purchase(Guid id, Guid customerId, Guid productId, DateTimeOffset creationTime, double priceAtPurchaseMoment)
        : this(id, customerId, productId, priceAtPurchaseMoment)
    {
        CreationTime = creationTime;
    }

    public Guid Id { get; }
    public Guid CustomerId { get; }
    public Guid ProductId { get; }
    public DateTimeOffset CreationTime { get; }
    public double PriceAtPurchaseMoment { get; }
}