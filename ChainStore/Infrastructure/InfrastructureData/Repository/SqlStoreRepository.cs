using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Pipelines;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlStoreRepository : IStoreRepository
    {
        private readonly MyDbContext _context;

        public SqlStoreRepository(MyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Store> GetSAllStores()
        {
            var storesToReturn = _context.Stores.Include(st => st.Categories).ThenInclude(cat => cat.Products).ToList();
            foreach (var store in storesToReturn.Where(store => store.MallId != null))
            {
                _context.Entry(store).Reference(st => st.Mall).Load();
            }

            return new ReadOnlyCollection<Store>(storesToReturn);
        }

        public Store GetStore(Guid storeId)
        {
            if (storeId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(storeId));
            var storeToReturn = _context.Stores.Where(st => st.StoreId.Equals(storeId)).Include(st => st.Categories)
                .ThenInclude(cat => cat.Products).FirstOrDefault();
            if (storeToReturn?.MallId != null) _context.Entry(storeToReturn).Reference(st => st.Mall).Load();
            return storeToReturn;
        }

        public void AddStore(Store store)
        {
            if (store == null) return;
            var checkForDuplicate = _context.Stores.Find(store.StoreId);
            if (checkForDuplicate != null) return;
            var checkForLocation = _context.Stores.FirstOrDefault(st =>
                st.Location.Equals(store.Location) && st.Name.Equals(store.Name) && st.MallId == null);
            if (checkForLocation != null) return;
            var enState = _context.Stores.Add(store);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateStore(Store store)
        {
            if (store == null) return;
            var checkForNull = _context.Stores.Find(store.StoreId);
            if (checkForNull == null) return;
            var checkForDuplicateOnTheSameLocation = _context.Stores.FirstOrDefault(st =>
                st.Location.Equals(store.Location) &&
                st.Name.Equals(store.Name) &&
                !st.StoreId.Equals(store.StoreId) &&
                st.MallId == null);
            if (checkForDuplicateOnTheSameLocation != null) return;
            var enState = _context.Stores.Update(store);
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStore(Guid storeId)
        {
            if (storeId.Equals(Guid.Empty)) return;
            var storeToRemove = _context.Stores.Find(storeId);
            if (storeToRemove == null) return;
            var enState = _context.Stores.Remove(storeToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}