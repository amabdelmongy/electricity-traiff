namespace Domain.Aggregate;

interface IStrategyTariff
{
    string Name();
    long CalculateAnnualCost(int consumption);
}