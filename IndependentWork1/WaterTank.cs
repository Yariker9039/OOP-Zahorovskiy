namespace Work1;

public class WaterTank
{
    private string _location;
    private double _capacityLiters;
    private double _waterLiters;

    public string Location { get => _location; set => _location = value; }
    public double CapacityLiters => _capacityLiters;
    public double WaterLiters => _waterLiters;

    public WaterTank(string location, double capacityLiters)
    {
        if (!double.IsFinite(capacityLiters) || capacityLiters <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacityLiters));
        _location = location;
        _capacityLiters = capacityLiters;
        _waterLiters = 0;
    }

    public bool TryFill(double liters)
    {
        if (!double.IsFinite(liters) || liters <= 0)
            throw new ArgumentOutOfRangeException(nameof(liters));
        if (liters > _capacityLiters - _waterLiters)
            return false;
        _waterLiters += liters;
        return true;
    }
}
