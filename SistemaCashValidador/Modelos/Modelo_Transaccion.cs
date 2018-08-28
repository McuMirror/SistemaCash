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

        public Hashtable getCashBox()
        {
            try
            {
                this.stored = new Hashtable();
                this.connection.Open();
                this.dataAdapter = new SqlCeDataAdapter("select top 1 * from Caja order by Id desc", this.connection);
                this.dataSet = new DataSet("registros");
                this.dataAdapter.Fill(dataSet,"registros");
                this.connection.Close();

                foreach (DataRow registro in dataSet.Tables["registros"].Rows)
                {
                    stored.Add("1", registro["M1"]);
                    stored.Add("2", registro["M2"]);
                    stored.Add("5", registro["M5"]);
                    stored.Add("10", registro["M10"]);
                    stored.Add("20", registro["B20"]);
                    stored.Add("50", registro["B50"]);
                    stored.Add("100", registro["B100"]);
                    stored.Add("200", registro["B200"]);
                    stored.Add("500", registro["B500"]);
                }

            }
            catch (SqlCeException ex)
            {
               throw new Exception("No se puede obtener el primer registro");
            }
            return stored;
        }

        public void setCashDeposit(Hashtable data)
        {
            DateTime day = DateTime.Today;
            string time = DateTime.Now.ToString("H:mm");            
            string query = "INSERT INTO [Caja]([Fecha],[Hora],[M1],[M2],[M5],[M10],[B20],[B50],[B100],[B200],[B500]) " +
                "VALUES(GETDATE()," +
                "'"+ time + "', " +
                ""+ data["1"].ToString()+", " +
                "" + data["2"].ToString() + ", " +
                "" + data["5"].ToString() + ", " +
                "" + data["10"].ToString() + ", " +
                "" + data["20"].ToString() + ", " +
                "" + data["50"].ToString() + ", " +
                "" + data["100"].ToString() + ", " +
                "" + data["200"].ToString() + ", " +
                "" + data["500"].ToString() + ")";
            Console.WriteLine(query);

            this.connection.Open();
            this.command.CommandText = query;

            if (this.command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Se guardo la configuracion");
            }
            this.connection.Close();
        }
    }
}
