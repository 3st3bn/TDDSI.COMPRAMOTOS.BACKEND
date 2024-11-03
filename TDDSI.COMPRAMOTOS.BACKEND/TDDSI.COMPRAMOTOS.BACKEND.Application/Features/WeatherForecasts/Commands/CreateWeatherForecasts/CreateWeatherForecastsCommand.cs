using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
public record CreateWeatherForecastsCommand(
    ) : ICommand<CreateWeatherForecastsResponse>;
