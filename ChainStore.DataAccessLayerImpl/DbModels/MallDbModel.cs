using System;
using System.Collections.Generic;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class MallDbModel
{
    private readonly List<StoreDbModel> _storeDbModels;


    public MallDbModel(Guid id, string name, string location)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(name, 2, 40);
        CustomValidator.ValidateString(location, 2, 40);
        Id = id;
        Name = name;
        Location = location;
        _storeDbModels = new List<StoreDbModel>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Location { get; private set; }
    public IReadOnlyCollection<StoreDbModel> StoreDbModels => _storeDbModels.AsReadOnly();
}