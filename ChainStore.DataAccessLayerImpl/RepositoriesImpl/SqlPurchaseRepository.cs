using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayerImpl.RepositoriesImpl
{
    public class SqlPurchaseRepository : IPurchaseRepository
    {
        private readonly MyDbContext _context;
        private readonly PurchaseMapper _purchaseMapper;
        public SqlPurchaseRepository(MyDbContext context)
        {
            _context = context;
            _purchaseMapper = new PurchaseMapper();
        }

        public void AddOne(Purchase item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.Id);
            if (!exists)
            {
                var enState = _context.Purchases.Add(_purchaseMapper.DomainToDb(item));
                enState.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var exists = Exists(id);
            if (exists)
            {
                var purchaseDbModel = _context.Purchases.Find(id);
                var enState = _context.Purchases.Remove(purchaseDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Purchases.Any(item => item.Id.Equals(id));
        }

        public List<Purchase> GetClientPurchases(Guid clientId)
        {
            var purchaseDbModelList = _context.Purchases.Where(p => p.ClientId.Equals(clientId)).ToList();
            var purchaseList = (from purchaseDbModel in purchaseDbModelList select _purchaseMapper.DbToDomain(purchaseDbModel)).ToList();
            return purchaseList;
        }
    }
}
