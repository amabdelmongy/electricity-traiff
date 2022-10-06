namespace Domain.Service;

public interface ITariffService
{
    Result<List<Tariff>> Analysis(int consumption);
}