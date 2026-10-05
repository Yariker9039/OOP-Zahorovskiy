using System.Globalization;
using System.Text;

namespace Work4;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
        Product original = new Product(101, "Laptop", 35000m, "Electronics", 5);
        Product quick = new Product(102, "Mouse", 800m);
        Product copy = new Product(original);
        Console.WriteLine("Створення товарів");
        Console.WriteLine($"Товар 1 (основний конструктор): {original}");
        Console.WriteLine($"Товар 2 (скорочений конструктор): {quick}");
        Console.WriteLine($"Товар 3 (конструктор копіювання): {copy}");
        Console.WriteLine($"Оригінал і копія — той самий об’єкт: {ReferenceEquals(original, copy)}.");
    }
}
