using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface ICategoryRepository
    {
        IReadOnlyCollection<Category> GetAllCategories();
        Category GetCategory(Guid categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Guid categoryId);
    }
}
