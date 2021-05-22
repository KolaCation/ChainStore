using ChainStore.Domain.DomainCore;
using System;
using System.Collections.Generic;

namespace ChainStore.ViewModels
{
    public class AddCategoryToStoreViewModel
    {
        public Store Store { get; set; }
        public Guid StoreId { get; set; }
        public Guid CategoryId { get; set; }
        public List<Category> CategoriesOption { get; set; }

        public AddCategoryToStoreViewModel()
        {
        }
    }
}