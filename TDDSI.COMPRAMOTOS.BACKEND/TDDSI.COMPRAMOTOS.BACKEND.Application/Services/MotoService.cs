using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Services;
public class MotoService 
{
    private readonly IMotoRepository _motoRepository;
    public MotoService(IMotoRepository motoRepository) 
    {
        _motoRepository = motoRepository;
    }
    public List<Moto> MostrarMotos() {
        return _motoRepository.ObtenerMotos();
    }
    public List<Moto> FiltrarMotos(string marca = null, string tipo = null, decimal? precio = null, int? anio = null ) {
        var motos = _motoRepository.ObtenerMotos();
        return motos.Where(m => 
            (marca == null || m.Marca == marca) &&
            (tipo ==  null || m.Tipo == tipo) &&
            (!precio.HasValue || m.Precio <= precio.Value) &&
            (!anio.HasValue || m.AnioFabricacion == anio.Value)).ToList();
    }
    public void AgregarMoto (Moto moto) {
        _motoRepository.AgregarMoto(moto);
    }
}
