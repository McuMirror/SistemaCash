using System;
using System.Collections;
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
    public partial class dialogoCaja : Form
    {
        public delegate void updateCashBoxEventHandler(object sender, EventArgs e, Hashtable data);
        public event updateCashBoxEventHandler cashBoxEvent;
        private Hashtable stored;

        public dialogoCaja()
        {
            InitializeComponent();       
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                stored = new Hashtable();
                stored.Add("1", this.validateInput(inpt1.Text));
                stored.Add("2", this.validateInput(inpt2.Text));
                stored.Add("5", Int32.Parse(inpt5.Text));
                stored.Add("10", Int32.Parse(inpt10.Text));
                stored.Add("20", Int32.Parse(inpt20.Text));
                stored.Add("50", Int32.Parse(inpt50.Text));
                stored.Add("100", Int32.Parse(inpt100.Text));
                stored.Add("200", Int32.Parse(inpt200.Text));
                stored.Add("500", Int32.Parse(inpt500.Text));
                cashBoxEvent(sender, e, stored);
                this.Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message);
            }
            
        }

        public void setInput(Hashtable data)
        {
            foreach (DictionaryEntry register in data)
            {
                inpt1.Text = data["1"].ToString();
                inpt2.Text = data["2"].ToString();
                inpt5.Text = data["5"].ToString();
                inpt10.Text = data["10"].ToString();
                inpt20.Text = data["20"].ToString();
                inpt50.Text = data["50"].ToString();
                inpt500.Text = data["100"].ToString();
                inpt200.Text = data["200"].ToString();
                inpt500.Text = data["500"].ToString();
            }
        }

        private int validateInput(string data)
        {
            try
            {
                if (data != "")
                {
                    int value = Convert.ToInt32(data);
                    return value;
                }
                else
                {
                    throw new Exception("No puede haber campos vacios.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se admiten letras");
            }
        }

        
    }
}
