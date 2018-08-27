using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCashValidador.Clases
{
    class MessageEventArgs : EventArgs
    {
        public string lbMessage { get; set; }
        public int listCoins { get; set; }
        public int listBills { get; set; }
        public int lbTotal { get; set; }
        public int lbCambio { get; set; }
        public int lbMoney1 { get; set; }
        public int lbMoney2 { get; set; }
        public int lbMoney5 { get; set; }
        public int lbMoney10 { get; set; }
        public int lbBill20 { get; set; }
        public int lbBill50 { get; set; }
        public int lbBill100 { get; set; }
        public int lbBill200 { get; set; }
        public int lbBill500 { get; set; } 

    }
}
