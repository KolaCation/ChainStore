using System;

namespace ChainStore.Domain.Repositories;

public interface ICreateDeleteRepository<T>
{
    void AddOne(T item);
    void DeleteOne(Guid id);
    bool Exists(Guid id);
}