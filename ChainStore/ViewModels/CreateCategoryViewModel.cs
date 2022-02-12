using System.ComponentModel.DataAnnotations;

namespace ChainStore.ViewModels;

public class CreateCategoryViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Category Name")]
    public string CategoryName { get; set; }
}