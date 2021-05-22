using ChainStore.Shared.Util;
using System;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal class ReliableClientDbModel : ClientDbModel
    {
        public int CashBackPercent { get; protected set; }
        public double CashBack { get; protected set; }

        public ReliableClientDbModel(Guid id, string name, double balance, double cashBack, int cashBackPercent) : base(id, name, balance)
        {
            CustomValidator.ValidateNumber(cashBackPercent, 0, 10);
            CustomValidator.ValidateNumber(cashBack, 0, 100_000_000);
            CashBack = cashBack;
            CashBackPercent = cashBackPercent;
        }
    }
}
