using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Purchase
    {
        public Guid PurchaseId { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public DateTimeOffset CreationTime { get; }

        public Purchase(Guid purchaseId, Guid clientId, Guid productId)
        {
            CustomValidator.ValidateId(purchaseId);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            PurchaseId = purchaseId;
            ClientId = clientId;
            ProductId = productId;
            CreationTime = DateTimeOffset.UtcNow;
        }

        public Purchase(Guid purchaseId, Guid clientId, Guid productId, DateTimeOffset creationTime) : this(purchaseId, clientId, productId)
        {
            CreationTime = creationTime;
        }
    }
}