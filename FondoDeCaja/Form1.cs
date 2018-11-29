using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FondoDeCaja.Models;

namespace FondoDeCaja
{
    public partial class Form1 : Form
    {
        private Point position = Point.Empty;
        private bool move;
        private Hashtable stored;
        private TextBox input;
        private Hashtable data;
        ArrayList keyBoardPress = new ArrayList() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private bool errorKeyBoard = false;
        private Model_DB_CashKiosk DB;
        private string minimumMoney = ConfigurationManager.AppSettings.Get("minimumMoney");
        private string minimumBill = ConfigurationManager.AppSettings.Get("minimumBill");

        public Form1()
        {
            InitializeComponent();
            DB = new Model_DB_CashKiosk();
            this.getCashBox();
        }

        private void getCashBox()
        {
            try
            {
                this.DB.openConnection();
                this.setCashCurrent();
            }
            catch (Exception ex)
            {
                this.showMessaje(this, ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void setCashCurrent()
        {
            this.data = this.DB.getCashBoxCurrent();
            this.setInput();
        }

        private int validateInput(string data)
        {

            if (data != "")
            {
                try
                {
                    return Convert.ToInt32(data);
                }
                catch (Exception ex)
                {
                    throw new Exception("No se admiten letras");
                }
            }
            else
            {
                throw new Exception("No puede haber campos vacios.");
            }

        }

        public void setInput()
        {
            foreach (DictionaryEntry register in this.data)
            {
                cantAct1.Text = data["M1"].ToString();
                cantAct5.Text = data["M5"].ToString();
                cantAct10.Text = data["M10"].ToString();
                cantAct20.Text = data["B20"].ToString();
                cantAct50.Text = data["B50"].ToString();
                cantAct100.Text = data["B100"].ToString();
                cantidad1.Text = minimumMoney;
                cantidad5.Text = minimumMoney;
                cantidad10.Text = minimumMoney;
                cantidad20.Text = minimumBill;
                cantidad50.Text = minimumBill;
                cantidad100.Text = minimumBill;
            }

            this.calculateMoneyInTextBox();
        }

        #region Evento botones Guardar y Cancelar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.setAmountCashCaptured();
                this.validateMinimumCashBox();
                this.DB.saveCashBox(stored);
                this.showMessaje(this, "Se guardo con exito el fondo de caja", false);
            }
            catch (Exception ex)
            {
                this.showMessaje(this, ex.Message);
            }
        }

        private void setAmountCashCaptured()
        {
            this.stored = new Hashtable();
            this.stored.Add("1",
                this.validateInput(cantidad1.Text) + Convert.ToInt32(data["M1"]));
            this.stored.Add("2", Convert.ToInt32(data["M2"]));
            this.stored.Add("5",
                this.validateInput(cantidad5.Text) + Convert.ToInt32(data["M5"]));
            this.stored.Add("10",
                this.validateInput(cantidad10.Text) + Convert.ToInt32(data["M10"]));
            this.stored.Add("20",
                this.validateInput(cantidad20.Text) + Convert.ToInt32(data["B20"]));
            this.stored.Add("50",
                this.validateInput(cantidad50.Text) + Convert.ToInt32(data["B50"]));
            this.stored.Add("100",
                this.validateInput(cantidad100.Text) + Convert.ToInt32(data["B100"]));
            this.stored.Add("200", Convert.ToInt32(data["B200"]));
            this.stored.Add("500", Convert.ToInt32(data["B500"]));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void validateMinimumCashBox()
        {
            string minimumMoney = ConfigurationManager.AppSettings.Get("minimumMoney");
            string minimumBill = ConfigurationManager.AppSettings.Get("minimumBill");
            string messageError = "";
            bool error = false;

            foreach (DictionaryEntry register in stored)
            {
                int count = Int32.Parse(register.Value.ToString());
                string key = register.Key.ToString();
                               
                switch (key)
                {
                    case "1":
                    case "5":
                    case "10":
                        messageError = minimumMoney + " para las monedas";
                        error = this.validateMinimum(Int32.Parse(minimumMoney), count);
                        break;
                    case "20":
                    case "50":
                    case "100":
                        messageError = minimumBill + " para los billetes";
                        error = this.validateMinimum(Int32.Parse(minimumBill), count);
                        break;
                }

                if (error)
                {
                    throw new Exception("No puede ingresar una cantidad menor de " + messageError);
                    break;
                }
            }

            
        }

        private bool validateMinimum(int minimum, int value)
        {
            bool error = false;

            if (value < minimum && value >= 0)
            {
                error = true;
            }

            return error;
        }

        #endregion

        #region Eventos de teclado de pantalla y fisico

        private void definedInput(object sender, EventArgs e)
        {
            this.input = (TextBox)sender;
        }

        private void getValueDigitalKeyboard(object sender, EventArgs e)
        {
            if (this.input.Text == "0")
            {
                this.input.Text = "";
                this.input.Text += ((Button)sender).Text;
            }
            else
            {
                this.input.Text += ((Button)sender).Text;
            }

            this.calculateMoneyInTextBox();
        }

        private void getValueKeyBoardPress(object sender, KeyPressEventArgs e)
        {
            TextBox input = (TextBox)sender;
            this.showMessaje(this, "");
            if (keyBoardPress.Contains(e.KeyChar))
            {
                if (input.Text == "0")
                {
                    input.Text = "";
                }
                input.Refresh();
                this.errorKeyBoard = false;
            }
            else
            {
                this.errorKeyBoard = true;
            }

        }

        private void getValueKeyBoardUp(object sender, KeyEventArgs e)
        {
            TextBox input = (TextBox)sender;
            if (e.KeyData == Keys.Delete || input.Text == "")
            {
                input.Text = "0";
            }

            if (this.errorKeyBoard && e.KeyData != Keys.Back && e.KeyData != Keys.Delete && e.KeyData != Keys.Enter)
            {
                input.Text = "0";
                this.errorKeyBoard = false;
                this.showMessaje(this, "Debes ingresar un valor valido");
            }

            try
            {
                this.calculateMoneyInTextBox();
            }
            catch (Exception ex)
            {
                this.showMessaje(this, "La cantidad que ingresas no es valida.");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.input.Text = "0";
            this.calculateMoneyInTextBox();
        }

        #endregion

        #region Eventos para la barra de titulo

        private void barTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.position = new Point(e.X, e.Y);
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
                this.Location = new Point((this.Left + e.X - this.position.X), (this.Top + e.Y - this.position.Y));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Eventos Para actualizar vistas
        private void showMessaje(object sender, string messaje, bool error = true)
        {
            float currentSize;
            currentSize = Error.Font.Size;


            if (error)
            {
                Error.ForeColor = Color.Red;
                currentSize = 15;
            }
            else
            {
                Error.ForeColor = Color.Green;
                currentSize = 18;
            }

            Error.Font = new Font(Error.Font.Name, currentSize, Error.Font.Style, Error.Font.Unit);
            Error.Text = messaje;
            Error.Refresh();
        }
        #endregion

        #region Metodos para calculo del efectivo

        private void calculateMoneyInTextBox()
        {
            this.calculateTotalMoneyRow();
            this.calculateTotalBillRow();
            this.calculateMoney();
            this.calculateBills();
            this.calculateCashBox();
        }

        private void calculateTotalMoneyRow()
        {
            calculateFila(cantAct1, cantidad1, total1, 1);
            calculateFila(cantAct5, cantidad5, total5, 5);
            calculateFila(cantAct10, cantidad10, total10, 10);
        }

        private void calculateTotalBillRow()
        {
            calculateFila(cantAct20, cantidad20, total20, 20);
            calculateFila(cantAct50, cantidad50, total50, 50);
            calculateFila(cantAct100, cantidad100, total100, 100);
        }

        private void calculateFila(object countInputCurrente, object countInput, object totalRow, int valueMoney)
        {
            int totalCountCurrent = (Int32.Parse(((TextBox)countInputCurrente).Text)) * valueMoney;
            int totalCountInput = (Int32.Parse(((TextBox)countInput).Text)) * valueMoney;
            int total = totalCountCurrent + totalCountInput;
            ((TextBox)totalRow).Text = total.ToString();
        }

        private void calculateMoney()
        {
            int total = 0;
            total += Int32.Parse(cantidad1.Text);
            total += (Int32.Parse(cantidad5.Text) * 5);
            total += (Int32.Parse(cantidad10.Text) * 10);

            totalMoney.Text = total.ToString();

        }

        private void calculateBills()
        {
            int total = 0;
            total += (Int32.Parse(cantidad20.Text) * 20);
            total += (Int32.Parse(cantidad50.Text) * 50);
            total += (Int32.Parse(cantidad100.Text) * 100);
            totalBill.Text = total.ToString();
        }

        private void calculateCashBox()
        {
            int total = 0;
            total = Int32.Parse(totalMoney.Text) + Int32.Parse(totalBill.Text);
            totalFondo.Text = total.ToString();
        }

        #endregion
    }
}
