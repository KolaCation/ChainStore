using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class DeleteCategoryFromStoreViewModel
{
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public Guid StoreId { get; set; }
}