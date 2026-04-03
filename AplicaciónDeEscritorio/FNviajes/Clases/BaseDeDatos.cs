using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FNviajes.Clases
{
    //Definicion de la clase BaseDeDatos
    public static class BaseDeDatos
    {
        const string conexionUri = "mongodb://localhost:27017/fnviajes";
        private static readonly MongoClientSettings settings = MongoClientSettings.FromConnectionString(conexionUri);


        private static readonly MongoClient cliente;

        //Metodo para conectarse a la base de datos
        static BaseDeDatos()
        {
            try
            {
                // Set the ServerApi field of the settings object to set the version of the Stable API on the client
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);

                // Create a new client and connect to the server
                cliente = new MongoClient(settings);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Error: No se pudo conectar a la base de datos. " + ex.Message);
            }
        }

        //Metodo para cargar los viajes en el data grid view
        public static void cargarDatosViajes<T>(string nombreBase, string nombreColeccion, DataGridView nombreDgv)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase(nombreBase);
                var coleccion = baseDeDatos.GetCollection<T>(nombreColeccion);
                List<T> listaColeccion = coleccion.Find(_ => true).ToList();
                nombreDgv.DataSource = listaColeccion;
                nombreDgv.Columns["_id"].Visible = false;
                nombreDgv.Columns["__v"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo cargar los datos de los viajes. " + ex.Message);
            }
        }

        //Metodo para agregar viajes al data grid view
        public static void agregarViajes(DataGridView viajeDgv, int idA, string nombreA, string lugarA, string descA, int duracionA, string imgA, int precioA)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Viajes>("viajes");

                var nuevoViaje = new Viajes
                {
                    id = idA,
                    nombre = nombreA,
                    lugar = lugarA,
                    desc = descA,
                    duracion = duracionA,
                    img = imgA,
                    precio = precioA
                };

                coleccion.InsertOne(nuevoViaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo agregar el viaje. " + ex.Message);
            }
        }

        //Metodo para eliminar viajes
        public static void eliminarViaje(int textoId)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Viajes>("viajes");

                var eliminar = Builders<Viajes>.Filter.Eq(v => v.id, textoId);
                coleccion.DeleteOne(eliminar);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo eliminar el viaje. " + ex.Message);
            }
        }

        //Metodo para modificar viajes
        public static void modificarViaje(int textoId, string textNombre, string textLugar, string textDesc, int textDuracion, string textImg, int textPrecio)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Viajes>("viajes");

                var documento = Builders<Viajes>.Filter.Eq(v => v.id, textoId);
                var actualizacion = Builders<Viajes>.Update
                    .Set(v => v.id, textoId)
                    .Set(v => v.nombre, textNombre)
                    .Set(v => v.lugar, textLugar)
                    .Set(v => v.desc, textDesc)
                    .Set(v => v.duracion, textDuracion)
                    .Set(v => v.img, textImg)
                    .Set(v => v.precio, textPrecio);

                coleccion.UpdateMany(documento, actualizacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo modificar el viaje. " + ex.Message);
            }
        }

        //Metodo para cargar los datos de las compras al data grid view
        public static void cargarDatosCompras(DataGridView nombreDgv)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Compras>("compras");

                var listaColeccion = coleccion.Find(_ => true).ToList();

                var mostrarListaColeccion = listaColeccion.Select(c => new
                {
                    c._id,
                    c.id,
                    c.usuario,
                    articulos = string.Join(", ", c.articulos)
                }).ToList();

                nombreDgv.DataSource = mostrarListaColeccion;
                nombreDgv.Columns["_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo cargar las compras. " + ex.Message);
            }
        }

        //Metodo para cargar los datos de las compras al data grid view
        public static void cargarDatosUsuario(DataGridView nombreDgv)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Usuarios>("usuarios");

                var listaColeccion = coleccion.Find(_ => true).ToList();

                var mostrarListaColeccion = listaColeccion.Select(u => new
                {
                    u._id,
                    u.id,
                    u.nombre,
                    u.apellido,
                    u.mail,
                    u.acceso,
                    u.password,
                    carrito = string.Join(", ", u.carrito),
                    compras = string.Join(", ", u.compras)
                }).ToList();

                nombreDgv.DataSource = mostrarListaColeccion;
                nombreDgv.Columns["_id"].Visible = false;
                nombreDgv.Columns["password"].Visible = false;
            }
   
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo cargar los usuarios. " + ex.Message);
            }
        }

        //Metodo para modificar el nivel de acceso de los usuarios
        public static void modificarNivelDeAcceso(int textoId, int textoAcceso)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Usuarios>("usuarios");
                var documento = Builders<Usuarios>.Filter.Eq(u => u.id, textoId);
                var actualizacion = Builders<Usuarios>.Update.Set(u => u.acceso, textoAcceso);


                coleccion.UpdateMany(documento, actualizacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo modificar el nivel de acceso. " + ex.Message);
            }
        }

        //Metodo para verificar el usuarios (mail, contraseña y acceso)
        public static int verificarUsuario(string mail, string password)
        {
            try
            {
                var baseDeDatos = cliente.GetDatabase("fnviajes");
                var coleccion = baseDeDatos.GetCollection<Usuarios>("usuarios");

                var filtro = Builders<Usuarios>.Filter.And(
                    Builders<Usuarios>.Filter.Eq(u => u.mail, mail),
                    Builders<Usuarios>.Filter.Eq(u => u.password, password),
                    Builders<Usuarios>.Filter.Gte(u => u.acceso, 1)
                );
                var usuario = coleccion.Find(filtro).FirstOrDefault();

                if (usuario != null)
                {
                    return usuario.acceso;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: No se pudo verificar el usuario. " + ex.Message);
                return -1;
            }
            
        }
    }
}