namespace Work2;

public class Product
{
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Вкажіть назву товару.", nameof(name));
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price));
        Name = name;
        Price = price;
    }
}
