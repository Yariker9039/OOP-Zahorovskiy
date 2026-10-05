using System.Runtime.CompilerServices;
using System.Text;

namespace Lab2;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Лабораторна №2. Варіант 7 — Phone");
        DemonstratePhones();
        Console.WriteLine("Посилання більше не використовуються. Запускаємо GC.");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Очікування фіналізаторів завершено.");
    }

    // Окремий невбудований метод усуває вплив локальних посилань Main на GC.
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void DemonstratePhones()
    {
        Phone first = new Phone();
        Phone second = new Phone("Apple", "iPhone 15", 85);
        Phone third = new Phone("Samsung", "Galaxy S24", 0);
        first.Call("+380501234567");
        second.Call("+380671234567");
        third.Call("+380931234567");
        try
        {
            second.BatteryLevel = 101;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine($"Валідація: заряд 101 відхилено; поточний заряд {second.BatteryLevel}%.");
        }
    }
}
