using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.DataAccessLayerImpl.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.DataAccessLayerImpl.RepositoriesImpl
{
    public sealed class SqlBookRepository : IBookRepository
    {
        private readonly MyDbContext _context;
        private readonly BookMapper _bookMapper;
        private readonly ProductMapper _productMapper;

        public SqlBookRepository(MyDbContext context)
        {
            _context = context;
            _bookMapper = new BookMapper();
            _productMapper = new ProductMapper();
        }

        public List<Book> GetClientBooks(Guid clientId)
        {
            CustomValidator.ValidateId(clientId);
            var bookDbModels = _context.Books.Where(b => b.ClientDbModelId.Equals(clientId)).ToList();
            var books = (from bookDbModel in bookDbModels select _bookMapper.DbToDomain(bookDbModel)).ToList();
            return books;
        }

        public void CheckBooksForExpiration()
        {
            var books = (from bookDbModel in _context.Books.ToList() select _bookMapper.DbToDomain(bookDbModel)).ToList();
            var booksToRemove = new List<Book>();
            foreach (var book in books)
            {
                var result = book.IsExpired();
                if (!result) return;
                var productDbModel = _context.Products.Find(book.ProductId);
                CustomValidator.ValidateObject(productDbModel);
                _context.Entry(productDbModel).Reference(p => p.CategoryDbModel).Load();
                if (productDbModel.CategoryDbModel.StoreDbModelId != null)
                {
                    _context.Entry(productDbModel.CategoryDbModel).Reference(cat => cat.StoreDbModel).Load();
                }
                if (productDbModel.CategoryDbModel.StoreDbModel != null)
                {
                    var product = _productMapper.DbToDomain(productDbModel);
                    product.ChangeStatus(ProductStatus.OnSale);
                    Detach<ProductDbModel>(product.ProductId);
                    _context.Products.Update(_productMapper.DomainToDb(product));
                }
                else
                {
                    _context.Products.Remove(productDbModel);
                }

                booksToRemove.Add(book);
            }

            foreach (var book in booksToRemove)
            {
                Detach<BookDbModel>(book.BookId);
                _context.Books.Remove(_bookMapper.DomainToDb(book));
            }

            _context.SaveChanges();
        }

        public void AddOne(Book item)
        {
            CustomValidator.ValidateObject(item);
            var exists = Exists(item.BookId);
            if (!exists)
            {
                var enState = _context.Books.Add(_bookMapper.DomainToDb(item));
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
                var bookDbModel = _context.Books.Find(id);
                var enState = _context.Books.Remove(bookDbModel);
                enState.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Books.Any(item => item.BookDbModelId.Equals(id));
        }

        private void Detach<TEntity>(Guid id) where TEntity : class
        {
            CustomValidator.ValidateId(id);
            var entity = _context.Set<TEntity>().Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }
    }
}