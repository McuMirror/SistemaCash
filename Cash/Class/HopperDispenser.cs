using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CashLib.Interfaces;

namespace CashLib.Class
{
    public class HopperDispenser : IDeviceDispenser
    {

        public HopperDispenser()
        {
            this.manufacturer = "USB Serial Port";
            this.device = "COMBOT";
        }

        public override void returnCash(int denominationCash, int countMoney = 255, int[] countBill = null)
        {            
            switch (denominationCash)
            {
                case 1:
                    this.emptyContainerCoin(33, (byte)countMoney);                    
                    break;
                case 5:
                    this.emptyContainerCoin(77, (byte)countMoney);                    
                    break;
                case 10:
                    this.emptyContainerCoin(76, (byte)countMoney);                    
                    break;
                case 2:
                    this.emptyMoneyBox();
                    break;
            }            
        }

        /*
         * Encagado de vaciar todos los contendores
         * Los valores de lso contendores son los siguientes:
         *  Contenedor 33 : $1
         *  Contenedor 76 : $10
         *  Contenedor 77 : $5
         *  
         */
        public void emptyContainesCoins()
        {
            this.emptyMoneyBox();
            this.emptyContainerCoin(33);
            this.emptyContainerCoin(77);
            this.emptyContainerCoin(76);
        }

        /*
         * Encargado de vaciar el contenedor alcancia con Id 2 contiene monedas de $2
         */
        public void emptyMoneyBox()
        {
            this.setMessage(new List<byte>() { 12, 0, 1, 70 }, new
            List<byte>() { 2 });
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
