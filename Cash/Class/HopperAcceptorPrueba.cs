using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    class HopperAcceptorPrueba : IDeviceAcceptor
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
            string puertoCOM = "COM1";
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

        public override byte[] getCashDesposite(int contador)
        {

            byte[] result = new byte[2];

            contador++;
            result[0] = 10;
            result[1] = (byte)contador;
            return result;
        }

        public override void setEvents()
        {
            throw new NotImplementedException();
        }
    }
}
