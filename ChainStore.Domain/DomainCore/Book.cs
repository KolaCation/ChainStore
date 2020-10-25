using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Book
    {
        public Guid Id { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public DateTimeOffset CreationTime { get; }
        public DateTimeOffset ExpirationTime { get; }
        public int ReserveDaysCount { get; }

        public Book(Guid id, Guid clientId, Guid productId, int reserveDaysCount)
        {
            CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            Id = id;
            ClientId = clientId;
            ProductId = productId;
            CreationTime = DateTimeOffset.UtcNow;
            ExpirationTime = CreationTime.AddDays(reserveDaysCount);
            ReserveDaysCount = reserveDaysCount;
        }

        public Book(Guid id, Guid clientId, Guid productId, DateTimeOffset creationTime,
            DateTimeOffset expirationTime, int reserveDaysCount) : this(id, clientId, productId, reserveDaysCount)
        {
            CreationTime = creationTime;
            ExpirationTime = expirationTime;
        }

        public bool IsExpired()
        {
            var difference = ExpirationTime - DateTimeOffset.Now;
            if (difference.Milliseconds > 0) return false;
            return true;
        }
    }
}