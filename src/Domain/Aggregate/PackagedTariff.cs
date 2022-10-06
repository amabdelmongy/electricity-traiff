namespace Domain.Aggregate;

internal class PackagedTariff : IStrategyTariff
{
    private const int MinimumCost  = 80000;
    private const int ConsumptionCost = 30;
    private const int ConsumptionBar = 4000;
    public string Name() => "Packaged tariff";
    public long CalculateAnnualCost(int consumption)
    {
        if (consumption <= ConsumptionBar) return MinimumCost;

        return MinimumCost
               + (consumption - ConsumptionBar) * ConsumptionCost;
    }
}