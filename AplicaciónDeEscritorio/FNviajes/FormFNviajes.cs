using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNviajes
{
    public partial class FormFNviajes : Form
    {
        //Creacion de variables para utilizar valores del form anterior
        private FormIniciarSesion formIniciarSesion;

        private int accesoUsuarioFNviajes;
        private string mailFNviajes;
        private string passwordFNviajes;

        //Inicializacion de las variables anteriores
        public FormFNviajes(FormIniciarSesion formIniciarSesion, int accesoUsuario, string mail, string password)
        {
            InitializeComponent();
            this.formIniciarSesion = formIniciarSesion;
            this.FormClosing += FormFNviajes_FormClosing;
            accesoUsuarioFNviajes = accesoUsuario;
            mailFNviajes = mail;
            passwordFNviajes = password;

        }

        //Boton del menu para acceder al apartado de los viajes
        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViajes formTodosLosViajes = new FormViajes(accesoUsuarioFNviajes, mailFNviajes, passwordFNviajes);

            formTodosLosViajes.MdiParent = this;

            formTodosLosViajes.Show();
        }

        //Boton del menu para acceder al apartado de los usuarios
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario(accesoUsuarioFNviajes, mailFNviajes, passwordFNviajes);

            formUsuario.MdiParent = this;

            formUsuario.Show();
        }

        //Boton del menu para acceder al apartado de las compras
        private void gananciaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCompras formCompras = new FormCompras();

            formCompras.MdiParent = this;

            formCompras.Show();
        }

        //Evento para que se muestre el form anterior cuando se cierra el actual
        private void FormFNviajes_FormClosing(object sender, FormClosingEventArgs e)
        {
            formIniciarSesion.Show();
        }
    }
}
