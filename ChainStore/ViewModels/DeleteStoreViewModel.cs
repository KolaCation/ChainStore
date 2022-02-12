using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class DeleteStoreViewModel
{
    public Store Store { get; set; }
    public Guid StoreId { get; set; }
}