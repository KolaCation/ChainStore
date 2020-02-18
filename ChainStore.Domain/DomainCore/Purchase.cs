using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Purchase
    {
        public Guid PurchaseId{ get; private set; }
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }

        public Purchase(Guid clientId, Guid productId)
        {
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            PurchaseId = Guid.NewGuid();
            ClientId = clientId;
            ProductId = productId;
            CreationTime = DateTimeOffset.UtcNow;
        }
    }
}
