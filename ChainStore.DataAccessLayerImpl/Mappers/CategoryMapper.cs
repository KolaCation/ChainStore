using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class CategoryMapper : ICategoryMapper
    {
        private readonly MyDbContext _context;
        private readonly ProductMapper _productMapper;

        public CategoryMapper(MyDbContext context)
        {
            _context = context;
            _productMapper = new ProductMapper();
        }

        public CategoryDbModel DomainToDb(Category item)
        {
            CustomValidator.ValidateObject(item);
            return new CategoryDbModel(item.CategoryId, item.Name);
        }

        public Category DbToDomain(CategoryDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var categoryDbModel = _context.Categories.Find(item.CategoryDbModelId);
            _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
            foreach(var pr in categoryDbModel.ProductDbModels)
            {
                _context.Entry(pr).Collection(pr => pr.StoreProductRelation).Load();
            }
           return new Category
           (
               (from productDbModel in categoryDbModel.ProductDbModels select _productMapper.DbToDomain(productDbModel)).ToList(),
               categoryDbModel.CategoryDbModelId,
               categoryDbModel.Name
           );
        }

        public Category DbToDomainStoreSpecificProducts(CategoryDbModel item, Guid storeId)
        {
            CustomValidator.ValidateObject(item);
            CustomValidator.ValidateId(storeId);
            var categoryDbModel = _context.Categories.Find(item.CategoryDbModelId);
            _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
            foreach (var pr in categoryDbModel.ProductDbModels)
            {
                _context.Entry(pr).Collection(pr => pr.StoreProductRelation).Load();
            }
            return new Category
            (
                (from productDbModel in categoryDbModel.GetStoreSpecificProducts(storeId) select _productMapper.DbToDomain(productDbModel)).ToList(),
                categoryDbModel.CategoryDbModelId,
                categoryDbModel.Name
            );
        }
    }
}
