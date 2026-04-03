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
    public partial class FormIniciarSesion : Form
    {
        //Creacion de variables para utilizar valores del form anterior
        private FormInicio formInicio;

        //Inicializacion de las variables anteriores
        public FormIniciarSesion(FormInicio formInicio)
        {
            InitializeComponent();

            this.formInicio = formInicio;

            this.FormClosing += FormIniciarSesion_FormClosing;
        }

        //Boton que hace la evaluacion de el mail, la contraseña y el acceso
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            int accesoUsuario = -1;
            if (txtboxMail.Text != "" && txtboxContraseña.Text != "")
            {
                var mail = txtboxMail.Text.Trim();
                var password = txtboxContraseña.Text.Trim();
                accesoUsuario = BaseDeDatos.verificarUsuario(mail, password);

                if (accesoUsuario >= 1)
                {
                    FormFNviajes formFNviajes = new FormFNviajes(this, accesoUsuario, mail, password);
                    formFNviajes.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Acceso denegado. Verifique si su mail, contraseña o nivel de acceso son correctos.");
                }
                
            }
            else
            {
                MessageBox.Show("No puede iniciar sesion con algun campo en blanco.");
            }
        }

        //Evento para que se muestre el form anterior cuando se cierra el actual
        private void FormIniciarSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            formInicio.Show();
        }
    }
}
