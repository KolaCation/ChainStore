using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal interface IMapper<TDomainModel, TDbModel>
    {
        TDbModel DomainToDb(TDomainModel item);
        TDomainModel DbToDomain(TDbModel item);
    }
}
