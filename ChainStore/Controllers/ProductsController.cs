using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.Domain.DomainCore;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBookRepository _bookRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository,
            IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index(string searchString)
        {
            _bookRepository.CheckBooksForExpiration();
            var products = _productRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(pr => pr.Name.ToLower().Contains(searchString.ToLower())).ToList().AsReadOnly();
            }

            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ReplenishProduct(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var product = _productRepository.GetOne(id.Value);
            if (product == null) return View("ProductNotFound", id.Value);

            var categoryProductsViewModel = new ReplenishProductsViewModel
            {
                Product = product, Category = _categoryRepository.GetOne(product.CategoryId),
                QuantityOfProductsToReplenish = 1
            };
            return View(categoryProductsViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ReplenishProduct(ReplenishProductsViewModel replenishProductsViewModel)
        {
            if (ModelState.IsValid)
            {
                var productToReplenish = _productRepository.GetOne(replenishProductsViewModel.ProductId);
                if (productToReplenish != null)
                {
                    for (var i = 1; i <= replenishProductsViewModel.QuantityOfProductsToReplenish; i++)
                    {
                        var product = new Product(Guid.NewGuid(), productToReplenish.Name,
                            productToReplenish.PriceInUAH,
                            ProductStatus.OnSale, replenishProductsViewModel.CategoryId);
                        _productRepository.AddOne(product);
                    }

                    return RedirectToAction(IndexAction, DefaultController);
                }
            }

            return View("ProductNotFound", replenishProductsViewModel.ProductId);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var category = _categoryRepository.GetOne(id.Value);
            if (category == null) return View("CategoryNotFound", id.Value);//CategoryNotFoundPage

            var createProductViewModel = new CreateProductViewModel
                {Category = category, QuantityOfProductsToAdd = 1};
            return View(createProductViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(CreateProductViewModel createProductViewModel)
        {
            if (ModelState.IsValid)
            {
                for (var i = 1; i <= createProductViewModel.QuantityOfProductsToAdd; i++)
                {
                    var product = new Product(Guid.NewGuid(), createProductViewModel.Name, createProductViewModel.Price,
                        ProductStatus.OnSale, createProductViewModel.CategoryId);
                    _productRepository.AddOne(product);
                }

                return RedirectToAction(IndexAction, DefaultController);
            }

            return RedirectToAction(IndexAction, DefaultController);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var productToDel = _productRepository.GetOne(id.Value);
            if (productToDel == null) return View("ProductNotFound", id.Value);

            var deleteProductViewModel = new DeleteProductViewModel {Product = productToDel};
            return View(deleteProductViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            var productToDel = _productRepository.GetOne(deleteProductViewModel.ProductId);
            if (productToDel == null) return View("ProductNotFound", deleteProductViewModel.ProductId);

            var productsToDel = _productRepository.GetAll().Where(pr =>
                    _categoryRepository.Exists(pr.CategoryId) &&
                    pr.Name.Equals(productToDel.Name) &&
                    pr.CategoryId.Equals(productToDel.CategoryId) &&
                    _categoryRepository.GetOne(pr.CategoryId).CategoryName.Equals(_categoryRepository.GetOne(productToDel.CategoryId).CategoryName) &&
                    pr.ProductStatus.Equals(productToDel.ProductStatus))
                .ToList();


            if (productsToDel.Count != 0)
            {
                var productsToDelete = productsToDel.ToList();
                foreach (var product in productsToDelete)
                {
                    _productRepository.DeleteOne(product.ProductId);
                }
            }


            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}