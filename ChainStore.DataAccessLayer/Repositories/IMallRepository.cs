using System;
using System.Collections.Generic;
using System.Text;
using ChainStore.Domain.DomainCore;

namespace ChainStore.Domain.DomainServices
{
    public interface IMallRepository
    {
        IReadOnlyCollection<Mall> GetAllMalls();
        Mall GetMall(Guid mallId);
        void AddMall(Mall mall);
        void UpdateMall(Mall mall);
        void DeleteMall(Guid mallId);
    }
}
