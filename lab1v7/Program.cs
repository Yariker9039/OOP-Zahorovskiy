class Phone
{
    private string brand;
    private string model;

    public int BatteryLevel { get; set; }

    public Phone(string brand, string model, int batteryLevel)
    {
        this.brand = brand;
        this.model = model;
        BatteryLevel = batteryLevel;
    }

    public void Call(string number)
    {
        if (BatteryLevel > 0)
        {
            Console.WriteLine($"{brand} {model}: дзвінок на номер {number}");
            BatteryLevel--;
            Console.WriteLine($"Рівень заряду: {BatteryLevel}%");
        }
        else
        {
            Console.WriteLine($"{brand} {model}: неможливо здійснити дзвінок, батарея розряджена.");
        }
    }
}

class Program
{
    static void Main()
    {
        Phone phone1 = new Phone("Apple", "iPhone 15", 85);
        Phone phone2 = new Phone("Samsung", "Galaxy S24", 60);
        Phone phone3 = new Phone("Xiaomi", "Redmi Note 13", 40);

        phone1.Call("+380501234567");
        phone2.Call("+380671234567");
        phone3.Call("+380931234567");
    }
}