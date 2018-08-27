using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCashValidador.Constrollers;

namespace SistemaCashValidador
{
    public partial class Dialogo : Form
    {
        private Controller_Transaccion controllerTransaccion;
        
        public Dialogo(Controller_Transaccion controller)
        {
            InitializeComponent();
            controllerTransaccion = controller;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        
    }
}
