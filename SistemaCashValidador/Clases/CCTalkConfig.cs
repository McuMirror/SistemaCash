using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCashValidador.Clases
{
    [Serializable]
    class CCTalkConfig
    {
        private Dictionary<string, string> deviceConfiguration;

        public CCTalkConfig()
        {
            deviceConfiguration = new Dictionary<string, string>();
            deviceConfiguration.Add("HOPPERACCEPTOR", "");
            deviceConfiguration.Add("HOPPERDISPENSER", "");
            deviceConfiguration.Add("BILLACCEPTOR", "");
            deviceConfiguration.Add("BILLDISPENSER", "");
        }

        public bool validateConfiguration()
        {
            bool areTheDeviceDefined = true;
            foreach (KeyValuePair<string, string> device in deviceConfiguration)
            {
                if (device.Value == "")
                {
                    areTheDeviceDefined = false;
                }
            }
            return areTheDeviceDefined;
        }

        public void setConfig(Dictionary<string, string> selectedDevices)
        {
            deviceConfiguration = selectedDevices;
        }
    }
}
