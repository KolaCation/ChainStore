using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class CategoryDbModel
    {
        public Guid CategoryDbModelId { get; private set; }
        public string Name { get; private set; }

        private readonly List<StoreCategoryDbModel> _storeCategoryRelation;
        public IReadOnlyCollection<StoreCategoryDbModel> StoreCategoryRelation => _storeCategoryRelation.AsReadOnly();

        private readonly List<ProductDbModel> _productDbModels;
        public IReadOnlyCollection<ProductDbModel> ProductDbModels => _productDbModels.AsReadOnly();

        public CategoryDbModel(Guid categoryDbModelId, string name)
        {
            CustomValidator.ValidateId(categoryDbModelId);
            CustomValidator.ValidateString(name, 2, 40);
            CategoryDbModelId = categoryDbModelId;
            Name = name;
            _productDbModels = new List<ProductDbModel>();
            _storeCategoryRelation = new List<StoreCategoryDbModel>();
        }

        internal IReadOnlyCollection<ProductDbModel> GetStoreSpecificProducts(Guid storeId)
        {
            CustomValidator.ValidateId(storeId);
            var storeSpecificProducts = (from pr in _productDbModels
                                         from storeProdRel in pr.StoreProductRelation
                                         where storeProdRel.Store1Id.Equals(storeId)
                                         && storeProdRel.ProductDbModel.CategoryDbModelId.Equals(CategoryDbModelId)
                                         select storeProdRel.ProductDbModel).ToList().AsReadOnly();
            return storeSpecificProducts;
        }
    }
}