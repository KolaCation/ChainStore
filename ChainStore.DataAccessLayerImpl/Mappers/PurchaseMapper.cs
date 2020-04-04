﻿using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class PurchaseMapper : IMapper<Purchase, PurchaseDbModel>
    {
        public PurchaseDbModel DomainToDb(Purchase item)
        {
            CustomValidator.ValidateObject(item);
            return new PurchaseDbModel(item.PurchaseId, item.ClientId, item.ProductId, item.CreationTime);
        }

        public Purchase DbToDomain(PurchaseDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new Purchase(item.PurchaseDbModelId, item.ClientDbModelId, item.ProductDbModelId, item.CreationTime);
        }
    }
}