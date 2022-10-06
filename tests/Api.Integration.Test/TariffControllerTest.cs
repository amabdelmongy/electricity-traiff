namespace Api.Integration.Test;

public class TariffControllerTest
{
    private const string Url = "/v1/tariff";

    private Fixture? _fixture;
    private HttpClient? _httpClient;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();

        var application = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddTransient<ITariffService, TariffService>();
                });
            });

        _httpClient = application.CreateClient();
    }
    public static StringContent CreateContent(object contentAsObj) =>
        new StringContent(JsonConvert.SerializeObject(contentAsObj), Encoding.UTF8, "application/json");
    private async Task<List<TariffDto>> ExecuteCall(int exceptedConsumption)
    {
        using var message = new HttpRequestMessage(HttpMethod.Get, Url + "/" + exceptedConsumption);
        var response = await _httpClient!.SendAsync(message);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<TariffDto>>(result);
    }

    [Test]
    public async Task WHEN_analysis_consumption_THEN_return_correct_Names()
    {
        var exceptedBasicName = "Basic tariff";
        var exceptedPackagedName = "Packaged tariff";
        var input = _fixture.Create<int>();

        var actualDtos = await ExecuteCall(input);

        Assert.That(actualDtos.Count, Is.EqualTo(2));
        Assert.That(actualDtos[0].Name, Is.EqualTo(exceptedBasicName));
        Assert.That(actualDtos[1].Name, Is.EqualTo(exceptedPackagedName));
    }



    [Test]
    public async Task WHEN_analysis_consumption_3500_THEN_return_correct_values()
    {
        var exceptedConsumption = 3500;
        var exceptedBasicCostRounded = 830;
        var exceptedPackagedCostRounded = 800;

        var actualDtos = await ExecuteCall(exceptedConsumption);

        Assert.That(actualDtos!.Count, Is.EqualTo(2));
        Assert.That(actualDtos.First().AnnualCost, Is.EqualTo(exceptedPackagedCostRounded));
        Assert.That(actualDtos.Last().AnnualCost, Is.EqualTo(exceptedBasicCostRounded));
    }

    [Test]
    public async Task WHEN_analysis_consumption_4500_THEN_return_correct_values()
    {
        var exceptedConsumption = 4500;
        var exceptedBasicCostRounded = 1050;
        var exceptedPackagedCostRounded = 950;

        var actualDtos = await ExecuteCall(exceptedConsumption);

        Assert.That(actualDtos!.Count, Is.EqualTo(2));
        Assert.That(actualDtos.First().AnnualCost, Is.EqualTo(exceptedPackagedCostRounded));
        Assert.That(actualDtos.Last().AnnualCost, Is.EqualTo(exceptedBasicCostRounded));
    }

    //todo add more tests
}