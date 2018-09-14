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
        public string Message { get; set; }       
        public int listCoins { get; set; }
        public int listBills { get; set; }
        public int lbIngresado { get; set; }
        public int lbCambio { get; set; }
        public int inputR1 { get; set; }
        public int inputR2 { get; set; }
        public int inputR5 { get; set; }
        public int inputR10 { get; set; }
        public int inputR20 { get; set; }
        public int inputR50 { get; set; }
        public int inputR100 { get; set; }
        public int inputR200 { get; set; }
        public int inputR500 { get; set; }
        public int inputE1 { get; set; }
        public int inputE2 { get; set; }
        public int inputE5 { get; set; }
        public int inputE10 { get; set; }
        public int inputE20 { get; set; }
        public int inputE50 { get; set; }
        public int inputE100 { get; set; }
        public int inputE200 { get; set; }
        public int inputE500 { get; set; }
        public int inputD1 { get; set; }
        public int inputD2 { get; set; }
        public int inputD5 { get; set; }
        public int inputD10 { get; set; }
        public int inputD20 { get; set; }
        public int inputD50 { get; set; }
        public int inputD100 { get; set; }
        public int inputD200 { get; set; }
        public int inputD500 { get; set; }
        public int inputT1 { get; set; }
        public int inputT2 { get; set; }
        public int inputT5 { get; set; }
        public int inputT10 { get; set; }
        public int inputT20 { get; set; }
        public int inputT50 { get; set; }
        public int inputT100 { get; set; }
        public int inputT200 { get; set; }
        public int inputT500 { get; set; }
    }
}
