using System;
using ChainStore.Domain.Repositories;
using ChainStore.ViewModels;
using ChainStore.ViewModels.ViewMakers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers;

[Authorize]
public class CustomerController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private const string CustomerNotFoundPage = "CustomerNotFound";
    private const string CustomerDetailsPage = "CustomerDetails";
    private readonly IBookRepository _bookRepository;
    private readonly CustomerDetailsViewModelMaker _customerDetailsViewModelMaker;
    private readonly ICustomerRepository _customerRepository;

    public CustomerController(ICustomerRepository customerRepository,
        IBookRepository bookRepository,
        CustomerDetailsViewModelMaker customerDetailsViewModelMaker)
    {
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
        _customerDetailsViewModelMaker = customerDetailsViewModelMaker;
    }

    [HttpGet]
    public IActionResult CustomerDetails(Guid? id)
    {
        _bookRepository.CheckBooksForExpiration();
        if (id == null) return RedirectToAction(IndexAction, DefaultController);
        var customer = _customerDetailsViewModelMaker.MakeCustomerDetailsViewModel(id.Value);
        return customer != null ? View(customer) : View(CustomerNotFoundPage, id.Value);
    }

    [HttpPost]
    public IActionResult ReplenishBalance(CustomerDetailsViewModel customerDetailsViewModel)
    {
        var customer = _customerRepository.GetOne(customerDetailsViewModel.CustomerId);
        if (customer == null) return View(CustomerNotFoundPage, customerDetailsViewModel.CustomerId);

        customer.ReplenishBalance(customerDetailsViewModel.CustomerBalance);
        _customerRepository.UpdateOne(customer);

        return RedirectToAction(CustomerDetailsPage, new {id = customer.Id});

    }

    [HttpPost]
    public IActionResult ChangeName(CustomerDetailsViewModel customerDetailsViewModel)
    {
        var customer = _customerRepository.GetOne(customerDetailsViewModel.CustomerId);
        if (customer == null) return View(CustomerNotFoundPage, customerDetailsViewModel.CustomerId);

        customer.UpdateName(customerDetailsViewModel.CustomerName);
        _customerRepository.UpdateOne(customer);

        return RedirectToAction(CustomerDetailsPage, new {id = customer.Id});

    }
}