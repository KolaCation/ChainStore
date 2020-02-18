using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Book
    {
        public Guid BookId { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }
        public DateTimeOffset ExpirationTime { get; private set; }
        public int ReserveDaysCount { get; private set; }

        public Book(Guid clientId, Guid productId, int reserveDaysCount)
        {
            CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            BookId = Guid.NewGuid();
            ClientId = clientId;
            ProductId = productId;
            CreationTime = DateTimeOffset.UtcNow;
            ExpirationTime = CreationTime.AddDays(reserveDaysCount);
            ReserveDaysCount = reserveDaysCount;
        }

        public bool IsExpired()
        {
            var difference = ExpirationTime - DateTimeOffset.Now;
            if (difference.Days > 0) return false;
            ClientId = Guid.Empty;
            return true;
        }
    }
}

