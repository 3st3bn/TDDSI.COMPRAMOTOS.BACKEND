using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;
public class CarritoCompra {
    [BsonId]
    [BsonRepresentation( BsonType.ObjectId )]
    public string Id { get; set; }
    public string Name { get; set; }
    public string telefono { get; set; }

    public string identificacion { get; set; }
    public string Modelo { get; set; }
    public decimal Precio { get; set; }
}
