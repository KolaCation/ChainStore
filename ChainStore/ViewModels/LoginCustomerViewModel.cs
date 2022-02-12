using System.ComponentModel.DataAnnotations;

namespace ChainStore.ViewModels;

public class LoginCustomerViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")] public bool RememberMe { get; set; }
}