using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.DomainServices;
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
            var malls = _mallRepository.GetAllMalls();
            if (!string.IsNullOrEmpty(searchString))
            {
                malls = malls.Where(m => m.Name.Contains(searchString)).ToList().AsReadOnly();
            }

            return View(malls);
        }

        [HttpGet]
        public IActionResult MallDetails(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var mall = _mallRepository.GetMall(id.Value);
            if (mall == null) return RedirectToAction(IndexAction, DefaultController);

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
                var mall = new Mall(mallViewModel.Name, mallViewModel.Location);
                _mallRepository.AddMall(mall);
                return RedirectToAction(IndexAction, DefaultController);
            }

            return View(mallViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var mallToEdit = _mallRepository.GetMall(id.Value);
            if (mallToEdit != null)
            {
                var editMallViewModel = new EditMallViewModel
                    {Name = mallToEdit.Name, Location = mallToEdit.Location, MallId = mallToEdit.MallId};
                return View(editMallViewModel);
            }

            return RedirectToAction(IndexAction, DefaultController);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMall(EditMallViewModel editMallViewModel)
        {
            if (ModelState.IsValid)
            {
                var mallToUpdate = _mallRepository.GetMall(editMallViewModel.MallId);
                if (mallToUpdate == null) return RedirectToAction(IndexAction, DefaultController);

                mallToUpdate.ChangeName(editMallViewModel.Name);
                mallToUpdate.ChangeLocation(editMallViewModel.Location);

                if (mallToUpdate.Stores.Count != 0)
                {
                    foreach (var store in mallToUpdate.Stores)
                    {
                        store.ChangeLocation(mallToUpdate.Location);
                        _storeRepository.UpdateStore(store);
                    }
                }

                _mallRepository.UpdateMall(mallToUpdate);
                return RedirectToAction(IndexAction, DefaultController);
            }

            return View(editMallViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMall(Guid? id)
        {
            if (id == null) return RedirectToAction(IndexAction, DefaultController);

            var mallToDel = _mallRepository.GetMall(id.Value);
            if (mallToDel == null) return RedirectToAction(IndexAction, DefaultController);

            var delMallViewModel = new DeleteMallViewModel
                {MallName = mallToDel.Name, MallLocation = mallToDel.Location, MallId = mallToDel.MallId};

            return View(delMallViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMall(DeleteMallViewModel deleteMallViewModel)
        {
            var mallToDel = _mallRepository.GetMall(deleteMallViewModel.MallId);
            if (mallToDel == null) return RedirectToAction(IndexAction, DefaultController);

            if (mallToDel.Stores.Count != 0)
            {
                ModelState.AddModelError(string.Empty,
                    $"Unable To Delete '{deleteMallViewModel.MallName}' : Make Sure To Delete All Stores First");
                return View(deleteMallViewModel);
            }

            _mallRepository.DeleteMall(mallToDel.MallId);
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}