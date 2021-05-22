using ChainStore.Domain.DomainCore;
using System;
using System.Collections.Generic;

namespace ChainStore.ViewModels
{
    public class MallStoresViewModel
    {
        public Guid MallId { get; set; }
        public IEnumerable<Store> StoresToAdd { get; set; }

        public MallStoresViewModel()
        {
        }
    }
}
