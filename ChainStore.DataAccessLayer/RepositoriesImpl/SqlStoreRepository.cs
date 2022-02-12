using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.DbModels;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.DataAccessLayer.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayer.RepositoriesImpl;

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
        var exists = Exists(item.Id);
        if (!exists)
        {
            var storeWithTheSameLocationAndNameExists = _context.Stores.Any(st =>
                st.Location.Equals(item.Location) &&
                st.Name.Equals(item.Name) &&
                !st.Id.Equals(item.Id) &&
                st.MallId == null);
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
            return _storeMapper.DbToDomain(storeDbModel);
        }

        return null;
    }

    public IReadOnlyCollection<Store> GetAll()
    {
        var storeDbModelList = _context.Stores.ToList();
        var storeList = (from storeDbModel in storeDbModelList select _storeMapper.DbToDomain(storeDbModel)).ToList();
        return storeList.AsReadOnly();
    }

    public void UpdateOne(Store item)
    {
        CustomValidator.ValidateObject(item);
        var exists = Exists(item.Id);
        if (exists)
        {
            var storeWithTheSameLocationAndNameExists = _context.Stores.Any(st =>
                st.Location.Equals(item.Location) &&
                st.Name.Equals(item.Name) &&
                !st.Id.Equals(item.Id) &&
                st.MallId == null);
            if (storeWithTheSameLocationAndNameExists) return;
            DetachService.Detach<StoreDbModel>(_context, item.Id);
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
        return _context.Stores.Any(item => item.Id.Equals(id));
    }
}