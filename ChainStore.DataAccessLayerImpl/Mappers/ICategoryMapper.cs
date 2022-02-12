using System;
using ChainStore.DataAccessLayer.DbModels;
using ChainStore.Domain.DomainCore;

namespace ChainStore.DataAccessLayer.Mappers;

internal interface ICategoryMapper : IMapper<Category, CategoryDbModel>
{
    Category DbToDomainStoreSpecificProducts(CategoryDbModel item, Guid storeId);
}