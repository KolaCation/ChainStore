using System;

namespace ChainStore.Domain.ApplicationServices
{
    public interface IPurchaseOperation
    {
        void Perform(Guid clientId, Guid productId, bool useCashBack, bool usePoints);
    }
}
