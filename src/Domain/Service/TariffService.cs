namespace Domain.Service;

public class TariffService : ITariffService
{
    public Result<List<Tariff>> Analysis(int consumption)
    {
        var tariffContext = new TariffContext();
        var result = new List<Tariff>();

        tariffContext.SetStrategy(new BasicTariff());
        result.Add(
            new Tariff(
                    tariffContext.Name(),
                    consumption,
                    tariffContext.CalculateAnnualCost(consumption)));

        tariffContext.SetStrategy(new PackagedTariff());
        result.Add(
            new Tariff(
                    tariffContext.Name(),
                    consumption,
                    tariffContext.CalculateAnnualCost(consumption)));

        return Result.Ok(result);
    }
}
