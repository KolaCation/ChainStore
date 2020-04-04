using System;
using System.Collections.Generic;
using System.Text;

namespace ChainStore.DataAccessLayer.Repositories
{
    public interface IRepository<T>
    {
        void AddOne(T item);
        T GetOne(Guid id);
        IReadOnlyCollection<T> GetAll();
        void UpdateOne(T item);
        void DeleteOne(Guid id);
        bool Exists(Guid id);
    }
}
