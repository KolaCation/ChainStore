using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal class ReliableClientDbModel : ClientDbModel
    {
        public int CashBackPercent { get; protected set; }
        public double CashBack { get; protected set; }

        public ReliableClientDbModel(Guid clientDbModelId, string name, double balance, double cashBack, int cashBackPercent) : base(clientDbModelId, name, balance)
        {
            CustomValidator.ValidateNumber(cashBackPercent, 0, 10);
            if (cashBack < 0) throw new ArgumentException();
            CashBack = cashBack;
            CashBackPercent = cashBackPercent;
        }
    }
}
