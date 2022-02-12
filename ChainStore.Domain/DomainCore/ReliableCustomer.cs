using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public class ReliableCustomer : Customer
{
    public ReliableCustomer(Guid id, string name, double balance, double cashBack, int cashBackPercent)
        : base(id, name, balance)
    {
        CustomValidator.ValidateNumber(cashBackPercent, 0, 10);
        CustomValidator.ValidateNumber(cashBack, 0, 100_000_000);
        CashBack = cashBack;
        CashBackPercent = cashBackPercent;
    }

    public int CashBackPercent { get; }
    public double CashBack { get; protected set; }

    public override bool Charge(double sum, bool useCashBack, bool usePoints)
    {
        if (sum < 0) return false;
        if (useCashBack)
        {
            if (Math.Abs(CashBack) < 1)
            {
                var res = base.Charge(sum, true, false);
                if (!res) return false;
                CashBack += sum * CashBackPercent / 100;
                return true;
            }

            if (CashBack > 0 && CashBack < sum)
            {
                sum -= CashBack;
                CashBack = 0;
                var res = base.Charge(sum, true, false);
                return res;
            }

            if (CashBack > 0 && CashBack >= sum)
            {
                CashBack -= sum;
                return true;
            }
        }
        else
        {
            var res = base.Charge(sum, false, false);
            if (!res) return false;
            CashBack += sum * CashBackPercent / 100;
            return true;
        }

        return false;
    }


    public override void ReplenishBalance(double sum)
    {
        if (sum < 0) return;
        CashBack += sum * CashBackPercent / 100;
        base.ReplenishBalance(sum);
    }
}