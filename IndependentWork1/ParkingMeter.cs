namespace Work1;

public class ParkingMeter
{
    private string _zone;
    private decimal _hourlyRate;

    public string Zone { get => _zone; set => _zone = value; }
    public decimal HourlyRate => _hourlyRate;

    public ParkingMeter(string zone, decimal hourlyRate)
    {
        if (hourlyRate < 0)
            throw new ArgumentOutOfRangeException(nameof(hourlyRate));
        _zone = zone;
        _hourlyRate = hourlyRate;
    }

    public decimal CalculateCost(int minutes)
    {
        if (minutes < 0)
            throw new ArgumentOutOfRangeException(nameof(minutes));
        return Math.Round(_hourlyRate * minutes / 60m, 2, MidpointRounding.AwayFromZero);
    }
}
