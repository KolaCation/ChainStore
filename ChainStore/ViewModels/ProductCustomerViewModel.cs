using System;
using System.ComponentModel.DataAnnotations;
using ChainStore.Domain.DomainCore;

namespace ChainStore.ViewModels;

public class ProductCustomerViewModel
{
    public Guid CustomerId { get; set; }
    public double Balance { get; set; }
    public double CashBack { get; set; }
    public int CashBackPercent { get; set; }
    public int DiscountPercent { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public bool UseCashBack { get; set; }
    public bool UsePoints { get; set; }
    public double Points { get; set; }

    [Required(ErrorMessage = "Count is required")]
    public int BookDaysCount { get; set; }
}