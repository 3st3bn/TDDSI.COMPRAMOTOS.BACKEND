using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TDDSI.COMPRAMOTOS.BACKEND.Api.Controllers {
    [Route( "api/v1/[controller]" )]
    [ApiController]
    public class CompraMotoController : ControllerBase {
        private readonly ICompraMotoService _compraMotoService;
        private readonly ILogger<CompraMotoController> _logger; 

        // Constructor que recibe el servicio y el logger
        public CompraMotoController( ICompraMotoService compraMotoService, ILogger<CompraMotoController> logger ) {
            _compraMotoService = compraMotoService;
            _logger = logger;
        }

        // Endpoint para agregar una nueva moto
        [HttpPost]
        public async Task<ActionResult> AddMotoAsync( [FromBody] Moto request, CancellationToken cancellationToken ) {
            if (request == null) {
                return BadRequest( "La moto no puede ser nula." );
            }

            _logger.LogInformation( "Recibiendo solicitud para agregar una nueva moto." );

            var resultado = await _compraMotoService.AddRoom( request );

            if (resultado) {
                return Ok( "Moto agregada exitosamente." );
            }

            return StatusCode( 500, "Hubo un problema al agregar la moto." );
        }
        [HttpGet( "GetMotoByMarca/{marca}" )]
        public async Task<ActionResult> GetMotosByMarca( string marca ) {
            // Llama al servicio para obtener las motos por marca
            var motos = await _compraMotoService.GetMoto(marca);

            if (motos != null) {
                return Ok( motos ); 
            }
            else {
                // Si no se encontraron motos
                return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
            }
        }
        [HttpGet( "GetMotos" )]
        public async Task<ActionResult> GetMotos() {
            // Llama al servicio para obtener las motos por marca
            var motos = await _compraMotoService.GetMotoList(); 

            if (motos != null) {
                return Ok( motos );
            }
            else {
                // Si no se encontraron motos
                return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
            }
        }
        [HttpGet( "GetMotoByPrecio/{precio}" )]
        public async Task<ActionResult> GetMotosByPrecio( int precio ) {
            // Llama al servicio para obtener las motos por marca
            var motos = await _compraMotoService.GetMotobyPrecio( precio );

            if (motos != null) {
                return Ok( motos );
            }
            else {
                // Si no se encontraron motos
                return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
            }
        }
        [HttpGet( "GetMotoByModelo/{modelo}" )]
        public async Task<ActionResult> GetMotosByModelo( string modelo ) {
            // Llama al servicio para obtener las motos por marca
            var moto = await _compraMotoService.GetMotByModelo( modelo );

            if (moto != null) {
                return Ok( moto );
            }
            else {
                // Si no se encontraron motos
                return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
            }
        }
        [HttpGet( "GetMotoByTipo/{tipo}" )]
        public async Task<ActionResult> GetMotosByTipo( string tipo ) {
            // Llama al servicio para obtener las motos por marca
            var motos = await _compraMotoService.GetMotoByTipo( tipo );

            if (motos != null) {
                return Ok( motos );
            }
            else {
                // Si no se encontraron motos
                return NotFound( new { Message = "No se encontraron motos para la marca especificada." } );
            }
        }
    }
}
