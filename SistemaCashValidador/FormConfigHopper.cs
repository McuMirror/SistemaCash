using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCashValidador
{
    public partial class FormConfigHopper : Form
    {
        public delegate void GetConfigDevicesEventHandler(Dictionary<string, string> data);
        public event GetConfigDevicesEventHandler getConfigDevicesEvent;

        public FormConfigHopper()
        {
            InitializeComponent();
        }

        private void FormConfigHopper_Load(object sender, EventArgs e)
        {
            selectHooperAcceptor.SelectedIndex = 0;
            selectHopperDispenser.SelectedIndex = 0;
            selectBillAcceptor.SelectedIndex = 0;
            selectBillDispenser.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> selects = new Dictionary<string, string>();
            selects.Add("HOPPERACCEPTOR", selectHooperAcceptor.SelectedItem.ToString());
            selects.Add("HOPPERDISPENSER", selectHopperDispenser.SelectedItem.ToString());
            selects.Add("BILLACCEPTOR", selectBillAcceptor.SelectedItem.ToString());
            selects.Add("BILLDISPENSER", selectBillDispenser.SelectedItem.ToString());
            bool undefineDevice = true;

            foreach (KeyValuePair<string, string> select in selects)
            {
                if (select.Value == "Seleccionar")
                {
                    undefineDevice = false;
                }
            }
            
            if (undefineDevice)
            {
                getConfigDevicesEvent(selects);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes definir todos los dispositivos");
            }
                        
        }


    }
}
