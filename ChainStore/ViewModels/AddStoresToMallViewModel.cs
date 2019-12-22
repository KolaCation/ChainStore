using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainStore.Domain.DomainCore;

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
