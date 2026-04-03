using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Windows.Forms;

using namespace FNviajes
{
    public class BaseDeDatos
    {


        public static void mostrarViajes()
        {
            string conexion = "mongodb+srv://mateonoba:<ISFT220>@cluster0.ixldm1o.mongodb.net/FNviajes?retryWrites=true&w=majority&appName=Cluster0";
            var cliente = new MongoClient(conexion);
            var baseDeDatos = cliente.GetBaseDeDatos("FNviajes");
            var coleccion = baseDeDatos.GetColeccion<BsonDocument>("viajes");
            var documento = coleccion.Find(new BsonDocument()).Tolist();

            return coleccion.Find(_ => true).ToList();
        }


    }
}

