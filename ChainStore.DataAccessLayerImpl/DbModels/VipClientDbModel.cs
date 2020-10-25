using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class VipClientDbModel : ReliableClientDbModel
    {
        public int DiscountPercent { get; private set; }
        public double Points { get; private set; }

        public VipClientDbModel(Guid id, string name, double balance, double cashBack, int cashBackPercent, double points)
            : base(id, name, balance, cashBack, cashBackPercent)
        {
            CustomValidator.ValidateNumber(points, 0, 100_000_000);
            DiscountPercent = 5;
            Points = points;
        }
    }
}