using System.ComponentModel.DataAnnotations;

namespace ChainStore.ViewModels
{
    public class LoginClientViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public LoginClientViewModel()
        {
        }
    }
}
