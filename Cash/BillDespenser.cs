using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CashLib
{
    public class BillDespenser : IDevice
    {
        private SerialPort port;
        private bool connection = true;
        private string COM;
        private byte[] resultMessage;
        private static string RX;
        private static string TX;

        private byte[] cancel = new byte[] { 0x10, 0x02, 0x00, 0x03, 0x00, 0x10, 0x1C, 0x10, 0x03, 0xE0, 0x48 };
        private byte[] request = new byte[] { 0x10, 0x05 };
        private byte[] request2 = new byte[] { 0x10, 0x06 };
        private byte[] configDefault = new byte[] { 0x10, 0x02, 0x00, 0x21, 0x60, 0x02, 0xFF, 0x00, 0x00, 0x1A, 0x00, 0x40, 0x082, 0x6E, 0x89, 0x75, 0x93, 0x7F, 0x00, 0x00, 0x0C, 0x0C, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0xA6, 0xAE };
        private byte[] bill20 = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0xB1, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x02, 0x02, 0x02, 0x00, 0x1C, 0x10, 0x03, 0x9A, 0xD6 };
        private byte[] bill50 = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0x30, 0x30, 0xB1, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x02, 0x02, 0x02, 0x00, 0x1C, 0x10, 0x03, 0x8B, 0x76 };
        private byte[] bill100 = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0x30, 0x30, 0x30, 0x30, 0xB1, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x02, 0x02, 0x02, 0x00, 0x1C, 0x10, 0x03, 0x99, 0x10 };
        private byte[] clear_log = new byte[] { 0x10, 0x02, 0x00, 0x2d, 0x60, 0x12, 0x29, 0x03, 0x4c, 0x6f, 0x67, 0x20, 0x63, 0x6c, 0x65, 0x61, 0x72, 0x20, 0x64, 0x61, 0x74, 0x65, 0x20, 0x3a, 0x20, 0x32, 0x30, 0x31, 0x38, 0x2e, 0x30, 0x38, 0x2e, 0x31, 0x35, 0x20, 0x31, 0x35, 0x3a, 0x35, 0x37, 0x3a, 0x33, 0x34, 0x00, 0x00, 0x00, 0x00, 0x1c, 0x10, 0x03, 0x76, 0x35 };
        private byte[] bill_count = new byte[] { 0x10, 0x02, 0x00, 0x19, 0x60, 0x03, 0x15, 0xE4, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0x14, 0x4d };
        private byte[] mechal_reset = new byte[] { 0x10, 0x02, 0x00, 0x11, 0x60, 0x02, 0x0D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1C, 0x10, 0x03, 0x64, 0xEC };

        public bool openConnection()
        {
            try
            {
                this.COM = getCOMPort();
                Console.WriteLine("Utiliza el puerto : {0}", this.COM);
                this.port = new SerialPort(this.COM, 9600, Parity.Even);
                port.Open();
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

        public string getCOMPort()
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
                    }
                }
            }

            if (puertoCOM == "")
            {
                this.port = null;
                throw new Exception("Bill Dispenser no conectado");
            }
            return puertoCOM;
        }

        public void enable()
        {
            setFreeDevice();
        }

        public void disable()
        {
            setFreeDevice();
        }

        public bool isConnection()
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

        public void returnCash(int money, int cantidad)
        {
            int contador = 0;

            while (contador < cantidad)
            {
                switch (money)
                {
                    case 20:                        
                        sendMessage(bill20);
                        setFreeDevice();
                        break;
                    case 50:
                        sendMessage(bill50);
                        setFreeDevice();
                        break;
                    case 100:
                        sendMessage(bill100);
                        setFreeDevice();
                        break;
                }
                contador++;                
            }
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
            setMessage(bill_count);
            getMessage();
            setFreeDevice();
            setMessage(cancel);
            getMessage();
            setFreeDevice();
            setMessage(mechal_reset);
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
            port.Write(parameters, 0, parameters.Length);
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
            byte[] result = new byte[port.BytesToRead];

            port.Read(result, 0, result.Length);
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
    }
}
