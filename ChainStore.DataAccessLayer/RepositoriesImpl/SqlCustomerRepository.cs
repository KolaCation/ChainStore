using System;
using System.Collections.Generic;
using System.Linq;
using ChainStore.DataAccessLayer.DbModels;
using ChainStore.DataAccessLayer.Helpers;
using ChainStore.DataAccessLayer.Mappers;
using ChainStore.Domain.DomainCore;
using ChainStore.Domain.Repositories;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChainStore.DataAccessLayer.RepositoriesImpl;

public class SqlCustomerRepository : ICustomerRepository
{
    private readonly IConfiguration _config;
    private readonly MyDbContext _context;
    private readonly CustomerMapper _customerMapper;

    public SqlCustomerRepository(MyDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
        _customerMapper = new CustomerMapper(new PropertyGetter(_config.GetConnectionString("ChainStoreDBVer2")));
    }

    public void AddOne(Customer item)
    {
        CustomValidator.ValidateObject(item);
        var exists = Exists(item.Id);
        if (!exists)
        {
            var enState = _context.Customers.Add(_customerMapper.DomainToDb(item));
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }
    }

    public Customer GetOne(Guid id)
    {
        CustomValidator.ValidateId(id);
        var exists = Exists(id);
        if (exists)
            return _customerMapper.DbToDomain(_context.Customers.Find(id));
        return null;
    }

    public IReadOnlyCollection<Customer> GetAll()
    {
        var customerDbModelList = _context.Customers.ToList();
        var customerList =
            (from customerDbModel in customerDbModelList select _customerMapper.DbToDomain(customerDbModel)).ToList();
        return customerList.AsReadOnly();
    }

    public void UpdateOne(Customer item)
    {
        CustomValidator.ValidateObject(item);
        var exists = Exists(item.Id);
        if (exists)
        {
            DetachService.Detach<CustomerDbModel>(_context, item.Id);
            var enState = _context.Customers.Update(_customerMapper.DomainToDb(item));
            enState.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }

    public void DeleteOne(Guid id)
    {
        CustomValidator.ValidateId(id);
        var exists = Exists(id);
        if (exists)
        {
            var customerDbModel = _context.Customers.Find(id);
            var enState = _context.Customers.Remove(customerDbModel);
            enState.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }

    public bool Exists(Guid id)
    {
        CustomValidator.ValidateId(id);
        return _context.Customers.Any(item => item.Id.Equals(id));
    }

    public void AddReliableCustomer(ReliableCustomer customer)
    {
        CustomValidator.ValidateObject(customer);
        var exists = Exists(customer.Id);
        if (!exists)
        {
            var enState = _context.ReliableCustomers.Add(new ReliableCustomerDbModel(customer.Id, customer.Name,
                customer.Balance, customer.CashBack, customer.CashBackPercent));
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }
    }

    public void AddVipCustomer(VipCustomer customer)
    {
        CustomValidator.ValidateObject(customer);
        var exists = Exists(customer.Id);
        if (!exists)
        {
            var enState = _context.VipCustomers.Add(new VipCustomerDbModel(customer.Id, customer.Name, customer.Balance,
                customer.CashBack, customer.CashBackPercent, customer.Points));
            enState.State = EntityState.Added;
            _context.SaveChanges();
        }
    }
}