using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IBookRepository : ICreateDeleteRepository<Book>
    {
        List<Book> GetClientBooks(Guid clientId);
        void CheckBooksForExpiration();
    }
}
