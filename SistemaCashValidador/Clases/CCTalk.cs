using System;
using System.Collections;
using System.Threading;

namespace SistemaCashValidador.Clases
{
    [Serializable]
    class CCTalk
    {
        private static CCTalk instancia = null;
        public delegate void updateListBillsEventHandler(object sender, MessageEventArgs e);
        public delegate void updateListCoinsEventHandler(object sender, MessageEventArgs e);
        public delegate void updateLbStoreEventHandler(object sender, MessageEventArgs e);
        public delegate void updateLbTransactionEventHandler(object sender, MessageEventArgs e);
        public event updateListBillsEventHandler listBillsEvent;
        public event updateListCoinsEventHandler listConisEvent;
        public event updateLbStoreEventHandler lbStoresEvent;
        public event updateLbTransactionEventHandler lbTransactionEvent;

        private CashLib.Interfaces.IDeviceAcceptor hopperAcceptor;
        private CashLib.Interfaces.IDeviceDispenser hopperDispenser;
        private CashLib.Interfaces.IDeviceAcceptor billAcceptor;
        private CashLib.Interfaces.IDeviceDispenser billDespenser;
        private CashLib.Factory.FactoryDeviceCash factory;

        private MessageEventArgs components;
        private Error error;
        private int billDesposited;
        private Hashtable stored;

        private string hopper = "";
        
        public CCTalk()
        {
            error = Error.getInstancia();
            factory = new CashLib.Factory.FactoryDeviceCash();
            hopperAcceptor = factory.CreateDeviceAcceptor("HOPPERPrueba");
            hopperDispenser = factory.CreateDeviceDispenser("HOPPERPrueba");
            billAcceptor = factory.CreateDeviceAcceptor("BILLPrueba");
            billDespenser = factory.CreateDeviceDispenser("BILLPrueba");
            components = new MessageEventArgs();
        }

        public static CCTalk getInstancia()
        {
            if (instancia == null)
            {
                instancia = new CCTalk();
            }
            return instancia;
        }

        public bool getConfigDevices()
        {
            if (this.hopper == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setHooper(string hopper)
        {
            this.hopper = hopper;
        }

        public void getStatus()
        {
            string fail = "";

            if (!hopperAcceptor.openConnection())
            {
                fail += " No Conectado Hopper Accepter";
            }

            if (!hopperAcceptor.openConnection())
            {
                fail += " No Conectado Hopper Dispenser";
            }

            if (!billAcceptor.openConnection())
            {
                fail += " No Conectado Bill Acceptor";
            }

            if (!billDespenser.openConnection())
            {
                fail += " No Conectado Bill Dispenser";
            }
            this.error.setMesseg(fail);
        }

        public void setEvents()
        {
            billAcceptor.powerUpEvent += powerUpHandle;
            billAcceptor.connectEvent += connectedHandle;
            billAcceptor.stackEvent += stackHandle;
            billAcceptor.powerUpCompleteEvent += PowerUpCompletedHandle;
            billAcceptor.escrowEvent += escrowHandle;
            billAcceptor.setEvents();
        }

        public void enableDevices(Hashtable DBStored)
        {
            billAcceptor.enable();
            //billDespenser.enable();
            hopperAcceptor.enable();
            hopperDispenser.enable();

            this.stored = DBStored;
            this.billDesposited = 0;
            this.setValuesInitialLabelsAndList();

            listConisEvent(this, components);
            listBillsEvent(this, components);
            lbTransactionEvent(this, components);
        }

        public int getCash(int total)
        {

            byte[] result;
            int deposited = 0;
            int contador = 0;
            this.error.setMesseg("Ingrese el efectivo");
            while (deposited < total)
            {
                result = hopperAcceptor.getCashDesposite(contador);

                if (result[1] != contador)
                {
                    switch (result[0])
                    {
                        case 10:
                            components.lbMoney10 += 1;
                            components.listCoins = 10;
                            deposited += 10;
                            listConisEvent(this, components);
                            this.stored["10"] = components.lbMoney10;
                            break;
                        case 5:
                            components.lbMoney5 += 1;
                            components.listCoins = 5;
                            deposited += 5;
                            listConisEvent(this, components);
                            this.stored["5"] = components.lbMoney5;
                            break;
                        case 2:
                            components.lbMoney2 += 1;
                            components.listCoins = 2;
                            deposited += 2;
                            listConisEvent(this, components);
                            this.stored["2"] = components.lbMoney2;
                            break;
                        case 1:
                            components.lbMoney1 += 1;
                            components.listCoins = 1;
                            deposited += 1;
                            listConisEvent(this, components);
                            this.stored["1"] = components.lbMoney5;
                            break;
                    }
                    components.lbTotal = deposited;
                    lbTransactionEvent(this, components);
                    lbStoresEvent(this, components);
                    contador = result[1];
                }
                else if (this.billDesposited != 0)
                {
                    switch (this.billDesposited)
                    {
                        case 20:
                            components.lbBill20 += 1;
                            components.listBills = 20;
                            listBillsEvent(this, components);
                            this.stored["20"] = components.lbBill20;
                            break;
                        case 50:
                            components.lbBill50 += 1;
                            components.listBills = 50;
                            listBillsEvent(this, components);
                            this.stored["50"] = components.lbBill50;
                            break;
                        case 100:
                            components.lbBill100 += 1;
                            components.listBills = 100;
                            listBillsEvent(this, components);
                            this.stored["100"] = components.lbBill100;
                            break;
                        case 200:
                            components.lbBill200 += 1;
                            components.listBills = 200;
                            listBillsEvent(this, components);
                            this.stored["200"] = components.lbBill200;
                            break;
                        case 500:
                            components.lbBill500 += 1;
                            components.listBills = 500;
                            listBillsEvent(this, components);
                            this.stored["500"] = components.lbBill500;
                            break;
                    }

                    lbStoresEvent(this, components);
                    deposited += this.billDesposited;
                    components.lbTotal = deposited;
                    lbTransactionEvent(this, components);
                    this.billDesposited = 0;

                }
            }
            this.error.setMesseg("Transacción terminada");
            return deposited;
        }

        public void disableDevices()
        {
            hopperAcceptor.disable();
            hopperDispenser.disable();
            billAcceptor.disable();
            billDespenser.disable();

        }

        private double getBillDeposite(double bill)
        {
            return bill;
        }

        private void setValuesInitialLabelsAndList()
        {
            this.components.listCoins = 0;
            this.components.listBills = 0;
            this.components.lbTotal = 0;
            this.components.lbMoney1 = (int)this.stored["1"];
            this.components.lbMoney2 = (int)this.stored["2"];
            this.components.lbMoney5 = (int)this.stored["5"];
            this.components.lbMoney10 = (int)this.stored["10"];
            this.components.lbBill20 = (int)this.stored["20"];
            this.components.lbBill50 = (int)this.stored["50"];
            this.components.lbBill100 = (int)this.stored["100"];
            this.components.lbBill200 = (int)this.stored["200"];
            this.components.lbBill500 = (int)this.stored["500"];
        }

        public Hashtable getCashStored()
        {
            return this.stored;
        }

        public void setDeliverCash(int cash, Hashtable countCash)
        {

            int[] returnBill = new int[3] { 0, 0, 0 };
            components.lbCambio = cash;
            lbTransactionEvent(this, components);

            this.error.setMesseg("Entregando cambio .... ");

            foreach (DictionaryEntry i in countCash)
            {
                int key = (int)i.Key;
                int value = (int)i.Value;              
                switch (key)
                {
                    case 20:
                        returnBill[0] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateComponents(key, value);
                        break;
                    case 50:
                        returnBill[1] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateComponents(key, value);
                        break;
                    case 100:
                        returnBill[2] = value;
                        this.stored[key.ToString()] = (int)this.stored[key.ToString()] - value;
                        this.updateComponents(key, value);
                        break;
                }                                
                lbStoresEvent(this, components);                
            }

            billDespenser.returnCash(0,0,returnBill);

            foreach (DictionaryEntry i in countCash)
            {
                int key = (int)i.Key;
                int value = (int)i.Value;
                if (key == 10 || key == 5 || key == 1)
                {
                    this.stored[key.ToString()] = (int)this.stored[key.ToString()] - 1;
                    this.updateComponents(key, value);
                    hopperDispenser.returnCash(key, value, null);
                }              
                lbStoresEvent(this, components);                                
            }

           this.error.setMesseg("Transacción terminada");
        }

        private void updateComponents(int value, int count)
        {
            switch (value)
            {
                case 1:
                    components.lbMoney1 -= count;
                    break;
                case 5:
                    components.lbMoney5 -= count;
                    break;
                case 10:
                    components.lbMoney10 -= count;
                    break;
                case 20:
                    components.lbBill20 -= count;
                    break;
                case 50:
                    components.lbBill50 -= count;
                    break;
                case 100:
                    components.lbBill100 -= count;
                    break;
                case 200:
                    components.lbBill200 -= count;
                    break;
                case 500:
                    components.lbBill500 -= count;
                    break;
            }
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
            this.billDesposited += (int)cash[0];            
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
