using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Messaging;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Abstractions;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Helpers;

namespace TDDSI.COMPRAMOTOS.BACKEND.Api.Controllers;
[Route( "api/v1/[controller]" )]
public class WeatherForecastController(
    ILogger<WeatherForecastController> logger,
    IDispatch dispatch
) : ControllerBase {

    [HttpGet()]
    public async Task<ActionResult<Result>> WeatherForecastAsync(
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                "WeatherForecastAsync",
                nameof( WeatherForecastController )
        );

        return await dispatch.Send(
            new WeatherForecastQuery(),
            cancellationToken
        );
    }

    [HttpPost()]
    public async Task<ActionResult<Result>> CreateWeatherForecastAsync(
            CancellationToken cancellationToken
        ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                "WeatherForecastAsync",
                nameof( WeatherForecastController )
        );

        return await dispatch.Send(
            new CreateWeatherForecastsCommand(),
            cancellationToken
        );
    }
}
