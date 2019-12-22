using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Infrastructure.InfrastructureData;
using ChainStore.ViewModels.ViewMakers.DetailedInfo;

namespace ChainStore.ViewModels.ViewMakers
{
    public class ClientDetailsViewModelMaker
    {
        private readonly MyDbContext _context;
        private readonly PropertyGetter<int> _intGetter;
        private readonly PropertyGetter<double> _doubleGetter;

        public ClientDetailsViewModelMaker(MyDbContext context, PropertyGetter<int> intGetter,
            PropertyGetter<double> doubleGetter)
        {
            _context = context;
            _intGetter = intGetter;
            _doubleGetter = doubleGetter;
        }

        public ClientDetailsViewModel MakeClientDetailsViewModel(Guid clientId)
        {
            if (clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            var checkClientForNull = _context.Clients.Find(clientId);
            if (checkClientForNull == null) return null;

            var purchases = (from product in _context.Products
                    join purchase in _context.Purchases.Where(cl => cl.ClientId.Equals(clientId)) on product.ProductId
                        equals purchase.ProductId
                    select new PurchaseDetailedInfo(product,
                        purchase.ClientId, purchase.CreationTime))
                .ToList();

            foreach (var purchase in purchases)
            {
                _context.Entry(purchase.Product).Reference(p => p.Category).Load();
            }

            var books = (from product in _context.Products
                    join book in _context.Books.Where(cl => cl.ClientId.Equals(clientId)) on product.ProductId equals
                        book.ProductId
                    select new BookDetailedInfo(product,
                        book.ClientId, book.CreationTime, book.ExpirationTime))
                .ToList();

            foreach (var book in books)
            {
                _context.Entry(book.Product).Reference(p => p.Category).Load();
            }

            var client = new List<Client> {checkClientForNull};
            var clCashBack = _doubleGetter.GetProperty(checkClientForNull.ClientId, "CashBack");
            var clCashBackPercent = _intGetter.GetProperty(checkClientForNull.ClientId, "CashBackPercent");
            var clDiscountPercent = _intGetter.GetProperty(checkClientForNull.ClientId, "DiscountPercent");
            var clPoints = _doubleGetter.GetProperty(checkClientForNull.ClientId, "Points");

            var clientDetailedInfo = (from cl in client
                join purchase in purchases on cl.ClientId equals purchase.ClientId into purchasesList
                join book in books on cl.ClientId equals book.ClientId into booksList
                select new ClientDetailsViewModel(purchasesList, booksList, cl.ClientId, cl.Name,
                    cl.Balance, clCashBack, clCashBackPercent, clDiscountPercent, clPoints)).First();
            return clientDetailedInfo;
        }
    }
}