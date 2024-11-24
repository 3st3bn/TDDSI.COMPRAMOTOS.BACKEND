using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Application.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Implementations;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Services;
public class CarritoCompraService : ICarritoCompraService {
    private readonly ICarritoCompra _carritoCompra;
    public CarritoCompraService(ICarritoCompra carritoCompra) {
        _carritoCompra = carritoCompra;        
    }
    public async Task<bool> AddCarrito( CarritoCompra request ) {
        var carrito = new CarritoCompra {
            Name = request.Name,
            identificacion = request.identificacion,
            telefono = request.telefono,
            Modelo = request.Modelo,
            Precio = request.Precio
            
        };
        await _carritoCompra.AddCarrito( carrito );
        return true;

    }

    public async Task<List<CarritoCompra>> GetCompraList() {
        return await _carritoCompra.GetCompraList();
    }
}
