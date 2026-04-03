using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FNviajes.Clases;

namespace FNviajes
{
    public partial class FormUsuario : Form
    {
        //Creacion de variables para utilizar valores del form anterior
        private int acceso;
        private string mail;
        private string password;

        //Inicializacion de las variables anteriores
        public FormUsuario(int accesoUsuarioFNviajes, string mailFNviajes, string passwordFNviajes)
        {
            InitializeComponent();

            BaseDeDatos.cargarDatosUsuario(dgvUsuario);

            acceso = accesoUsuarioFNviajes;
            mail = mailFNviajes;
            password = passwordFNviajes;
        }

        //Evento de que cuando haces click en alguna celda del data grid view, los valores se muestren en los textbox
        private void dgvUsuario_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow fila = dgvUsuario.Rows[e.RowIndex];
                txtId.Text = fila.Cells[1].Value.ToString();
                txtNivelDeAcceso.Text = fila.Cells[5].Value.ToString();
            }
        }

        //Boton para poder modificar el nivel de acceso de los usuarios
        private void btnModificarNivelDeAcceso_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtNivelDeAcceso.Text != "")
            {
                if (acceso == 2)
                {
                    var id = int.Parse(txtId.Text);
                    var textAcceso = int.Parse(txtNivelDeAcceso.Text);
                    txtId.Clear();
                    txtNivelDeAcceso.Clear();

                    if(id > 2)
                    {
                        id = 2;
                    }else if(id < 0)
                    {
                        id = 0;
                    }
                    
                    BaseDeDatos.modificarNivelDeAcceso(id, textAcceso);
                    BaseDeDatos.cargarDatosUsuario(dgvUsuario);
                    acceso = BaseDeDatos.verificarUsuario(mail, password);
                }
                else
                {
                    MessageBox.Show("No tenes el nivel de acceso necesario para realizar esta accion.");
                }
            }
            else
            {
                MessageBox.Show("No se puede modificar el nivel de acceso con algun campo en blanco.");
            }
            
        }
            
    }
}
