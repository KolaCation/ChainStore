using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Infrastructure.InfrastructureData.Repository
{
    public class SqlBookRepository : IBookRepository
    {
        private readonly MyDbContext _context;

        public SqlBookRepository(MyDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            if (book == null) return;
            var checkForDuplicate = _context.Books.Find(book.BookId);
            if (checkForDuplicate != null) return;
            var enState = _context.Books.Add(book);
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void DeleteBook(Guid bookId)
        {
            if (bookId.Equals(Guid.Empty)) return;
            var bookToRemove = _context.Books.Find(bookId);
            if (bookToRemove == null) return;
            var enState = _context.Books.Remove(bookToRemove);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Book> GetClientBooks(Guid clientId)
        {
            if (clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            var books = _context.Books.Where(b => b.ClientId.Equals(clientId)).ToList();
            return books;
        }

        public void CheckBooksForExpiration()
        {
            var books = _context.Books.ToList();
            var booksToRemove = new List<Book>();
            foreach (var book in books)
            {
                var result = book.IsExpired();
                if (!result) return;
                var product = _context.Products.Find(book.ProductId);
                if (product == null) throw new ArgumentNullException(nameof(product));
                _context.Entry(product).Reference(p => p.Category).Load();
                if (product.Category.StoreId != null) _context.Entry(product.Category).Reference(c => c.Store).Load();
                if (product.Category.Store != null)
                {
                    product.ChangeStatus(ProductStatus.OnSale);
                    _context.Products.Update(product);
                }
                else
                {
                    _context.Products.Remove(product);
                }

                booksToRemove.Add(book);
            }

            foreach (var book in booksToRemove)
            {
                _context.Books.Remove(book);
            }

            _context.SaveChanges();
        }
    }
}