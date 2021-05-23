using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteIngaia.Entity
{
    public class ValorUnidadeMedida
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId InternalId { get; set; }
        public long Id { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        // [Range(10, 10000, ErrorMessage="Este campo deve ser menor que 10.000 m²" )]
        public string unidadeMedida { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public double valor { get; set; }
    }
}
