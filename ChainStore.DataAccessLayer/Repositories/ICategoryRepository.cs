using ChainStore.Domain.DomainCore;
using System;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void AddCategoryToStore(Category category, Guid storeId);
        void DeleteCategoryFromStore(Category category, Guid storeId);
    }
}
