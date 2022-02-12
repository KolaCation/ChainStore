using System;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer;
using ChainStore.Domain.Repositories;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers;

[Authorize]
public class BookController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private readonly IBookRepository _bookRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IReservationService _reservationService;
    private readonly UserManager<ApplicationUser> _userManager;

    public BookController(IProductRepository productRepository, ICustomerRepository customerRepository,
        UserManager<ApplicationUser> userManager, IReservationService reservationService,
        IBookRepository bookRepository)
    {
        _productRepository = productRepository;
        _customerRepository = customerRepository;
        _userManager = userManager;
        _reservationService = reservationService;
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> BookOperation(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var productToBook = _productRepository.GetOne(id.Value);
        if (productToBook == null) return View("ProductNotFound", id.Value); //ProductNotFound

        var customer = await _userManager.GetUserAsync(User);
        if (customer == null) return View("CustomerNotFound"); //CustomerNotFound

        var productCustomerViewModel = new ProductCustomerViewModel
            {CustomerId = customer.CustomerDbModelId, Product = productToBook};
        return View(productCustomerViewModel);
    }


    [HttpPost]
    public IActionResult BookOperation(ProductCustomerViewModel productCustomerViewModel)
    {
        var customer = _customerRepository.GetOne(productCustomerViewModel.CustomerId);
        if (customer == null) return View("CustomerNotFound", productCustomerViewModel.CustomerId); //CustomerNotFound

        var product = _productRepository.GetOne(productCustomerViewModel.ProductId);
        if (product == null) return View("ProductNotFound", productCustomerViewModel.ProductId); //ProductNotFound

        var checkForLimit = _bookRepository.GetCustomerBooks(productCustomerViewModel.CustomerId);
        if (checkForLimit == null) return View("CustomerNotFound", productCustomerViewModel.CustomerId);

        if (productCustomerViewModel.BookDaysCount is > 7 or < 1)
        {
            ModelState.AddModelError(string.Empty, "Books Days Count | Max: 7 Min: 1");
            return View(new ProductCustomerViewModel
                {CustomerId = customer.Id, Product = product, BookDaysCount = productCustomerViewModel.BookDaysCount});
        }

        if (checkForLimit.Count >= 3)
        {
            ModelState.AddModelError(string.Empty,
                $"Maximum Limit Of Books: 3 | Your Quantity Of Books: {checkForLimit.Count}");
            return View(new ProductCustomerViewModel
                {CustomerId = customer.Id, Product = product, BookDaysCount = productCustomerViewModel.BookDaysCount});
        }

        _reservationService.HandleOperation(productCustomerViewModel.CustomerId, productCustomerViewModel.ProductId,
            productCustomerViewModel.BookDaysCount);
        return RedirectToAction(IndexAction, DefaultController);
    }
}