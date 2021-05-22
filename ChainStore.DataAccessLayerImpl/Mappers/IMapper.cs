namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal interface IMapper<TDomainModel, TDbModel>
    {
        TDbModel DomainToDb(TDomainModel item);
        TDomainModel DbToDomain(TDbModel item);
    }
}
