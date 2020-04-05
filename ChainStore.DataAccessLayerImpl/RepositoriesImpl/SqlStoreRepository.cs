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
    public class SqlStoreRepository : IStoreRepository
    {
        private readonly MyDbContext _context;
        private readonly StoreMapper _storeMapper;

        public SqlStoreRepository(MyDbContext context)
        {
            _context = context;
            _storeMapper = new StoreMapper(context);
        }

        public void AddOne(Store item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.StoreId);
            if (!exists)
            {
                var storeWithTheSameLocationAndNameExists = _context.Stores.Any(st =>
                        st.Location.Equals(item.Location) &&
                        st.Name.Equals(item.Name) &&
                        !st.StoreDbModelId.Equals(item.StoreId) &&
                        st.MallDbModelId == null);
                if (storeWithTheSameLocationAndNameExists) return;
                var enState = _context.Stores.Add(_storeMapper.DomainToDb(item));
                enState.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public Store GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                var storeDbModel = _context.Stores.Find(id);
                _context.Entry(storeDbModel).Collection(st => st.CategoryDbModels).Load();
                foreach (var categoryDbModel in storeDbModel.CategoryDbModels)
                {
                    _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
                }
                return _storeMapper.DbToDomain(storeDbModel);
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyCollection<Store> GetAll()
        {
            var storeDbModelList = _context.Stores.ToList();
            foreach (var storeDbModel in storeDbModelList)
            {
                _context.Entry(storeDbModel).Collection(st => st.CategoryDbModels).Load();
                foreach (var categoryDbModel in storeDbModel.CategoryDbModels)
                {
                    _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
                }
            }
            var storeList = (from storeDbModel in storeDbModelList select _storeMapper.DbToDomain(storeDbModel)).ToList();
            return storeList.AsReadOnly();
        }

        public void UpdateOne(Store item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.StoreId);
            if (exists)
            {
                var storeWithTheSameLocationAndNameExists = _context.Stores.Any(st =>
                    st.Location.Equals(item.Location) &&
                    st.Name.Equals(item.Name) &&
                    !st.StoreDbModelId.Equals(item.StoreId) &&
                    st.MallDbModelId == null);
                if (storeWithTheSameLocationAndNameExists) return;
                Detach(item.StoreId);
                var enState = _context.Stores.Update(_storeMapper.DomainToDb(item));
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
                var storeDbModel = _context.Stores.Find(id);
                var enState = _context.Stores.Remove(storeDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Stores.Any(item => item.StoreDbModelId.Equals(id));
        }

        private void Detach(Guid id)
        {
            CustomValidator.ValidateId(id);
            var entity = _context.Stores.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}