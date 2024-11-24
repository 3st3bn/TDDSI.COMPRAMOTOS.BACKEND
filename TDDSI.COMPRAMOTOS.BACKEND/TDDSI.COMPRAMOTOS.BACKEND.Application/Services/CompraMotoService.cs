using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Services;
public class CompraMotoService : ICompraMotoService {
    private readonly ICompraMotoRepository _compramotoRepository;
    public CompraMotoService(ICompraMotoRepository compraMotoRepository) {
        _compramotoRepository = compraMotoRepository;
    }
    public async Task<bool> AddRoom( Moto request ) {
        var moto = new Moto {
            Tipo = request.Tipo,
            Precio = request.Precio,
            Modelo = request.Modelo,
            Marca = request.Marca,
            EspecificacionesTecnicas = request.EspecificacionesTecnicas,
            AnioFabricacion = request.AnioFabricacion    
            
        };
        await _compramotoRepository.AddMoto( moto );
        return true;
    }

    public async Task<Moto> GetMotByModelo( string modelo ) {
        return await _compramotoRepository.GetMotByModelo(modelo);
    }

    public async Task<List<Moto>> GetMoto( string marca ) {
        return await _compramotoRepository.GetMoto(marca);
    }

    public Task<List<Moto>> GetMotobyPrecio( int precio ) {
        return _compramotoRepository.GetMotobyPrecio( precio );
    }

    public Task<List<Moto>> GetMotoByTipo( string tipo ) {
        return _compramotoRepository.GetMotoByTipo(tipo);
    }

    public Task<List<Moto>> GetMotoList() {
        return _compramotoRepository.GetMotoList();
    }
}
