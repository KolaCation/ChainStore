using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReservationService _reservationService;
        private readonly IBookRepository _bookRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public BookController(IProductRepository productRepository, IClientRepository clientRepository,
            UserManager<ApplicationUser> userManager, IReservationService reservationService,
            IBookRepository bookRepository)
        {
            _productRepository = productRepository;
            _clientRepository = clientRepository;
            _userManager = userManager;
            _reservationService = reservationService;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BookOperation(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var productToBook = _productRepository.GetOne(id.Value);
            if (productToBook == null) return View("ProductNotFound", id.Value);//ProductNotFound

            var client = await _userManager.GetUserAsync(User);
            if (client == null) return View("ClientNotFound");//ClientNotFound

            var productClientViewModel = new ProductClientViewModel
                {ClientId = client.ClientDbModelId, Product = productToBook};
            return View(productClientViewModel);
        }


        [HttpPost]
        public IActionResult BookOperation(ProductClientViewModel productClientViewModel)
        {
            var client = _clientRepository.GetOne(productClientViewModel.ClientId);
            if (client == null) return View("ClientNotFound", productClientViewModel.ClientId);//ClientNotFound

            var product = _productRepository.GetOne(productClientViewModel.ProductId);
            if (product == null) return View("ProductNotFound", productClientViewModel.ProductId);//ProductNotFound

            var checkForLimit = _bookRepository.GetClientBooks(productClientViewModel.ClientId);
            if (checkForLimit == null) return View("ClientNotFound", productClientViewModel.ClientId);

            if (productClientViewModel.BookDaysCount > 7 || productClientViewModel.BookDaysCount < 1)
            {
                ModelState.AddModelError(string.Empty, "Books Days Count | Max: 7 Min: 1");
                return View(new ProductClientViewModel
                    {ClientId = client.Id, Product = product, BookDaysCount = productClientViewModel.BookDaysCount});
            }

            if (checkForLimit.Count >= 3)
            {
                ModelState.AddModelError(string.Empty,
                    $"Maximum Limit Of Books: 3 | Your Quantity Of Books: {checkForLimit.Count}");
                return View(new ProductClientViewModel
                    {ClientId = client.Id, Product = product, BookDaysCount = productClientViewModel.BookDaysCount});
            }

            _reservationService.HandleOperation(productClientViewModel.ClientId, productClientViewModel.ProductId,
                productClientViewModel.BookDaysCount);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}