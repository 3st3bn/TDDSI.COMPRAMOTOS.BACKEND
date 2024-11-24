using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
public interface ICompraMotoService {
    Task<bool> AddRoom( Moto request );
    Task<List<Moto>> GetMoto( string marca );
    Task<List<Moto>> GetMotoList();
    Task<List<Moto>> GetMotobyPrecio( int precio );
    Task<Moto> GetMotByModelo( string modelo );
    Task<List<Moto>> GetMotoByTipo( string tipo );

}
    