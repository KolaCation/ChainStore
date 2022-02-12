using System;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public class Customer
{
    public Customer(Guid id, string name, double balance)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(name, 2, 40);
        CustomValidator.ValidateNumber(balance, 0, 100_000_000);
        Id = id;
        Name = name;
        Balance = balance;
    }

    public Guid Id { get; }
    public string Name { get; protected set; }
    public double Balance { get; protected set; }

    public void UpdateName(string newName)
    {
        CustomValidator.ValidateString(newName, 2, 40);
        Name = newName;
    }

    public virtual void ReplenishBalance(double sum)
    {
        CustomValidator.ValidateNumber(sum, 0, 100_000_000);
        Balance += sum;
    }

    public virtual bool Charge(double sum, bool useCashBack, bool usePoints)
    {
        CustomValidator.ValidateNumber(sum, 0, 100_000_000);
        if (Balance < sum) return false;
        Balance -= sum;
        return true;
    }
}