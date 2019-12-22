using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public SqlCategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Category> GetAllCategories()
        {
            var categoriesToReturn = _context.Categories
                .Include(cat => cat.Products).ToList();
            return new ReadOnlyCollection<Category>(categoriesToReturn);
        }

        public Category GetCategory(Guid categoryId)
        {
            if (categoryId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(categoryId));
            var categoryToReturn = _context.Categories.Where(cat => cat.CategoryId.Equals(categoryId))
                .Include(cat => cat.Products).FirstOrDefault();
            return categoryToReturn;
        }

        public void AddCategory(Category category)
        {
            if (category == null) return;
            var checkForDuplicate = _context.Categories.Find(category.CategoryId);
            if (checkForDuplicate != null) return;
            var checkForName = _context.Categories
                .FirstOrDefault(cat =>
                    cat.CategoryName.Equals(category.CategoryName) && cat.StoreId.Equals(category.StoreId));
            if (checkForName != null) return;
            var enState = _context.Categories.Add(category);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            if (category == null) return;
            var checkForNull = _context.Categories.Find(category.CategoryId);
            if (checkForNull == null) return;
            var checkForName = _context.Categories
                .FirstOrDefault(cat =>
                    cat.CategoryName.Equals(category.CategoryName) && cat.StoreId.Equals(category.StoreId));
            if (checkForName != null) return;
            var enState = _context.Categories.Update(category);
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            if (categoryId.Equals(Guid.Empty)) return;
            var categoryToRemove = _context.Categories.Find(categoryId);
            if (categoryToRemove == null) return;
            var enState = _context.Categories.Remove(categoryToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}