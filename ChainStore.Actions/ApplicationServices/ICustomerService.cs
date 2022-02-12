using System;

namespace ChainStore.Actions.ApplicationServices;

public interface ICustomerService
{
    bool TryUpdateCustomerStatus(Guid customerId, int daysInApplication);
}