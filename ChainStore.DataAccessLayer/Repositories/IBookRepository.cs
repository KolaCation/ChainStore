using ChainStore.Domain.DomainCore;
using System;
using System.Collections.Generic;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IBookRepository : ICreateDeleteRepository<Book>
    {
        List<Book> GetClientBooks(Guid clientId);
        void CheckBooksForExpiration();
    }
}
