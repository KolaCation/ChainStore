using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.Domain.DomainCore;
using ChainStore.ViewModels;
using ChainStore.ViewModels.ViewMakers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChainStore.Controllers
{
    public class StoresController : Controller
    {
        private readonly IMallRepository _mallRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBookRepository _bookRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";


        public StoresController(IMallRepository mallRepository, IStoreRepository storeRepository, IProductRepository productRepository,
            IBookRepository bookRepository)
        {
            _mallRepository = mallRepository;
            _storeRepository = storeRepository;
            _productRepository = productRepository;
            _bookRepository = bookRepository;
        }


        public IActionResult Index(string searchString)
        {
            _bookRepository.CheckBooksForExpiration();
            var stores = _storeRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                stores = stores.Where(st => st.Name.ToLower().Contains(searchString.ToLower())).ToList().AsReadOnly();
            }
            return View(stores);
        }

        [HttpGet]
        public IActionResult StoreDetails(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var store = _storeRepository.GetOne(id.Value);


            if (store == null) return View("StoreNotFound", id.Value);

            return View(store);
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
            if (ModelState.IsValid)
            {
                var store = new Store(Guid.NewGuid(), storeViewModel.Name, storeViewModel.Location, 0, null);
                _storeRepository.AddOne(store);
                return RedirectToAction("StoreDetails", new {id=store.StoreId});
            }

            return View(storeViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStoreToMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var stores = _storeRepository.GetAll().Where(st => st.MallId == null);
            var viewModel = new MallStoresViewModel {MallId = id.Value, StoresToAdd = stores};
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
                    var updatedStore = new Store(store.StoreId, store.Name, mall.Location, store.Profit, mall.MallId);
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
            if (storeToEdit != null)
            {
                var editStoreViewModel = new EditStoreViewModel
                    {Name = storeToEdit.Name, Location = storeToEdit.Location, StoreId = storeToEdit.StoreId};
                return View(editStoreViewModel);
            }

            return View("StoreNotFound", id.Value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStore(EditStoreViewModel editStoreViewModel)
        {
            if (ModelState.IsValid)
            {
                var storeToUpdate = _storeRepository.GetOne(editStoreViewModel.StoreId);
                if (storeToUpdate == null) return View("StoreNotFound", editStoreViewModel.StoreId);
                var updatedStore = new Store(editStoreViewModel.StoreId, editStoreViewModel.Name, editStoreViewModel.Location, storeToUpdate.Profit, storeToUpdate.MallId);
                if (storeToUpdate.MallId != null && _mallRepository.Exists(storeToUpdate.MallId.Value) && !_mallRepository.GetOne(storeToUpdate.MallId.Value).Location.Equals(editStoreViewModel.Location))
                {
                   updatedStore = new Store(editStoreViewModel.StoreId, editStoreViewModel.Name, editStoreViewModel.Location, storeToUpdate.Profit, null);
                }
                _storeRepository.UpdateOne(updatedStore);
                return RedirectToAction("StoreDetails", new {id=updatedStore.StoreId});
            }

            return View(editStoreViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStore(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var storeToDel = _storeRepository.GetOne(id.Value);
            if (storeToDel == null) return View("StoreNotFound", id.Value);

            var delStoreViewModel = new DeleteStoreViewModel {Store = storeToDel};
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
                foreach (var category in storeToDel.Categories)
                {
                    productsToRemove.AddRange(category.Products
                        .Where(pr =>
                            pr.CategoryId.Equals(category.CategoryId) &&
                            !pr.ProductStatus.Equals(ProductStatus.Purchased))
                        .ToList());
                }

                foreach (var product in productsToRemove)
                {
                    _productRepository.DeleteOne(product.ProductId);
                }
            }

            _storeRepository.DeleteOne(storeToDel.StoreId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}