using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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
        private Pago paying;

        public delegate void ErrorEventHandler(object sender, MessageEventArgs e);
        public delegate void InformationDevicesEventHandler(object sender, MessageEventArgs e);
        public delegate void DialogErrorEventHandler(object sender, MessageEventArgs e);
        public delegate void StoreEventHandler(object sender, MessageEventArgs e);
        public delegate void TransactionEventHandler(object sender, MessageEventArgs e);
        public delegate void ConfigHopperEventHandler(object sender, EventArgs e);
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event ErrorEventHandler errorEvent;
        public event InformationDevicesEventHandler informationDeviceEvent;
        //public event DialogErrorEventHandler dialogErrorEvent;
        public event StoreEventHandler storeEvent;
        public event TransactionEventHandler transactionEvent;
        public event ConfigHopperEventHandler configHopperEvent;
        public event MessageEventHandler messageEvent;

        public Controller_Transaccion()
        {
            this.cctalk = CCTalk.getInstancia();
            this.error = Error.getInstancia();
            this.transaction = new Transaccion();
            this.cashBox = new Caja();
            this.paying = new Pago();
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
            this.cctalk.messageEvent += new CCTalk.messageEventHandler(messageEvent);
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

        public void startNewTransaction(int payout)
        {
            Hashtable caja = this.cashBox.getCashBox();

            this.cctalk.enableDevices(caja);
            this.paying.getCurrentCashBox(caja);
            messageEvent(this, new MessageEventArgs { Message = "Empezando transaccion .... " });
            int cashReceived = cctalk.getCash(payout);
            int extraMoney = cashReceived - payout;

            if (extraMoney == 0)
            {
                this.cashBox.update(this.cctalk.getCashStored());
                this.transaction.createNewTransaction(payout, cashReceived, extraMoney, this.cctalk.getCashDelivered(), this.cctalk.getCashDeposited());    
                messageEvent(this, new MessageEventArgs { Message = "Transaccion terminada"});
            }
            else if (this.paying.validateExtraMoney(extraMoney))
            {
                messageEvent(this, new MessageEventArgs { Message = "Entragando cambio ... "});
                this.cctalk.deliveryExtraMoney(extraMoney, this.paying.getReturnCash());
                this.cashBox.update(this.cctalk.getCashStored());
                this.transaction.createNewTransaction(payout, cashReceived, extraMoney, this.cctalk.getCashDelivered(), this.cctalk.getCashDeposited());   
                messageEvent(this, new MessageEventArgs { Message = "Transaccion terminada"});
            }
            else
            {
                this.transaction.createNewTransaction(payout, cashReceived, extraMoney, this.cctalk.getCashDelivered(), this.cctalk.getCashDeposited());
                transactionEvent(this, new MessageEventArgs { lbCambio = extraMoney , lbIngresado = cashReceived });
                messageEvent(this, new MessageEventArgs { Message = "No cuento con efectivo disponible pare entregar el cambio, favor de pasar a ventanilla para solicitarlo"});
                Thread.Sleep(3000);
                messageEvent(this, new MessageEventArgs { Message = "Transaccion terminada" });
            }
            this.cctalk.disableDevices();
            Thread.Sleep(3000);
            messageEvent(this, new MessageEventArgs { Message = "Bienvenido al Sistema Demo Cash" });
        }

        public void updateCashBox(Hashtable data)
        {
            this.cashBox.update(data);
        }

        public Hashtable getDataTransaction()
        {
            return this.transaction.getLastDataTransaction();
        }

        public void closesDevices()
        {
            //this.cctalk.disableDevices();
        }
    }
}
