using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.Actions.ApplicationServices
{
    public interface IClientService
    {
        void CheckForStatusUpdate(Guid clientId, int daysInApplication);
    }
}