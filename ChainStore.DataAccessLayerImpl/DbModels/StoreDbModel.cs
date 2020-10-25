using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class StoreDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public Guid? MallId { get; private set; }
        [ForeignKey(nameof(MallId))]
        public MallDbModel MallDbModel { get; private set; }

        private readonly List<StoreCategoryDbModel> _storeCategoryRelation;
        public IReadOnlyCollection<StoreCategoryDbModel> StoreCategoryRelation => _storeCategoryRelation.AsReadOnly();

        private readonly List<StoreProductDbModel> _storeProductRelation;
        public IReadOnlyCollection<StoreProductDbModel> StoreProductRelation => _storeProductRelation.AsReadOnly();

        private List<CategoryDbModel> _categoryDbModels;
        public IReadOnlyCollection<CategoryDbModel> CategoryDbModels => GetStoreSpecificCategories();

        public double Profit { get; private set; }

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

        private IReadOnlyCollection<CategoryDbModel> GetStoreSpecificCategories()
        {
            return (from storeCatRel in _storeCategoryRelation where storeCatRel.StoreDbModelId.Equals(Id) select storeCatRel.CategoryDbModel).ToList().AsReadOnly();
        }
    }
}
