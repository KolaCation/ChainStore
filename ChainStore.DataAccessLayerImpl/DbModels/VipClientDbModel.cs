using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal class VipClientDbModel : ReliableClientDbModel
    {
        public int DiscountPercent { get; private set; }
        public double Points { get; private set; }

        public VipClientDbModel(Guid clientDbModelId, string name, double balance, double cashBack, int cashBackPercent, double points)
            : base(clientDbModelId, name, balance, cashBack, cashBackPercent)
        {
            if(points < 0) throw new ArgumentException();
            DiscountPercent = 5;
            Points = points;
        }
    }
}