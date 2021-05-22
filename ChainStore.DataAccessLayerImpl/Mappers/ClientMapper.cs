using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.DataAccessLayerImpl.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class ClientMapper : IMapper<Client, ClientDbModel>
    {
        private readonly PropertyGetter _propertyGetter;

        public ClientMapper(PropertyGetter propertyGetter)
        {
            _propertyGetter = propertyGetter;
        }

        public ClientDbModel DomainToDb(Client item)
        {
            CustomValidator.ValidateObject(item);
            var entityName = nameof(Client);
            var idColumnName = nameof(ClientDbModel.Id);

            var cashBackPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClient.CashBackPercent), idColumnName, item.Id);
            if (cashBackPercent == 0) return new ClientDbModel(item.Id, item.Name, item.Balance);

            var discountPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClient.DiscountPercent), idColumnName, item.Id);


            if (cashBackPercent != 0 && discountPercent == 0)
            {
                var reliable = (ReliableClient)item;
                return new ReliableClientDbModel(reliable.Id, reliable.Name, reliable.Balance, reliable.CashBack, cashBackPercent);
            }
            else
            {
                var vip = (VipClient)item;
                return new VipClientDbModel(vip.Id, vip.Name, vip.Balance, vip.CashBack, cashBackPercent, vip.Points);
            }
        }

        public Client DbToDomain(ClientDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var entityName = nameof(Client);
            var idColumnName = nameof(ClientDbModel.Id);

            var cashBackPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClient.CashBackPercent), idColumnName, item.Id);
            if (cashBackPercent == 0) return new Client(item.Id, item.Name, item.Balance);

            var discountPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClient.DiscountPercent), idColumnName, item.Id);

            if (cashBackPercent != 0 && discountPercent == 0)
            {
                var reliable = (ReliableClientDbModel)item;
                return new ReliableClient(reliable.Id, reliable.Name, reliable.Balance, reliable.CashBack, cashBackPercent);
            }
            else
            {
                var vip = (VipClientDbModel)item;
                return new VipClient(vip.Id, vip.Name, vip.Balance, vip.CashBack, cashBackPercent, vip.Points);
            }
        }
    }
}