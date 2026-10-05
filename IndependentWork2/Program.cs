using System.Globalization;
using System.Text;

namespace Work2;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
        // Процедурна частина: лише масиви, числа та статичні методи Program.
        string[] names = { "Клавіатура", "Миша", "Килимок" };
        decimal[] prices = { 1000m, 500m, 200m };
        int[] quantities = { 1, 2, 3 };
        decimal[] subtotals = CalculateSubtotals(prices, quantities);
        decimal[] discounted = ApplyDiscounts(prices, subtotals);
        Console.WriteLine("ПРОЦЕДУРНИЙ ПІДХІД");
        for (int i = 0; i < names.Length; i++)
            Console.WriteLine($"{names[i]}: {prices[i]:F2} × {quantities[i]} = {subtotals[i]:F2}; знижка {subtotals[i] - discounted[i]:F2}; до сплати {discounted[i]:F2} грн.");
        decimal proceduralTotal = CalculateTotal(discounted);
        Console.WriteLine($"Разом: {proceduralTotal:F2} грн.");

        Console.WriteLine("\nОБ’ЄКТНИЙ ПІДХІД");
        Cart cart = new Cart();
        for (int i = 0; i < names.Length; i++)
            cart.AddItem(new Product(names[i], prices[i]), quantities[i]);
        cart.PrintItems();
        decimal objectTotal = cart.GetTotal();
        Console.WriteLine($"Разом: {objectTotal:F2} грн.");
        Console.WriteLine($"Підсумки однакові: {proceduralTotal == objectTotal}.");
    }

    private static decimal[] CalculateSubtotals(decimal[] prices, int[] quantities)
    {
        if (prices.Length != quantities.Length)
            throw new ArgumentException("Масиви повинні мати однакову довжину.");
        decimal[] results = new decimal[prices.Length];
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < 0 || quantities[i] <= 0)
                throw new ArgumentException("Некоректна ціна або кількість.");
            results[i] = prices[i] * quantities[i];
        }
        return results;
    }

    private static decimal[] ApplyDiscounts(decimal[] prices, decimal[] subtotals)
    {
        if (prices.Length != subtotals.Length)
            throw new ArgumentException("Масиви повинні мати однакову довжину.");
        decimal[] results = new decimal[prices.Length];
        for (int i = 0; i < prices.Length; i++)
            results[i] = prices[i] > 500m ? subtotals[i] * 0.90m : subtotals[i];
        return results;
    }

    private static decimal CalculateTotal(decimal[] amounts)
    {
        decimal total = 0m;
        foreach (decimal amount in amounts)
            total += amount;
        return total;
    }
}
