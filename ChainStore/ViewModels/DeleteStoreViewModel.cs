using ChainStore.Domain.DomainCore;
using System;

namespace ChainStore.ViewModels
{
    public class DeleteStoreViewModel
    {
        public Store Store { get; set; }
        public Guid StoreId { get; set; }

        public DeleteStoreViewModel()
        {
        }
    }
}
