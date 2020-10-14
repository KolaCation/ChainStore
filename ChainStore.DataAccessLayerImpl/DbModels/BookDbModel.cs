using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class BookDbModel
    {
        public Guid BookDbModelId { get; private set; }
        public Guid ClientDbModelId { get; private set; }
        public Guid ProductDbModelId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }
        public DateTimeOffset ExpirationTime { get; private set; }
        public int ReserveDaysCount { get; private set; }

        public BookDbModel(Guid bookDbModelId, Guid clientDbModelId, Guid productDbModelId, DateTimeOffset creationTime, DateTimeOffset expirationTime, int reserveDaysCount)
        {
            CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
            CustomValidator.ValidateId(bookDbModelId);
            CustomValidator.ValidateId(clientDbModelId);
            CustomValidator.ValidateId(productDbModelId);
            BookDbModelId = bookDbModelId;
            ClientDbModelId = clientDbModelId;
            ProductDbModelId = productDbModelId;
            CreationTime = creationTime;
            ExpirationTime = expirationTime;
            ReserveDaysCount = reserveDaysCount;
        }
    }
}
