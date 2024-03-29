﻿using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.Domain.DomainCore;

public sealed class Mall
{
    private readonly List<Store> _stores;


    public Mall(Guid id, string name, string location)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(name, 2, 40);
        CustomValidator.ValidateString(location, 2, 40);
        Id = id;
        Name = name;
        Location = location;
        _stores = new List<Store>();
    }

    public Mall(List<Store> stores, Guid id, string name, string location) : this(id, name, location)
    {
        CustomValidator.ValidateObject(stores);
        _stores = stores;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Location { get; }
    public IReadOnlyCollection<Store> Stores => _stores.AsReadOnly();
}