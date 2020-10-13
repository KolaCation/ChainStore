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
    public class CategoriesController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";
        private const string StoreDetailsPage = "StoreDetails";

        public CategoriesController(IStoreRepository storeRepository, ICategoryRepository categoryRepository,
            IProductRepository productRepository)
        {
            _storeRepository = storeRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category(Guid.NewGuid(), createCategoryViewModel.CategoryName);
                var categories = _categoryRepository.GetAll();
                if (categories.Any(e => e.Name.ToLower().Equals(category.Name.ToLower())))
                {
                    ModelState.AddModelError(string.Empty, $"Category '{category.Name}' already exists");
                    return View(createCategoryViewModel);
                }
                _categoryRepository.AddOne(category);
                return RedirectToAction(IndexAction, DefaultController);
            }
            return View(createCategoryViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategoryToStore(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var store = _storeRepository.GetOne(id.Value);
            if (store == null) return View("StoreNotFound", id.Value);

            var addCategoryToStoreViewModel = new AddCategoryToStoreViewModel
            {
                Store = store
            };
            return View(addCategoryToStoreViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategoryToStore(AddCategoryToStoreViewModel addCategoryToStoreViewModel)
        {
            var store = _storeRepository.GetOne(addCategoryToStoreViewModel.StoreId);
            if (store == null) return View("StoreNotFound", addCategoryToStoreViewModel.StoreId);
            if (store.Categories.Any(category => category.Name.ToLower().Equals(addCategoryToStoreViewModel.CategoryName.ToString().ToLower())))
            {
                ModelState.AddModelError(string.Empty, $"Category '{addCategoryToStoreViewModel.CategoryName}' already exists");
                return View(new AddCategoryToStoreViewModel { Store = store });
            }
            var categoryToAdd = _categoryRepository.GetAll().FirstOrDefault(e=>e.Name.ToLower().Equals(addCategoryToStoreViewModel.CategoryName.ToLower()));
            _categoryRepository.AddCategoryToStore(categoryToAdd, store.StoreId);
            return RedirectToAction(IndexAction, DefaultController);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var categoryToDel = _categoryRepository.GetOne(id.Value);
            if (categoryToDel == null) return View("CategoryNotFound", id.Value);//CategoryNotFound

            var delCategoryViewModel = new DeleteCategoryViewModel { Category = categoryToDel };
            return View(delCategoryViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            var categoryToDel = _categoryRepository.GetOne(deleteCategoryViewModel.CategoryId);
            if (categoryToDel == null) return View("CategoryNotFound", deleteCategoryViewModel.CategoryId);//CategoryNotFound

            var productsInCatToDel = _productRepository.GetAll().Where(pr =>
                    pr.CategoryId.Equals(categoryToDel.CategoryId) &&
                    !pr.ProductStatus.Equals(ProductStatus.Purchased))
                .ToList();
            if (productsInCatToDel.Count != 0)
            {
                var productsToDel = productsInCatToDel.ToList();
                productsToDel.AddRange(productsToDel);
                foreach (var product in productsToDel)
                {   //you should not delete category
                    _productRepository.DeleteOne(product.ProductId);
                }
            }
            var catToDel = new Category(categoryToDel.CategoryId, categoryToDel.Name);//?
            _categoryRepository.DeleteOne(catToDel.CategoryId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}