using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
public interface ICarritoCompraService {
    Task<bool> AddCarrito( CarritoCompra request );
    Task<List<CarritoCompra>> GetCompraList();

}
