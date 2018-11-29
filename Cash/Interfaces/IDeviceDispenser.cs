using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashLib.Interfaces
{
    public abstract class IDeviceDispenser : IDeviceHopper
    {
        public abstract void returnCash(int denominationCash, int countMoney, int[] countBill);
        public abstract void resetDevice();
    }
}
