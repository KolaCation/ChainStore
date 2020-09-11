using System;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IPurchaseService
    {
        void HandleOperation(Guid clientId, Guid productId, bool useCashBack, bool usePoints);
    }
}
