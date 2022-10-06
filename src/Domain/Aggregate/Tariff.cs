namespace Domain.Aggregate;

public record Tariff(
    string Name,
    int Consumption,
    long AnnualCostInCent)
{
    public int AnnualCost =>
        (int)Math.Round(
            (double)AnnualCostInCent/100,
            MidpointRounding.ToZero);
}
