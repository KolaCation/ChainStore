using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels
{
    public class DeleteProductViewModel
    {
        public Product Product { get; set; }
        public Guid ProductId{ get; set; }
        public Category Category{ get; set; }
        public Guid CategoryId{ get; set; }
        public DeleteProductViewModel()
        {
        }
    }
}
