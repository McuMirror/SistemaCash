using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SistemaCashValidador.Clases
{

    class CCTalk
    {
        private static CCTalk instancia = null;
        public delegate void updateInformationDevicesEventHandler(object sender, MessageEventArgs e);  
        public delegate void updateLbStoreEventHandler(object sender, MessageEventArgs e);
        public delegate void updateLbTransactionEventHandler(object sender, MessageEventArgs e);
        public delegate void messageEventHandler(object sender, MessageEventArgs e);
        public event updateInformationDevicesEventHandler lbInformationDeviceEvent;
        public event updateLbStoreEventHandler lbStoresEvent;
        public event updateLbTransactionEventHandler lbTransactionEvent;
        public event messageEventHandler messageEvent;

        private CashLib.Interfaces.IDeviceAcceptor hopperAcceptor;
        private CashLib.Interfaces.IDeviceDispenser hopperDispenser;
        private CashLib.Interfaces.IDeviceAcceptor billAcceptor;
        private CashLib.Interfaces.IDeviceDispenser billDispenser;
        private CashLib.Factory.FactoryDeviceCash factory;

        private MessageEventArgs components;
        private Error error;
        private int billDesposited;
        private Hashtable stored;
        private Hashtable cashDelivered;
        private Hashtable cashDeposited;
        private CCTalkConfig config;
        
        public CCTalk()
        {
            error = Error.getInstancia();
            factory = new CashLib.Factory.FactoryDeviceCash();
            components = new MessageEventArgs();
            config = new CCTalkConfig();            
        }

        public static CCTalk getInstancia()
        {
            if (instancia == null)
            {
                instancia = new CCTalk();
            }
            return instancia;
        }

        public bool validateConfigDevices()
        {
            try
            {
                BinaryFormatter formated = new BinaryFormatter();
                Stream file = new FileStream("configDevices.cash", FileMode.Open, FileAccess.Read, FileShare.None);
                this.config = (CCTalkConfig)formated.Deserialize(file);
                file.Close();
                return this.config.validateConfiguration();
            }
            catch (IOException ex)
            {
                return this.config.validateConfiguration();
            }
            
        }

        public void setConfigDevices(Dictionary<string, string> selectedDevices)
        {
            this.config.setConfig(selectedDevices);
            BinaryFormatter formated = new BinaryFormatter();
            Stream file = new FileStream("configDevices.cash", FileMode.Create, FileAccess.Write, FileShare.None);
            formated.Serialize(file, this.config);
            file.Close();
        }       

        public void initializeDevices()
        {
            Dictionary<string, string> devices = this.config.getConfig();
            this.hopperAcceptor = factory.CreateDeviceAcceptor(devices["HOPPERACCEPTOR"]);
            this.hopperDispenser = factory.CreateDeviceDispenser(devices["HOPPERDISPENSER"]);
            this.billAcceptor = factory.CreateDeviceAcceptor(devices["BILLACCEPTOR"]);
            this.billDispenser = factory.CreateDeviceDispenser(devices["BILLDISPENSER"]);
            this.setEvents();
        }

        public Dictionary<string, string> getConfigDevices()
        {
            return this.config.getConfig();
        }

        private void setEvents()
        {
            billAcceptor.powerUpEvent += powerUpHandle;
            billAcceptor.connectEvent += connectedHandle;
            billAcceptor.stackEvent += stackHandle;
            billAcceptor.powerUpCompleteEvent += PowerUpCompletedHandle;
            billAcceptor.escrowEvent += escrowHandle;
            billAcceptor.setEvents();
        }

        public void getStatus()
        {
            string fail = "";

            if (!hopperAcceptor.openConnection())
            {
                fail += " No Conectado Hopper Accepter";
            }

            if (!hopperDispenser.openConnection())
            {
                fail += " No Conectado Hopper Dispenser";
            }

            if (!billAcceptor.openConnection())
            {
                fail += " No Conectado Bill Acceptor";
            }

            if (!billDispenser.openConnection())
            {
                fail += " No Conectado Bill Dispenser";
            }
            this.components.lbMessage = fail;
            lbInformationDeviceEvent(this, components);
        }

        public void enableDevices(Hashtable DBStored)
        {
            billAcceptor.enable();
            billDispenser.enable();
            hopperAcceptor.enable();
            hopperDispenser.enable();

            this.stored = DBStored;
            this.billDesposited = 0;
            this.setValuesInitialLabelsAndList();
            this.cashDelivered = new Hashtable();
            this.cashDelivered.Add("1",0);
            this.cashDelivered.Add("5", 0);
            this.cashDelivered.Add("10", 0);
            this.cashDelivered.Add("20", 0);
            this.cashDelivered.Add("50", 0);
            this.cashDelivered.Add("100", 0);

            this.cashDeposited = new Hashtable();
            this.cashDeposited.Add("1", 0);
            this.cashDeposited.Add("2", 0);
            this.cashDeposited.Add("5", 0);
            this.cashDeposited.Add("10", 0);
            this.cashDeposited.Add("20", 0);
            this.cashDeposited.Add("50", 0);
            this.cashDeposited.Add("100", 0);
            this.cashDeposited.Add("200", 0);
            this.cashDeposited.Add("500", 0);

            lbTransactionEvent(this, components);
        }

        public int getCash(int total)
        {

            byte[] result;
            int deposited = 0;
            int contador = 0;
            components.Message = "Ingrese el efectivo";            
            messageEvent(this,components);
            while (deposited < total)
            {
                result = hopperAcceptor.getCashDesposite(contador);

                if (result[1] != contador)
                {
                    switch (result[0])
                    {
                        case 10:
                            components.inputR10 += 1;
                            components.listCoins = 10;
                            deposited += 10;                          
                            this.stored["10"] = components.inputR10;
                            this.updateCashReceived("10");
                            break;
                        case 5:
                            components.inputR5 += 1;
                            components.listCoins = 5;
                            deposited += 5;                            
                            this.stored["5"] = components.inputR5;
                            this.updateCashReceived("5");
                            break;
                        case 2:
                            components.inputR2 += 1;
                            components.listCoins = 2;
                            deposited += 2;                            
                            this.stored["2"] = components.inputR2;
                            this.updateCashReceived("2");
                            break;
                        case 1:
                            components.inputR1 += 1;
                            components.listCoins = 1;
                            deposited += 1;
                            this.stored["1"] = components.inputR5;
                            this.updateCashReceived("1");
                            break;
                    }
                    components.lbIngresado = deposited;
                    lbTransactionEvent(this, components);
                    lbStoresEvent(this, components);
                    contador = result[1];
                }
                else if (this.billDesposited != 0)
                {
                    switch (this.billDesposited)
                    {
                        case 20:
                            components.inputR20 += 1;
                            components.listBills = 20;
                            this.stored["20"] = components.inputR20;
                            this.updateCashReceived("20");
                            break;
                        case 50:
                            components.inputR50 += 1;
                            components.listBills = 50;
                            this.stored["50"] = components.inputR50;
                            this.updateCashReceived("50");
                            break;
                        case 100:
                            components.inputR100 += 1;
                            components.listBills = 100;
                            this.stored["100"] = components.inputR100;
                            this.updateCashReceived("100");
                            break;
                        case 200:
                            components.inputR200 += 1;
                            components.listBills = 200;
                            this.stored["200"] = components.inputR200;
                            this.updateCashReceived("200");
                            break;
                        case 500:
                            components.inputR500 += 1;
                            components.listBills = 500;
                            this.stored["500"] = components.inputR500;
                            this.updateCashReceived("500");
                            break;
                    }

                    lbStoresEvent(this, components);
                    deposited += this.billDesposited;
                    components.lbIngresado = deposited;
                    lbTransactionEvent(this, components);
                    this.billDesposited = 0;

                }
            }
            return deposited;
        }

        private void updateCashReceived(string typeMoney)
        {
            this.cashDeposited[typeMoney] = (int)this.cashDeposited[typeMoney] + 1;
        }

        public void disableDevices()
        {
            hopperAcceptor.disable();
            hopperDispenser.disable();
            billAcceptor.disable();
            billDispenser.disable();
        }

        private double getBillDeposite(double bill)
        {
            return bill;
        }

        private void setValuesInitialLabelsAndList()
        {
            this.components.listCoins = 0;
            this.components.listBills = 0;
            this.components.lbIngresado = 0;
            this.components.inputR1 = (int)this.stored["1"];
            this.components.inputR2 = (int)this.stored["2"];
            this.components.inputR5 = (int)this.stored["5"];
            this.components.inputR10 = (int)this.stored["10"];
            this.components.inputR20 = (int)this.stored["20"];
            this.components.inputR50 = (int)this.stored["50"];
            this.components.inputR100 = (int)this.stored["100"];
            this.components.inputR200 = (int)this.stored["200"];
            this.components.inputR500 = (int)this.stored["500"];
        }

        public Hashtable getCashStored()
        {
            return this.stored;
        }

        public void deliveryExtraMoney(int cash, Hashtable countCash)
        {

            int[] returnBill = new int[3] { 0, 0, 0 };            
            components.lbCambio = cash;
            lbTransactionEvent(this, components);

            foreach (DictionaryEntry i in countCash)
            {
                int key = (int)i.Key;
                int value = (int)i.Value;              
                switch (key)
                {
                    case 20:
                        returnBill[0] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateCashDelivered(key.ToString(), value);
                        break;
                    case 50:
                        returnBill[1] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateCashDelivered(key.ToString(), value);
                        break;
                    case 100:
                        returnBill[2] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateCashDelivered(key.ToString(), value);
                        break;
                }                                
                lbStoresEvent(this, components);                
            }

            billDispenser.returnCash(0,0,returnBill);

            foreach (DictionaryEntry i in countCash)
            {
                int key = (int)i.Key;
                int value = (int)i.Value;
                if (key == 10 || key == 5 || key == 1)
                {
                    this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                    this.updateCashDelivered(key.ToString(), value);
                    hopperDispenser.returnCash(key, value, null);
                }              
                lbStoresEvent(this, components);                                
            }

        }

        private void updateCashDelivered(string typeMoney, int count)
        {
            this.cashDelivered[typeMoney] = count;
        }

        public Hashtable getCashDelivered()
        {
            return this.cashDelivered;
        }

        public Hashtable getCashDeposited()
        {
            return this.cashDeposited;
        }

        #region Eventos para Bill Accetor

        private void powerUpHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador de POWER UP");
        }

        private void connectedHandle(object sender, EventArgs e)
        {
            billAcceptor.setConfig();
        }

        private void stackHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : Stack");
            byte[] cash = billAcceptor.getCashDesposite();
            if (cash[0] == 244)
            {
                billDesposited += 500;
            }
            else
            {
                billDesposited += (int)cash[0];
            }
            Console.WriteLine("Recibido : {0}", this.billDesposited);
        }

        private void PowerUpCompletedHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : POWERUP_COMPLETED");
        }

        private void escrowHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : ESCROW");
        }

        #endregion

    }
}
