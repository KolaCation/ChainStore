using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChainStore.DataAccessLayerImpl.DbModels;
using ChainStore.Domain.DomainCore;
using ChainStore.Shared.Util;

namespace ChainStore.DataAccessLayerImpl.Mappers
{
    internal sealed class MallMapper : IMapper<Mall, MallDbModel>
    {
        private readonly MyDbContext _context;
        private readonly StoreMapper _storeMapper;

        public MallMapper(MyDbContext context)
        {
            _context = context;
            _storeMapper = new StoreMapper(context);
        }

        public MallDbModel DomainToDb(Mall item)
        {
            CustomValidator.ValidateObject(item);
            return new MallDbModel(item.MallId, item.Name, item.Location);
        }

        public Mall DbToDomain(MallDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var mallDbModel = _context.Malls.Find(item.MallDbModelId);
            _context.Entry(mallDbModel).Collection(st => st.StoreDbModels).Load();
            return new Mall
            (
                (from storeDbModel in mallDbModel.StoreDbModels select _storeMapper.DbToDomain(storeDbModel)).ToList(),
                item.MallDbModelId,
                item.Name,
                item.Location
            );
        }
    }
}
