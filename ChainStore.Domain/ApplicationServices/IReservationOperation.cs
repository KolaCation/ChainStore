using System;

namespace ChainStore.Domain.ApplicationServices
{
    public interface IReservationOperation
    {
        void Perform(Guid clientId, Guid productId, int reserveDaysCount);
    }
}
