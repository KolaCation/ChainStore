using System;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal class ReliableCustomerDbModel : CustomerDbModel
{
    public ReliableCustomerDbModel(Guid id, string name, double balance, double cashBack, int cashBackPercent) : base(
        id, name, balance)
    {
        CustomValidator.ValidateNumber(cashBackPercent, 0, 10);
        CustomValidator.ValidateNumber(cashBack, 0, 100_000_000);
        CashBack = cashBack;
        CashBackPercent = cashBackPercent;
    }

    public int CashBackPercent { get; protected set; }
    public double CashBack { get; protected set; }
}