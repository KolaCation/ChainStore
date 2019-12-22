using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels
{
    public class CreateCategoryViewModel
    {
        public Store Store { get; set; }
        public Guid StoreId { get; set; }
        public CategoryNames CategoryName { get; set; }

        public CreateCategoryViewModel()
        {
        }
    }
}