using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;

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
            return new CategoryDbModel(item.Id, item.Name);
        }

        public Category DbToDomain(CategoryDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var categoryDbModel = _context.Categories.Where(e => e.Id.Equals(item.Id))
                .Include(e => e.ProductDbModels).ThenInclude(e => e.StoreProductRelation).ThenInclude(e => e.StoreDbModel).FirstOrDefault();
            return new Category
            (
                (from productDbModel in categoryDbModel.ProductDbModels select _productMapper.DbToDomain(productDbModel)).ToList(),
                categoryDbModel.Id,
                categoryDbModel.Name
            );
        }

        public Category DbToDomainStoreSpecificProducts(CategoryDbModel item, Guid storeId)
        {
            CustomValidator.ValidateObject(item);
            CustomValidator.ValidateId(storeId);
            var categoryDbModel = _context.Categories.Where(e => e.Id.Equals(item.Id))
                        .Include(e => e.ProductDbModels).ThenInclude(e => e.StoreProductRelation).ThenInclude(e => e.StoreDbModel).FirstOrDefault();
            return new Category
            (
                (from productDbModel in categoryDbModel.GetStoreSpecificProducts(storeId) select _productMapper.DbToDomain(productDbModel)).ToList(),
                categoryDbModel.Id,
                categoryDbModel.Name
            );
        }
    }
}
