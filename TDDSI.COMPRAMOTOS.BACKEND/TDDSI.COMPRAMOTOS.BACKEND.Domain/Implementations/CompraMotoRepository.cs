using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Implementations;
public class CompraMotoRepository : ICompraMotoRepository {
    public List<Moto> MotoList { get; set; }
    private readonly IMongoCollection<Moto> _motos;
    public CompraMotoRepository(IConfiguration configuration) {
        var client = new MongoClient( configuration.GetConnectionString( "MongoDb" ) );
        var database = client.GetDatabase( "CompraMotos" );
        _motos = database.GetCollection<Moto>( "Motos" );
    }
    public async Task AddMoto( Moto moto ) {
        try {
            await _motos.InsertOneAsync( moto );
        }
        catch (Exception ex){
            Console.WriteLine( $"Error al registrar la boleta: {ex.Message}" );
            throw;
        }
    }

    public async Task<List<Moto>> GetMoto( string marca ) {
        return await _motos.Find<Moto>( moto => moto.Marca == marca.ToLower()).ToListAsync();
    }

    public async Task<List<Moto>> GetMotoList() {
        return await _motos.Find<Moto>( _ => true ).ToListAsync();
    }
    public async Task<List<Moto>> GetMotobyPrecio( int precio ) {
        return await _motos.Find<Moto>( moto => moto.Precio == precio).ToListAsync();
    }

    public async Task<Moto> GetMotByModelo( string modelo ) {
        return await _motos.Find<Moto>( moto => moto.Modelo == modelo.ToLower()).FirstOrDefaultAsync();
    }

    public async Task<List<Moto>> GetMotoByTipo( string tipo ) {
        return await _motos.Find<Moto>(moto => moto.Tipo == tipo.ToLower()).ToListAsync();
    }
}
