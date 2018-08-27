using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CashLib
{
    public class HopperAcceptor : Hopper
    {       
        /*
         * Encardo de obtener la cantidad y monedas depositadas en el hopper acceptor
         */        
        public byte[] depositCash()
        {            
            this.setMessage(new List<byte>() { 26, 0, 1, 229 }, new
                List<byte>() { 4 });
            return this.resultMessage;
        }
        
    }
}
