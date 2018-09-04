using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    class BillAcceptorPrueba : IDeviceAcceptor
    {
        private string COM = "";
        private bool connection = true;

        public override bool openConnection()
        {
            try
            {
                this.COM = getCOMPort();
                Console.WriteLine("Utiliza el puerto : {0}", COM);
            }
            catch (Exception ex)
            {
                this.connection = false;
            }

            return this.connection;
        }

        public override string getCOMPort()
        {
            string puertoCOM = "COM3";
            return puertoCOM;
        }

        public override bool isConnection()
        {
            return true;
        }

        public override void enable()
        {

        }

        public override void disable()
        {

        }

        public override byte[] getCashDesposite(int count = 0)
        {
            throw new NotImplementedException();
        }

        public override void setEvents()
        {
            Console.WriteLine("Eventos establecidos");
        }
    }
}
