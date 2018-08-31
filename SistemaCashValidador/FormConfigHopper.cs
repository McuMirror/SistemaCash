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
        public delegate void GetHopperEventHandler(string data);
        public event GetHopperEventHandler getHopperEvent;

        public FormConfigHopper()
        {
            InitializeComponent();
        }

        private void FormConfigHopper_Load(object sender, EventArgs e)
        {
            selectHooper.SelectedIndex = 0;
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            int index = selectHooper.SelectedIndex;
            Object hopper = selectHooper.SelectedItem;

            if (index != 0)
            {
                getHopperEvent(hopper.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes definir el tipo de hopper");
            }
          
            
        }

      
    }
}
