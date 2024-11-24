using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Implementations;
public class CarritoCompraRepository : ICarritoCompra {
    public List<CarritoCompra> CarritoCompraList { get; set; }
    private readonly IMongoCollection<CarritoCompra> _carritoCompra;
    public CarritoCompraRepository( IConfiguration configuration ) {
        var client = new MongoClient( configuration.GetConnectionString( "MongoDb" ) );
        var database = client.GetDatabase( "CompraMotos" );
        _carritoCompra = database.GetCollection<CarritoCompra>( "Compras" );
    }
    public async Task AddCarrito( CarritoCompra carritoCompra ) {
        try {
            await _carritoCompra.InsertOneAsync( carritoCompra );
        }
        catch (Exception ex) {
            Console.WriteLine( $"Error al registrar la boleta: {ex.Message}" );
            throw;
        }
    }

    public async Task<List<CarritoCompra>> GetCompraList() {
        return await _carritoCompra.Find<CarritoCompra>( _ => true ).ToListAsync();

    }
}
