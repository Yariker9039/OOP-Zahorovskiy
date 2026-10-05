namespace Work2;

public class Cart
{
    private readonly List<(Product Product, int Quantity)> _items = new();

    public void AddItem(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));
        _items.Add((product, quantity));
    }

    // Повертає суму позиції після знижки; початкову ціну не змінює.
    public decimal ApplyDiscount(Product product, int quantity)
    {
        ArgumentNullException.ThrowIfNull(product);
        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity));
        decimal subtotal = product.Price * quantity;
        return product.Price > 500m ? subtotal * 0.90m : subtotal;
    }

    public decimal GetTotal()
    {
        decimal total = 0m;
        foreach (var item in _items)
            total += ApplyDiscount(item.Product, item.Quantity);
        return total;
    }

    public void PrintItems()
    {
        foreach (var item in _items)
        {
            decimal subtotal = item.Product.Price * item.Quantity;
            decimal final = ApplyDiscount(item.Product, item.Quantity);
            Console.WriteLine($"{item.Product.Name}: {item.Product.Price:F2} × {item.Quantity} = {subtotal:F2}; знижка {subtotal - final:F2}; до сплати {final:F2} грн.");
        }
    }
}
