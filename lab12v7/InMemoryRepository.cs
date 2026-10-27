namespace Lab7;
public class InMemoryRepository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public T GetById(int id)
    {
        int index = FindIndex(id);
        return _items[index];
    }

    public IEnumerable<T> GetAll() => _items.ToArray();

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        if (_items.Any(existing => existing.Id == item.Id))
            throw new ArgumentException("Елемент з таким Id вже існує.", nameof(item));
        _items.Add(item);
    }

    public void Update(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        int index = FindIndex(item.Id);
        _items[index] = item;
    }

    public void Delete(int id)
    {
        int index = FindIndex(id);
        _items.RemoveAt(index);
    }

    private int FindIndex(int id)
    {
        int index = _items.FindIndex(item => item.Id == id);
        if (index == -1)
            throw new KeyNotFoundException($"Елемент з Id {id} не знайдено.");
        return index;
    }
}
