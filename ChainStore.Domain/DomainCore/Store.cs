using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public sealed class Store
{
    private readonly List<Category> _categories;

    public Store(Guid id, string name, string location, double profit, Guid? mallId)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(name, 2, 40);
        CustomValidator.ValidateString(location, 2, 40);
        CustomValidator.ValidateNumber(profit, 0, double.MaxValue);
        CustomValidator.ValidateId(mallId);
        Id = id;
        Name = name;
        Location = location;
        Profit = profit;
        MallId = mallId;
        _categories = new List<Category>();
    }

    public Store(List<Category> categories, Guid id, string name, string location, Guid? mallId, double profit) : this(
        id, name, location, profit, mallId)
    {
        CustomValidator.ValidateObject(categories);
        _categories = categories;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Location { get; }
    public Guid? MallId { get; }
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

    public double Profit { get; private set; }

    public void GetProfit(double sum)
    {
        CustomValidator.ValidateNumber(sum, 0, 100_000_000);
        Profit += sum;
    }
}