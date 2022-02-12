using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.Repositories;

public interface IBookRepository : ICreateDeleteRepository<Book>
{
    List<Book> GetCustomerBooks(Guid customerId);
    void CheckBooksForExpiration();
}