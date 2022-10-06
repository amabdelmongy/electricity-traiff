namespace Domain.UnitTest;

public class TariffServiceTest
{
    private TariffService? _tariffService;

    [SetUp]
    public void Setup()
    {
        _tariffService = new TariffService();
    }
    [Test]
    public void WHEN_analysis_consumption_THEN_return_correct_Names()
    {
        var exceptedBasicName = "Basic tariff";
        var exceptedPackagedName = "Packaged tariff";
        var exceptedConsumption = 3500;


        var actual =
            _tariffService!.Analysis(exceptedConsumption);

        Assert.True(actual.IsOk);
        Assert.That(actual.Value!.Count, Is.EqualTo(2));

        var actualBasicTariff = actual.Value.First();
        Assert.That(actualBasicTariff.Name, Is.EqualTo(exceptedBasicName));
        Assert.That(actualBasicTariff.Consumption, Is.EqualTo(exceptedConsumption));

        var actualPackagedTariff = actual.Value.Last();
        Assert.That(actualPackagedTariff.Name, Is.EqualTo(exceptedPackagedName));
        Assert.That(actualPackagedTariff.Consumption, Is.EqualTo(exceptedConsumption));
    }

    [Test]
    public void WHEN_analysis_consumption_3500_THEN_return_correct_values()
    {
        var exceptedConsumption = 3500;
        var exceptedBasicCostRounded = 830;
        var exceptedPackagedCostRounded = 800;

        var actual = _tariffService!.Analysis(exceptedConsumption);

        Assert.That(actual.Value!.Count, Is.EqualTo(2));
        Assert.That(actual.Value.First().AnnualCost, Is.EqualTo(exceptedBasicCostRounded));
        Assert.That(actual.Value.Last().AnnualCost, Is.EqualTo(exceptedPackagedCostRounded));
    }

    [Test]
    public void WHEN_analysis_consumption_4500_THEN_return_correct_values()
    {
        var exceptedConsumption = 4500;
        var exceptedBasicCostRounded = 1050;
        var exceptedPackagedCostRounded = 950;

        var actual = _tariffService!.Analysis(exceptedConsumption);

        Assert.That(actual.Value!.Count, Is.EqualTo(2));
        Assert.That(actual.Value.First().AnnualCost, Is.EqualTo(exceptedBasicCostRounded));
        Assert.That(actual.Value.Last().AnnualCost, Is.EqualTo(exceptedPackagedCostRounded));
    }

    [Test]
    public void WHEN_analysis_consumption_6000_THEN_return_correct_values()
    {
        var exceptedConsumption = 6000;
        var exceptedBasicCostRounded = 1380;
        var exceptedPackagedCostRounded = 1400;

        var actual = _tariffService!.Analysis(exceptedConsumption);

        Assert.That(actual.Value!.Count, Is.EqualTo(2));
        Assert.That(actual.Value.First().AnnualCost, Is.EqualTo(exceptedBasicCostRounded));
        Assert.That(actual.Value.Last().AnnualCost, Is.EqualTo(exceptedPackagedCostRounded));
    }
    //todo add more unit tests
}
