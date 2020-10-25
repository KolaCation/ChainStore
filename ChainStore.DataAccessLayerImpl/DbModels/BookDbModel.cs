using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class BookDbModel
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }
        public DateTimeOffset ExpirationTime { get; private set; }
        public int ReserveDaysCount { get; private set; }

        public BookDbModel(Guid id, Guid clientId, Guid productId, DateTimeOffset creationTime, DateTimeOffset expirationTime, int reserveDaysCount)
        {
            CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            Id = id;
            ClientId = clientId;
            ProductId = productId;
            CreationTime = creationTime;
            ExpirationTime = expirationTime;
            ReserveDaysCount = reserveDaysCount;
        }
    }
}
