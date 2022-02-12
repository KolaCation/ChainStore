using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class MallStoresViewModel
{
    public Guid MallId { get; set; }
    public IEnumerable<Store> StoresToAdd { get; set; }
}