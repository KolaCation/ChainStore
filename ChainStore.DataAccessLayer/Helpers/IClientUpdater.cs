using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Helpers
{
    public interface IClientUpdater
    {
        void UpdateClientStatus(Client client, ClientStatus clientStatus);
    }
}
