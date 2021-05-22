using ChainStore.Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class CategoryDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        private readonly List<StoreCategoryDbModel> _storeCategoryRelation;
        public IReadOnlyCollection<StoreCategoryDbModel> StoreCategoryRelation => _storeCategoryRelation.AsReadOnly();

        private readonly List<ProductDbModel> _productDbModels;
        public IReadOnlyCollection<ProductDbModel> ProductDbModels => _productDbModels.AsReadOnly();

        public Guid? StoreDbModelId { get; private set; }

        public CategoryDbModel(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 40);
            Id = id;
            Name = name;
            _productDbModels = new List<ProductDbModel>();
            _storeCategoryRelation = new List<StoreCategoryDbModel>();
            StoreDbModelId = default;
        }

        internal IReadOnlyCollection<ProductDbModel> GetStoreSpecificProducts(Guid storeId)
        {
            CustomValidator.ValidateId(storeId);
            var storeSpecificProducts = (from pr in _productDbModels
                                         from storeProdRel in pr.StoreProductRelation
                                         where storeProdRel.StoreDbModelId.Equals(storeId)
                                         && storeProdRel.ProductDbModel.CategoryId.Equals(Id)
                                         select storeProdRel.ProductDbModel).ToList().AsReadOnly();
            return storeSpecificProducts;
        }
    }
}