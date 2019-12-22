using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Domain.Util;

namespace ChainStore.Domain.DomainCore
{
    public class ReliableClient : Client
    {
        public double CashBack { get; private set; }
        public int CashBackPercent { get; private set; }

        public ReliableClient(Guid clientId, string name, double balance, double cashBack, int cashBackPercent) : base(
            clientId, name, balance)
        {
            if (cashBackPercent < 0 || cashBackPercent > 10) throw new ArgumentException();
            if(cashBack < 0) throw new ArgumentException();
            CashBack = cashBack;
            CashBackPercent = cashBackPercent;
        }

        public override void Pay(double sum, bool useCashBack, bool usePoints)
        {
            if (sum < 0) return;
            if (useCashBack)
            {
                if (Math.Abs(CashBack) < 1)
                {
                    base.Pay(sum, true, false);
                    CashBack += sum * CashBackPercent / 100;
                }

                if (CashBack > 0 && CashBack < sum)
                {
                    sum -= CashBack;
                    CashBack = 0;
                    base.Pay(sum, true, false);
                }

                if (CashBack > 0 && CashBack >= sum)
                {
                    CashBack -= sum;
                }
            }
            else
            {
                CashBack += sum * CashBackPercent / 100;
                base.Pay(sum, false, false);
            }
        }


        public override void ReplenishBalance(double sum)
        {
            if(sum < 0) return;
            CashBack += sum * CashBackPercent / 100;
            base.ReplenishBalance(sum);
        }
    }
}