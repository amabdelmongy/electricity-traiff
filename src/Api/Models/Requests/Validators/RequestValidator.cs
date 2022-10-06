namespace Api.Models.Requests.Validators;

public class RequestValidator : AbstractValidator<int>
{
    public RequestValidator()
    {
        RuleFor(x => x)
            .GreaterThanOrEqualTo(0)
            .WithMessage(ErrorCodes.Consumptionmustbegreaterthanorequalto1);
    }
}
