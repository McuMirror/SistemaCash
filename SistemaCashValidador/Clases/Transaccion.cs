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
        private int numTransaccion;
        private Modelo_Transaccion DB;
        private Pago pago;
        private int total;
        private Hashtable stored;

        public Transaccion()
        {
            DB = new Modelo_Transaccion();
            pago = new Pago();
        }

        public Hashtable getDBStore()
        {            
            return this.DB.getCashBox();
        }

        public void setNewRegister(int payout)
        {
            this.numTransaccion = this.DB.getlatestRegister();
            stored = this.DB.getCashBox();
            this.pago.setNewOperation(payout, this.stored);
            this.total = 0;
        }        
                
    }
}
