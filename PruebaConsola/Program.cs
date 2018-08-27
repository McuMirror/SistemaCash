using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.IO;
using System.IO.Ports;
using CPI.BanknoteDevices;
using CPI.BanknoteDevices.Events;
using MPOST;

namespace PruebaConsola
{
    class Program
    {
        private static CashLib.HopperAcceptor hopperAcceptor;
        private static CashLib.BillAcceptor billAcceptor;
        private static CashLib.HopperDispenser hopperDispenser;
        private static CashLib.BillDespenser billDespenser;
        //private static Recycler scr = new Recycler();
        private static MPOST.Acceptor billAccept;

        private static Hashtable devolver = new Hashtable();
        private static Hashtable denominacion = new Hashtable();
        private static int billDesposited;


        static void Main(string[] args)
        {

            hopperAcceptor = new CashLib.HopperAcceptor();
            hopperDispenser = new CashLib.HopperDispenser();
            billAcceptor = new CashLib.BillAcceptor();
            billDespenser = new CashLib.BillDespenser();

            billAcceptor.powerUpEvent += powerUpHandle;
            billAcceptor.connectEvent += connectedHandle;
            billAcceptor.stackEvent += stackHandle;
            billAcceptor.powerUpCompleteEvent += PowerUpCompletedHandle;
            billAcceptor.escrowEvent += escrowHandle;

            

            Console.WriteLine("1.- Abriendo conexion Hopper Acceptor");
            if (hopperAcceptor.openConnection())
            {
                Console.WriteLine("Esta conectado");
            }
            else
            {
                Console.WriteLine("No esta conectado");
            }

            Console.WriteLine("2.- Abriendo conexion Hopper Dispenser");
            if (hopperDispenser.openConnection())
            {
                Console.WriteLine("Esta conectado");
            }
            else
            {
                Console.WriteLine("No esta conectado");
            }

            Console.WriteLine("3.- Abriendo conexion Bill Acceptor");
            if (billAcceptor.openConnection())
            {
                Console.WriteLine("Esta conectado");
            }
            else
            {
                Console.WriteLine("No esta conectado");
            }

            Console.WriteLine("4.- Abriendo conexion Bill Dispenser");
            if (billDespenser.openConnection())
            {
                Console.WriteLine("Esta conectado");
            }
            else
            {
                Console.WriteLine("No esta conectado");
            }
            Console.WriteLine("-------------");


            billDespenser.enable();
            //billDespenser.returnCash(20, 3);
            //billDespenser.returnCash(50, 2);
            billDespenser.returnCash(100, 1);
            billDespenser.disable();

            //hopperDispenser.enable();
            //hopperDispenser.returnCash(10,2);
            //hopperDispenser.returnCash(5,2);
            //hopperDispenser.returnCash(1,5);


            //billAcceptor.setEvents();            
            //hopperAcceptor.enable();
            ////recibirMonedas();
            //bool seguir = true;
            //while (seguir)
            //{
            //    Console.WriteLine("Ingresa la cantidad a depositar: ");
            //    string cantidad = Console.ReadLine();
            //    int solicitado = Int32.Parse(cantidad);
            //    billDesposited = 0;
            //    billAcceptor.enable();
            //    Console.WriteLine("Ingrese el efectivo: ");
            //    while (billDesposited < solicitado)
            //    {
            //    }

            //    billAcceptor.disable();

            //    Console.WriteLine("Quieres realizar otra peracion (S/N) :");
            //    string continuar = Console.ReadLine();
            //    if (continuar == "N" || continuar == "n")
            //    {
            //        seguir = false;
            //    }

            //}


            //hopperDispenser.emptyContainesCoins();
            ////recibirMonedas();
            ////utilizandoPayout();
            ////Console.WriteLine("Vaciando Contenedores ....");
            ////hopperDispenser.emptyContainerCoin(33,5);
            Console.WriteLine("Termino proceso");

        }

        static void powerUpHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador de POWER UP");
        }

        static void connectedHandle(object sender, EventArgs e)
        {
            billAcceptor.configEnable();            
        }

        static void stackHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : Stack");            
            billDesposited += (int)billAcceptor.getDepositeBill();
            Console.WriteLine("Recibido : {0}", billDesposited);
            
        }

        static void PowerUpCompletedHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : POWERUP_COMPLETED");
        }

        static void escrowHandle(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : ESCROW");
        }

        static void recibirMonedas()
        {
            byte[] result;
            int toPay = 60;
            int deposited = 0;
            int contador = 0;

            while (deposited < toPay)
            {
                result = hopperAcceptor.depositCash();

                if (result[4] != contador)
                {
                    switch (result[5])
                    {
                        case 7:
                            deposited += 10;
                            break;
                        case 6:
                            deposited += 5;
                            break;
                        case 5:
                            deposited += 2;
                            break;
                        case 4:
                            deposited += 1;
                            break;
                    }
                    Console.WriteLine("Depositado: " + deposited);
                    Console.WriteLine("   ");
                    contador = result[4];
                }

                Thread.Sleep(500);
            }
        }

        #region Funcion para entregar cambio

        static void entregarCambio()
        {
            int cambio = 16;
            //int cantidad = 0;

            denominacion.Add("500", 1);
            denominacion.Add("200", 1);
            denominacion.Add("100", 5);
            denominacion.Add("50", 1);
            denominacion.Add("20", 5);
            denominacion.Add("10", 5);
            denominacion.Add("5", 4);
            denominacion.Add("2", 10);
            denominacion.Add("1", 10);

            Console.WriteLine("Cambio : {0}", cambio);
            cambio = devolverCambio(cambio, 500);
            cambio = devolverCambio(cambio, 200);
            cambio = devolverCambio(cambio, 100);
            cambio = devolverCambio(cambio, 50);
            cambio = devolverCambio(cambio, 20);
            cambio = devolverCambio(cambio, 10);
            cambio = devolverCambio(cambio, 5);
            cambio = devolverCambio(cambio, 2);
            cambio = devolverCambio(cambio, 1);
            Console.WriteLine("Cambio despues : {0}", cambio);


            Console.WriteLine("////////////////////////");

            foreach (DictionaryEntry i in devolver)
            {
                Console.WriteLine("{0} : {1}", i.Key, i.Value);
            }
        }

        static int devolverCambio(int cambio, int moneda )
        {
            int cantidad = 0;

            if (cambio >= moneda)
            {
                cantidad = cambio / moneda;
                if ((int)denominacion[moneda.ToString()] >= cantidad)
                {
                    cambio -= (cantidad * moneda);
                    devolver.Add(moneda, cantidad);
                }
                else if ((int)denominacion[moneda.ToString()] > 0)
                {
                    cantidad -= (int)denominacion[moneda.ToString()];
                    cambio -= ((int)denominacion[moneda.ToString()] * moneda);
                    devolver.Add(moneda, (int)denominacion[moneda.ToString()]);
                }
            }

            return cambio;
        }

        #endregion

        #region Manipulacion de Bill Acceptor
        static void utilizandoPayout()
        {
            Console.WriteLine("     ");
            Console.WriteLine("Comenzando conexion con bill acceptor");
            bool seguir = true;
            billAccept = new MPOST.Acceptor();
            try
            {
                billAccept.OnPowerUp += new PowerUpEventHandler(handlePowerUp);
                billAccept.OnConnected += new ConnectedEventHandler(handleConnected);
                billAccept.OnStacked += new StackedEventHandler(handleStack);
                billAccept.OnPowerUpComplete += new PowerUpCompleteEventHandler(handlePowerUpCompleted);
                billAccept.OnEscrow += new EscrowEventHandler(handleEscrow);

                billAccept.Open("COM6", MPOST.PowerUp.A);

                while (seguir)
                {

                    if (billAccept.DeviceState == State.Disconnected)
                    {
                        //habilitar();
                        //Console.WriteLine("Estado : {0}", billAccept.DeviceState);
                    }

                    if (billAccept.DeviceState == State.Escrow)
                    {
                        //Thread.Sleep(5000);
                        //billAccept.EscrowReturn();

                    }
                }

                //billAccept.Close();                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }


            //scr.DeviceStateChanged += new DeviceStateEventHandler(obtenerStatusEvento);
            //scr.DocumentStatusReported += new DocumentStatusEventHandler(obtenerStatusDocumento);
            //scr.EscrowSessionSummaryReported += new EscrowSessionSummaryEventHandler(obtenerEstatus);
            //scr.EnableAcceptance();

        }

        static void handlePowerUp(object sender, EventArgs e)
        {
            Console.WriteLine("Manejador de POWER UP");
        }

        static void handleConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : Connected");
            configDefault();
            billAccept.EnableAcceptance = true;
            billAccept.AutoStack = true;
            Console.WriteLine("Estado : {0}", billAccept.DeviceState);
        }

        static void handleStack(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : Stack");
            if (billAccept.DocType == DocumentType.Bill)
            {
                Console.WriteLine("Estado : {0}", billAccept.DeviceState);
                MPOST.Bill bills = billAccept.Bill;
                //Console.WriteLine("Bill: {0}", billAccept.Bill);
                Console.WriteLine("Depositado : ${0}.00", bills.Value);
            }
        }

        static void handlePowerUpCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : POWERUP_COMPLETED");
        }

        static void handleEscrow(object sender, EventArgs e)
        {
            Console.WriteLine("Evento : ESCROW");
            Console.WriteLine("billAccept.DocType : {0}", billAccept.DocType);
            if (billAccept.DocType == DocumentType.Bill)
            {
                MPOST.Bill bills = billAccept.Bill;
                Console.WriteLine("Bill: {0}", billAccept.Bill);
                Console.WriteLine(bills.Value);
            }
        }

        static void habilitar()
        {
            billAccept.EnableAcceptance = true;
            billAccept.AutoStack = true;
        }

        static void configDefault()
        {
            Console.WriteLine("Obteniendo configuración");
            MPOST.Bill[] bills = billAccept.BillValues;
            Boolean[] enables = billAccept.GetBillValueEnables();
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i].Value == 1000)
                {
                    enables[i] = false;
                }
                Console.WriteLine("{0} :: {1}", bills[i].Value, enables[i]);
            }
            billAccept.SetBillValueEnables(ref enables);
        }

        //static void obtenerStatusEvento(object sender, DeviceStateEventArgs e)
        //{
        //    Console.WriteLine("Evento : {0}", e.State.ToString());
        //    switch (e.State)
        //    {
        //        case DeviceState.ESCROWED:
        //            scr.StackDocumentToCassette();
        //            //scr.DisableAcceptance();
        //            break;
        //    }
        //}

        //static void obtenerStatusDocumento(object sender, DocumentStatusEventArgs e)
        //{
        //    Banknote banknoteTmp;
        //    banknoteTmp = e.Document as Banknote;
        //    Console.WriteLine("Documento : {0}, {1}", e.Event, banknoteTmp.Value);
        //}

        //static void obtenerEstatus(object sender, EscrowSessionSummaryEventArgs e)
        //{
        //    Console.WriteLine("Estatus : {0}", e.TotalDocumentsPendingStorage);
        //}



        //static void obtenerDineroAlmacenado(object sender, EscrowSessionSummaryEventArgs e)
        //{
        //    Console.WriteLine("Detalles : {0}", e.EscrowSessionStatus);
        //}

        #endregion

        #region Manipulacion de hopper

        //static void utilizandoHopper()
        //{
        //    string result = "";
        //    CashLib.Hopper hopper = new CashLib.Hopper();
        //    hopper.abrirConexion();

        //    int cantidad = 100;

        //    //Configuracion inicial de los containers
        //    hopper.resetHooperAccepter();
        //    hopper.configuracionDefaultHoppers();
        //    hopper.configDefaultAcceptor();

        //    //Oteniendo los ID de los dispositvos del hopper
        //    //hopper.getIDDispositvos();

        //    //Console.WriteLine("--------Esperando el deposito de efectivo-------");
        //    //recibirMonedas(hopper, cantidad);

        //    //Vaciar contenedores
        //    hopper.vaciarAlcancia(2);
        //    //hopper.vaciarContenedor(33);
        //    //hopper.vaciarContenedores();
        //}

        //static void recibirMonedas(Cash.Hopper hopper,int toPay)
        //{            
        //    byte[] result;
        //    int deposited = 0;
        //    int contador = 0;

        //    while (deposited < toPay)
        //    {
        //        result = hopper.showCoinsDeposited();

        //        //Console.WriteLine("Posicion [4] = {0}", this.resultMessage[4]);
        //        //Console.WriteLine("Contador = {0}", contador);
        //        //Console.WriteLine("Posicion [5] = {0}", this.resultMessage[5]);

        //        if (result[4] != contador)
        //        {
        //            switch (result[5])
        //            {
        //                case 7:
        //                    deposited += 10;
        //                    break;
        //                case 6:
        //                    deposited += 5;
        //                    break;
        //                case 5:
        //                    deposited += 2;
        //                    break;
        //                case 4:
        //                    deposited += 1;
        //                    break;
        //            }
        //            Console.WriteLine("Depositado: " + deposited);
        //            Console.WriteLine("   ");
        //            contador = result[4];
        //        }

        //        Thread.Sleep(500);
        //    }            
        //}

        #endregion
    }
}
