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
            this.deviceConfiguration = new Dictionary<string, string>();
            this.deviceConfiguration.Add("HOPPERACCEPTOR", "");
            this.deviceConfiguration.Add("HOPPERDISPENSER", "");
            this.deviceConfiguration.Add("BILLACCEPTOR", "");
            this.deviceConfiguration.Add("BILLDISPENSER", "");
        }

        public bool validateConfiguration()
        {
            bool areTheDeviceDefined = true;
            foreach (KeyValuePair<string, string> device in this.deviceConfiguration)
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
            this.deviceConfiguration = selectedDevices;
        }

        public Dictionary<string, string> getConfig()
        {
            return this.deviceConfiguration;
        }
    }
}
