using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class PurchaseDbModel
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }
        public double PriceAtPurchaseMoment { get; private set; }

        public PurchaseDbModel(Guid id, Guid clientId, Guid productId, DateTimeOffset creationTime, double priceAtPurchaseMoment)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            CustomValidator.ValidateNumber(priceAtPurchaseMoment, 0, 100_000_000);
            Id = id;
            ClientId = clientId;
            ProductId = productId;
            CreationTime = creationTime;
            PriceAtPurchaseMoment = priceAtPurchaseMoment;
        }
    }
}
