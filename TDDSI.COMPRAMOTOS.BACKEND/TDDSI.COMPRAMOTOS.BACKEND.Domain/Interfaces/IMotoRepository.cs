using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Interfaces;
public interface IMotoRepository 
{
    List<Moto> ObtenerMotos();
    void AgregarMoto(Moto moto);
}
