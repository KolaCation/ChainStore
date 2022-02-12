using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    void AddCategoryToStore(Category category, Guid storeId);
    void DeleteCategoryFromStore(Category category, Guid storeId);
}