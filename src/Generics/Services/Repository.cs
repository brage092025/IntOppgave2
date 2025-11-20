using Generics.Interfaces;

namespace Generics.Services;

public class Repository<T> : IRepository<T>
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    public bool Remove(T item) => _items.Remove(item);

    public IEnumerable<T> GetAll() => _items;

    public T? Get(Func<T, bool> predicate) =>
        _items.FirstOrDefault(predicate);

    public int Count => _items.Count;
}

