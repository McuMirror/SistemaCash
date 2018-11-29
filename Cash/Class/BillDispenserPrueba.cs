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
    class BillDispenserPrueba : IDeviceDispenser
    {
        private bool connection = true;
        private string COM;        

        private Dictionary<int, int> quantityCodeToDelivered;

        public BillDispenserPrueba()
        {            
            this.quantityCodeToDelivered = new Dictionary<int, int>();
        }

        public override bool openConnection()
        {
            try
            {
                this.COM = getCOMPort();
                Console.WriteLine("Utiliza el puerto : {0}", this.COM);
                
            }          
            catch (Exception ex)
            {
                this.connection = false;
            }

            return this.connection;
        }

        public override string getCOMPort()
        {
            string puertoCOM = "COM4";                       
            return puertoCOM;
        }

        public override void enable()
        {
            setFreeDevice();
        }

        public override void disable()
        {
            setFreeDevice();
        }

        public override bool isConnection()
        {
            return this.connection;
        }

        private Parity SetPortParity(Parity defaultPortParity)
        {
            string parity = Console.ReadLine();

            if (parity == "")
            {
                parity = defaultPortParity.ToString();
            }

            return (Parity)Enum.Parse(typeof(Parity), parity);
        }

        public override void returnCash(int denominationCash, int countMoney, int[] countBill)
        {
            
        }

        private void setConfigDefault()
        {
         
        }

        private void setFreeDevice()
        {
           
        }

        public override void resetDevice()
        {
            
        }

        private void sendMessage(byte[] parameter)
        {
            
        }

        private void setMessage(byte[] parameters)
        {
            
        }

        private byte getMessage()
        {            
            byte finalByte = 0;            
            return finalByte;
        }

        public void setCheckSum()
        {

        }
    }
}
