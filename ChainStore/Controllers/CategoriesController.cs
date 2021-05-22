using ChainStore.DataAccessLayer.Repositories;
using ChainStore.Domain.DomainCore;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            var categories = _categoryRepository.GetAll();

            var addCategoryToStoreViewModel = new AddCategoryToStoreViewModel
            {
                Store = store,
                CategoriesOption = categories.Where(cat => !store.Categories.Any(x => x.Id.Equals(cat.Id))).ToList()
            };
            return View(addCategoryToStoreViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategoryToStore(AddCategoryToStoreViewModel addCategoryToStoreViewModel)
        {
            var store = _storeRepository.GetOne(addCategoryToStoreViewModel.StoreId);
            if (store == null) return View("StoreNotFound", addCategoryToStoreViewModel.StoreId);
            var categoryWithThatId = _categoryRepository.GetOne(addCategoryToStoreViewModel.CategoryId);
            _categoryRepository.AddCategoryToStore(categoryWithThatId, store.Id);
            return RedirectToAction(IndexAction, DefaultController);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategoryFromStore(Guid? storeId, Guid? categoryId)
        {
            if (storeId == null || categoryId == null) return RedirectToAction(IndexAction, DefaultController);

            var store = _storeRepository.GetOne(storeId.Value);
            if (store == null) return View("StoreNotFound", storeId.Value);

            var categoryToDel = _categoryRepository.GetOne(categoryId.Value);
            if (categoryToDel == null) return View("CategoryNotFound", categoryId.Value);//CategoryNotFound

            var delCategoryViewModel = new DeleteCategoryFromStoreViewModel { StoreId = store.Id, Category = categoryToDel };
            return View(delCategoryViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategoryFromStore(DeleteCategoryFromStoreViewModel deleteCategoryFromStoreViewModel)
        {
            var store = _storeRepository.GetOne(deleteCategoryFromStoreViewModel.StoreId);
            if (store == null) return View("StoreNotFound", deleteCategoryFromStoreViewModel.StoreId);//StoreNotFound

            var categoryToDelFromStore = _categoryRepository.GetOne(deleteCategoryFromStoreViewModel.CategoryId);
            if (categoryToDelFromStore == null) return View("CategoryNotFound", deleteCategoryFromStoreViewModel.CategoryId);//CategoryNotFound

            var productsInCatToDel = store.Categories.First(e => e.Id.Equals(categoryToDelFromStore.Id)).Products;
            if (productsInCatToDel.Count != 0)
            {
                var productsToDel = productsInCatToDel.ToList();
                productsToDel.AddRange(productsToDel);
                foreach (var product in productsToDel)
                {   //you should not delete category
                    _productRepository.DeleteOne(product.Id);
                }
            }
            var catToDel = new Category(categoryToDelFromStore.Id, categoryToDelFromStore.Name);//?
            _categoryRepository.DeleteCategoryFromStore(catToDel, store.Id);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}