using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Collections;
using System.Data;

namespace SistemaCashValidador.Modelos
{
    class Modelo_Transaccion
    {
        private Hashtable stored;
        private SqlCeConnection connection;
        private SqlCeDataAdapter dataAdapter;
        private SqlCeDataReader query;
        private DataSet dataSet;
        private SqlCeCommand command;


        public Modelo_Transaccion() {
            this.connection = new SqlCeConnection(@"DataSource=DBCash.sdf");
            this.command = new SqlCeCommand();
            this.command.Connection = this.connection;
        }

        public int getlatestRegister()
        {
            return 1;
        }

        public Hashtable getCashStore()
        {
            try
            {
                this.stored = new Hashtable();
                this.connection.Open();
                this.dataAdapter = new SqlCeDataAdapter("select * from Caja", this.connection);
                this.dataSet = new DataSet("registros");
                this.dataAdapter.Fill(dataSet,"registros");
                this.connection.Close();

                //foreach (DataRow registro in dataSet.Tables["registros"].Rows)
                //{
                //    stored.Add("1", registro["M1"]);
                //    stored.Add("2", registro["M2"]);
                //    stored.Add("5", registro["M5"]);
                //    stored.Add("10", registro["M10"]);
                //    stored.Add("20", registro["B20"]);
                //    stored.Add("50", registro["B50"]);
                //    stored.Add("100", registro["B100"]);
                //    stored.Add("200", registro["B200"]);
                //    stored.Add("500", registro["B500"]);
                //}
            
            }
            catch (SqlCeException ex)
            {
               
            }

            stored = new Hashtable();
            stored.Add("1", 9);
            stored.Add("2", 5);
            stored.Add("5", 4);
            stored.Add("10", 5);
            stored.Add("20", 10);
            stored.Add("50", 10);
            stored.Add("100", 10);
            stored.Add("200", 0);
            stored.Add("500", 0);
            return stored;
        }
    }
}
