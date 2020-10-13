using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class StoreMapper : IMapper<Store, StoreDbModel>
    {
        private readonly MyDbContext _context;
        private readonly CategoryMapper _categoryMapper;

        public StoreMapper(MyDbContext context)
        {
            _context = context;
            _categoryMapper = new CategoryMapper(context);
        }

        public StoreDbModel DomainToDb(Store item)
        {
            CustomValidator.ValidateObject(item);
            return new StoreDbModel(item.StoreId, item.Name, item.Location, item.MallId, item.Profit);
        }

        public Store DbToDomain(StoreDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var storeDbModel = _context.Stores.Find(item.StoreDbModelId);
            _context.Entry(storeDbModel).Collection(st => st.StoreCategoryRelation).Load();
            _context.Entry(storeDbModel).Collection(st => st.StoreProductRelation).Load();
            return new Store
            (
                (from categoryDbModel in storeDbModel.CategoryDbModels select _categoryMapper.DbToDomainStoreSpecificProducts(categoryDbModel, item.StoreDbModelId)).ToList(),
                item.StoreDbModelId,
                item.Name,
                item.Location,
                item.MallDbModelId,
                item.Profit
                );
        }
    }
}
