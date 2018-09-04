using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Management;



namespace CashLib.Interfaces
{


    public class IDeviceHopper : IDevice
    {
        protected static SerialPort portHopper;
        private bool connection = true;
        protected byte[] resultMessage;
        private static string COM;
        protected string manufacturer;
        protected string device;


        public virtual bool openConnection()
        {
            try
            {
                if (portHopper == null)
                {
                    COM = getCOMPort();
                    Console.WriteLine("Utiliza el puerto : {0}", COM);
                    portHopper = new SerialPort(COM, 9600);
                    portHopper.Open();
                }
                else
                {
                    Console.WriteLine("Utiliza el puerto : {0}", COM);
                }
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

        public virtual string getCOMPort()
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
                        if (valor.Contains(this.manufacturer))
                        {
                            puertoCOM = valor.Substring(valor.LastIndexOf("COM"), 4);
                        }
                    }
                }
            }

            if (puertoCOM == "")
            {
                portHopper = null;
                throw new Exception("Hopper no conectado");
            }
            return puertoCOM;
        }

        public virtual bool isConnection()
        {
            return this.connection;
        }

        public virtual void enable()
        {
            this.setConfig();
        }

        public virtual void disable()
        {

        }

        //Envia mensaje al dispositivo
        protected void setMessage(List<byte> parameter, List<byte> data)
        {
            parameter = this.setChecksum(parameter, data);
            this.sendMessage(parameter);
            Thread.Sleep(500);
            this.getMessage(parameter);
        }

        //Regresa el Checksum
        private List<byte> setChecksum(List<byte> parameter, List<byte> data)
        {
            byte sum = 0;
            if (data.Count > 0)
            {
                parameter[1] = (byte)data.Count;
            }

            parameter.AddRange(data);

            foreach (byte i in parameter)
            {
                sum += i;
            }

            sum = (byte)(256 - (sum % 256));

            parameter.Add(sum);

            return parameter;
        }

        //Envia el mensaje al dispositivo
        private void sendMessage(List<byte> parameters)
        {
            string TX = "TX : ";
            byte[] arrayWrite = new byte[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                arrayWrite[i] = parameters[i];
                TX += parameters[i] + " ";
            }

            portHopper.Write(arrayWrite, 0, arrayWrite.Length);
            //Console.WriteLine(TX);
        }

        //Regresa la respuesta del dispositvo
        private void getMessage(List<byte> parameters)
        {
            string RX = "RX : ";
            int length = 0;
            byte[] result = new byte[portHopper.BytesToRead];
            portHopper.Read(result, 0, result.Length);
            length = (this.device == "COMBOT") ? result.Length : (result.Length - parameters.Count);
            resultMessage = new byte[length];
            length = (this.device == "COMBOT") ? 0 : parameters.Count;

            for (int i = length, j = 0; i < result.Length; i++, j++)
            {
                resultMessage[j] = result[i];
                RX += result[i] + " ";
            }
            Console.WriteLine(RX);
        }

        /*
         * Encargado de definir por default la denominacion para todos los 
         * contenedores de monedas
         */
        protected void setDefaultConfigConteinersCoins()
        {
            this.setValueConteinerCoins(new byte[] { 4, 2 });//monedas de 1
            this.setValueConteinerCoins(new byte[] { 5, 0 });//monedas de 2
            this.setValueConteinerCoins(new byte[] { 6, 3 });//monedas de 5
            this.setValueConteinerCoins(new byte[] { 7, 5 });//monedas de 10
        }

        /*
        * Encardado de modificar la denominacion que tendra el contenedor de monedas
        */
        public void setValueConteinerCoins(byte[] data)
        {
            this.setMessage(new List<byte>() { 26, 0, 1, 210 }, new
            List<byte>(data));
        }

        //Estableciendo la configuracion inicial para el hooper
        public virtual void setConfig()
        {
            if (this.device == "COMBOT")
            {
                this.resetAccepter();
                this.setDefaultConfigConteinersCoins();
                this.setConfigDefault();
            }
            else
            {
                this.resetAccepter();
                this.setConfigDefault();
            }
        }

        /*
        * Encargado de recetear el Acceptador para limpiar los datos 
        * de la ultima transacción
        */
        private void resetAccepter()
        {
            if (this.device == "COMBOT")
            {
                this.setMessage(new List<byte>() { 26, 0, 1, 1 }, new List<byte>());
            }
            else
            {
                this.setMessage(new List<byte>() { 2, 0, 1, 1 }, new List<byte>());  
            }
        }

        /*
         * Encargado de configurar por default las monedas que se van aceptar con las denominaciones:
         * $1,$2,$5,$10 
         */
        private void setConfigDefault()
        {
            //Binario para aceptar las monedas
            //[00000000] = 0 no acepta monedas
            //[00000001] = 1 acepta $0.10 (coin 1)
            //[00000010] = 2 acepta $0.20 (coin 2)
            //[00000100] = 6 acepta $0.50 (coin 3)
            //[00001000] = 8 acepta $1 (coin 4)
            //[00010000] = 16 acepta $2 (coin 5)
            //[00100000] = 32 acepta $5 (coin 6)
            //[01000000] = 64 acepta $10 (coin 7)
            //[10000000] = 128 acepta $20 (coin 8)

            //Para agregar solo las $10,$5,$2 $1 mandar 120 
            //[01111000] = 120 
            // El data queda [120,255] el 255 siempres se va a poner
            if (this.device == "COMBOT")
            {
                this.setMessage(new List<byte>() { 26, 0, 1, 231 }, new
            List<byte>() { 120, 255 });
            }
            else
            {
                this.setMessage(new List<byte>() { 2, 0, 1, 231 }, new
           List<byte>() { 255, 255 });
            }

        }

        /*
         * Obtiene los id que tienen los dispositivos 
         */
        public void getIdDevice()
        {
            this.setMessage(new List<byte>() { 0, 0, 1, 253 }, new
            List<byte>());
        }


    }
}
