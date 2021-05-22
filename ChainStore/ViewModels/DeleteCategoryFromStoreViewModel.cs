using ChainStore.Domain.DomainCore;
using System;

namespace ChainStore.ViewModels
{
    public class DeleteCategoryFromStoreViewModel
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Guid StoreId { get; set; }


        public DeleteCategoryFromStoreViewModel()
        {
        }
    }
}
