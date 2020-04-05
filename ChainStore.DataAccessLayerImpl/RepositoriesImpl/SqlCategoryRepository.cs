using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayerImpl.RepositoriesImpl
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;
        private readonly CategoryMapper _categoryMapper;

        public SqlCategoryRepository(MyDbContext context)
        {
            _context = context;
            _categoryMapper = new CategoryMapper(context);
        }

        public void AddOne(Category item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.CategoryId);
            if (!exists)
            {
                var hasSameName = _context.Categories.Any(cat => cat.CategoryName.Equals(item.CategoryName) && cat.StoreDbModelId.Equals(item.StoreId));
                if(hasSameName) return;
                var enState = _context.Categories.Add(_categoryMapper.DomainToDb(item));
                enState.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public Category GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                var categoryDbModel = _context.Categories.Find(id);
                _context.Entry(categoryDbModel).Collection(cat=>cat.ProductDbModels).Load();
                return _categoryMapper.DbToDomain(categoryDbModel);
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyCollection<Category> GetAll()
        {
            var categoryDbModelList = _context.Categories.ToList();
            foreach (var categoryDbModel in categoryDbModelList)
            {
                _context.Entry(categoryDbModel).Collection(cat=>cat.ProductDbModels).Load();
            }
            var categoryList = (from categoryDbModel in categoryDbModelList select _categoryMapper.DbToDomain(categoryDbModel)).ToList();
            return categoryList.AsReadOnly();
        }

        public void UpdateOne(Category item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.CategoryId);
            if (exists)
            {
                var hasSameName = _context.Categories.Any(cat => cat.CategoryName.Equals(item.CategoryName) && cat.StoreDbModelId.Equals(item.StoreId));
                if (hasSameName) return;
                Detach(item.CategoryId);
                var enState = _context.Categories.Update(_categoryMapper.DomainToDb(item));
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                var categoryDbModel = _context.Categories.Find(id);
                var enState = _context.Categories.Remove(categoryDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Categories.Any(item => item.CategoryDbModelId.Equals(id));
        }

        private void Detach(Guid id)
        {
            CustomValidator.ValidateId(id);
            var entity = _context.Categories.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}