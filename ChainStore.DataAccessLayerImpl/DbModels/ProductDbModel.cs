using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChainStore.DataAccessLayerImpl.DbModels
{
    internal sealed class ProductDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double PriceInUAH { get; private set; }
        public ProductStatus ProductStatus { get; private set; }
        public Guid CategoryId { get; private set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryDbModel CategoryDbModel { get; private set; }

        private readonly List<StoreProductDbModel> _storeProductRelation;
        public IReadOnlyCollection<StoreProductDbModel> StoreProductRelation => _storeProductRelation.AsReadOnly();

        public ProductDbModel(Guid id, string name, double priceInUAH, ProductStatus productStatus, Guid categoryId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(categoryId);
            CustomValidator.ValidateString(name, 2, 40);
            CustomValidator.ValidateNumber(priceInUAH, 0, 100_000_000);
            Id = id;
            Name = name;
            PriceInUAH = priceInUAH;
            ProductStatus = productStatus;
            CategoryId = categoryId;
            _storeProductRelation = new List<StoreProductDbModel>();
        }
    }
}
