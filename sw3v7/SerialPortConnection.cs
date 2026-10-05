namespace Work3;

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
