using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
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
            var products = _productRepository.GetAllProducts();
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(pr => pr.Name.Contains(searchString)).ToList().AsReadOnly();
            }

            return View(products);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ReplenishProduct(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var product = _productRepository.GetProduct(id.Value);
            if (product == null) return RedirectToAction(IndexAction, DefaultController);

            var categoryProductsViewModel = new ReplenishProductsViewModel
                {Product = product, Category = product.Category, QuantityOfProductsToReplenish = 1};
            return View(categoryProductsViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ReplenishProduct(ReplenishProductsViewModel replenishProductsViewModel)
        {
            if (ModelState.IsValid)
            {
                var productToReplenish = _productRepository.GetProduct(replenishProductsViewModel.ProductId);
                if (productToReplenish != null)
                {
                    for (var i = 1; i <= replenishProductsViewModel.QuantityOfProductsToReplenish; i++)
                    {
                        var product = new Product(productToReplenish.Name, productToReplenish.Price,
                            ProductStatus.OnSale,
                            replenishProductsViewModel.CategoryId);
                        _productRepository.AddProduct(product);
                    }

                    return RedirectToAction(IndexAction, DefaultController);
                }
            }

            return RedirectToAction(IndexAction, DefaultController);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var category = _categoryRepository.GetCategory(id.Value);
            if (category == null) return RedirectToAction(IndexAction, DefaultController);

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
                    var product = new Product(createProductViewModel.Name, createProductViewModel.Price,
                        ProductStatus.OnSale,
                        createProductViewModel.CategoryId);
                    _productRepository.AddProduct(product);
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

            var productToDel = _productRepository.GetProduct(id.Value);
            if (productToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var deleteProductViewModel = new DeleteProductViewModel {Product = productToDel};
            return View(deleteProductViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(DeleteProductViewModel deleteProductViewModel)
        {
            var productToDel = _productRepository.GetProduct(deleteProductViewModel.ProductId);
            if (productToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var productsToDel = _productRepository.GetAllProducts().Where(pr =>
                    pr.Category != null &&
                    pr.Name.Equals(productToDel.Name) &&
                    pr.Category.CategoryName.Equals(
                        productToDel.Category
                            .CategoryName) &&
                    pr.CategoryId.Equals(productToDel
                        .CategoryId) &&
                    pr.ProductStatus.Equals(productToDel
                        .ProductStatus))
                .ToList();


            if (productsToDel.Count != 0)
            {
                var productsToDelete = productsToDel.ToList();
                foreach (var product in productsToDelete)
                {
                    _productRepository.DeleteProduct(product.ProductId);
                }
            }


            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}