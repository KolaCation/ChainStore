using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.Domain.DomainCore;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    public class MallsController : Controller
    {
        private readonly IMallRepository _mallRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;
        private const string IndexAction = "Index";
        private const string DefaultController = "Malls";

        public MallsController(IMallRepository mallRepository, IStoreRepository storeRepository,
            IBookRepository bookRepository)
        {
            _mallRepository = mallRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult Index(string searchString)
        {
            _bookRepository.CheckBooksForExpiration();
            var malls = _mallRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                malls = malls.Where(m => m.Name.ToLower().Contains(searchString.ToLower())).ToList().AsReadOnly();
            }

            return View(malls);
        }

        [HttpGet]
        public IActionResult MallDetails(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var mall = _mallRepository.GetOne(id.Value);
            if (mall == null) return View("MallNotFound", id.Value);

            return View(mall);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMall()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateMall(CreateMallViewModel mallViewModel)
        {
            if (ModelState.IsValid)
            {
                var mall = new Mall(Guid.NewGuid(), mallViewModel.Name, mallViewModel.Location);
                _mallRepository.AddOne(mall);
                return RedirectToAction("MallDetails", new {id=mall.MallId});
            }

            return View(mallViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var mallToEdit = _mallRepository.GetOne(id.Value);
            if (mallToEdit != null)
            {
                var editMallViewModel = new EditMallViewModel
                    {Name = mallToEdit.Name, Location = mallToEdit.Location, MallId = mallToEdit.MallId};
                return View(editMallViewModel);
            }

            return View("MallNotFound", id.Value);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMall(EditMallViewModel editMallViewModel)
        {
            if (ModelState.IsValid)
            {
                var mallToUpdate = _mallRepository.GetOne(editMallViewModel.MallId);
                if (mallToUpdate == null) return View("MallNotFound", editMallViewModel.MallId);
                var updatedMall = new Mall(editMallViewModel.MallId, editMallViewModel.Name, editMallViewModel.Location);
                if (mallToUpdate.Stores.Count != 0)
                {
                    foreach (var store in mallToUpdate.Stores)
                    {
                        var updatedStore = new Store(store.StoreId, store.Name, updatedMall.Location, store.Profit, updatedMall.MallId);
                        _storeRepository.UpdateOne(updatedStore);
                    }
                }

                _mallRepository.UpdateOne(updatedMall);
                return RedirectToAction("MallDetails", new {id=updatedMall.MallId});
            }

            return View(editMallViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var mallToDel = _mallRepository.GetOne(id.Value);
            if (mallToDel == null) return View("MallNotFound", id.Value);

            var delMallViewModel = new DeleteMallViewModel
                {MallName = mallToDel.Name, MallLocation = mallToDel.Location, MallId = mallToDel.MallId};

            return View(delMallViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMall(DeleteMallViewModel deleteMallViewModel)
        {
            var mallToDel = _mallRepository.GetOne(deleteMallViewModel.MallId);
            if (mallToDel == null) return View("MallNotFound", deleteMallViewModel.MallId);

            if (mallToDel.Stores.Count != 0)
            {
                ModelState.AddModelError(string.Empty,
                    $"Unable To Delete '{deleteMallViewModel.MallName}' : Make Sure To Delete All Stores First");
                return View(deleteMallViewModel);
            }

            _mallRepository.DeleteOne(mallToDel.MallId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}