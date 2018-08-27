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
    class HopperOld
    {
        private SerialPort port;        
        protected byte[] resultMessage;

        //habre la conexcion al puerto
        public void abrirConexion()
        {
            try
            {
                port = new SerialPort(getPortCOM(), 9600);
                port.Open();
            }
            catch (IOException ex)
            {
                throw new Exception("Error: No se puede abrir la conexion con el dispositivo.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*
         * Encargado de obtener el puerto COM del dispositivo Hopper
         */
        private string getPortCOM()
        {
            string portCOM = "";
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
                            portCOM = valor.Substring(valor.LastIndexOf("COM"), 4);
                        }
                    }
                }
            }

            if (portCOM != "")
            {                
                return portCOM;
            }
            else
            {
                throw new Exception("Error: Hopper se encuentra desconectado");
            }
        }

        /*
         * Encargado de obtener el puerto COM del dispositivo para el bill dispenser 
         */
        private string getPortCOM2()
        {
            string puertoCOM = "";
            string[] ports = SerialPort.GetPortNames();

            foreach (string i in ports)
            {
                Console.WriteLine("Puerto : {0}", i);
                this.port = new SerialPort(i, 9600, Parity.Even);
                try
                {
                    this.port.Open();
                    //setFreeDevice();
                    //setMessage(request);
                    //getMessage();
                    if (resultMessage.Length > 0)
                    {
                        puertoCOM = i;
                    }
                    this.port.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            if (puertoCOM == "")
            {
                this.port = null;
                throw new Exception("Bill Dispenser no conectado");
            }
            return puertoCOM;
        }

        /*
         * Encargado de generar el codigo para enviarlo al dispositivo hooper.
         */
        public void getPeticion(List<byte> parameter, List<byte> data)
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

            this.setMessegePort(parameter);
            Thread.Sleep(500);
            this.getResultPort(parameter);
        }

        /*
         * Encargado de enviar el mensaje al dispositvo por el puerto COM
         */
        private void setMessegePort(List<byte> parameters)
        {
            string TX = "TX : ";
            byte[] arrayWrite = new byte[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                arrayWrite[i] = parameters[i];
                TX += parameters[i] + " ";
            }

            port.Write(arrayWrite, 0, arrayWrite.Length);
            //Console.WriteLine(TX);
        }

        /*
         *Encargado de almacenar de recibir la respuesta del puerto COM 
         */
        private void getResultPort(List<byte> parameters)
        {
            string RX = "RX : ";
            byte[] result = new byte[port.BytesToRead];
            port.Read(result, 0, result.Length);
            resultMessage = new byte[result.Length];

            for (int i = 0, j = 0; i < result.Length; i++, j++)
            {
                resultMessage[j] = result[i];
                RX += result[i] + " ";
            }
            //Console.WriteLine(RX); 
        }

        /*
       * Encargado de recetear el hopper Acceptor para que no almacene los datos 
       * de la ultima transacción
       */
        public void resetHooperAccepter()
        {
            this.getPeticion(new List<byte>() { 26, 0, 1, 1 }, new
            List<byte>());
        }

        /*
         * Encargado de obtener los numero de serie del dispositvo
         */
        public byte[] getNumberSerie(byte dispositivo)
        {
            byte[] serie = new byte[4];
            this.getPeticion(new List<byte>() { dispositivo, 0, 1, 242 }, new
            List<byte>());

            for (int i = 4, j = 0; i < this.resultMessage.Length - 1; i++, j++)
            {
                serie[j] = this.resultMessage[i];
            }
            return serie;
        }

        /*
         * Encargado de habilitar el contenedor de monedas.
         */
        public void enableContenedor(byte dispositivo)
        {
            this.getPeticion(new List<byte>() { dispositivo, 0, 1, 164 }, new
            List<byte>() { 165 });
        }

        /*
         * Encardado de modificar la denominacion que tendra el contenedor de monedas
         */
        public void indicarDepositoHopper(byte[] data)
        {
            this.getPeticion(new List<byte>() { 26, 0, 1, 210 }, new
            List<byte>(data));
        }

        /*
         * Encargado de definir por default la denominacion para todos los 
         * contenedores de monedas
        */
        public void configuracionDefaultHoppers()
        {
            this.indicarDepositoHopper(new byte[] { 4, 2 });//monedas de 1
            this.indicarDepositoHopper(new byte[] { 5, 0 });//monedas de 2
            this.indicarDepositoHopper(new byte[] { 6, 3 });//monedas de 5
            this.indicarDepositoHopper(new byte[] { 7, 5 });//monedas de 10
        }

        /*
         * Encargado de vaciar el contenedor alcancia 
         */
        public void vaciarAlcancia(byte data)
        {
            //si data = 1 se vacia por atras
            //si data = 2 se vacia por enfrente
            this.getPeticion(new List<byte>() { 12, 0, 1, 70 }, new
            List<byte>() { data });
        }

        /*
      * Encagado de vaciar todos los contendores
      */
        public void vaciarContenedores()
        {
            this.vaciarAlcancia(2);
            this.vaciarContenedor(33);
            this.vaciarContenedor(76);
            this.vaciarContenedor(77);
        }

        /*
         * Encargado de vaciar el contenedor especificando el dispositivo
         */
        public void vaciarContenedor(byte dispositvo)
        {
            this.enableContenedor(dispositvo);
            Thread.Sleep(500);

            byte[] serie = this.getNumberSerie(dispositvo);
            serie[3] = 255;
            this.getPeticion(new List<byte>() { dispositvo, 0, 1, 167 }, new
            List<byte>(serie));
            Thread.Sleep(500);
        }

        /*
          * Encargado de configurar por default las monedas que se van aceptar con las denominaciones:
          * $1,$2,$5,$10 
          */
        public void configDefaultAcceptor()
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
            // El data queda [120,255] el dos 255 siempres se va a poner

            this.getPeticion(new List<byte>() { 26, 0, 1, 231 }, new
            List<byte>() { 120, 255 });
        }

        /*
         * Encardo de obtener los ID de los contenedores
         * Por default los dispositivos tienen los siguientes ID:
         *  0 = tarjeta principal (controladora master)
         *  12 = contenedor alcancia
         *  26 = Hopper Acceptor
         *  33 = Contenedor inferior
         *  76 = contenedor superior
         *  77 = contenedor de en medio
         */
        public void getIDDispositvos()
        {
            this.getPeticion(new List<byte>() { 0, 0, 1, 253 }, new
            List<byte>());
        }

        /*
         * Encardo de obtener la cantidad y monedas depositadas en el hopper acceptor
         */
        public byte[] showCoinsDeposited()
        {
            this.getPeticion(new List<byte>() { 26, 0, 1, 229 }, new
                List<byte>() { 4 });

            return this.resultMessage;
        }


        #region Funciones no usadas

        /*
         * Encargado de validar si el puerto sigue conectado.
         * Se validara si metodo tiene funcionalidad en caso de no utilizarce se elimina de la clase
         */
        public bool validarPuerto()
        {
            return port.IsOpen;
        }

        /*
         * Encargado de habilitar todas las monedas que se van aceptar
         * las denominaciones de monedas son ($0.1, $.50,$1,$2,$5,$10). 
         */
        public void enableCoins()
        {
            this.getPeticion(new List<byte>() { 26, 0, 1, 231 }, new
            List<byte>() { 255, 255 });
        }


        #endregion
    }
}
