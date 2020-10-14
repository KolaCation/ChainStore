using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get;  set; }
        public Guid CategoryId { get;  set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int QuantityOfProductsToAdd { get; set; }

        public Guid StoreId { get; set; }

        public CreateProductViewModel()
        {
        }
    }
}
