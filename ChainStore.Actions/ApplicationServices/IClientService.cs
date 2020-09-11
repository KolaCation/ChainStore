using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IClientService
    {
        bool TryUpdateClientStatus(Guid clientId, int daysInApplication);
    }
}