using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FNviajes.Clases
{
    //Definicion de la clase Compras
    internal class Compras
    {
        //Esquema de como se guardaran y mostraran los datos de la base de datos
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public int id { get; set; }

        [BsonElement("usuario")]

        public int usuario { get; set; }

        [BsonElement("articulos")]
        public int[] articulos { get; set; }

        [BsonElement("monto")]
        public int monto { get; set; }

        [BsonElement("__v")]

        public int __v { get; set; }
    }
}
