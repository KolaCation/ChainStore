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
                sum -= sum * DiscountPercent / 100;
                var res = base.Pay(sum, true, false);
                if (!res) return false;
                Points += sum / 1000;
                return true;
            }
            else
            {
                sum -= sum * DiscountPercent / 100;
                var res = base.Pay(sum, false, false);
                if (!res) return false;
                Points += sum / 1000;
                return true;
            }

            return false;
        }
    }
}