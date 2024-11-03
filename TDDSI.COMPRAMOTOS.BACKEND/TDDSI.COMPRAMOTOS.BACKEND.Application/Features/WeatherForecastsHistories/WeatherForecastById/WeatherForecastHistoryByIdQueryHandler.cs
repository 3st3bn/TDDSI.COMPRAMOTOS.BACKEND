using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Ports;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecasts.Dtos;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecastsHistories;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecastsHistories.WeatherForecastById;
internal sealed record class WeatherForecastHistoryByIdQueryHandler(
          WeatherForecastsHistoryService WeatherForecastsHistoryService
        , IJsonConfiguration JsonConfiguration
    ) : IQueryHandler<WeatherForecastHistoryByIdQuery, WeatherForecastHistoryByIdQueryResponse> {

    public async Task<Result<WeatherForecastHistoryByIdQueryResponse>> Handle(
          WeatherForecastHistoryByIdQuery request
        , CancellationToken cancellationToken
    ) {
        var history = await WeatherForecastsHistoryService.GetByAsync(
              request.Id
            , cancellationToken
        );

        var result = new WeatherForecastHistoryByIdQueryResponse(
            history.Id
            , JsonConfiguration.DeserializeObject<WeatherForecastByIdDto>( history.Proccess! )
            , history.CreatedDate
            , history.CreatedByUser
            , history.LastModifiedDate
            , history.LastModifiedByUser
        );

        return result;
    }
}
