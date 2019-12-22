using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChainStore.ViewModels.ViewMakers.DetailedInfo;

namespace ChainStore.ViewModels
{
    public sealed class ClientDetailsViewModel
    {
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must at least 3 letters and not exceed 20 letters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Sum is required")]
        public double ClientBalance { get; set; }

        public double CashBack { get; set; }
        public int CashBackPercent { get; set; }
        public int DiscountPercent { get; set; }
        public double Points { get; set; }

        public IEnumerable<PurchaseDetailedInfo> ClientPurchaseDetailedInfoList { get; private set; }
        public IEnumerable<BookDetailedInfo> ClientBookDetailedInfoList { get; private set; }

        public ClientDetailsViewModel(IEnumerable<PurchaseDetailedInfo> purchaseDetailedInfoList,
            IEnumerable<BookDetailedInfo> bookDetailedInfoList, Guid clientId, string clientName,
            double balance, double cashBack, int cashBackPercent, int discountPercent, double points)
        {
            ClientPurchaseDetailedInfoList = purchaseDetailedInfoList ??
                                             throw new ArgumentNullException(nameof(purchaseDetailedInfoList));
            ClientBookDetailedInfoList =
                bookDetailedInfoList ?? throw new ArgumentNullException(nameof(bookDetailedInfoList));
            ClientId = clientId;
            ClientName = clientName;
            ClientBalance = balance;
            CashBack = cashBack;
            CashBackPercent = cashBackPercent;
            DiscountPercent = discountPercent;
            Points = points;
        }

        public ClientDetailsViewModel()
        {
        }
    }
}