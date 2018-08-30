using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CashLib
{
    public class HopperDispenserASAHI: Hopper
    {

        public HopperDispenserASAHI()
        {
            this.manufacturer = "Silicon Labs CP210x USB to UART Bridge";
            this.device = "ASAHI";
        }

        public void returnCash(int typeCash, int count = 255)
        {
            switch (typeCash)
            {
                case 1:
                    this.emptyContainerCoin(4, (byte)count);
                    break;
                case 5:
                    this.emptyContainerCoin(5, (byte)count);
                    break;
                case 10:
                    this.emptyContainerCoin(7, (byte)count);
                    break;               
            }
        }

        /*
        * Encagado de vaciar todos los contendores
        * Los valores de lso contendores son los siguientes:
        *  Contenedor 4 : $1
        *  Contenedor 5 : $5
        *  Contenedor 7 : $10
        *  
        */
        public void emptyContainesCoins()
        {
            this.emptyContainerCoin(4);
            this.emptyContainerCoin(5);
            this.emptyContainerCoin(7);
        }

        
        /*
         * Encargado de vaciar el contenedor especificando el dispositivo
         */
        private void emptyContainerCoin(byte device, byte count = 255)
        {
            this.enableContainerCoin(device);
            Thread.Sleep(500);
            byte[] serie = this.getNumberSerie(device);
            serie[3] = count; //Define la cantidad que debe vaciar
            this.setMessage(new List<byte>() { device, 0, 1, 167 }, new
            List<byte>(serie));
            Thread.Sleep(500);
        }

        /*
         * Encargado de habilitar el contenedor de monedas.
         */
        private void enableContainerCoin(byte device)
        {
            this.setMessage(new List<byte>() { device, 0, 1, 164 }, new
            List<byte>() { 165 });
        }

        /*
        * Encargado de obtener los numero de serie del dispositvo
        */
        private byte[] getNumberSerie(byte device)
        {
            byte[] serie = new byte[4];
            this.setMessage(new List<byte>() { device, 0, 1, 242 }, new
            List<byte>());

            for (int i = 4, j = 0; i < this.resultMessage.Length - 1; i++, j++)
            {
                serie[j] = this.resultMessage[i];
            }
            return serie;
        }
    }
}
