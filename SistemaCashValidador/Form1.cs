using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using SistemaCashValidador.Constrollers;
using SistemaCashValidador.Clases;
using System.Threading;
using System.Collections;

namespace SistemaCashValidador
{
    public partial class Form1 : Form
    {
        private Controller_Transaccion controllerTransaccion;

        public Form1()
        {
            InitializeComponent();
            controllerTransaccion = new Controller_Transaccion();
            this.controllerTransaccion.errorEvent += messageError;
            this.controllerTransaccion.ListBillsEvent += updateListBill;
            this.controllerTransaccion.ListCoinsEvent += updateListCoins;
            this.controllerTransaccion.storeEvent += updateLbStore;
            this.controllerTransaccion.transactionEvent += updateLbTransaccion;
            this.controllerTransaccion.setConfigEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.controllerTransaccion.getStatusDevices();
            this.showStored(this.controllerTransaccion.getStoredDevices());
            //listBilletes.Enabled = true;
        }

        private void generarTransaccion(object sender, EventArgs e)
        {
            int depositoRequerido = Int32.Parse(inputEfectivo.Text);
            this.controllerTransaccion.setNewPayout(depositoRequerido);    
        }

        private void showStored(Hashtable stored)
        {
            lbM1.Text = stored["1"].ToString();
            lbM2.Text = stored["2"].ToString();
            lbM5.Text = stored["5"].ToString();
            lbM10.Text = stored["10"].ToString();
            lbB20.Text = stored["20"].ToString();
            lbB50.Text = stored["50"].ToString();
            lbB100.Text = stored["100"].ToString();
            lbB200.Text = stored["200"].ToString();
            lbB500.Text = stored["500"].ToString();
        }

        #region Eventos Para actualizar vistas

        private void messageError(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { messageError(sender, e); }));
            }
            else
            {
                if (e.lbMessage != "")
                {
                    lbMensajeProceso.ForeColor = Color.Red;
                    lbMensajeProceso.Text = e.lbMessage;
                }
                else
                {
                    lbMensajeProceso.ForeColor = Color.Green;
                    lbMensajeProceso.Text = "Dispositivos Conectados";
                }
                lbMensajeProceso.Refresh();
            }
        }

        private void dialogError(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { dialogError(sender, e); }));
            }
            else
            {
                
            }
        }

        private void updateListBill(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { updateListBill(sender, e); }));
            }
            else
            {
                if (e.listBills == 0)
                {
                    listBilletes.Items.Clear();
                    listBilletes.Refresh();
                }
                else
                {
                    listBilletes.Items.Add("$" + e.listBills.ToString());
                    listBilletes.Refresh();

                }
            }
        }

        private void updateListCoins(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { updateListBill(sender, e); }));
            }
            else
            {
                if (e.listCoins == 0)
                {
                    listMonedas.Items.Clear();
                    listMonedas.Refresh();
                }
                else
                {
                    listMonedas.Items.Add("$" + e.listCoins.ToString());
                    listMonedas.Refresh();

                }
            }
        }

        private void updateLbStore(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { updateLbStore(sender, e); }));
            }
            else
            {
                lbM1.Text = e.lbMoney1.ToString();
                lbM1.Refresh();
                lbM2.Text = e.lbMoney2.ToString();
                lbM2.Refresh();
                lbM5.Text = e.lbMoney5.ToString();
                lbM5.Refresh();
                lbM10.Text = e.lbMoney10.ToString();
                lbM10.Refresh();
                lbB20.Text = e.lbBill20.ToString();
                lbB20.Refresh();
                lbB50.Text = e.lbBill50.ToString();
                lbB50.Refresh();
                lbB100.Text = e.lbBill100.ToString();
                lbB100.Refresh();
                lbB200.Text = e.lbBill200.ToString();
                lbB200.Refresh();
                lbB500.Text = e.lbBill500.ToString();
                lbB500.Refresh();
            }
        }

        private void updateLbTransaccion(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { updateLbTransaccion(sender, e); }));
            }
            else
            {
                if (e.lbTotal == 0)
                {
                    lbCambio.Text = "$0";
                    lbCambio.Refresh();
                    lbTotal.Text = "$0";
                    lbTotal.Refresh();
                }
                else
                {
                    lbCambio.Text = "$" + e.lbCambio.ToString();
                    lbCambio.Refresh();
                    lbTotal.Text = "$" + e.lbTotal.ToString();
                    lbTotal.Refresh();
                }
            }
        }

        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.controllerTransaccion.closesDevices();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            Dialogo dialogo = new Dialogo();
            dialogo.ShowDialog();
        }
    }
}
