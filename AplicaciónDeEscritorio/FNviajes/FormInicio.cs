using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNviajes
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
            
        }

        //Boton para abir el form de inicio de sesion
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            FormIniciarSesion inicioSesionForm = new FormIniciarSesion(this);
            inicioSesionForm.Show();
            this.Hide();
        }
    }
}
