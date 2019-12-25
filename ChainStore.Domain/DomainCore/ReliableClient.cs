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

        public override bool Pay(double sum, bool useCashBack, bool usePoints)
        {
            if (sum < 0) return false;
            if (useCashBack)
            {
                if (Math.Abs(CashBack) < 1)
                {
                    var res = base.Pay(sum, true, false);
                    if (!res) return false;
                    CashBack += sum * CashBackPercent / 100;
                    return true;
                }

                if (CashBack > 0 && CashBack < sum)
                {
                    sum -= CashBack;
                    CashBack = 0;
                    var res = base.Pay(sum, true, false);
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
                
                var res = base.Pay(sum, false, false);
                if (!res) return false;
                CashBack += sum * CashBackPercent / 100;
                return true;
            }

            return false;
        }


        public override void ReplenishBalance(double sum)
        {
            if(sum < 0) return;
            CashBack += sum * CashBackPercent / 100;
            base.ReplenishBalance(sum);
        }
    }
}