# Звіт з лабораторної роботи №2

Посилання на репозиторій: https://github.com/Yariker9039/OOP-Zahorovskiy

**Студент:** Загоровський Ярослав Віталійович  
**Група:** ІПЗ 3/1  
**Варіант:** 7 — Phone

## Тема та мета

Клас із кількома конструкторами. Життєвий цикл об’єкта. Мета — реалізувати перевантажені конструктори, дослідити порядок їх виклику та фіналізацію об’єктів.

## Виконання

Створено консольний проєкт lab2v7. Реалізовано приватні поля, публічні властивості та перевірку рівня батареї. Конструктор без параметрів викликає параметризований через this. Створено три телефони, продемонстровано дзвінок, розряджену батарею та відхилення некоректного заряду. Після повернення з допоміжного методу виконано GC.Collect та GC.WaitForPendingFinalizers.

## Phone.cs

```csharp
namespace Lab2;

public class Phone
{
    private string _brand;
    private string _model;
    private int _batteryLevel;

    public string Brand { get => _brand; set => _brand = value; }
    public string Model { get => _model; set => _model = value; }
    public int BatteryLevel
    {
        get => _batteryLevel;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Заряд має бути від 0 до 100.");
            _batteryLevel = value;
        }
    }

    public Phone() : this("Generic", "Basic", 50)
    {
        Console.WriteLine("Завершено конструктор без параметрів.");
    }

    public Phone(string brand, string model, int batteryLevel)
    {
        _brand = brand;
        _model = model;
        BatteryLevel = batteryLevel;
        Console.WriteLine($"Параметризований конструктор: {Brand} {Model}, заряд {BatteryLevel}%.");
    }

    public void Call(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Номер не може бути порожнім.", nameof(number));
        if (BatteryLevel == 0)
        {
            Console.WriteLine($"{Brand} {Model}: батарея розряджена, дзвінок неможливий.");
            return;
        }
        BatteryLevel--;
        Console.WriteLine($"{Brand} {Model}: дзвінок на {number}, залишок заряду {BatteryLevel}%.");
    }

    ~Phone()
    {
        Console.WriteLine($"Фіналізатор Phone: {Brand} {Model}.");
    }
}
```

## Program.cs

```csharp
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
```

## Результат запуску

```text
Лабораторна №2. Варіант 7 — Phone
Параметризований конструктор: Generic Basic, заряд 50%.
Завершено конструктор без параметрів.
Параметризований конструктор: Apple iPhone 15, заряд 85%.
Параметризований конструктор: Samsung Galaxy S24, заряд 0%.
Generic Basic: дзвінок на +380501234567, залишок заряду 49%.
Apple iPhone 15: дзвінок на +380671234567, залишок заряду 84%.
Samsung Galaxy S24: батарея розряджена, дзвінок неможливий.
Валідація: заряд 101 відхилено; поточний заряд 84%.
Посилання більше не використовуються. Запускаємо GC.
Фіналізатор Phone: Generic Basic.
Фіналізатор Phone: Samsung Galaxy S24.
Фіналізатор Phone: Apple iPhone 15.
Очікування фіналізаторів завершено.
```

Порядок фіналізації трьох телефонів може відрізнятися між запусками.

## Висновок

Ланцюговий виклик this усуває дублювання ініціалізації. Властивість BatteryLevel захищає стан від некоректних значень. Об’єкт стає кандидатом на збирання після втрати досяжності, але це не означає негайної фіналізації. У демонстрації примусове збирання та очікування фіналізаторів дозволяють побачити відповідні повідомлення; у звичайному коді час збирання визначає .NET.
