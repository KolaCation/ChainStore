using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.Domain.DomainCore
{
    public class VipClient : ReliableClient
    {
        public int DiscountPercent { get; private set; }
        public double Points { get; private set; }

        public VipClient(Guid clientId, string name, double balance, double cashBack, int cashBackPercent) : base(
            clientId, name,
            balance, cashBack, cashBackPercent)
        {
            DiscountPercent = 5;
            Points = 0;
        }

        public override bool Pay(double sum, bool useCashBack, bool usePoints)
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
                var res = base.Pay(priceWithDiscount, true, false);
                Points += sum / 1000;
                if (!res) return false;
                
                return true;
            }
            else
            {
                
                var priceWithDiscount = sum - sum * DiscountPercent / 100;
                var res = base.Pay(priceWithDiscount, false, false);
                Points += sum / 1000;
                if (!res) return false;
                return true;
            }

            return false;
        }
    }
}