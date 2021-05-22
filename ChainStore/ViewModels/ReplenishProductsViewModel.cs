using ChainStore.Domain.DomainCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChainStore.ViewModels
{
    public class ReplenishProductsViewModel
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int QuantityOfProductsToReplenish { get; set; }

        public ReplenishProductsViewModel()
        {
        }
    }
}