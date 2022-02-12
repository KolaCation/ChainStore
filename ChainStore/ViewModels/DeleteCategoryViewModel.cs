using System;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class DeleteCategoryViewModel
{
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
}