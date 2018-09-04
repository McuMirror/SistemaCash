using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CPI.BanknoteDevices;
using CPI.BanknoteDevices.Events;
using System.Windows.Forms;
using MPOST;
using System.Management;
using CashLib.Interfaces;

namespace CashLib.Class
{
    public class BillAcceptor : IDeviceAcceptor
    {        
        private string COM;
        private Acceptor billAcceptor = new Acceptor();

        //Se realizara pruebas con dispositivos en caso de tener prueba exitosa se eliminara estos delegates.
        //public delegate void powerUpEventHandler(object sender, EventArgs e);
        //public delegate void connectEventHandler(object sender, EventArgs e);
        //public delegate void stackEventHandler(object sender, EventArgs e);
        //public delegate void powerUpCompletedEventHandler(object sender, EventArgs e);
        //public delegate void escrowEventHandler(object sender, EventArgs e);
        public override event powerUpEventHandler powerUpEvent;
        public override event connectEventHandler connectEvent;
        public override event stackEventHandler stackEvent;
        public override event powerUpCompletedEventHandler powerUpCompleteEvent;
        public override event escrowEventHandler escrowEvent;
        private bool connection = true;        

        public override bool openConnection()
        {
            try
            {                
                this.COM = getCOMPort();
                Console.WriteLine("Utiliza el puerto : {0}", this.COM);
            }
            catch (IOException ex)
            {
                this.connection = false;
            }
            catch (Exception ex)
            {
                this.connection = false;
            }

            return this.connection;
        }

        public override string getCOMPort()
        {
            string puertoCOM = "";

            //Obteneniendo los dispositivos
            ManagementObjectCollection collection;

            //utilizando la WMI para obtener las propiedade de los dispositivos.
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_PNPEntity");

            //Asignamos los dispositivos a nuestra coleccion
            collection = searcher.Get();

            //Recorremos la colección
            foreach (var device in collection)
            {
                foreach (PropertyData properties in device.Properties)
                {
                    if (properties.Name == "Name" && properties.Value != null)
                    {
                        var valor = (String)properties.Value;
                        if (valor.Contains("MEI Inc. Cashflow-SC Bill Acceptor (EBDS over USB)"))
                        {
                            puertoCOM = valor.Substring(valor.LastIndexOf("COM"), 4);
                        }
                    }
                }
            }

            if (puertoCOM == "")
            {                
                throw new Exception("Bill Acceptor no conectado");
            }
            return puertoCOM;           
        }

        public override bool isConnection()
        {
            return this.connection;
        }

        public override void enable()
        {        
            billAcceptor.Open(this.COM, PowerUp.A);
        }

        public override void disable()
        {
            billAcceptor.Close();
        }

        public void setEvents()
        {
            billAcceptor.OnPowerUp += new PowerUpEventHandler(powerUpEvent);
            billAcceptor.OnConnected += new ConnectedEventHandler(connectEvent);
            billAcceptor.OnStacked += new StackedEventHandler(stackEvent);
            billAcceptor.OnPowerUpComplete += new PowerUpCompleteEventHandler(powerUpCompleteEvent);
            billAcceptor.OnEscrow += new EscrowEventHandler(escrowEvent);
        }

        public override void setConfig()
        {
            this.configDefault();
            billAcceptor.EnableAcceptance = true;
            billAcceptor.AutoStack = true;            
        }

        private void configDefault()
        {
            MPOST.Bill[] bills = billAcceptor.BillValues;
            Boolean[] enables = billAcceptor.GetBillValueEnables();
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i].Value == 1000)
                {
                    enables[i] = false;
                }
            }
            billAcceptor.SetBillValueEnables(ref enables);
        }

        //Despues de validar su funcionamiento con el metod getCashDeposite se elimina esta funcion
        //public double getDepositeBill()
        //{
        //    double bill = 0;
        //    if (billAcceptor.DocType == DocumentType.Bill)
        //    {
        //        MPOST.Bill bills = billAcceptor.Bill;
        //        bill = bills.Value;
        //    }
        //    return bill;
        //}

        public override byte[] getCashDesposite(int count)
        {
            byte[] bill = new byte[1];
            if (billAcceptor.DocType == DocumentType.Bill)
            {
                MPOST.Bill bills = billAcceptor.Bill;
                bill[0] = (byte)bills.Value;
            }
            return bill;
        }
    }
}
