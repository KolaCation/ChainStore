using System;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IReservationService
    {
        void HandleOperation(Guid clientId, Guid productId, int reserveDaysCount);
    }
}
