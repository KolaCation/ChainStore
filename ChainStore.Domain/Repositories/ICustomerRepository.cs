using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    void AddReliableCustomer(ReliableCustomer customer);
    void AddVipCustomer(VipCustomer customer);
}