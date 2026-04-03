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
    internal class Usuarios
    {
        //Esquema de como se guardaran y mostraran los datos de la base de datos
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public int id { get; set; }

        [BsonElement("nombre")]

        public string nombre { get; set; }

        [BsonElement("apellido")]

        public string apellido { get; set; }

        [BsonElement("mail")]
        public string mail { get; set; }

        [BsonElement("acceso")]

        public int acceso { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("carrito")]
        public int[] carrito { get; set; }

        [BsonElement("compras")]

        public int[] compras { get; set; }

        [BsonElement("__v")]

        public int __v { get; set; }
    }
}
