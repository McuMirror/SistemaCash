using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;

namespace FondoDeCaja.Models
{
    class Model_DB_CashKiosk
    {
        private SqlConnection connection;
        private SqlCommand query;
        private SqlDataReader dataQuery;
        private SqlTransaction transaction;
        private string user;
        private string password;
        private string IP;

        public Model_DB_CashKiosk()
        {
            this.user = ConfigurationManager.AppSettings.Get("userDB");
            this.password = ConfigurationManager.AppSettings.Get("passwordDB");
            this.IP = ConfigurationManager.AppSettings.Get("hostDB");
        }

        public void openConnection()
        {
            try
            {
                this.connection = new SqlConnection(@"Data Source=" + this.IP + "; Initial Catalog=KioskoCash; User ID=" + this.user + "; Password=" + this.password);
                this.query = new SqlCommand();
                this.query.Connection = this.connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error para conectarse a la base de datos");
            }
        }

        public Hashtable getCashBoxCurrent()
        {
            Hashtable data = new Hashtable();
            try
            {
                this.query.CommandText = "select " +
                        "hdispenser.Monedas1 as M1," +
                        "hdispenser.Monedas2 as M2," +
                        "hdispenser.Monedas5 as M5," +
                        "hdispenser.Monedas10 as M10," +
                        "bdispenser.Billetes20 as B20," +
                        "bdispenser.Billetes50 as B50," +
                        "bdispenser.Billetes100 as B100, " +
                        "bdispenser.Billetes200 as B200, " +
                        "bdispenser.Billetes500 as B500 " +
                    "from dbo.Caja caja inner join BillDispenser bdispenser " +
                    "on bdispenser.IdCaja = caja.IdCaja " +
                    "inner join dbo.HopperDispenser hdispenser " +
                    "on hdispenser.IdCaja = caja.IdCaja where Abierta = 1";
                this.connection.Open();
                this.dataQuery = this.query.ExecuteReader();

                while (this.dataQuery.Read())
                {
                    data.Add("M1", this.dataQuery["M1"]);
                    data.Add("M2", this.dataQuery["M2"]);
                    data.Add("M5", this.dataQuery["M5"]);
                    data.Add("M10", this.dataQuery["M10"]);
                    data.Add("B20", this.dataQuery["B20"]);
                    data.Add("B50", this.dataQuery["B50"]);
                    data.Add("B100", this.dataQuery["B100"]);
                    data.Add("B200", this.dataQuery["B200"]);
                    data.Add("B500", this.dataQuery["B500"]);
                }

                this.connection.Close();

                if (data.Count == 0)
                {
                    data.Add("M1", 0);
                    data.Add("M2", 0);
                    data.Add("M5", 0);
                    data.Add("M10", 0);
                    data.Add("B20", 0);
                    data.Add("B50", 0);
                    data.Add("B100", 0);
                    data.Add("B200", 0);
                    data.Add("B500", 0);
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:" + ex.Message);
            }
        }

        public void saveCashBox(Hashtable countCash)
        {

            string idCajaLast = this.getLastRecord();
            string idCajaNew;

            if (idCajaLast != "")
            {
                this.updateLastRecordCashBox(idCajaLast);
                this.insertNewRecordBox();
                idCajaNew = this.getLastRecord();
                this.insertNewRecordHopperDispenser(idCajaNew, countCash);
                this.insertNewRecordBillDispenser(idCajaNew, countCash);
            }
            else
            {

            }
            //this.query.CommandText = "insert into dbo.Caja values(" +
            //    "'" + data["B20"] + "'," +
            //    "'" + data["B50"] + "'," +
            //    "'" + data["B100"] + "')";

            //this.query.CommandText = "insert into dbo.BillDispenser values(" +
            //    "'" + data["B20"] + "'," +
            //    "'" + data["B50"] + "'," +
            //    "'" + data["B100"] + "')";

        }

        private string getLastRecord()
        {
            string idCaja = "";
            this.query.CommandText = "select IdCaja from dbo.Caja where Abierta = 1";
            try
            {
                this.connection.Open();
                this.dataQuery = this.query.ExecuteReader();

                while (this.dataQuery.Read())
                {
                    idCaja = this.dataQuery.GetValue(0).ToString();
                }
                this.connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error con la Base de datos");
            }

            return idCaja;
        }

        private void updateLastRecordCashBox(string id)
        {
            try
            {
                this.query.CommandText = "update dbo.Caja set Abierta = 0 where IdCaja = " + id;
                this.connection.Open();
                this.query.ExecuteNonQuery();
                this.connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error con la base de datos");
            }

        }

        private void insertNewRecordBox()
        {
            this.query.CommandText = "insert into dbo.Caja(CinemaCode," +
                "WorkstationName," +
                "Abierta," +
                "FechaModificacion)" +
                " values(" +
                "'" + ConfigurationManager.AppSettings.Get("CinemaCode") + "'," +
                "'" + ConfigurationManager.AppSettings.Get("WorkstationName") + "'," +
                "1," +
                "getdate())";
            this.connection.Open();
            this.query.ExecuteNonQuery();
            this.connection.Close();
        }

        private void insertNewRecordBillDispenser(string idCaja, Hashtable cash)
        {
            this.query.CommandText = "insert into dbo.BillDispenser(" +
                "IdCaja," +
                "Billetes20," +
                "Billetes50," +
                "Billetes100," +
                "Billetes200," +
                "Billetes500) values(" + idCaja + "," + cash["20"] + "," + cash["50"] + "," + cash["100"] + "," + cash["200"] + "," + cash["500"] + ")";
            this.connection.Open();
            this.query.ExecuteNonQuery();
            this.connection.Close();
        }

        private void insertNewRecordHopperDispenser(string idCaja, Hashtable cash)
        {
            this.query.CommandText = "insert into dbo.HopperDispenser(" +
                "IdCaja," +
                "Monedas1," +
                "Monedas2," +
                "Monedas5," +
                "Monedas10) values(" + idCaja + "," + cash["1"] + "," + cash["2"] + "," + cash["5"] + "," + cash["10"] + ")";
            this.connection.Open();
            this.query.ExecuteNonQuery();
            this.connection.Close();
        }
    }
}
