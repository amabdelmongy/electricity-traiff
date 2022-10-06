namespace Api.Integration.Test;

internal class RequestValidationTest
{
    private const string Url = "/v1/tariff";

    private HttpClient? _httpClient;

    [SetUp]
    public void Setup()
    {
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
    private async Task<List<string>> ExecuteCall(int exceptedConsumption)
    {
        using var message = new HttpRequestMessage(HttpMethod.Get, Url + "/" + exceptedConsumption);
        var response = await _httpClient!.SendAsync(message);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<string>>(result);
    }
    [Test]
    public async Task WHEN_analysis_consumption_less_than_zero_THEN_return_Error()
    {
        var exceptedConsumption = -1;
        var actual = await ExecuteCall(exceptedConsumption);
        Assert.That(actual.Count, Is.EqualTo(1));
        Assert.That(actual.First(), Is.EqualTo(ErrorCodes.Consumptionmustbegreaterthanorequalto1));
    }
}