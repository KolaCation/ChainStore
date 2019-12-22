using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void DeleteBook(Guid bookId);
        List<Book> GetClientBooks(Guid clientId);
        void CheckBooksForExpiration();
    }
}
