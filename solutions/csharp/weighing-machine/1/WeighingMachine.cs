class WeighingMachine(int precision)
{
    private double weight;

    public int Precision { get; } = precision;

    public double Weight
    {
        get
        {
            return weight;
        }

        set {
            ArgumentOutOfRangeException.ThrowIfNegative(value);

            weight = value;
        }
    }
    
    public double TareAdjustment
    { get; set; } = 5.0;

    public string DisplayWeight
    {
        get
        {
            double adjustedWeight = Weight -  TareAdjustment;
            string adjustedWeightTo3DP = adjustedWeight.ToString($"F{Precision}");
            return $"{adjustedWeightTo3DP} kg";
        }
    }
}
