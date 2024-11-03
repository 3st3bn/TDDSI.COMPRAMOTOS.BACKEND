using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Events.NotifyWeatherForecastCreated;
public record NotifyWeatherForecastCreatedCommand(
    string Proccess
) : INotify;
