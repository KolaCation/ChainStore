using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels.ViewMakers.DetailedInfo;

public sealed class BookDetailedInfo
{
    public BookDetailedInfo(Product product, Guid customerId, DateTimeOffset bookCreationTime,
        DateTimeOffset bookExpirationTime)
    {
        Product = product;
        CustomerId = customerId;
        BookCreationTime = bookCreationTime;
        BookExpirationTime = bookExpirationTime;
    }

    public Product Product { get; }
    public Guid CustomerId { get; }
    public DateTimeOffset BookCreationTime { get; }
    public DateTimeOffset BookExpirationTime { get; }
}