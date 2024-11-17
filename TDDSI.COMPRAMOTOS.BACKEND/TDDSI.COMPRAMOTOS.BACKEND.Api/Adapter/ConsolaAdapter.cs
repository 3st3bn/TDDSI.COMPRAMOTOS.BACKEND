using TDDSI.COMPRAMOTOS.BACKEND.Application.Services;

namespace TDDSI.COMPRAMOTOS.BACKEND.Api.Adapter;

public class ConsolaAdapter {
    private readonly MotoService _motoService;
    public ConsolaAdapter(MotoService motoService) {
        _motoService = motoService;
    }
    public void MostrarMotos() {
        var motos = _motoService.MostrarMotos();
        foreach (var moto in motos) {
            Console.WriteLine( $"Marca: {moto.Marca}, Modelo: {moto.Modelo}, Precio: {moto.Precio}" );
        }
    }
}
