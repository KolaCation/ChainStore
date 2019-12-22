using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public SqlProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            var productsToReturn = _context.Products.Include(pr => pr.Category).ToList();
            return new ReadOnlyCollection<Product>(productsToReturn);
        }

        public Product GetProduct(Guid productId)
        {
            if (productId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(productId));
            var productToReturn = _context.Products.Find(productId);
            if (productToReturn != null)
            {
                _context.Entry(productToReturn).Reference(p => p.Category).Load();
                if (productToReturn.Category.StoreId != null)
                    _context.Entry(productToReturn.Category).Reference(c => c.Store).Load();
            }

            return productToReturn;
        }

        public void AddProduct(Product product)
        {
            if (product == null) return;
            var checkForDuplicate = _context.Products.Find(product.ProductId);
            if (checkForDuplicate != null) return;
            if (_context.Products.FirstOrDefault(pr =>
                    product.Name.Equals(pr.Name) && product.CategoryId.Equals(pr.CategoryId) &&
                    Math.Abs(product.Price - pr.Price) > 1) != null) return;
            var enState = _context.Products.Add(product);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null) return;
            var checkForNull = _context.Products.Find(product.ProductId);
            if (checkForNull == null) return;
            if (_context.Products.FirstOrDefault(pr =>
                    product.Name.Equals(pr.Name) && product.CategoryId.Equals(pr.CategoryId) &&
                    Math.Abs(product.Price - pr.Price) > 1) != null) return;
            var enState = _context.Products.Update(product);
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(Guid productId)
        {
            if (productId.Equals(Guid.Empty)) return;
            var productToRemove = _context.Products.Find(productId);
            if (productToRemove == null) return;
            var enState = _context.Products.Remove(productToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}