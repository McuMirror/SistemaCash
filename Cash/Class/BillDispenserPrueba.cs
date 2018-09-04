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
            this.quantityCodeToDelivered.Add(0, 48);
            this.quantityCodeToDelivered.Add(1, 177);
            this.quantityCodeToDelivered.Add(2, 178);
            this.quantityCodeToDelivered.Add(3, 51);
            this.quantityCodeToDelivered.Add(4, 180);
            this.quantityCodeToDelivered.Add(5, 53);
            this.quantityCodeToDelivered.Add(6, 54);
            this.quantityCodeToDelivered.Add(7, 183);
            this.quantityCodeToDelivered.Add(8, 57);
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

        private void resetDevice()
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
