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
    public class SqlMallRepository : IMallRepository
    {
        private readonly MyDbContext _context;
        private readonly MallMapper _mallMapper;
        public SqlMallRepository(MyDbContext context)
        {
            _context = context;
            _mallMapper = new MallMapper(context);
        }

        public void AddOne(Mall item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.MallId);
            if (!exists)
            {
                var mallWithTheSameNameExists = _context.Malls.Any(m => m.Name.Equals(item.Name) && m.Location.Equals(item.Location));
                if(mallWithTheSameNameExists) return;
                var enState = _context.Malls.Add(_mallMapper.DomainToDb(item));
                enState.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public Mall GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                var mallDbModel = _context.Malls.Find(id);
                _context.Entry(mallDbModel).Collection(m => m.StoreDbModels).Load();
                foreach (var storeDbModel in mallDbModel.StoreDbModels)
                {
                    _context.Entry(storeDbModel).Collection(st=>st.CategoryDbModels).Load();
                    foreach (var categoryDbModel in storeDbModel.CategoryDbModels)
                    {
                        _context.Entry(categoryDbModel).Collection(cat=>cat.ProductDbModels).Load();
                    }
                }
                return _mallMapper.DbToDomain(mallDbModel);
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyCollection<Mall> GetAll()
        {
            var mallDbModelList = _context.Malls.ToList();
            foreach (var mallDbModel in mallDbModelList)
            {
                _context.Entry(mallDbModel).Collection(m => m.StoreDbModels).Load();
                foreach (var storeDbModel in mallDbModel.StoreDbModels)
                {
                    _context.Entry(storeDbModel).Collection(st => st.CategoryDbModels).Load();
                    foreach (var categoryDbModel in storeDbModel.CategoryDbModels)
                    {
                        _context.Entry(categoryDbModel).Collection(cat => cat.ProductDbModels).Load();
                    }
                }
            }
            var mallList = (from mallDbModel in mallDbModelList select _mallMapper.DbToDomain(mallDbModel)).ToList();
            return mallList.AsReadOnly();
        }

        public void UpdateOne(Mall item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.MallId);
            if (exists)
            {
                var mallWithTheSameNameExists = _context.Malls.Any(m => m.Name.Equals(item.Name) && m.Location.Equals(item.Location));
                if (mallWithTheSameNameExists) return;
                Detach(item.MallId);
                var enState = _context.Malls.Update(_mallMapper.DomainToDb(item));
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
                var mallDbModel = _context.Malls.Find(id);
                var enState = _context.Malls.Remove(mallDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Malls.Any(item => item.MallDbModelId.Equals(id));
        }

        private void Detach(Guid id)
        {
            CustomValidator.ValidateId(id);
            var entity = _context.Malls.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}