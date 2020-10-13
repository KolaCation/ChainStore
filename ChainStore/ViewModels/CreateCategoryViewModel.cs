using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChainStore.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string CategoryName { get; set; }
    }
}
