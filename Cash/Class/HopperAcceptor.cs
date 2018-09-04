using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    public class HopperAcceptor : IDeviceAcceptor
    {
        public HopperAcceptor()
        {
            this.manufacturer = "USB Serial Port";
            this.device = "COMBOT";
        }

        /*
         * Encardo de obtener la cantidad y monedas depositadas en el hopper acceptor
         */
        public override byte[] getCashDesposite(int contador)
        {
            
            byte[] result = new byte[2];
            this.setMessage(new List<byte>() { 2, 0, 1, 229 }, new
                List<byte>() { 4 });

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
        
    }
}
