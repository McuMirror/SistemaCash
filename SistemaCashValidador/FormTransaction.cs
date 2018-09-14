using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCashValidador
{
    public partial class FormTransaction : Form
    {
        
        public FormTransaction()
        {
            InitializeComponent();            
        }

        public void getDataTransaction(Hashtable data)
        {
            
            tbPago.Text = data["Pago"].ToString();
            tbDeposito.Text = data["Depositado"].ToString();
            tbCambio.Text = data["Cambio"].ToString();
            tb1.Text = data["M1"].ToString();
            tb2.Text = data["M2"].ToString();
            tb5.Text = data["M5"].ToString();
            tb10.Text = data["M10"].ToString();
            tb20.Text = data["B20"].ToString();
            tb50.Text = data["B50"].ToString();
            tb100.Text = data["B100"].ToString();
            tb200.Text = data["B200"].ToString();
            tb500.Text = data["B500"].ToString();
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
