using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class BookDbModel
{
    public BookDbModel(Guid id, Guid customerId, Guid productId, DateTimeOffset creationTime,
        DateTimeOffset expirationTime, int reserveDaysCount)
    {
        CustomValidator.ValidateNumber(reserveDaysCount, 1, 7);
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateId(customerId);
        CustomValidator.ValidateId(productId);
        Id = id;
        CustomerId = customerId;
        ProductId = productId;
        CreationTime = creationTime;
        ExpirationTime = expirationTime;
        ReserveDaysCount = reserveDaysCount;
    }

    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid ProductId { get; private set; }
    public DateTimeOffset CreationTime { get; private set; }
    public DateTimeOffset ExpirationTime { get; private set; }
    public int ReserveDaysCount { get; private set; }
}