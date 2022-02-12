using System;
using ChainStore.Actions.ApplicationServices;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;

namespace ChainStore.ActionsImpl.ApplicationServicesImpl;

public class BookService : IReservationService
{
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;


    public BookService(IProductRepository productRepository,
        IBookRepository bookRepository, ICustomerRepository customerRepository)
    {
        _productRepository = productRepository;
        _bookRepository = bookRepository;
        _customerRepository = customerRepository;
    }

    public void HandleOperation(Guid customerId, Guid productId, int reserveDaysCount)
    {
        CustomValidator.ValidateId(customerId);
        CustomValidator.ValidateId(productId);
        if (reserveDaysCount > 7 || reserveDaysCount < 1) return;
        var customerExists = _customerRepository.Exists(customerId);
        var productExists = _productRepository.Exists(productId);

        if (customerExists && productExists)
        {
            var product = _productRepository.GetOne(productId);
            var checkForLimit = _bookRepository.GetCustomerBooks(customerId);
            if (checkForLimit.Count >= 3) return;
            product.ChangeStatus(ProductStatus.Booked);
            var book = new Book(Guid.NewGuid(), customerId, productId, reserveDaysCount);
            _productRepository.UpdateOne(product);
            _bookRepository.AddOne(book);
        }
    }
}