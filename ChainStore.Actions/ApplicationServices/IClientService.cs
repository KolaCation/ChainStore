using System;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IClientService
    {
        bool TryUpdateClientStatus(Guid clientId, int daysInApplication);
    }
}