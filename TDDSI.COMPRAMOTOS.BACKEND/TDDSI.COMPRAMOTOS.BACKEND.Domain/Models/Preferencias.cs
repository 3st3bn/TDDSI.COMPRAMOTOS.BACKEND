using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;
public class Preferencias {
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal Precio { get; set; }
    public string Tipo { get; set; }
}
