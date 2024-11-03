using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecasts;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecasts.Dtos;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
internal sealed class WeatherForecastQueryHandler(
        WeatherForecastService forecastService
    ) : IQueryHandler<WeatherForecastQuery, WeatherForecastResponse> {

    public async Task<Result<WeatherForecastResponse>> Handle( WeatherForecastQuery request
        , CancellationToken cancellationToken
    ) {

        IEnumerable<WeatherForecastDto> weatherForecasts = await forecastService.WeatherForecastsAsync();
        return new WeatherForecastResponse( weatherForecasts );
    }
}
