using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
public interface ICompraMotoRepository {
    Task AddMoto( Moto moto );
    Task<List<Moto>> GetMotoList();
    Task<List<Moto>> GetMotobyPrecio( int precio );
    Task<List<Moto>> GetMoto( string marca );
    Task<Moto> GetMotByModelo( string modelo );
    Task<List<Moto>> GetMotoByTipo( string tipo);

}

