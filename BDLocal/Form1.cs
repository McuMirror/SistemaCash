using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Threading;

namespace BDLocal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string c = "DataSource=\"DBLocalPrueba.sdf\";";

                SqlCeConnection conexion = new SqlCeConnection(@"DataSource =DBLocalPrueba.sdf");
                conexion.Open();
                MessageBox.Show("Conexion abierta");
                SqlCeDataAdapter adapter = new SqlCeDataAdapter("select * from Usuarios",conexion);
                DataSet ds = new DataSet("Usuarios");
                adapter.Fill(ds,"Usuarios");
                conexion.Close();
                
                //SqlCeCommand query = new SqlCeCommand();
                //DataSet dataSet = new DataSet();
                //SqlDataAdapter data = new SqlDataAdapter(query);

                //query.Connection = conexion;
                //conexion.Open();
                //query.CommandText = "select * from Usuarios";
                //data.Fill(dataSet, "Usuarios");
                //conexion.Close();

                rejilla.DataSource = ds.Tables["Usuarios"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
