using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void AddCategoryToStore(Category category, Guid storeId);
        void DeleteCategoryFromStore(Category category, Guid storeId);
    }
}
