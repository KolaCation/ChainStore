using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayer.DbModels;

internal sealed class StoreDbModel
{
    private readonly List<StoreCategoryDbModel> _storeCategoryRelation;

    private readonly List<StoreProductDbModel> _storeProductRelation;

    private List<CategoryDbModel> _categoryDbModels;

    public StoreDbModel(Guid id, string name, string location, Guid? mallId, double profit)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(name, 2, 40);
        CustomValidator.ValidateString(location, 2, 40);
        CustomValidator.ValidateNumber(profit, 0, double.MaxValue);
        CustomValidator.ValidateId(mallId);
        Id = id;
        Name = name;
        Location = location;
        MallId = mallId;
        Profit = profit;
        _storeCategoryRelation = new List<StoreCategoryDbModel>();
        _storeProductRelation = new List<StoreProductDbModel>();
        _categoryDbModels = new List<CategoryDbModel>();
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Location { get; private set; }
    public Guid? MallId { get; private set; }

    [ForeignKey(nameof(MallId))] public MallDbModel MallDbModel { get; private set; }

    public IReadOnlyCollection<StoreCategoryDbModel> StoreCategoryRelation => _storeCategoryRelation.AsReadOnly();
    public IReadOnlyCollection<StoreProductDbModel> StoreProductRelation => _storeProductRelation.AsReadOnly();
    public IReadOnlyCollection<CategoryDbModel> CategoryDbModels => GetStoreSpecificCategories();

    public double Profit { get; private set; }

    private IReadOnlyCollection<CategoryDbModel> GetStoreSpecificCategories()
    {
        return (from storeCatRel in _storeCategoryRelation
            where storeCatRel.StoreDbModelId.Equals(Id)
            select storeCatRel.CategoryDbModel).ToList().AsReadOnly();
    }
}