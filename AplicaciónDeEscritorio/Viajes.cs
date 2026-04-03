using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace FNviajes.Clases
{
    public class Viaje
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id")]
        public string id { get; set; }

        [BsonElement("nombre")]
        public double nombre { get; set; }

        [BsonElement("dias")]
        public int dias { get; set; }

        [BsonElement("precio")]
        public int precio { get; set; }
    }

}