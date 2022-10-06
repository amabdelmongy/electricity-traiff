using Api.Models.Requests.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITariffService, TariffService>();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddOptions();
builder.Services.AddTransient<IValidator<int>, RequestValidator>();
builder.Services.AddSwaggerGen();
// remove default logging providers
builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Host.UseSerilog(logger);

var app = builder.Build();
app.MapHealthChecks("/health");
app.MapControllers();
// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ariff API V1");
});

app.Logger.LogInformation("The application started");
app.Run();
namespace Api
{
    public partial class Program { }
}