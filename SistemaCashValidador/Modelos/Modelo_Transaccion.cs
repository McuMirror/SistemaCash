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
        Hashtable dataTransaction;


        public Modelo_Transaccion() {
            this.connection = new SqlCeConnection(@"DataSource=DBCash.sdf");
            this.command = new SqlCeCommand();
            this.command.Connection = this.connection;
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

        public void setCashBox(Hashtable data)
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

            this.connection.Open();
            this.command.CommandText = query;

            if (this.command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Se guardo la configuracion");
            }
            this.connection.Close();
        }

        public void generateNewTransaction(int payout, int cashReceived, int extraMoney)
        {
            int idCashBox = this.getRegisterLastCashBox();
            string query = "INSERT INTO [Transaccion]([IdCaja],[Pago],[Depositado],[Cambio]) " +
                "VALUES(" +
                "" + idCashBox.ToString() + ", " +
                "" + payout.ToString() + ", " +
                "" + cashReceived.ToString() + ", " +
                "" + extraMoney.ToString() + ")";
            Console.WriteLine(query);
            this.connection.Open();
            this.command.CommandText = query;

            if (this.command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Se guardo la configuracion");
            }
            this.connection.Close();
        }

        public int getRegisterLastCashBox()
        {
            int register = 0;
            this.connection.Open();
            this.dataAdapter = new SqlCeDataAdapter("select top 1 * from Caja order by Id desc", this.connection);
            this.dataSet = new DataSet("registros");
            this.dataAdapter.Fill(dataSet, "registros");
            this.connection.Close();

            foreach (DataRow registro in dataSet.Tables["registros"].Rows)
            {
                register = (int)registro["Id"];
            }

            return register;
        }

        public void setExtraMoneyTransaction(Hashtable extraMoney)
        {
            int idTransaction = this.getlatestRegisterTransaction();
            string query = "INSERT INTO [Cambio]([IdTransaccion],[M1],[M2],[M5],[M10],[B20],[B50],[B100],[B200],[B500]) " +
                "VALUES(" +
                "" + idTransaction.ToString() + ", " +
                "" + extraMoney["1"].ToString() + ", " +
                "0," +
                "" + extraMoney["5"].ToString() + ", " +
                "" + extraMoney["10"].ToString() + ", " +
                "" + extraMoney["20"].ToString() + ", " +
                "" + extraMoney["50"].ToString() + ", " +
                "" + extraMoney["100"].ToString() + ", " +
                "0, " +
                "0)";

            this.connection.Open();
            this.command.CommandText = query;

            if (this.command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Se guardo la configuracion");
            }
            this.connection.Close();
        }

        public void setPayoutTransaction(Hashtable cashReceived)
        {
            int idTransaction = this.getlatestRegisterTransaction();
            string query = "INSERT INTO [Pago]([IdTransaccion],[M1],[M2],[M5],[M10],[B20],[B50],[B100],[B200],[B500]) " +
                "VALUES(" +
                "" + idTransaction.ToString() + ", " +
                "" + cashReceived["1"].ToString() + ", " +
                "" + cashReceived["2"].ToString() + ", " +
                "" + cashReceived["5"].ToString() + ", " +
                "" + cashReceived["10"].ToString() + ", " +
                "" + cashReceived["20"].ToString() + ", " +
                "" + cashReceived["50"].ToString() + ", " +
                "" + cashReceived["100"].ToString() + ", " +
                "" + cashReceived["200"].ToString() + ", " +
                "" + cashReceived["500"].ToString() + ")";

            this.connection.Open();
            this.command.CommandText = query;

            if (this.command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Se guardo el pago");
            }
            this.connection.Close();
        }

        public int getlatestRegisterTransaction()
        {
            int numTransaction = 0;
            this.connection.Open();
            this.dataAdapter = new SqlCeDataAdapter("select top 1 * from Transaccion order by Id desc", this.connection);
            this.dataSet = new DataSet("registros");
            this.dataAdapter.Fill(dataSet, "registros");
            this.connection.Close();
            foreach (DataRow registro in dataSet.Tables["registros"].Rows)
            {
                numTransaction = (int)registro["Id"];
            }

            return numTransaction;
        }

        public void setDataTransaction()
        {
            dataTransaction = new Hashtable();
            dataTransaction.Add("Pago", 0);
            dataTransaction.Add("Depositado",0);
            dataTransaction.Add("Cambio",0);
            dataTransaction.Add("M1",0);
            dataTransaction.Add("M2",0);
            dataTransaction.Add("M5",0);
            dataTransaction.Add("M10",0);
            dataTransaction.Add("B20",0);
            dataTransaction.Add("B50",0);
            dataTransaction.Add("B100",0);
            dataTransaction.Add("B200",0);
            dataTransaction.Add("B500",0);

            int idTransaction = this.getlatestRegisterTransaction();
            this.connection.Open();
            this.dataAdapter = new SqlCeDataAdapter("select * from Transaccion where Id = " + idTransaction, this.connection);
            this.dataSet = new DataSet("registros");
            this.dataAdapter.Fill(dataSet, "registros");
            this.connection.Close();
            foreach (DataRow registro in dataSet.Tables["registros"].Rows)
            {
                dataTransaction["Pago"] = registro["Pago"];
                dataTransaction["Depositado"] = registro["Depositado"];
                dataTransaction["Cambio"] = registro["Cambio"];
            }
        }

        public void setDataDepositeTransaction()
        {
            int idTransaction = this.getlatestRegisterTransaction();
            this.connection.Open();
            this.dataAdapter = new SqlCeDataAdapter("select * from Cambio where Id = " + idTransaction, this.connection);
            this.dataSet = new DataSet("registros");
            this.dataAdapter.Fill(dataSet, "registros");
            this.connection.Close();
            foreach (DataRow registro in dataSet.Tables["registros"].Rows)
            {
                dataTransaction["M1"] = registro["M1"];
                dataTransaction["M2"] = registro["M2"];
                dataTransaction["M5"] = registro["M5"];
                dataTransaction["M10"] = registro["M10"];
                dataTransaction["B20"] = registro["B20"];
                dataTransaction["B50"] = registro["B50"];
                dataTransaction["B100"] = registro["B100"];
                dataTransaction["B200"] = registro["B200"];
                dataTransaction["B500"] = registro["B500"];
            }
        }

        public Hashtable getDataTrasnsaction()
        {
            return this.dataTransaction;
        }
    }
}
