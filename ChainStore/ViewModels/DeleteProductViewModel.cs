using ChainStore.Domain.DomainCore;
using System;

namespace ChainStore.ViewModels
{
    public class DeleteProductViewModel
    {
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public DeleteProductViewModel()
        {
        }
    }
}