using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FNviajes.Clases
{
    //Definicion de la clase BaseDeDatos
    internal class Viajes
    {
        //Esquema de como se guardaran y mostraran los datos de la base de datos
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public int id { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }

        [BsonElement("lugar")]

        public string lugar { get; set; }

        [BsonElement("desc")]

        public string desc { get; set; }

        [BsonElement("duracion")]
        public int duracion { get; set; }

        [BsonElement("img")]

        public string img { get; set; }

        [BsonElement("precio")]
        public int precio { get; set; }

        [BsonElement("__v")]

        public int __v { get; set; }
    }
}
