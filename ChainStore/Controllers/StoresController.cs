using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
using ChainStore.Identity;
using ChainStore.Infrastructure.InfrastructureData;
using ChainStore.Infrastructure.InfrastructureData.Repository;
using ChainStore.ViewModels;
using ChainStore.ViewModels.ViewMakers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            var stores = _storeRepository.GetSAllStores();
            if (!string.IsNullOrEmpty(searchString))
            {
                stores = stores.Where(st => st.Name.Contains(searchString)).ToList().AsReadOnly();
            }
            return View(stores);
        }

        [HttpGet]
        public IActionResult StoreDetails(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var store = _storeRepository.GetStore(id.Value);


            if (store == null) return RedirectToAction(IndexAction, DefaultController);

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
                var store = new Store(storeViewModel.Name, storeViewModel.Location, null);
                _storeRepository.AddStore(store);
                return RedirectToAction(IndexAction, DefaultController);
            }

            return View(storeViewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStoreToMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var stores = _storeRepository.GetSAllStores().Where(st => st.MallId == null);
            var viewModel = new MallStoresViewModel {MallId = id.Value, StoresToAdd = stores};
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddStoreToMall(IEnumerable<Guid> storesToAdd, Guid mallId)
        {
            var mall = _mallRepository.GetMall(mallId);
            if (mall == null) return RedirectToAction(IndexAction, DefaultController);
            foreach (var storeId in storesToAdd)
            {
                var store = _storeRepository.GetStore(storeId);
                if (store == null) return RedirectToAction(IndexAction, DefaultController);
                if (store.MallId == null)
                {
                    store.MoveToMall(mallId, mall.Location);
                    _storeRepository.UpdateStore(store);
                }
            }

            return RedirectToAction(IndexAction, "Malls");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStore(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var storeToEdit = _storeRepository.GetStore(id.Value);
            if (storeToEdit != null)
            {
                var editStoreViewModel = new EditStoreViewModel
                    {Name = storeToEdit.Name, Location = storeToEdit.Location, StoreId = storeToEdit.StoreId};
                return View(editStoreViewModel);
            }

            return RedirectToAction(IndexAction, DefaultController);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditStore(EditStoreViewModel editStoreViewModel)
        {
            if (ModelState.IsValid)
            {
                var storeToUpdate = _storeRepository.GetStore(editStoreViewModel.StoreId);
                if (storeToUpdate == null) return RedirectToAction(IndexAction, DefaultController);
                storeToUpdate.ChangeName(editStoreViewModel.Name);
                if (storeToUpdate.MallId != null && !storeToUpdate.Mall.Location.Equals(editStoreViewModel.Location))
                {
                    storeToUpdate.MoveFromMall(editStoreViewModel.Location);
                }

                storeToUpdate.ChangeLocation(editStoreViewModel.Location);
                _storeRepository.UpdateStore(storeToUpdate);
                return RedirectToAction(IndexAction, DefaultController);
            }

            return View(editStoreViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStore(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var storeToDel = _storeRepository.GetStore(id.Value);
            if (storeToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var delStoreViewModel = new DeleteStoreViewModel {Store = storeToDel};
            return View(delStoreViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteStore(DeleteStoreViewModel deleteStoreViewModel)
        {
            var storeToDel = _storeRepository.GetStore(deleteStoreViewModel.StoreId);
            if (storeToDel == null) return RedirectToAction(IndexAction, DefaultController);

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
                    _productRepository.DeleteProduct(product.ProductId);
                }
            }

            _storeRepository.DeleteStore(storeToDel.StoreId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}