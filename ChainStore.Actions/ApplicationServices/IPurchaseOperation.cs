using System;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IPurchaseOperation
    {
        void Perform(Guid clientId, Guid productId, bool useCashBack, bool usePoints);
    }
}
