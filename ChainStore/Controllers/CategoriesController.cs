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
    public class CategoriesController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public CategoriesController(IStoreRepository storeRepository, ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategoryToStore(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var store = _storeRepository.GetStore(id.Value);
            if (store == null) return RedirectToAction(IndexAction, DefaultController);

            var createCategoryViewModel = new CreateCategoryViewModel
            {
                Store = store
            };
            return View(createCategoryViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategoryToStore(CreateCategoryViewModel createCategoryViewModel)
        {
            var store = _storeRepository.GetStore(createCategoryViewModel.StoreId);
            if (store == null) return RedirectToAction(IndexAction, DefaultController);

            foreach (var category in store.Categories)
            {
                if (category.CategoryName.Equals(createCategoryViewModel.CategoryName))
                {
                    ModelState.AddModelError(string.Empty, $"Category '{category.CategoryName}' already exists");
                    return View(new CreateCategoryViewModel {Store = store});
                }
            }

            var categoryToAdd = new Category(createCategoryViewModel.CategoryName, store.StoreId);
            _categoryRepository.AddCategory(categoryToAdd);
            return RedirectToAction(IndexAction, DefaultController);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var categoryToDel = _categoryRepository.GetCategory(id.Value);
            if (categoryToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var delCategoryViewModel = new DeleteCategoryViewModel {Category = categoryToDel};
            return View(delCategoryViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            var categoryToDel = _categoryRepository.GetCategory(deleteCategoryViewModel.CategoryId);
            if (categoryToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var productsInCatToDel = _productRepository.GetAllProducts().Where(pr =>
                    pr.CategoryId.Equals(categoryToDel.CategoryId) &&
                    !pr.ProductStatus.Equals(ProductStatus.Purchased))
                .ToList();
            if (productsInCatToDel.Count != 0)
            {
                var productsToDel = productsInCatToDel.ToList();
                productsToDel.AddRange(productsToDel);
                foreach (var product in productsToDel)
                {
                    _productRepository.DeleteProduct(product.ProductId);
                }
            }

            categoryToDel.RemoveFromStore();
            _categoryRepository.DeleteCategory(categoryToDel.CategoryId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}