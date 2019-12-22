using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.ApplicationServices;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;

namespace ChainStore.Infrastructure.InfrastructureBusiness
{
    public class BookOperation : IReservationOperation
    {
        private readonly IProductRepository _productRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IClientRepository _clientRepository;


        public BookOperation(IProductRepository productRepository,
            IBookRepository bookRepository, IClientRepository clientRepository)
        {
            _productRepository = productRepository;
            _bookRepository = bookRepository;
            _clientRepository = clientRepository;
        }

        public void Perform(Guid clientId, Guid productId, int reserveDaysCount)
        {
            if (clientId.Equals(Guid.Empty) || productId.Equals(Guid.Empty)) throw new ArgumentException();
            var client = _clientRepository.GetClient(clientId);
            var product = _productRepository.GetProduct(productId);

            if (client != null && product != null)
            {
                if (reserveDaysCount > 7 || reserveDaysCount < 1) return;
                var checkForLimit = _bookRepository.GetClientBooks(clientId);
                if (checkForLimit.Count >= 3) return;
                product.ChangeStatus(ProductStatus.Booked);
                var book = new Book(clientId, productId, reserveDaysCount);
                _productRepository.UpdateProduct(product);
                _bookRepository.AddBook(book);
            }
        }
    }
}