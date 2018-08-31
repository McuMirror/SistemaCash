using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCashValidador.Clases
{
    public class FactoryDevices
    {
        public static FactoryDevices instance;

        public static FactoryDevices getInstancia()
        {
            if (instance == null)
            {
                instance = new FactoryDevices();
            }
            return instance;
        }       

        public CashLib.BillAcceptor getBillAcceptor(string device)
        {
            return new CashLib.BillAcceptor();
        }

        public CashLib.BillDespenser getBillDispenser(string device)
        {
            return new CashLib.BillDespenser();
        }

        public CashLib.Hopper getHopperAcceptor(string device)
        {
            CashLib.Hopper objectAcceptor = null;
            
            if (device == "COMBOT")
            {
                objectAcceptor = new CashLib.HopperAcceptor();
            }
            else if (device == "ASAHI")
            {
                objectAcceptor = new CashLib.HopperAcceptorASAHI();
            }

            return objectAcceptor;
        }

        public CashLib.Hopper getHopperDispenser(string device)
        {
            CashLib.Hopper objectDispenser = null;

            if (device == "COMBOT")
            {
                objectDispenser =  new CashLib.HopperAcceptor();
            }
            else if (device == "ASAHI")
            {
                objectDispenser =  new CashLib.HopperDispenserASAHI();
            }

            return objectDispenser;
        }
    }
}
