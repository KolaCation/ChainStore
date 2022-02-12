using System;

namespace ChainStore.Actions.ApplicationServices;

public interface IReservationService
{
    void HandleOperation(Guid customerId, Guid productId, int reserveDaysCount);
}