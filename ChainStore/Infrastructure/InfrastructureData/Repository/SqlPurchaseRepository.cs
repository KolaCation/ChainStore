using System;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlPurchaseRepository : IPurchaseRepository
    {
        private readonly MyDbContext _context;
        public SqlPurchaseRepository(MyDbContext context)
        {
            _context = context;
        }
        public void AddPurchase(Purchase purchase)
        {
            if (purchase == null) return;
            var checkForDuplicate = _context.Purchases.Find(purchase.PurchaseId);
            if (checkForDuplicate != null) return;
            var enState = _context.Purchases.Add(purchase);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeletePurchase(Guid purchaseId)
        {
            if (purchaseId.Equals(Guid.Empty)) return;
            var purchaseToRemove = _context.Purchases.Find(purchaseId);
            if (purchaseToRemove == null) return;
            var enState = _context.Purchases.Remove(purchaseToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
