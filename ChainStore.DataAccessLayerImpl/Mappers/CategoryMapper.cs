using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class CategoryMapper : IMapper<Category, CategoryDbModel>
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
            return new CategoryDbModel(item.CategoryId, item.CategoryName, item.StoreId);
        }

        public Category DbToDomain(CategoryDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var categoryDbModel = _context.Categories.Find(item.CategoryDbModelId);
            _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
           return new Category
           (
               (from productDbModel in categoryDbModel.ProductDbModels select _productMapper.DbToDomain(productDbModel)).ToList(),
               categoryDbModel.CategoryDbModelId,
               categoryDbModel.CategoryName,
               categoryDbModel.StoreDbModelId
           );
        }
    }
}
