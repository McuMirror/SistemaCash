using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCashValidador.Modelos;

namespace SistemaCashValidador.Clases
{
    class Transaccion
    {
 
        private Modelo_Transaccion DB;

        public Transaccion()
        {
            DB = new Modelo_Transaccion();
        }

        public Hashtable getDBStore()
        {            
            return this.DB.getCashBox();
        }

        public void createNewTransaction(int payout, int cashReceived, int extraMoney, Hashtable cashDelivered, Hashtable cashDeposited)
        {
            this.DB.generateNewTransaction(payout, cashReceived, extraMoney);
            this.DB.setExtraMoneyTransaction(cashDelivered);
            this.DB.setPayoutTransaction(cashDeposited);           
        }        
                
    }
}
