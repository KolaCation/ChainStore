﻿using System;

namespace ChainStore.Domain.DomainCore;

public class VipCustomer : ReliableCustomer
{
    public VipCustomer(Guid id, string name, double balance, double cashBack, int cashBackPercent, double points)
        : base(id, name, balance, cashBack, cashBackPercent)
    {
        DiscountPercent = 5;
        Points = points;
    }

    public int DiscountPercent { get; }
    public double Points { get; private set; }

    public override bool Charge(double sum, bool useCashBack, bool usePoints)
    {
        if (sum < 0) return false;
        if (usePoints)
        {
            sum /= 1000;
            if (Points < sum) return false;
            if (Points >= sum)
            {
                Points -= sum;
                return true;
            }
        }
        else if (useCashBack)
        {
            var priceWithDiscount = sum - sum * DiscountPercent / 100;
            var res = base.Charge(priceWithDiscount, true, false);
            Points += sum / 1000;
            if (!res) return false;

            return true;
        }
        else
        {
            var priceWithDiscount = sum - sum * DiscountPercent / 100;
            var res = base.Charge(priceWithDiscount, false, false);
            Points += sum / 1000;
            if (!res) return false;
            return true;
        }

        return false;
    }
}