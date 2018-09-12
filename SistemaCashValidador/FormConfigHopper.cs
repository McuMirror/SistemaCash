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

        public void setValuesSelects(Dictionary<string, string> devices)
        {            
            foreach (KeyValuePair<string,string> device in devices)
            {                
                switch (device.Key)
                {
                    case "HOPPERACCEPTOR":
                        selectHooperAcceptor.SelectedIndex = getValueSelectDevice(device.Value);
                        break;
                    case "HOPPERDISPENSER":
                        selectHopperDispenser.SelectedIndex = getValueSelectDevice(device.Value);  
                        break;
                    case "BILLACCEPTOR":
                        selectBillAcceptor.SelectedIndex = getValueSelectDevice(device.Value);                        
                        break;
                    case "BILLDISPENSER":
                        selectBillDispenser.SelectedIndex = getValueSelectDevice(device.Value);
                        break;
                }
            }                        
        }
       
        private int getValueSelectDevice(string valueDevice)
        {
            int valueSelect = 0;
            switch (valueDevice)
            {            
                case "COMBOT":
                    valueSelect = 1;
                    break;
                case "ASAHI":
                    valueSelect = 2;
                    break;
                case "HOPPER PRUEBA":
                    valueSelect = 3;
                    break;
                case "SCADVANCE":
                    valueSelect = 1;
                    break;
                case "F53":
                    valueSelect = 1;
                    break;
                case "BILL PRUEBA":
                    valueSelect = 2;
                    break;
            }
            return valueSelect;
        }
                              
    }
}
