using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.DataAccessLayerImpl.Helpers;
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
                var hasSameName = _context.Categories.Any(cat => cat.Name.ToLower().Equals(item.Name.ToLower()));
                if (hasSameName) return;
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
            var categoryList = (from categoryDbModel in categoryDbModelList select _categoryMapper.DbToDomain(categoryDbModel)).ToList();
            return categoryList.AsReadOnly();
        }

        public void UpdateOne(Category item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.CategoryId);
            if (exists)
            {
                var hasSameName = _context.Categories.Any(cat => cat.Name.ToLower().Equals(item.Name.ToLower()));
                if (hasSameName) return;
                DetachService.Detach<CategoryDbModel>(_context, item.CategoryId);
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

        public void AddCategoryToStore(Category category, Guid storeId)
        {
            CustomValidator.ValidateObject(category);
            CustomValidator.ValidateId(storeId);
            var storeCatRel = new StoreCategoryDbModel(storeId, category.CategoryId);
            if (!_context.StoreCategoryDbModels
                .Any(e => e.CategoryId.Equals(storeCatRel.CategoryId) && e.Store2Id.Equals(storeId)))
            {
                _context.StoreCategoryDbModels.Add(storeCatRel);
            }
        }
    }
}