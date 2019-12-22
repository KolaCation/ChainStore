using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlMallRepository : IMallRepository
    {
        private readonly MyDbContext _context;

        public SqlMallRepository(MyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Mall> GetAllMalls()
        {
            var mallsToReturn = _context.Malls.Include(m => m.Stores).ThenInclude(st => st.Categories)
                .ThenInclude(cat => cat.Products).ToList();
            return new ReadOnlyCollection<Mall>(mallsToReturn);
        }

        public Mall GetMall(Guid mallId)
        {
            if (mallId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(mallId));
            var mallToReturn = _context.Malls.Where(m => m.MallId.Equals(mallId)).Include(m => m.Stores)
                .ThenInclude(st => st.Categories).ThenInclude(cat => cat.Products).FirstOrDefault();
            return mallToReturn;
        }

        public void AddMall(Mall mall)
        {
            if (mall == null) return;
            var checkForDuplicate = _context.Malls.Find(mall.MallId);
            if (checkForDuplicate != null) return;
            var checkForMallWithTheSameName =
                _context.Malls.FirstOrDefault(m => m.Name.Equals(mall.Name) && m.Location.Equals(mall.Location));
            if(checkForMallWithTheSameName != null) return;
            var enState = _context.Malls.Add(mall);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateMall(Mall mall)
        {
            if (mall == null) return;
            var checkForNull = _context.Malls.Find(mall.MallId);
            if (checkForNull == null) return;
            var checkForMallWithTheSameName =
                _context.Malls.FirstOrDefault(m => m.Name.Equals(mall.Name) && m.Location.Equals(mall.Location));
            if (checkForMallWithTheSameName != null) return;
            var enState = _context.Malls.Update(mall);
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMall(Guid mallId)
        {
            if (mallId.Equals(Guid.Empty)) return;
            var mallToRemove = _context.Malls.Find(mallId);
            if (mallToRemove == null) return;
            var enState = _context.Malls.Remove(mallToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}