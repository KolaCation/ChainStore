using System;
using System.Threading.Tasks;
using ChainStore.Actions.ApplicationServices;
using ChainStore.DataAccessLayer;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.Controllers;

public class AccountController : Controller
{
    private const string IndexAction = "Index";
    private const string DefaultController = "Stores";
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerService _customerService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(ICustomerRepository customerRepository,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ICustomerService customerService, RoleManager<IdentityRole> roleManager)
    {
        _customerRepository = customerRepository;
        _userManager = userManager;
        _signInManager = signInManager;
        _customerService = customerService;
        _roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCustomerViewModel registerCustomerViewModel)
    {
        if (!ModelState.IsValid) return View(registerCustomerViewModel);

        var customerDetails = new Customer(Guid.NewGuid(), registerCustomerViewModel.Name, 0);

        var customer = new ApplicationUser
        {
            Id = customerDetails.Id.ToString(),
            UserName = registerCustomerViewModel.Email,
            Email = registerCustomerViewModel.Email,
            CustomerDbModelId = customerDetails.Id,
            CreationTime = DateTimeOffset.Now
        };

        _customerRepository.AddOne(customerDetails);

        var result = await _userManager.CreateAsync(customer, registerCustomerViewModel.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(customer, false);
            return RedirectToAction(IndexAction, DefaultController);
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
            return View(registerCustomerViewModel);
        }

        return View(registerCustomerViewModel);
    }

    [AcceptVerbs("Get", "Post")]
    public async Task<IActionResult> IsEmailInUse(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user == null ? Json(true) : Json($"Email {email} is already in use");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCustomerViewModel loginCustomerViewModel)
    {
        if (!ModelState.IsValid) return View(loginCustomerViewModel);

        var result = await _signInManager.PasswordSignInAsync(loginCustomerViewModel.Email,
            loginCustomerViewModel.Password, loginCustomerViewModel.RememberMe,
            false);

        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(loginCustomerViewModel.Email);
            if (user == null) return RedirectToAction(IndexAction, DefaultController);
            var checkForReliability = DateTimeOffset.Now - user.CreationTime;
            _customerService.TryUpdateCustomerStatus(user.CustomerDbModelId, checkForReliability.Days);

            return RedirectToAction(IndexAction, DefaultController);
        }

        ModelState.AddModelError(string.Empty, "Invalid Credentials");

        return View(loginCustomerViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(IndexAction, DefaultController);
    }
}