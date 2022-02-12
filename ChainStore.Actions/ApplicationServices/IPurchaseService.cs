using System;

namespace ChainStore.Actions.ApplicationServices;

public interface IPurchaseService
{
    void HandleOperation(Guid customerId, Guid productId, bool useCashBack, bool usePoints);
}