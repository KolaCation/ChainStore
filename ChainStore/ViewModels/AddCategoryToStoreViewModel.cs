using System;
using System.Collections.Generic;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class AddCategoryToStoreViewModel
{
    public Store Store { get; set; }
    public Guid StoreId { get; set; }
    public Guid CategoryId { get; set; }
    public List<Category> CategoriesOption { get; set; }
}