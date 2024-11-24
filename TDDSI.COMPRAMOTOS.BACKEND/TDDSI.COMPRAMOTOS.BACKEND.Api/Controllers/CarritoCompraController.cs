using Microsoft.AspNetCore.Mvc;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Services;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Api.Controllers;
[Route( "api/v1/[controller]" )]
[ApiController]
public class CarritoCompraController : ControllerBase {
    private readonly ILogger<CarritoCompraController> _logger;
    private readonly ICarritoCompraService _carritoCompraService;
    public CarritoCompraController( ICarritoCompraService carritoCompra, ILogger<CarritoCompraController> logger ) {
        _carritoCompraService = carritoCompra;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult> AddCarritoAsync( [FromBody] CarritoCompra request, CancellationToken cancellationToken ) {
        if (request == null) {
            return BadRequest( "La moto no puede ser nula." );
        }

        _logger.LogInformation( "Recibiendo solicitud para agregar una nueva moto." );

        var resultado = await _carritoCompraService.AddCarrito( request );

        if (resultado) {
            return Ok( "Moto agregada exitosamente." );
        }

        return StatusCode( 500, "Hubo un problema al agregar la moto." );
    }
    [HttpGet( "GetCompras" )]
    public async Task<ActionResult> GetCompras() {
        // Llama al servicio para obtener las motos por marca
        var compras = await _carritoCompraService.GetCompraList();

        if (compras != null) {
            return Ok( compras );
        }
        else {
            // Si no se encontraron motos
            return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
        }
    }
}
