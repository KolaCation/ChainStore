using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore.Storage;

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
            var entityName = typeof(ClientDbModel).Name;
            var idColumnName = nameof(ClientDbModel.ClientDbModelId);

            var cashBackPercent = _propertyGetter.GetProperty<int>(entityName, nameof(ReliableClientDbModel.CashBackPercent), idColumnName, item.ClientId);
            if (cashBackPercent == 0) return new ClientDbModel(item.ClientId, item.Name, item.Balance);

            var discountPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClientDbModel.DiscountPercent), idColumnName, item.ClientId);
            var cashBack = _propertyGetter.GetProperty<int>(entityName, nameof(ReliableClientDbModel.CashBack), idColumnName, item.ClientId);

            if (cashBackPercent != 0 && discountPercent == 0)
            {
                return new ReliableClientDbModel(item.ClientId, item.Name, item.Balance, cashBackPercent,
                    cashBackPercent);
            }
            else
            {
                var points = _propertyGetter.GetProperty<int>(entityName, nameof(VipClientDbModel.Points), idColumnName, item.ClientId);
                return new VipClientDbModel(item.ClientId, item.Name, item.Balance, cashBack, cashBackPercent, points);
            }
        }

        public Client DbToDomain(ClientDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var entityName = typeof(ClientDbModel).Name;
            var idColumnName = nameof(ClientDbModel.ClientDbModelId);

            var cashBackPercent = _propertyGetter.GetProperty<int>(entityName, nameof(ReliableClientDbModel.CashBackPercent), idColumnName, item.ClientDbModelId);
            if (cashBackPercent == 0) return new Client(item.ClientDbModelId, item.Name, item.Balance);

            var discountPercent = _propertyGetter.GetProperty<int>(entityName, nameof(VipClientDbModel.DiscountPercent), idColumnName, item.ClientDbModelId);
            var cashBack = _propertyGetter.GetProperty<int>(entityName, nameof(ReliableClientDbModel.CashBack), idColumnName, item.ClientDbModelId);

            if (cashBackPercent != 0 && discountPercent == 0)
            {
                return new ReliableClient(item.ClientDbModelId, item.Name, item.Balance, cashBackPercent,
                    cashBackPercent);
            }
            else
            {
                var points = _propertyGetter.GetProperty<int>(entityName, nameof(VipClientDbModel.Points), idColumnName, item.ClientDbModelId);
                return new VipClient(item.ClientDbModelId, item.Name, item.Balance, cashBack, cashBackPercent, points);
            }
        }
    }
}