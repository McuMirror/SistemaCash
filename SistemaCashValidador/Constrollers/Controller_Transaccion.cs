using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SistemaCashValidador.Clases;

namespace SistemaCashValidador.Constrollers
{
    class Controller_Transaccion
    {
        private Transaccion transaction;
        private CCTalk cctalk;
        private Error error;
        private Caja cashBox;

        public delegate void ErrorEventHandler(object sender, MessageEventArgs e);
        public delegate void InformationDevicesEventHandler(object sender, MessageEventArgs e);
        public delegate void DialogErrorEventHandler(object sender, MessageEventArgs e);       
        public delegate void StoreEventHandler(object sender, MessageEventArgs e);
        public delegate void TransactionEventHandler(object sender, MessageEventArgs e);
        public delegate void ConfigHopperEventHandler(object sender, EventArgs e);
        public event ErrorEventHandler errorEvent;
        public event InformationDevicesEventHandler informationDeviceEvent;
        //public event DialogErrorEventHandler dialogErrorEvent;
        public event StoreEventHandler storeEvent;
        public event TransactionEventHandler transactionEvent;
        public event ConfigHopperEventHandler configHopperEvent;

        public Controller_Transaccion()
        {
            this.cctalk = CCTalk.getInstancia();
            this.error = Error.getInstancia();
            this.transaction = new Transaccion();
            this.cashBox = new Caja();
        }

        public void validateConfigDevices()
        {
            if (!this.cctalk.validateConfigDevices())
            {
                configHopperEvent(this, new EventArgs());
            }
        }

        public Dictionary<string, string> getConfigDevices()
        {
            return this.cctalk.getConfigDevices();
        }

        public void setConfigEventError()
        {
            this.error.errorEvent += new Error.ErrorEventHandler(errorEvent);
            //this.error.dialogErrorEvent += new Error.DialogoErrorEventHandler(dialogErrorEvent);
        }

        public void setConfigEventsDevices()
        {            
            this.cctalk.lbInformationDeviceEvent += new CCTalk.updateInformationDevicesEventHandler(informationDeviceEvent);
            this.cctalk.lbStoresEvent += new CCTalk.updateLbStoreEventHandler(storeEvent);
            this.cctalk.lbTransactionEvent += new CCTalk.updateLbTransactionEventHandler(transactionEvent);
            this.cashBox.lbStoreEvent += new Caja.lbStoreEventHandler(storeEvent);
        }
      
        public void initializeDevices()
        {
            this.cctalk.initializeDevices();
        }

        public void setConfigDevices(Dictionary<string, string> selectedDevices)
        {
            this.cctalk.setConfigDevices(selectedDevices);
        }

        public void getStatusDevices()
        {
            this.cctalk.getStatus();
        }

        public Hashtable getCashBox()
        {
            return this.cashBox.setCashBoxInitial();
        }

        public void setNewPayout(int payout)
        {
            this.transaction.setNewRegister(payout);
        }

        public void updateCashBox(Hashtable data)
        {
            this.cashBox.update(data);
        }

        public void closesDevices()
        {
            //this.cctalk.disableDevices();
        }
    }
}
