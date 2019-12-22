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

        public override void Pay(double sum, bool useCashBack, bool usePoints)
        {
            if (sum < 0) return;
            if (usePoints)
            {
                sum /= 1000;
                if (Points < sum) return;
                if (Points >= sum) Points -= sum;
            }
            else if (useCashBack)
            {
                Points += sum / 1000;
                sum -= sum * DiscountPercent / 100;
                base.Pay(sum, true, false);
            }
            else
            {
                Points += sum / 1000;
                sum -= sum * DiscountPercent / 100;
                base.Pay(sum, false, false);
            }
        }
    }
}