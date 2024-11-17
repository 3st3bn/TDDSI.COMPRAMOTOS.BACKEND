using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Api.Adapter;

public class MotoRepositoryEnMemoria {
    private List<Moto> motos = new List<Moto>();
    public List<Moto> ObtenerMotos() {
        return motos;
    }
    public void AgregarMoto(Moto moto) {
        motos.Add(moto);
    }
}
