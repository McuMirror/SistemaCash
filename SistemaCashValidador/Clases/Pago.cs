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

        public Pago()
        {
            cctalk = CCTalk.getInstancia();
            error = Error.getInstancia();
        }
        
        public void setNewOperation(int payout, Hashtable DBStored)
        {
            returnCash = new Hashtable();
            this.total = payout;
            this.cctalk.enableDevices(DBStored);
            this.deposited = cctalk.getCash(this.total);
            this.deliverCash();
            this.cctalk.disableDevices();
        }
           
        private void deliverCash()
        {
            stored = cctalk.getCashStored();
            int cashReturn = deposited - this.total;
            int tempCashReturn = cashReturn;

            if (cashReturn > 0)
            {
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 100);
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 50);
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 20);
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 10);
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 5);
                tempCashReturn = this.setAmountDeliverCash(tempCashReturn, 1);

                if (tempCashReturn == 0)
                {
                    this.cctalk.setDeliverCash(cashReturn, this.returnCash);
                }
                else
                {
                    //mostrar Mensaje cuando no hay cambio
                }
            }

        }

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
    }
}
