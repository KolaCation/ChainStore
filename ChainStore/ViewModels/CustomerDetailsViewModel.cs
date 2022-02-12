using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChainStore.ViewModels.ViewMakers.DetailedInfo;

namespace ChainStore.ViewModels;

public sealed class CustomerDetailsViewModel
{
    public CustomerDetailsViewModel(IEnumerable<PurchaseDetailedInfo> purchaseDetailedInfoList,
        IEnumerable<BookDetailedInfo> bookDetailedInfoList, Guid customerId, string customerName,
        double balance, double cashBack, int cashBackPercent, int discountPercent, double points)
    {
        CustomerPurchaseDetailedInfoList = purchaseDetailedInfoList ??
                                           throw new ArgumentNullException(nameof(purchaseDetailedInfoList));
        CustomerBookDetailedInfoList =
            bookDetailedInfoList ?? throw new ArgumentNullException(nameof(bookDetailedInfoList));
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerBalance = balance;
        CashBack = cashBack;
        CashBackPercent = cashBackPercent;
        DiscountPercent = discountPercent;
        Points = points;
    }

    public CustomerDetailsViewModel()
    {
    }

    public Guid CustomerId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must at least 3 letters and not exceed 20 letters")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
    public string CustomerName { get; set; }

    [Required(ErrorMessage = "Sum is required")]
    public double CustomerBalance { get; set; }

    public double CashBack { get; set; }
    public int CashBackPercent { get; set; }
    public int DiscountPercent { get; set; }
    public double Points { get; set; }

    public IEnumerable<PurchaseDetailedInfo> CustomerPurchaseDetailedInfoList { get; }
    public IEnumerable<BookDetailedInfo> CustomerBookDetailedInfoList { get; }
}