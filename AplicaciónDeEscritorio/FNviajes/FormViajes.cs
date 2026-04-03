using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics;
using FNviajes.Clases;

namespace FNviajes
{
    public partial class FormViajes : Form
    {
        //Creacion de variables para utilizar valores del form anterior
        private int acceso;
        private string mail;
        private string password;

        //Inicializacion de las variables anteriores
        public FormViajes(int accesoUsuarioFNviajes, string mailFNviajes, string passwordFNviajes)
        {
            InitializeComponent();

            BaseDeDatos.cargarDatosViajes<Viajes>("fnviajes", "viajes", dgvViajes);
            acceso = accesoUsuarioFNviajes;
            mail = mailFNviajes;
            password = passwordFNviajes;
        }

        //Boton para agregar un nuevo viaje a la base de datos y mostrarlo en el data grid view
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            acceso = BaseDeDatos.verificarUsuario(mail, password);
            if (txtId.Text != "" && txtNombre.Text != "" && txtLugar.Text != "" && txtDuracion.Text != "" && txtImg.Text != "" && txtDesc.Text != "" && txtPrecio.Text != "")
            {
                if (acceso == 2)
                {
                    int id = int.Parse(txtId.Text);
                    string nombre = txtNombre.Text;
                    string lugar = txtLugar.Text;
                    string desc = txtDesc.Text;
                    int duracion = int.Parse(txtDuracion.Text);
                    string img = txtImg.Text;
                    int precio = int.Parse(txtPrecio.Text);

                    txtId.Clear();
                    txtNombre.Clear();
                    txtLugar.Clear();
                    txtDesc.Clear();
                    txtDuracion.Clear();
                    txtImg.Clear();
                    txtPrecio.Clear();


                    BaseDeDatos.agregarViajes(dgvViajes, id, nombre, lugar, desc, duracion, img, precio);

                    BaseDeDatos.cargarDatosViajes<Viajes>("fnviajes", "viajes", dgvViajes);
                }
                else
                {
                    MessageBox.Show("No tenes el nivel de acceso necesario para realizar esta accion.");
                }  
            }
            else
            {
                MessageBox.Show("No se puede agregar un viaje con campos incompletos.");
            }
        }

        //Boton para eliminar viajes ya existentes de la base de datos y luego actualizar el data grid view
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            acceso = BaseDeDatos.verificarUsuario(mail, password);
            if (txtId.Text != "" && txtNombre.Text != "" && txtLugar.Text != "" && txtDuracion.Text != "" && txtImg.Text != "" && txtDesc.Text != "" && txtPrecio.Text != "")
            {
                if (acceso == 2)
                {
                    int id = int.Parse(txtId.Text);

                    txtId.Clear();
                    txtNombre.Clear();
                    txtLugar.Clear();
                    txtDesc.Clear();
                    txtDuracion.Clear();
                    txtImg.Clear();
                    txtPrecio.Clear();

                    BaseDeDatos.eliminarViaje(id);
                    BaseDeDatos.cargarDatosViajes<Viajes>("fnviajes", "viajes", dgvViajes);
                }
                else
                {
                    MessageBox.Show("No tenes el nivel de acceso necesario para realizar esta accion.");
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar un viaje con campos incompletos.");
            }
            
        }

        //Boton para modificar viajes ya existentes en la base de datos y luego actualizar el data grid view
        private void btnModificar_Click(object sender, EventArgs e)
        {
            acceso = BaseDeDatos.verificarUsuario(mail, password);
            if (txtId.Text != "" && txtNombre.Text != "" && txtLugar.Text != "" && txtDuracion.Text != "" && txtImg.Text != "" && txtDesc.Text != "" && txtPrecio.Text != "")
            {
                if (acceso == 2)
                {
                    int id = int.Parse(txtId.Text);
                    string nombre = txtNombre.Text;
                    string lugar = txtLugar.Text;
                    string desc = txtDesc.Text;
                    int duracion = int.Parse(txtDuracion.Text);
                    string img = txtImg.Text;
                    int precio = int.Parse(txtPrecio.Text);

                    txtId.Clear();
                    txtNombre.Clear();
                    txtLugar.Clear();
                    txtDesc.Clear();
                    txtDuracion.Clear();
                    txtImg.Clear();
                    txtPrecio.Clear();

                    BaseDeDatos.modificarViaje(id, nombre, lugar, desc, duracion, img, precio);
                    BaseDeDatos.cargarDatosViajes<Viajes>("fnviajes", "viajes", dgvViajes);
                }
                else
                {
                    MessageBox.Show("No tenes el nivel de acceso necesario para realizar esta accion.");
                }
                
            }
            else
            {
                MessageBox.Show("No se puede modificar un viaje con campos incompletos.");
            }
            
        }

        //Evento de que cuando haces click en alguna celda del data grid view, los valores se muestren en los textbox
        private void dgvViajes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow fila = dgvViajes.Rows[e.RowIndex];

                txtId.Text = fila.Cells[1].Value.ToString();
                txtNombre.Text = fila.Cells[2].Value.ToString();
                txtLugar.Text = fila.Cells[3].Value.ToString();
                txtDesc.Text = fila.Cells[4].Value.ToString();
                txtDuracion.Text = fila.Cells[5].Value.ToString();
                txtImg.Text = fila.Cells[6].Value.ToString();
                txtPrecio.Text = fila.Cells[7].Value.ToString();
            }
        }
    }
}