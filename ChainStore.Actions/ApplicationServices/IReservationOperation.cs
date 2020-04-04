using System;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IReservationOperation
    {
        void Perform(Guid clientId, Guid productId, int reserveDaysCount);
    }
}
