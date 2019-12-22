using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels.ViewMakers.DetailedInfo
{
    public sealed class PurchaseDetailedInfo
    {
        public Product Product { get; private set; }
        public Guid ClientId { get; private set; }
        public DateTimeOffset PurchaseCreationTime { get; private set; }

        public PurchaseDetailedInfo(Product product, Guid clientId, DateTimeOffset creationTime)
        {
            Product = product;
            ClientId = clientId;
            PurchaseCreationTime = creationTime;
        }
    }
}
