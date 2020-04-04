using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore
{
    public sealed class Book
    {
        public Guid BookId { get; }
        public Guid ClientId { get; }
        public Guid ProductId { get; }
        public DateTimeOffset CreationTime { get; }
        public DateTimeOffset ExpirationTime { get; }
        public int ReserveDaysCount { get; }

        public Book(Guid bookId, Guid clientId, Guid productId, int reserveDaysCount)
        {
            CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
            CustomValidator.ValidateId(bookId);
            CustomValidator.ValidateId(clientId);
            CustomValidator.ValidateId(productId);
            BookId = bookId;
            ClientId = clientId;
            ProductId = productId;
            CreationTime = DateTimeOffset.UtcNow;
            ExpirationTime = CreationTime.AddDays(reserveDaysCount);
            ReserveDaysCount = reserveDaysCount;
        }

        public Book(Guid bookId, Guid clientId, Guid productId, DateTimeOffset creationTime,
            DateTimeOffset expirationTime, int reserveDaysCount) : this(bookId, clientId, productId, reserveDaysCount)
        {
            CreationTime = creationTime;
            ExpirationTime = expirationTime;
        }

        public bool IsExpired()
        {
            var difference = ExpirationTime - DateTimeOffset.Now;
            if (difference.Days > 0) return false;
            return true;
        }
    }
}