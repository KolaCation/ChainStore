using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels
{
    public class DeleteCategoryViewModel
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public DeleteCategoryViewModel()
        {
        }
    }
}