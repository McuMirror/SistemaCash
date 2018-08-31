using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLib
{
    public class DeviceBill : IDevice
    {

        public virtual bool openConnection()
        {
            return true;
        }

        public virtual string getCOMPort()
        {
            return null;
        }

        public virtual bool isConnection()
        {
            return true;
        }

        public virtual void disable()
        {
            
        }

        public virtual void enable()
        {
            
        }
        
    }
}
