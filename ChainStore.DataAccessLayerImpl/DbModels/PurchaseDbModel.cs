using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class PurchaseDbModel
    {
        public Guid PurchaseDbModelId { get; private set; }
        public Guid ClientDbModelId { get; private set; }
        public Guid ProductDbModelId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }

        public PurchaseDbModel(Guid purchaseDbModelId, Guid clientDbModelId, Guid productDbModelId, DateTimeOffset creationTime)
        {
            CustomValidator.ValidateId(purchaseDbModelId);
            CustomValidator.ValidateId(clientDbModelId);
            CustomValidator.ValidateId(productDbModelId);
            PurchaseDbModelId = purchaseDbModelId;
            ClientDbModelId = clientDbModelId;
            ProductDbModelId = productDbModelId;
            CreationTime = creationTime;
        }
    }
}
