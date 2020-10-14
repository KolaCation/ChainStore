using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class ProductDbModel
    {
        public Guid ProductDbModelId { get; private set; }
        public string Name { get; private set; }
        public double PriceInUAH { get; private set; }
        public ProductStatus ProductStatus { get; private set; }
        public Guid CategoryDbModelId { get; private set; }
        public CategoryDbModel CategoryDbModel { get; private set; }

        private readonly List<StoreProductDbModel> _storeProductRelation;
        public IReadOnlyCollection<StoreProductDbModel> StoreProductRelation => _storeProductRelation.AsReadOnly();

        public ProductDbModel(Guid productDbModelId, string name, double priceInUAH, ProductStatus productStatus, Guid categoryDbModelId)
        {
            CustomValidator.ValidateId(productDbModelId);
            CustomValidator.ValidateId(categoryDbModelId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(priceInUAH, 0, 100_000_000);
            ProductDbModelId = productDbModelId;
            Name = name;
            PriceInUAH = priceInUAH;
            ProductStatus = productStatus;
            CategoryDbModelId = categoryDbModelId;
            _storeProductRelation = new List<StoreProductDbModel>();
        }
    }
}
