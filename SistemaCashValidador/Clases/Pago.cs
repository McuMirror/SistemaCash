using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCashValidador.Clases
{
    class Pago
    {
        private CCTalk cctalk;
        private Error error;
        private int total;
        private int deposited;
        private Hashtable stored;
        private Hashtable returnCash;
        private int extraMoney;

        public Pago()
        {
            cctalk = CCTalk.getInstancia();
            error = Error.getInstancia();
        }

        public void getCurrentCashBox(Hashtable cashBox)
        {
            this.stored = cashBox;
        }
        
        //public void setNewOperation(int payout, Hashtable DBStored)
        //{
        //    //returnCash = new Hashtable();
        //    //this.total = payout;
        //    //this.cctalk.enableDevices(DBStored);
        //    //this.deposited = cctalk.getCash(this.total);
        //    //this.validateCashDelivery();
        //    //this.cctalk.disableDevices();
        //}
           
        

        private int setAmountDeliverCash(int cash, int coinType)
        {
            int cantidad = 0;

            if (cash >= coinType)
            {
                cantidad = cash / coinType;
                if ((int)stored[coinType.ToString()] >= cantidad)
                {
                    cash -= (cantidad * coinType);
                    returnCash.Add(coinType, cantidad);
                }
                else if ((int)stored[coinType.ToString()] > 0)
                {
                    cantidad -= (int)stored[coinType.ToString()];
                    cash -= ((int)stored[coinType.ToString()] * coinType);
                    returnCash.Add(coinType, (int)stored[coinType.ToString()]);
                }
            }

            return cash;            
        }

        public bool validateExtraMoney(int money)
        {            
            this.calculateExtraMoney(money);
            if (this.extraMoney == 0)
            {
                return true;
            }
            else
            {
                return false;                     
            }
        }

        private void calculateExtraMoney(int money)
        {
            //stored = cctalk.getCashStored();
            //int cashDelivery = deposited - this.total;
            returnCash = new Hashtable();
            int cash = money;

            if (money > 0)
            {
                cash = this.setAmountDeliverCash(cash, 100);
                cash = this.setAmountDeliverCash(cash, 50);
                cash = this.setAmountDeliverCash(cash, 20);
                cash = this.setAmountDeliverCash(cash, 10);
                cash = this.setAmountDeliverCash(cash, 5);
                cash = this.setAmountDeliverCash(cash, 1);
            }

            this.extraMoney = cash;

        }

        public Hashtable getReturnCash()
        {
            return this.returnCash;
        }
    }
}
