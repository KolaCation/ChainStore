using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class VipCustomerDbModel : ReliableCustomerDbModel
{
    public VipCustomerDbModel(Guid id, string name, double balance, double cashBack, int cashBackPercent, double points)
        : base(id, name, balance, cashBack, cashBackPercent)
    {
        CustomValidator.ValidateNumber(points, 0, 100_000_000);
        DiscountPercent = 5;
        Points = points;
    }

    public int DiscountPercent { get; private set; }
    public double Points { get; private set; }
}