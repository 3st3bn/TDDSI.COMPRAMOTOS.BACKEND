using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
public record WeatherForecastQuery(
) : IQuery<WeatherForecastResponse>;
