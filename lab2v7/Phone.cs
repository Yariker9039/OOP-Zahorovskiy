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
