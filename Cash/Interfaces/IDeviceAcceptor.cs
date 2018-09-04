using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLib.Interfaces
{
    public abstract class IDeviceAcceptor : IDeviceHopper
    {
        public delegate void powerUpEventHandler(object sender, EventArgs e);
        public delegate void connectEventHandler(object sender, EventArgs e);
        public delegate void stackEventHandler(object sender, EventArgs e);
        public delegate void powerUpCompletedEventHandler(object sender, EventArgs e);
        public delegate void escrowEventHandler(object sender, EventArgs e);
        public virtual event powerUpEventHandler powerUpEvent;
        public virtual event connectEventHandler connectEvent;
        public virtual event stackEventHandler stackEvent;
        public virtual event powerUpCompletedEventHandler powerUpCompleteEvent;
        public virtual event escrowEventHandler escrowEvent;

        public abstract byte[] getCashDesposite(int count = 0);
        public abstract void setEvents();
    }
}
