using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class BookMapper : IMapper<Book, BookDbModel>
    {
        public BookDbModel DomainToDb(Book item)
        {
            CustomValidator.ValidateObject(item);
            return new BookDbModel(item.BookId, item.ClientId, item.ProductId, item.CreationTime, item.ExpirationTime, item.ReserveDaysCount);
        }

        public Book DbToDomain(BookDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new Book(item.BookDbModelId, item.ClientDbModelId, item.ProductDbModelId, item.CreationTime, item.ExpirationTime, item.ReserveDaysCount);
        }
    }
}
