using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer.Repositories;
using ChainStore.DataAccessLayerImpl;
using ChainStore.Domain.DomainCore;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IClientService _clientService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private const string IndexAction = "Index";
        private const string DefaultController = "Stores";

        public AccountController(IClientRepository clientRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IClientService clientService, RoleManager<IdentityRole> roleManager)
        {
            _clientRepository = clientRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _clientService = clientService;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterClientViewModel registerClientViewModel)
        {
            if (ModelState.IsValid)
            {
                var clientDetails = new Client(Guid.NewGuid(), registerClientViewModel.Name, 0);
                var client = new ApplicationUser
                {
                    Id = clientDetails.Id.ToString(),
                    UserName = registerClientViewModel.Email,
                    Email = registerClientViewModel.Email,
                    ClientDbModelId = clientDetails.Id,
                    CreationTime = DateTimeOffset.Now
                };
                _clientRepository.AddOne(clientDetails);
                var result = await _userManager.CreateAsync(client, registerClientViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(client, isPersistent: false);
                    return RedirectToAction(IndexAction, DefaultController);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(registerClientViewModel);
                }
            }

            return View(registerClientViewModel);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json($"Email {email} is already in use");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginClientViewModel loginClientViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginClientViewModel.Email,
                    loginClientViewModel.Password, loginClientViewModel.RememberMe,
                    false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(loginClientViewModel.Email);
                    if (user != null)
                    {
                        var checkForReliability = DateTimeOffset.Now - user.CreationTime;
                        _clientService.TryUpdateClientStatus(user.ClientDbModelId, checkForReliability.Days);
                    }

                    return RedirectToAction(IndexAction, DefaultController);
                }

                ModelState.AddModelError(string.Empty, "Invalid Credentials");
            }

            return View(loginClientViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(IndexAction, DefaultController);
        }
    }
}