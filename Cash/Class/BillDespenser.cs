using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    public class BillDespenser : IDeviceDispenser
    {
        private SerialPort portDispenser;
        private bool connection = true;
        private string COM;
        //private byte[] resultMessage; Se eliminar encuanto se determine que ya esta funcionando sin requerir esta variable
        private static string RX;
        private static string TX;
        //private byte[] deliveriBill; Se validara si ya no se requiere la variable
        private byte[] cancel = new byte[] { 0x10, 0x02, 0x00, 0x03, 0x00, 0x10, 0x1C, 0x10, 0x03, 0xE0, 0x48 };
        private byte[] request = new byte[] { 0x10, 0x05 };
        private byte[] request2 = new byte[] { 0x10, 0x06 };
        private byte[] configDefault = new byte[] { 0x10, 0x02, 0x00, 0x21, 0x60, 0x02, 0xFF, 0x00, 0x00, 0x1A, 0x00, 0x40, 0x082, 0x6E, 0x89, 0x75, 0x93, 0x7F, 0x00, 0x00, 0x0C, 0x0C, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0xA6, 0xAE };

        private byte[] dispenserBill = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0xB1, 0x30, 0xB1, 0x30, 0xB1, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x02, 0x02, 0x02, 0x00, 0x1C, 0x10, 0x03, 0x9A, 0xD6 };

        private byte[] clearLog = new byte[] { 0x10, 0x02, 0x00, 0x2d, 0x60, 0x12, 0x29, 0x03, 0x4c, 0x6f, 0x67, 0x20, 0x63, 0x6c, 0x65, 0x61, 0x72, 0x20, 0x64, 0x61, 0x74, 0x65, 0x20, 0x3a, 0x20, 0x32, 0x30, 0x31, 0x38, 0x2e, 0x30, 0x38, 0x2e, 0x31, 0x35, 0x20, 0x31, 0x35, 0x3a, 0x35, 0x37, 0x3a, 0x33, 0x34, 0x00, 0x00, 0x00, 0x00, 0x1c, 0x10, 0x03, 0x76, 0x35 };
        private byte[] billCount = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0x14, 0x4d };
        private byte[] mechalReset = new byte[] { 0x10, 0x02, 0x00, 0x11, 0x60, 0x02, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0x64, 0xEC };

        private Dictionary<int, int> quantityCodeToDelivered;
       
        public BillDespenser()
        {
            //this.deliveriBill = new byte[] {48,177,178,51,180,53,54,183,57};
            this.quantityCodeToDelivered = new Dictionary<int, int>();
            this.quantityCodeToDelivered.Add(0,48);
            this.quantityCodeToDelivered.Add(1,177);
            this.quantityCodeToDelivered.Add(2,178);
            this.quantityCodeToDelivered.Add(3,51);
            this.quantityCodeToDelivered.Add(4,180);
            this.quantityCodeToDelivered.Add(5,53);
            this.quantityCodeToDelivered.Add(6,54);
            this.quantityCodeToDelivered.Add(7,183);
            this.quantityCodeToDelivered.Add(8,57);            
        }

        public override bool openConnection()
        {
            try
            {
                this.COM = getCOMPort();
                Console.WriteLine("Utiliza el puerto : {0}", this.COM);
                this.portDispenser = new SerialPort(this.COM, 9600, Parity.Even);
                this.portDispenser.Open();
                //resetDevice();
                setConfigDefault();
            }
            catch (IOException ex)
            {
                this.connection = false;
            }
            catch (Exception ex)
            {
                this.connection = false;
            }

            return this.connection;
        }

        public override string getCOMPort()
        {
            string puertoCOM = "";

            //Obteneniendo los dispositivos
            ManagementObjectCollection collection;

            //utilizando la WMI para obtener las propiedade de los dispositivos.
            var searcher = new ManagementObjectSearcher(@"Select * From Win32_PNPEntity");

            //Asignamos los dispositivos a nuestra coleccion
            collection = searcher.Get();

            //Recorremos la colección
            foreach (var device in collection)
            {
                foreach (PropertyData properties in device.Properties)
                {
                    if (properties.Name == "Name" && properties.Value != null)
                    {
                        var valor = (String)properties.Value;
                        if (valor.Contains("Prolific USB-to-Serial Comm Port"))
                        {
                            puertoCOM = valor.Substring(valor.LastIndexOf("COM"), 4);
                        }
                        else if(valor.Contains("Puerto de comunicaciones"))
                        {
                            puertoCOM = "COM2";
                        }
                    }
                }
            }

            if (puertoCOM == "")
            {
                this.portDispenser = null;
                throw new Exception("Bill Dispenser no conectado");
            }
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
            Thread.Sleep(2000);
            //this.dispenserBill[9] = this.deliveriBill[countBill[0]]; //billetes 20
            //this.dispenserBill[11] = this.deliveriBill[countBill[1]]; // billetes 50
            //this.dispenserBill[13] = this.deliveriBill[countBill[2]]; //billetes 100
            this.dispenserBill[9] = (byte)this.quantityCodeToDelivered[countBill[0]]; //billetes 20
            this.dispenserBill[11] = (byte)this.quantityCodeToDelivered[countBill[1]]; // billetes 50
            this.dispenserBill[13] = (byte)this.quantityCodeToDelivered[countBill[2]]; //billetes 100
            this.setCheckSum();
            sendMessage(this.dispenserBill);
            setFreeDevice();
        }

        private void setConfigDefault()
        {
            sendMessage(request);
            sendMessage(configDefault);
        }

        private void setFreeDevice()
        {
            setMessage(cancel);
            getMessage();
            setMessage(request2);
            setMessage(request);
            getMessage();
            setMessage(request2);
            getMessage();
            setMessage(request2);
            setMessage(request);
            getMessage();
            setMessage(request);
            getMessage();
        }

        private void resetDevice()
        {
            //Pendiente ya que se requiere ver el codigo de error del dispisitivo
            //Se validara con jesus para obtener el código
            setFreeDevice();
            setMessage(cancel);
            getMessage();
            setFreeDevice();
            setMessage(billCount);
            getMessage();
            setFreeDevice();
            setMessage(cancel);
            getMessage();
            setFreeDevice();
            setMessage(mechalReset);
            getMessage();
        }

        private void sendMessage(byte[] parameter)
        {
            byte result = 0;
            bool error = false;
            do
            {

                setMessage(parameter);
                result = getMessage();

                if (result != 6)
                {
                    setMessage(request2);
                    setMessage(request);
                    getMessage();
                    error = true;
                }
                else
                {
                    error = false;
                }
            } while (error);
        }

        private void setMessage(byte[] parameters)
        {
            TX = "TX: ";
            this.portDispenser.Write(parameters, 0, parameters.Length);
            Thread.Sleep(150);

            for (int i = 0, j = 0; i < parameters.Length; i++, j++)
            {
                TX += parameters[i] + " ";
            }
            //Console.WriteLine(TX);
        }

        private byte getMessage()
        {
            RX = "RX :";
            byte finalByte = 0;
            byte[] result = new byte[this.portDispenser.BytesToRead];

            this.portDispenser.Read(result, 0, result.Length);
            Thread.Sleep(500);
            resultMessage = new byte[result.Length];
            for (int i = 0, j = 0; i < result.Length; i++, j++)
            {
                resultMessage[j] = result[i];
                RX += result[i] + " ";
                finalByte = result[i];
            }
            //Console.WriteLine(RX);
            return finalByte;
        }

        public void setCheckSum()
        {

            byte[] range = new byte[29];
            int cont = 2;
            ushort[] table = new ushort[256];
            ushort polynomial = (ushort)0x8408;
            ushort value;
            ushort pow;
            ushort crc = 0;

            //Obteniendo el rango que se va a calcular
            for (int i = 0; i < this.dispenserBill.Length; i++)
            {
                range[i] = this.dispenserBill[cont];           
                if (cont == 30)
                {
                    break;
                }
                else
                {
                    cont++;
                }
            }
            
            //Definir los valore elevados a la potencia agregandolos a la tabla
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                pow = i;

                for (byte j = 0; j < 8; j++)
                {
                    if (((value ^ pow) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    pow >>= 1;
                }
                table[i] = value;
            }
            
            //Obtenniendo el checksum
            for (int x = 0; x < range.Length; x++)
            {
                byte index = (byte)(crc ^ range[x]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }

            //Invirtiendo los valores del checksum
            crc = (ushort)((crc << 8) | ((crc >> 8) & 0xFF));

            //Obtenemos el checksum en byte
            byte[] listCheckSum = BitConverter.GetBytes(crc);

            this.dispenserBill[31] = listCheckSum[1];
            this.dispenserBill[32] = listCheckSum[0];            
        }

    }
}
