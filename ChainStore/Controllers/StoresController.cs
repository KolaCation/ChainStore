using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers;

public class StoresController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private readonly IBookRepository _bookRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMallRepository _mallRepository;
    private readonly IProductRepository _productRepository;
    private readonly IStoreRepository _storeRepository;


    public StoresController(IMallRepository mallRepository, IStoreRepository storeRepository,
        IProductRepository productRepository,
        IBookRepository bookRepository, ICategoryRepository categoryRepository)
    {
        _mallRepository = mallRepository;
        _storeRepository = storeRepository;
        _productRepository = productRepository;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
    }


    public IActionResult Index(string searchStringStore, string searchStringProduct)
    {
        _bookRepository.CheckBooksForExpiration();
        var stores = _storeRepository.GetAll();
        var storesToDisplay = new List<Store>();
        if (!string.IsNullOrEmpty(searchStringStore))
            storesToDisplay.AddRange(stores.Where(st => st.Name.ToLower().Contains(searchStringStore.ToLower()))
                .ToList());

        if (!string.IsNullOrEmpty(searchStringProduct))
        {
            if (string.IsNullOrEmpty(searchStringStore)) storesToDisplay = stores.ToList();
            var storesToIterate = new List<Store>(storesToDisplay);

            foreach (var store in storesToIterate)
            {
                var success = store.Categories.SelectMany(category => category.Products).Any(product => product.Name.ToLower().Contains(searchStringProduct.ToLower()));

                if (!success) storesToDisplay.Remove(store);
            }
        }

        if (string.IsNullOrEmpty(searchStringStore) && string.IsNullOrEmpty(searchStringProduct))
            storesToDisplay = stores.ToList();

        return View(storesToDisplay);
    }

    [HttpGet]
    public IActionResult StoreDetails(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var store = _storeRepository.GetOne(id.Value);

        return store == null ? View("StoreNotFound", id.Value) : View(store);
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateStore()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult CreateStore(CreateStoreViewModel storeViewModel)
    {
        if (!ModelState.IsValid) return View(storeViewModel);

        var store = new Store(Guid.NewGuid(), storeViewModel.Name, storeViewModel.Location, 0, null);
        _storeRepository.AddOne(store);

        return RedirectToAction("StoreDetails", new { id = store.Id });

    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AddStoreToMall(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var stores = _storeRepository.GetAll().Where(st => st.MallId == null);
        var viewModel = new MallStoresViewModel { MallId = id.Value, StoresToAdd = stores };

        return View(viewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult AddStoreToMall(IEnumerable<Guid> storesToAdd, Guid mallId)
    {
        var mall = _mallRepository.GetOne(mallId);
        if (mall == null) return RedirectToAction(IndexAction, DefaultController);
        foreach (var storeId in storesToAdd)
        {
            var store = _storeRepository.GetOne(storeId);
            if (store == null) return View("StoreNotFound", storeId);
            if (store.MallId == null)
            {
                var updatedStore = new Store(store.Id, store.Name, mall.Location, store.Profit, mall.Id);
                _storeRepository.UpdateOne(updatedStore);
            }
        }

        return RedirectToAction(IndexAction, "Malls");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult EditStore(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var storeToEdit = _storeRepository.GetOne(id.Value);
        if (storeToEdit == null) return View("StoreNotFound", id.Value);

        var editStoreViewModel = new EditStoreViewModel
            { Name = storeToEdit.Name, Location = storeToEdit.Location, StoreId = storeToEdit.Id };

        return View(editStoreViewModel);

    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult EditStore(EditStoreViewModel editStoreViewModel)
    {
        if (!ModelState.IsValid) return View(editStoreViewModel);

        var storeToUpdate = _storeRepository.GetOne(editStoreViewModel.StoreId);
        if (storeToUpdate == null) return View("StoreNotFound", editStoreViewModel.StoreId);

        var updatedStore = new Store(editStoreViewModel.StoreId, editStoreViewModel.Name,
            editStoreViewModel.Location, storeToUpdate.Profit, storeToUpdate.MallId);
        if (storeToUpdate.MallId != null && _mallRepository.Exists(storeToUpdate.MallId.Value) && !_mallRepository
                .GetOne(storeToUpdate.MallId.Value).Location.Equals(editStoreViewModel.Location))
            updatedStore = new Store(editStoreViewModel.StoreId, editStoreViewModel.Name,
                editStoreViewModel.Location, storeToUpdate.Profit, null);
        _storeRepository.UpdateOne(updatedStore);

        return RedirectToAction("StoreDetails", new { id = updatedStore.Id });

    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteStore(Guid? id)
    {
        if (id == null) return RedirectToAction(IndexAction, DefaultController);

        var storeToDel = _storeRepository.GetOne(id.Value);
        if (storeToDel == null) return View("StoreNotFound", id.Value);

        var delStoreViewModel = new DeleteStoreViewModel { Store = storeToDel };
        return View(delStoreViewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult DeleteStore(DeleteStoreViewModel deleteStoreViewModel)
    {
        var storeToDel = _storeRepository.GetOne(deleteStoreViewModel.StoreId);
        if (storeToDel == null) return View("StoreNotFound", deleteStoreViewModel.StoreId);

        if (storeToDel.Categories.Count != 0)
        {
            var productsToRemove = new List<Product>();
            var categoriesToRemoveFromStore = new List<Category>();
            foreach (var category in storeToDel.Categories)
            {
                productsToRemove.AddRange(category.Products
                    .Where(pr =>
                        pr.CategoryId.Equals(category.Id) &&
                        !pr.ProductStatus.Equals(ProductStatus.Purchased))
                    .ToList());
                categoriesToRemoveFromStore.Add(category);
            }

            foreach (var product in productsToRemove) _productRepository.DeleteOne(product.Id);

            foreach (var category in categoriesToRemoveFromStore)
                _categoryRepository.DeleteCategoryFromStore(category, storeToDel.Id);
        }

        _storeRepository.DeleteOne(storeToDel.Id);
        return RedirectToAction(IndexAction, DefaultController);
    }
}