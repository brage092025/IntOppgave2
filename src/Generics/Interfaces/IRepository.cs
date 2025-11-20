using System;

namespace Generics.Interfaces;

public interface IRepository<T>
{
    void Add(T item);
    bool Remove(T item);
    IEnumerable<T> GetAll();
    T? Get(Func<T, bool> predicate);
    int Count { get; }

}
