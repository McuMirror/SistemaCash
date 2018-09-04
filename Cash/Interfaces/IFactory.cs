using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLib.Interfaces
{
    public interface IFactory
    {
        IDeviceAcceptor CreateDeviceAcceptor(string device);
        IDeviceDispenser CreateDeviceDispenser(string device);
    }
}
