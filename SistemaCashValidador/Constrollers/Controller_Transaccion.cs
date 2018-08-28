using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public delegate void DialogErrorEventHandler(object sender, MessageEventArgs e);
        public delegate void ListBillsEventHandler(object sender, MessageEventArgs e);
        public delegate void ListCoinsEventHandler(object sender, MessageEventArgs e);
        public delegate void StoreEventHandler(object sender, MessageEventArgs e);
        public delegate void TransactionEventHandler(object sender, MessageEventArgs e);
        public event ErrorEventHandler errorEvent;
        public event DialogErrorEventHandler dialogErrorEvent;
        public event ListBillsEventHandler ListBillsEvent;
        public event ListCoinsEventHandler ListCoinsEvent;
        public event StoreEventHandler storeEvent;
        public event TransactionEventHandler transactionEvent;

        public Controller_Transaccion()
        {
            this.cctalk = CCTalk.getInstancia();
            this.error = Error.getInstancia();
            this.transaction = new Transaccion();
            this.cashBox = new Caja();
            
        }

        public void setConfigEvents()
        {
            this.error.errorEvent += new Error.ErrorEventHandler(errorEvent);
            //this.error.dialogErrorEvent += new Error.DialogoErrorEventHandler(dialogErrorEvent);
            this.cctalk.listBillsEvent += new CCTalk.updateListBillsEventHandler(ListBillsEvent);
            this.cctalk.listConisEvent += new CCTalk.updateListCoinsEventHandler(ListCoinsEvent);
            this.cctalk.lbStoresEvent += new CCTalk.updateLbStoreEventHandler(storeEvent);
            this.cctalk.lbTransactionEvent += new CCTalk.updateLbTransactionEventHandler(transactionEvent);
            this.cctalk.setEvents();
            this.cashBox.lbStoreEvent += new Caja.lbStoreEventHandler(storeEvent);
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
