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
    public partial class FormCompras : Form
    {
        public FormCompras()
        {
            InitializeComponent();

            //Llamado del metodo para mostrar los datos de las compras en el data grid view
            BaseDeDatos.cargarDatosCompras(dgvCompras);
        }
    }
}
