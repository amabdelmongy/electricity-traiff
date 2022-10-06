namespace Domain.Aggregate;

internal class BasicTariff : IStrategyTariff
{
    private const int CostMonthly = 500;
    private const int ConsumptionCost = 22;
    private const int NumOfMonths = 12;
    public string Name() => "Basic tariff";

    public long CalculateAnnualCost(int consumption) =>
        NumOfMonths * CostMonthly
        + consumption * ConsumptionCost;
}