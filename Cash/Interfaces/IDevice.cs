using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLib.Interfaces
{
    public interface IDevice
    {        
        bool openConnection(); //Abre la conexion con el dispositvo
        string getCOMPort(); //Obtiene el puerto COM
        bool isConnection(); //Regresa el valor de la conexion actual  
        void enable(); //Habilita dispositivo
        void disable(); //Deshabilita dispositivo
    }
}
