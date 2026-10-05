namespace Work1;

public class Parcel
{
    private string _trackingCode;
    private decimal _weightKg;

    public string TrackingCode { get => _trackingCode; set => _trackingCode = value; }
    public decimal WeightKg => _weightKg;

    public Parcel(string trackingCode, decimal weightKg)
    {
        if (weightKg <= 0)
            throw new ArgumentOutOfRangeException(nameof(weightKg));
        _trackingCode = trackingCode;
        _weightKg = weightKg;
    }

    // Навчальний тариф, не тариф реального перевізника.
    public decimal CalculateDeliveryCost(decimal baseFee, decimal pricePerKg)
    {
        if (baseFee < 0 || pricePerKg < 0)
            throw new ArgumentOutOfRangeException(nameof(baseFee), "Тарифи не можуть бути від’ємними.");
        return baseFee + _weightKg * pricePerKg;
    }
}
