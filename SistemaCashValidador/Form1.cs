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
        private Point position = Point.Empty;
        private bool move;

        public Form1()
        {
            InitializeComponent();
            controllerTransaccion = new Controller_Transaccion();
            this.controllerTransaccion.errorEvent += messageError;
            this.controllerTransaccion.informationDeviceEvent += messageError;
            this.controllerTransaccion.storeEvent += updateLbStore;
            this.controllerTransaccion.transactionEvent += updateLbTransaccion;
            this.controllerTransaccion.configHopperEvent += setConfigHopper;
            this.controllerTransaccion.messageEvent += dialogMessage;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.controllerTransaccion.setConfigEventError();
            this.controllerTransaccion.validateConfigDevices();
            this.controllerTransaccion.setConfigEventsDevices();
            this.controllerTransaccion.initializeDevices();
            this.controllerTransaccion.getStatusDevices();
            this.controllerTransaccion.getCashBox();
        }

        private void generarTransaccion(object sender, EventArgs e)
        {
            try
            {
                int depositoRequerido = Int32.Parse(inputEfectivo.Text);
                if (depositoRequerido > 0)
                {
                    this.controllerTransaccion.startNewTransaction(depositoRequerido);
                }
                else
                {
                    MessageBox.Show("Debes definir una cantidad mayor a cero para llevar a cabo la transacción");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.controllerTransaccion.closesDevices();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            dialogoCaja dialogo = new dialogoCaja();
            dialogo.cashBoxEvent += updateCashBox;
            dialogo.setInput(this.controllerTransaccion.getCashBox());
            dialogo.ShowDialog();
        }

        private void getValueKeyboard(object sender, EventArgs e)
        {
            string number = inputEfectivo.Text;
            if (number == "0")
            {
                inputEfectivo.Text = "";
                inputEfectivo.Text += ((Button)sender).Text;
            }
            else
            {
                inputEfectivo.Text += ((Button)sender).Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            inputEfectivo.Text = "0";            
        }
 
        #region Eventos para la barra de titulo

        private void barTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.position = new Point(e.X,e.Y);
            this.move = true;
        }

        private void barTitle_MouseUp(object sender, MouseEventArgs e)
        {
            this.move = false;
        }

        private void barTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.move)
            {                
                this.Location = new Point((this.Left + e.X - this.position.X),(this.Top + e.Y - this.position.Y));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

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
                    lbMensajeProceso.ForeColor = Color.FromArgb(16, 45, 54);
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

        private void updateLbStore(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { updateLbStore(sender, e); }));
            }
            else
            {
                //InpR1.Text = e.inputR1.ToString();
                //InpR1.Refresh();
                //InpR2.Text = e.inputR2.ToString();
                //InpR2.Refresh();
                //InpR5.Text = e.inputR5.ToString();
                //InpR5.Refresh();
                //InpR10.Text = e.inputR10.ToString();
                //InpR10.Refresh();
                //InpR20.Text = e.inputR20.ToString();
                //InpR20.Refresh();
                //InpR50.Text = e.inputR50.ToString();
                //InpR50.Refresh();
                //InpR100.Text = e.inputR100.ToString();
                //InpR100.Refresh();
                //InpR200.Text = e.inputR200.ToString();
                //InpR200.Refresh();
                //InpR500.Text = e.inputR500.ToString();
                //InpR500.Refresh();
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
                if (e.lbIngresado == 0)
                {
                    inptCambio.Text = "$0";
                    inptCambio.Refresh();
                    inptIngresado.Text = "$0";
                    inptIngresado.Refresh();
                }
                else
                {
                    inptCambio.Text = "$" + e.lbCambio.ToString();
                    inptCambio.Refresh();
                    inptIngresado.Text = "$" + e.lbIngresado.ToString();
                    inptIngresado.Refresh();
                }
            }
        }

        private void updateCashBox(object sender, EventArgs e, Hashtable data)
        {
            this.controllerTransaccion.updateCashBox(data);
        }

        private void setConfigHopper(object sender, EventArgs e)
        {
           
            Dictionary<string, string> configDevices = this.controllerTransaccion.getConfigDevices();
            FormConfigHopper formConfigHopper = new FormConfigHopper();
            formConfigHopper.getConfigDevicesEvent += setConfigDevices;
            formConfigHopper.setValuesSelects(configDevices);
            formConfigHopper.ShowDialog();
        }

        private void setConfigDevices(Dictionary<string, string> selectedDevices)
        {          
            this.controllerTransaccion.setConfigDevices(selectedDevices);
            this.controllerTransaccion.setConfigEventsDevices();
            this.controllerTransaccion.initializeDevices();
            this.controllerTransaccion.getStatusDevices();
        }

        private void dialogMessage(object sender, MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { dialogMessage(sender, e); }));
            }
            else
            {
                MessageBox.Show(e.Message);              
            }
        }

        #endregion

       
    }
}
