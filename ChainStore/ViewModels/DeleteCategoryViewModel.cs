using ChainStore.Domain.DomainCore;
using System;

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