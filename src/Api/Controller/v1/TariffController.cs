namespace Api.Controller.v1;

[ApiController]
[Route("v1/tariff")]
public class TariffController : ControllerBase
{
    private readonly ITariffService _tariffService;
    private readonly IValidator<int> _validator;

    public TariffController(
        ITariffService tariffService,
        IValidator<int> validator
        )
    {
        _tariffService = tariffService;
        _validator = validator;
    }

    [HttpGet]
    [Route("{consumption}")]
    public ActionResult Get(int consumption)
    {
        var errors = _validator.Validate(consumption);
        if (!errors.IsValid)
            return new BadRequestObjectResult(
                errors.Errors.ToList()
                    .Select(error =>
                        error.ErrorMessage
                    ));

        var result = _tariffService.Analysis(consumption);


        if (result.HasErrors)
            return new BadRequestObjectResult(
                result.Errors
                    .Select(error =>
                        error.Message
                    ));

        var aggregate = result.Value;

        return Ok(
            aggregate!.Select(tariff =>
                new TariffDto
                {
                    Name = tariff.Name,
                    AnnualCost = tariff.AnnualCost,
                    Consumption = tariff.Consumption
                }).OrderBy(t=>t.AnnualCost)
            );
    }
}