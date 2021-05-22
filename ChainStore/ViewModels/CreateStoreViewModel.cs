using System;
using System.ComponentModel.DataAnnotations;

namespace ChainStore.ViewModels
{
    public class CreateStoreViewModel
    {
        public Guid MallId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must at least 3 letters and not exceed 20 letters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Location must at least 3 letters and not exceed 30 letters")]
        [RegularExpression(@"^\d+\s[A-z]+\s[A-z]+", ErrorMessage = "Location not valid")]
        public string Location { get; set; }

        public CreateStoreViewModel()
        {
        }

    }
}