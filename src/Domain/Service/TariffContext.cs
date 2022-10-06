namespace Domain.Service;

class TariffContext
{
    private IStrategyTariff? _strategy;

    public TariffContext()
    {
    }

    public void SetStrategy(IStrategyTariff? strategy)
    {
        _strategy = strategy;
    }

    internal long CalculateAnnualCost(int consumption) =>
        _strategy!.CalculateAnnualCost(consumption);

    internal string Name() =>
        _strategy!.Name();
}
