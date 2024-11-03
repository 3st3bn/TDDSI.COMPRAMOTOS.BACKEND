using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecasts.Dtos;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
public record WeatherForecastResponse(
    IEnumerable<WeatherForecastDto> WeatherForecasts
);
