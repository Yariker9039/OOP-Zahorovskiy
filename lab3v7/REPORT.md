# Лабораторна робота №3

Загоровський Ярослав Віталійович, ІПЗ 3/1. Варіант 7.

Тема: Життєвий цикл об’єкта та звільнення ресурсів.

Репозиторій: https://github.com/Yariker9039/OOP-Zahorovskiy

## Що зроблено

Я зробив клас SerialPortConnection, який імітує COM-порт. Конструктор відкриває порт, SendData показує передані байти, а Dispose закриває його. Справжній порт не використовується. У Main є три способи завершити роботу з об’єктом: using, прямий виклик Dispose та фіналізатор. Після GC.Collect викликається GC.WaitForPendingFinalizers, щоб дочекатися фіналізатора.

## Запуск

Потрібен .NET SDK 10. З кореня репозиторію:

```powershell
dotnet run --project lab3v7
```

## Результат запуску

[Текст консолі](console-output.txt).

![Консольний вивід](console-output.png)

## Контрольні питання

**1. Що таке життєвий цикл об’єкта?**

Об’єкт створюється, використовується, а коли він стає недоступним, GC може звільнити його пам’ять. Для об’єкта з фіналізатором спочатку виконується фіналізація.

**2. Чим відрізняються керовані та некеровані ресурси?**

Пам’яттю звичайних об’єктів керує .NET. Файлові дескриптори та подібні системні ресурси потрібно закривати окремо. Наприклад, FileStream є керованим об’єктом, але утримує ресурс операційної системи.

**3. Для чого IDisposable?**

Він задає метод Dispose, через який об’єкт звільняє свої ресурси.

**4. Що робить using?**

Автоматично викликає Dispose при виході з блоку, навіть якщо виникла помилка.

**5. Навіщо GC.SuppressFinalize?**

Після Dispose прибирання вже виконано, тому фіналізатор для цього об’єкта більше не потрібен.

**6. Чому Dispose(true) та Dispose(false)?**

При true можна звільняти і керовані, і некеровані ресурси. При false прибирають лише власні некеровані ресурси: стан інших керованих об’єктів у фіналізаторі не гарантований. Тут порт лише імітується.

## Висновок

Using закриває порт автоматично. При явному Dispose потрібно самому пам’ятати про виклик. Фіналізатор — запасний варіант: час його запуску не визначений. GC.Collect використано тільки для демонстрації.



## Повний код

### SerialPortConnection.cs

```csharp
namespace Lab3;

// Навчальна імітація: справжній COM-порт не відкривається.
public class SerialPortConnection : IDisposable
{
    private string _portName;
    private bool _isPortOpen;
    private bool _disposed;

    public string PortName => _portName;
    public bool IsPortOpen => _isPortOpen;
    public bool IsDisposed => _disposed;

    public SerialPortConnection(string portName)
    {
        if (string.IsNullOrWhiteSpace(portName))
            throw new ArgumentException("Вкажіть назву порту.", nameof(portName));
        _portName = portName;
        _isPortOpen = true;
        Console.WriteLine($"Відкрито порт {_portName} (імітація).");
    }

    public void SendData(byte[] data)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        ArgumentNullException.ThrowIfNull(data);
        if (!_isPortOpen)
            throw new InvalidOperationException("Порт закрито.");
        Console.WriteLine($"{_portName}: передано {data.Length} байт — {Convert.ToHexString(data)}.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        if (disposing)
        {
            // Тут звільняють керовані IDisposable-ресурси, якщо клас їх має.
            // У цій імітації таких ресурсів немає.
        }
        if (_isPortOpen)
        {
            _isPortOpen = false;
            // Діагностичний вивід потрібен лише для навчальної демонстрації.
            Console.WriteLine($"Порт {_portName} закрито: {(disposing ? "Dispose" : "фіналізатор")}.");
        }
        _disposed = true;
    }

    ~SerialPortConnection()
    {
        Dispose(false);
    }
}
```

### Program.cs

```csharp
using System.Runtime.CompilerServices;
using System.Text;
namespace Lab3;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("1. Використання using");
        using (var port = new SerialPortConnection("COM1"))
        {
            port.SendData(new byte[] { 1, 2, 3 });
        }

        Console.WriteLine("\n2. Явний виклик Dispose");
        var secondPort = new SerialPortConnection("COM2");
        secondPort.SendData(new byte[] { 10, 20 });
        secondPort.Dispose();
        secondPort.Dispose(); // Повторний виклик нічого не змінює.

        Console.WriteLine("\n3. Без Dispose, прибирання через GC");
        CreateForgottenPort();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Фіналізацію завершено.");
    }

    // Окремий метод не залишає локального посилання в Main.
    [MethodImpl(MethodImplOptions.NoInlining)]
    static void CreateForgottenPort()
    {
        var port = new SerialPortConnection("COM3");
        port.SendData(new byte[] { 100 });
    }
}
```

## Текстовий результат

```text
1. Використання using
Відкрито порт COM1 (імітація).
COM1: передано 3 байт — 010203.
Порт COM1 закрито: Dispose.

2. Явний виклик Dispose
Відкрито порт COM2 (імітація).
COM2: передано 2 байт — 0A14.
Порт COM2 закрито: Dispose.

3. Без Dispose, прибирання через GC
Відкрито порт COM3 (імітація).
COM3: передано 1 байт — 64.
Порт COM3 закрито: фіналізатор.
Фіналізацію завершено.
```
