using ChainStore.Shared.Util;
using Microsoft.EntityFrameworkCore;
using System;

namespace ChainStore.DataAccessLayerImpl.Helpers
{
    internal static class DetachService
    {
        internal static void Detach<TEntity>(MyDbContext context, Guid id) where TEntity : class
        {
            CustomValidator.ValidateId(id);
            var entity = context.Set<TEntity>().Find(id);
            context.Entry(entity).State = EntityState.Detached;
        }
    }
}
