using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashLib.Interfaces;
using CashLib.Class;


namespace CashLib.Factory
{
    public class FactoryDeviceCash
    {
        public IDeviceAcceptor CreateDeviceAcceptor(string device)
        {
            switch (device)
            {
                case "ASAHI":
                    return new HopperAcceptorASAHI();
                case "COMBOT":
                    return new HopperAcceptor();
                case "SCADVANCE":
                    return new BillAcceptor();
                case "HOPPER PRUEBA":
                    return new HopperAcceptorPrueba();               
                case "BILL PRUEBA":
                    return new BillAcceptorPrueba();               
                default:
                    return null;
            }
        }

        public IDeviceDispenser CreateDeviceDispenser(string device)
        {
            switch (device)
            {
                case "ASAHI":
                    return new HopperDispenserASAHI();
                case "COMBOT":
                    return new HopperDispenser();
                case "F53":
                    return new BillDespenser();
                case "HOPPER PRUEBA":
                    return new HopperDispenserPrueba(); 
                case "BILL PRUEBA":
                    return new BillDispenserPrueba();
                default:
                    return null;
            }
        }
    }
}
