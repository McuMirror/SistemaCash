using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaCashValidador.Modelos;

namespace SistemaCashValidador.Clases
{
    class Error
    {
        private static Error instancia = null;
        private Modelo_Transaccion db;

        public delegate void ErrorEventHandler(object sender, MessageEventArgs e);
        public delegate void DialogoErrorEventHandler(object sender, MessageEventArgs e);
        public event ErrorEventHandler errorEvent;
        public event DialogoErrorEventHandler dialogErrorEvent;

        public Error()
        {
            db = new Modelo_Transaccion();
        }

        public static Error getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Error();
            }
            return instancia;
        }
    
        public void setLog(string mensaje)
        {
            errorEvent(this, new MessageEventArgs() { lbMessage = mensaje});
        }

        public void setMesseg(string mensaje)
        {            
            errorEvent(this, new MessageEventArgs() { lbMessage = mensaje });
        }
        
    }
}
