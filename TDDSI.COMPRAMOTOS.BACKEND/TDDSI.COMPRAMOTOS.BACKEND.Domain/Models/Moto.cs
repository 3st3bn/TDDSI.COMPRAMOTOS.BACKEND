﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDSI.COMPRAMOTOS.BACKEND.Domain.Models;
public class Moto
{
    [BsonId]
    [BsonRepresentation( BsonType.ObjectId )]
    public string Id { get; set; }
    public string Marca {  get; set; }
    public string Modelo { get; set; }  
    public decimal Precio { get; set; }
    public int AnioFabricacion { get; set; }
    public string Tipo { get; set; }
    public string EspecificacionesTecnicas { get; set; }
}
