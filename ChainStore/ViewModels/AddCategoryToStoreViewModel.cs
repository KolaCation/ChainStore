using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels
{
    public class AddCategoryToStoreViewModel
    {
        public Store Store { get; set; }
        public Guid StoreId { get; set; }
        public string CategoryName { get; set; }//replace with DB list

        public AddCategoryToStoreViewModel()
        {
        }
    }
}