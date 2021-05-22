using System;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface ICreateDeleteRepository<T>
    {
        void AddOne(T item);
        void DeleteOne(Guid id);
        bool Exists(Guid id);
    }
}
