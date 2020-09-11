using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.Domain.DomainCore;
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
        private const string ClientNotFoundPage = "ClientNotFound";
        private const string ClientDetailsPage = "ClientDetails";

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

            return View(ClientNotFoundPage, id.Value);
        }

        [HttpPost]
        public IActionResult ReplenishBalance(ClientDetailsViewModel clientDetailsViewModel)
        {
            var client = _clientRepository.GetOne(clientDetailsViewModel.ClientId);
            if (client != null)
            {
                client.ReplenishBalance(clientDetailsViewModel.ClientBalance);
                _clientRepository.UpdateOne(client);
                return RedirectToAction(ClientDetailsPage, new {id = client.ClientId});
            }
            return View(ClientNotFoundPage, clientDetailsViewModel.ClientId);
        }

        [HttpPost]
        public IActionResult ChangeName(ClientDetailsViewModel clientDetailsViewModel)
        {
            var client = _clientRepository.GetOne(clientDetailsViewModel.ClientId);
            if (client != null)
            {
                client.UpdateName(clientDetailsViewModel.ClientName);
                _clientRepository.UpdateOne(client);
                return RedirectToAction(ClientDetailsPage, new { id = client.ClientId });
            }
            return View(ClientNotFoundPage, clientDetailsViewModel.ClientId);
        }
    }
}