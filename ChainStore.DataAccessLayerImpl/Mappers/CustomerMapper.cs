using ChainStore.DataAccessLayer.DbModels;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.Mappers;

internal sealed class CustomerMapper : IMapper<Customer, CustomerDbModel>
{
    private readonly PropertyGetter _propertyGetter;

    public CustomerMapper(PropertyGetter propertyGetter)
    {
        _propertyGetter = propertyGetter;
    }

    public CustomerDbModel DomainToDb(Customer item)
    {
        CustomValidator.ValidateObject(item);
        var entityName = nameof(Customer);
        var idColumnName = nameof(CustomerDbModel.Id);

        var cashBackPercent =
            _propertyGetter.GetProperty<int>(entityName, nameof(VipCustomer.CashBackPercent), idColumnName, item.Id);
        if (cashBackPercent == 0) return new CustomerDbModel(item.Id, item.Name, item.Balance);

        var discountPercent =
            _propertyGetter.GetProperty<int>(entityName, nameof(VipCustomer.DiscountPercent), idColumnName, item.Id);


        if (cashBackPercent != 0 && discountPercent == 0)
        {
            var reliable = (ReliableCustomer) item;
            return new ReliableCustomerDbModel(reliable.Id, reliable.Name, reliable.Balance, reliable.CashBack,
                cashBackPercent);
        }

        var vip = (VipCustomer) item;
        return new VipCustomerDbModel(vip.Id, vip.Name, vip.Balance, vip.CashBack, cashBackPercent, vip.Points);
    }

    public Customer DbToDomain(CustomerDbModel item)
    {
        CustomValidator.ValidateObject(item);
        var entityName = nameof(Customer);
        var idColumnName = nameof(CustomerDbModel.Id);

        var cashBackPercent =
            _propertyGetter.GetProperty<int>(entityName, nameof(VipCustomer.CashBackPercent), idColumnName, item.Id);
        if (cashBackPercent == 0) return new Customer(item.Id, item.Name, item.Balance);

        var discountPercent =
            _propertyGetter.GetProperty<int>(entityName, nameof(VipCustomer.DiscountPercent), idColumnName, item.Id);

        if (cashBackPercent != 0 && discountPercent == 0)
        {
            var reliable = (ReliableCustomerDbModel) item;
            return new ReliableCustomer(reliable.Id, reliable.Name, reliable.Balance, reliable.CashBack,
                cashBackPercent);
        }

        var vip = (VipCustomerDbModel) item;
        return new VipCustomer(vip.Id, vip.Name, vip.Balance, vip.CashBack, cashBackPercent, vip.Points);
    }
}