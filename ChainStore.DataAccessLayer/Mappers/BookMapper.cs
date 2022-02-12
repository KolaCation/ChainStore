using ChainStore.DataAccessLayer.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.Mappers;

internal sealed class BookMapper : IMapper<Book, BookDbModel>
{
    public BookDbModel DomainToDb(Book item)
    {
        CustomValidator.ValidateObject(item);
        return new BookDbModel(item.Id, item.CustomerId, item.ProductId, item.CreationTime, item.ExpirationTime,
            item.ReserveDaysCount);
    }

    public Book DbToDomain(BookDbModel item)
    {
        CustomValidator.ValidateObject(item);
        return new Book(item.Id, item.CustomerId, item.ProductId, item.CreationTime, item.ExpirationTime,
            item.ReserveDaysCount);
    }
}