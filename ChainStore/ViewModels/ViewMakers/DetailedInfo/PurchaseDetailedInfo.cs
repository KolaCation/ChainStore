using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels.ViewMakers.DetailedInfo;

public sealed class PurchaseDetailedInfo
{
    public PurchaseDetailedInfo(Product product, Guid customerId, DateTimeOffset creationTime)
    {
        Product = product;
        CustomerId = customerId;
        PurchaseCreationTime = creationTime;
    }

    public Product Product { get; }
    public Guid CustomerId { get; }
    public DateTimeOffset PurchaseCreationTime { get; }
}