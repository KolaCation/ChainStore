using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ChainStore.ViewModels;

public class RegisterCustomerViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must at least 3 letters and not exceed 20 letters")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [Remote("IsEmailInUse", "Account")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
}