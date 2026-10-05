namespace Work4;

public class Product
{
    private readonly int _id;
    private readonly string _name;
    private readonly decimal _price;
    private readonly string _category;
    private readonly int _stockCount;

    public int Id => _id;
    public string Name => _name;
    public decimal Price => _price;
    public string Category => _category;
    public int StockCount => _stockCount;

    public Product(int id, string name, decimal price, string category, int stockCount)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Вкажіть назву.", nameof(name));
        if (price < 0) throw new ArgumentOutOfRangeException(nameof(price));
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException("Вкажіть категорію.", nameof(category));
        if (stockCount < 0) throw new ArgumentOutOfRangeException(nameof(stockCount));
        _id = id;
        _name = name;
        _price = price;
        _category = category;
        _stockCount = stockCount;
    }

    public Product(int id, string name, decimal price)
        : this(id, name, price, "Uncategorized", 0)
    {
    }

    public Product(Product other)
        : this((other ?? throw new ArgumentNullException(nameof(other)))._id,
            other._name, other._price, other._category, other._stockCount)
    {
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price:C}, Category: {Category}, Stock: {StockCount}";
    }
}
