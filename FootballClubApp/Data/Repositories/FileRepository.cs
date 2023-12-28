namespace FootballClubApp.Data.Repositories;

public class FileRepository<T> : IRepository<T>
        where T : class, IEntity, new()
{
    private readonly List<T> _items = new();
    private int lastUsedId = 1;
    private readonly string path = $"{typeof(T).Name}_save.json";

    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemRemoved;

    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }

    public void Add(T item)
    {
        if (_items.Count == 0)
        {
            item.Id = lastUsedId;
            lastUsedId++;
        }
        else if (_items.Count > 0)
        {
            lastUsedId = _items[_items.Count - 1].Id;
            item.Id = ++lastUsedId;
        }

        _items.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public T? GetById(int id)
    {
        var itemById = _items.SingleOrDefault(item => item.Id == id);
        if (itemById == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Object {typeof(T).Name} with id {id} not found.");
            Console.ResetColor();
        }
        return itemById;
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemRemoved?.Invoke(this, item);
    }

    public void Save()
    {
        File.Delete(path);
        var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
        File.WriteAllText(path, objectsSerialized);
    }
    public IEnumerable<T> Read()
    {
        if (File.Exists(path))
        {
            var objectsSerialized = File.ReadAllText(path);
            var deserializedObjects = JsonSerializer.Deserialize<IEnumerable<T>>(objectsSerialized);
            if (deserializedObjects != null)
            {
                foreach (var item in deserializedObjects)
                {
                    _items.Add(item);
                }
            }
        }
        return _items;
    }

    public int GetListCount()
    {
        return _items.Count;
    }
}
