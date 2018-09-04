using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    public class HopperAcceptorASAHI : IDeviceAcceptor
    {
        public HopperAcceptorASAHI()
        {
            this.manufacturer = "Silicon Labs CP210x USB to UART Bridge";
            this.device = "ASAHI";
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
                    case 6:
                        result[0] = 10;
                        break;
                    case 7:
                        result[0] = 10;
                        break;
                    case 4:
                        result[0] = 2;
                        break;
                    case 5:
                        result[0] = 5;
                        break;
                    case 3:
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
