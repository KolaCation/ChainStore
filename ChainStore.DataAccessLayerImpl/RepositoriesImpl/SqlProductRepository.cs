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
    public class SqlProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        private readonly ProductMapper _productMapper;
        private readonly StoreMapper _storeMapper;

        public SqlProductRepository(MyDbContext context)
        {
            _context = context;
            _productMapper = new ProductMapper();
            _storeMapper = new StoreMapper(context);
        }

        public void AddOne(Product item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.ProductId);
            if (!exists)
            {
                var enState = _context.Products.Add(_productMapper.DomainToDb(item));
                enState.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public Product GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                return _productMapper.DbToDomain(_context.Products.Find(id));
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            var productDbModelList = _context.Products.ToList();
            var productList = (from productDbModel in productDbModelList select _productMapper.DbToDomain(productDbModel)).ToList();
            return productList.AsReadOnly();
        }

        public void UpdateOne(Product item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.ProductId);
            if (exists)
            {
                DetachService.Detach<ProductDbModel>(_context, item.ProductId);
                var enState = _context.Products.Update(_productMapper.DomainToDb(item));
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
                var productDbModel = _context.Products.Find(id);
                var enState = _context.Products.Remove(productDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Products.Any(item => item.ProductDbModelId.Equals(id));
        }

        public Store GetStoreOfSpecificProduct(Guid productId)
        {
            CustomValidator.ValidateId(productId);
            var res = _context.StoreProductDbModels.FirstOrDefault(e => e.ProductId.Equals(productId));
            if(res != null)
            {
                var storeDbModelId = res.Store1Id;
                var storeDbModel = _context.Stores.Find(storeDbModelId);
                return _storeMapper.DbToDomain(storeDbModel);
            }
            return null;
        }
    }
}