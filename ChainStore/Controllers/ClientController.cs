using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainServices;
using ChainStore.Identity;
using ChainStore.ViewModels;
using ChainStore.ViewModels.ViewMakers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ClientDetailsViewModelMaker _clientDetailsViewModelMaker;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public ClientController(IClientRepository clientRepository,
            IBookRepository bookRepository,
            ClientDetailsViewModelMaker clientDetailsViewModelMaker)
        {
            _clientRepository = clientRepository;
            _bookRepository = bookRepository;
            _clientDetailsViewModelMaker = clientDetailsViewModelMaker;
        }

        [HttpGet]
        public IActionResult ClientDetails(Guid? id)
        {
            _bookRepository.CheckBooksForExpiration();
            if (id == null) return RedirectToAction(IndexAction, DefaultController);
            var client = _clientDetailsViewModelMaker.MakeClientDetailsViewModel(id.Value);
            if (client != null)
            {
                return View(client);
            }

            return View("ClientNotFound");
        }

        [HttpPost]
        public IActionResult ReplenishBalance(ClientDetailsViewModel clientDetailsViewModel)
        {
            var client = _clientRepository.GetClient(clientDetailsViewModel.ClientId);
            if (client != null)
            {
                client.ReplenishBalance(clientDetailsViewModel.ClientBalance);
                _clientRepository.UpdateClient(client);
                return RedirectToAction("ClientDetails", new {id = client.ClientId});
            }
            return View("ClientNotFound");
        }

        [HttpPost]
        public IActionResult ChangeName(ClientDetailsViewModel clientDetailsViewModel)
        {
            var client = _clientRepository.GetClient(clientDetailsViewModel.ClientId);
            if (client != null)
            {
                client.ChangeName(clientDetailsViewModel.ClientName);
                _clientRepository.UpdateClient(client);
                return RedirectToAction("ClientDetails", new { id = client.ClientId });
            }
            return View("ClientNotFound");
        }
    }
}