using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQuery(
    Guid Id
) : IQuery<WeatherForecastHistoryByIdQueryResponse>;