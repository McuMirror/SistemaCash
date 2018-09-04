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

            if (resultMessage[4] != contador)
            {
                switch (resultMessage[5])
                {
                    case 7:
                        result[0] = 10;
                        break;
                    case 6:
                        result[0] = 5;
                        break;
                    case 5:
                        result[0] = 2;
                        break;
                    case 4:
                        result[0] = 1;
                        break;
                }

            }
            result[1] = this.resultMessage[4];
            return result;
        }

        public override void setEvents()
        {
            throw new NotImplementedException();
        }
    }
}
