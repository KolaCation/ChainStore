using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels.ViewMakers.DetailedInfo
{
    public sealed class BookDetailedInfo
    {
        public Product Product { get; private set; }
        public Guid ClientId { get; private set; }
        public DateTimeOffset BookCreationTime { get; private set; }
        public DateTimeOffset BookExpirationTime { get; private set; }
        public BookDetailedInfo(Product product,  Guid clientId, DateTimeOffset bookCreationTime,
            DateTimeOffset bookExpirationTime)
        {
            Product = product;
            ClientId = clientId;
            BookCreationTime = bookCreationTime;
            BookExpirationTime = bookExpirationTime;
        }
    }
}