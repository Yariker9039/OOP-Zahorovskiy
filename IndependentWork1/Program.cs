using System.Globalization;
using System.Text;

namespace Work1;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
        WaterTank tank = new WaterTank("Сад", 100);
        tank.Location = "Теплиця";
        Console.WriteLine($"Бак ({tank.Location}): додати 40 л — {tank.TryFill(40)}.");
        Console.WriteLine($"Додати ще 70 л — {tank.TryFill(70)}; води {tank.WaterLiters} із {tank.CapacityLiters} л.");

        Parcel parcel = new Parcel("UA0007", 2.5m);
        Console.WriteLine($"Посилка {parcel.TrackingCode}, {parcel.WeightKg} кг: доставка {parcel.CalculateDeliveryCost(40m, 12m):F2} грн.");

        ParkingMeter parking = new ParkingMeter("Центр", 20m);
        Console.WriteLine($"Паркування ({parking.Zone}): 90 хв = {parking.CalculateCost(90):F2} грн.");
    }
}
