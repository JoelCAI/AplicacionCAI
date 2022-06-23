using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace AplicacionCAI
{
    class Pedido
    {
        private static int newId;

        private Pedido()
        {
            newId = CrearIdPedido();
        }

        public Pedido(string linea)
        {
            var datos = linea.Split(';');
            IdPedido = int.Parse(datos[0]);
            EstadoPedido = datos[1];
            FechaPedido = DateTime.Parse(datos[2]);

            PaisOrigen = datos[3];
            RegionOrigen = datos[4];
            ProvinciaOrigen = datos[5];
            LocalidadOrigen = datos[6];
            DomicilioOrigen = datos[7];

            PaisDestino = datos[8];
            RegionDestino = datos[9];
            ProvinciaDestino = datos[10];
            LocalidadDestino = datos[11];
            DomicilioDestino = datos[12];

            PesoEncomienda = decimal.Parse(datos[13]);

            CuitCorporativo = long.Parse(datos[14]);
            RazonSocialCorporativo = datos[15];

            Urgente = bool.Parse(datos[16]);
            EntregaDomicilio = bool.Parse(datos[17]);
            RetiroEnPuerta = bool.Parse(datos[18]);

            SubTotalCalculoPedido = decimal.Parse(datos[19]);
            TotalCalculoPedido = decimal.Parse(datos[20]);

            Facturado = bool.Parse(datos[21]);
            TipoServicio = (datos[22]);
        }

        public int IdPedido { get; set; }
        private long CuitCorporativo { get; set; }
        private string RazonSocialCorporativo { get; }
        public DateTime FechaPedido { get; private set; }
        public string EstadoPedido { get; private set; }
        private string RegionOrigen { get; set; }
        private string ProvinciaOrigen { get; set; }
        private string LocalidadOrigen { get; set; }
        private string DomicilioOrigen { get; set; }
        private string PaisOrigen { get; set; }
        private string RegionDestino { get; set; }
        private string ProvinciaDestino { get; set; }
        private string LocalidadDestino { get; set; }
        private string DomicilioDestino { get; set; }
        private string PaisDestino { get; set; }
        private bool Urgente { get; set; }
        private bool EntregaDomicilio { get; set; }
        private bool RetiroEnPuerta { get; set; }
        private decimal PesoEncomienda { get; set; }
        private decimal SubTotalCalculoPedido { get; set; }
        public decimal TotalCalculoPedido { get; set; }
        public bool Facturado { get; set; }
        private string TipoServicio { get; set; }

        static string[] ubicacionesGlobales = File.ReadAllLines("ubicacionesGlobales.txt");
        static string[] ubicacionesLocales = File.ReadAllLines("ubicacionesLocales.txt");
        
        static List<string> _ubicacionesLimitrofes = UbicacionesLimitrofes();
        static List<string> _ubicacionesLatam = UbicacionesLatam();
        static List<string> _ubicacionesNoram = UbicacionesNoram();
        static List<string> _ubicacionesEuropa = UbicacionesEuropa();
        static List<string> _ubicacionesAsia = UbicacionesAsia();
        
        public static Pedido CrearPedido()
        {
            // COMIENZO DE SOLICITUD DE NUEVO PEDIDO
            var pedido = new Pedido();

            pedido.IdPedido = newId;

            pedido.EstadoPedido = "INICIADO";
            pedido.FechaPedido = DateTime.Now;
            pedido.CuitCorporativo = UsuarioLogueado();
            pedido.Facturado = false;
            //LOS ENVÍOS SIEMPRE TENDRÁN ARGENTINA COMO ORIGEN 
            pedido.PaisOrigen = "ARGENTINA";

            bool flag = true;

            do
            {
                //SELECCIÓN CIUDAD DE ORIGEN
                Console.Clear();
                Console.WriteLine("\n Elija la ciudad de origen");

                var ciudadesArg = UbicacionesArg();
                int i = 1;

                foreach (string item in ciudadesArg)

                    Console.WriteLine("["+ i++ +"] "+ item);

                var infoOrigen = Console.ReadLine();
                

                // REGIÓN, PROVINCIA Y LOCALIDAD SE AUTOASIGNAN DE ACUERDO A LA CIUDAD ELEGIDA
                switch (infoOrigen)
                {
                    case "1":
                        Console.Clear();
                        pedido.RegionOrigen = "CENTRO";
                        pedido.ProvinciaOrigen = "BUENOS AIRES";
                        pedido.LocalidadOrigen = "CABA";
                        flag = false;
                        break;

                    case "2":
                        Console.Clear();
                        pedido.RegionOrigen = "CENTRO";
                        pedido.ProvinciaOrigen = "GBA";
                        pedido.LocalidadOrigen = "MAR DEL PLATA";
                        flag = false;
                        break;

                    case "3":
                        Console.Clear();
                        pedido.RegionOrigen = "CUYO";
                        pedido.ProvinciaOrigen = "SAN JUAN";
                        pedido.LocalidadOrigen = "CIUDAD DE SAN JUAN";
                        flag = false;
                        break;

                    case "4":
                        Console.Clear();
                        pedido.RegionOrigen = "NOA";
                        pedido.ProvinciaOrigen = "JUJUY";
                        pedido.LocalidadOrigen = "SAN SALVADOR DE JUJUY";
                        flag = false;
                        break;

                    case "5":
                        Console.Clear();
                        pedido.RegionOrigen = "PATAGONIA";
                        pedido.ProvinciaOrigen = "RÍO NEGRO";
                        pedido.LocalidadOrigen = "BARILOCHE";
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("La opción ingresada es inválida.");
                        break;
                }
            } while (flag);


            pedido.DomicilioOrigen = Validador.TextInput("Por favor ingrese Domicilio y altura de Origen");

            string seguirUno;

            seguirUno = pedido.ValidarSioNoPedidoInicial("\n¿Desea Continuar?");

            bool flag2;

            if (seguirUno == "SI" && pedido.PaisOrigen != null)
            {
                flag2 = true;
                Console.Clear();
            }
            else
            {
                flag2 = false;
                Console.Clear();
            }

            //INFORMACIÓN DE DESTINO
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "\n Elija Argentina para envíos locales. Elija otra opción para envíos internacionales.");

                var ubicacionesGlobales = UbicacionesGlobales();
                int i = 1; 
                foreach (string item in ubicacionesGlobales)

                    Console.WriteLine("["+ i++ +"] "+ item);

                var infoDestino = Console.ReadLine();

                switch (infoDestino)
                {
                    case "1":
                        pedido.PaisDestino = "ARGENTINA";

                        Console.WriteLine("\n Elija la ciudad de destino.");

                        var ciudadesArg = UbicacionesArg();
                        int a = 1;

                        foreach (string item in ciudadesArg)

                            Console.WriteLine("["+ a++ +"] "+ item);

                        var seleccionArg = Console.ReadLine();

                        switch (seleccionArg)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = "CENTRO";
                                pedido.ProvinciaDestino = "BUENOS AIRES";
                                pedido.LocalidadDestino = "CABA";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionOrigen = "CENTRO";
                                pedido.ProvinciaOrigen = "GBA";
                                pedido.LocalidadOrigen = "MAR DEL PLATA";
                                break;

                            case "3":
                                Console.Clear();
                                pedido.RegionOrigen = "CUYO";
                                pedido.ProvinciaOrigen = "SAN JUAN";
                                pedido.LocalidadOrigen = "CIUDAD DE SAN JUAN";
                                break;

                            case "4":
                                Console.Clear();
                                pedido.RegionOrigen = "NOA";
                                pedido.ProvinciaOrigen = "JUJUY";
                                pedido.LocalidadOrigen = "SAN SALVADOR DE JUJUY";
                                break;

                            case "5":
                                Console.Clear();
                                pedido.RegionOrigen = "PATAGONIA";
                                pedido.ProvinciaOrigen = "RÍO NEGRO";
                                pedido.LocalidadOrigen = "BARILOCHE";
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }
                        flag2 = false;
                        break;

                    case "2":
                        pedido.PaisDestino = "PAÍSES LIMÍTROFES";
                        
                        var ubicacionesLimitrofes = UbicacionesLimitrofes();
                        int b = 1;

                        foreach (string item in ubicacionesLimitrofes)

                            Console.WriteLine("["+ b++ +"] "+ item);

                        var seleccionLimitrofes = Console.ReadLine();

                        switch (seleccionLimitrofes)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = "REG. METROPOLITANA";
                                pedido.ProvinciaDestino = "MONTEVIDEO";
                                pedido.LocalidadDestino = "MONTEVIDEO";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionDestino = "SUDESTE";
                                pedido.ProvinciaDestino = "SAO PAULO";
                                pedido.LocalidadDestino = "SAO PAULO";
                                break;
                            default: 
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }
                        flag2 = false;
                        break;


                    case "3":
                        Console.Clear();
                        pedido.PaisDestino = "RESTO DE AMÉRICA LATINA";
                        
                        var ubicacionesLatam = UbicacionesLatam();
                        int c = 1;

                        foreach (string item in ubicacionesLatam)

                            Console.WriteLine("["+ c++ +"] "+ item);

                        var seleccionLatam = Console.ReadLine();

                        switch (seleccionLatam)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "QUITO";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionDestino = "";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "BOGOTÁ";
                                break;
                            default: 
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }

                        flag2 = false;
                        break;
                    
                    case "4":
                        pedido.PaisDestino = "AMÉRICA DEL NORTE";
                        
                        var ubicacionesNoram = UbicacionesNoram();
                        int d = 1;

                        foreach (string item in ubicacionesNoram)

                            Console.WriteLine("["+ d++ +"] "+ item);

                        var seleccionNoram = Console.ReadLine();

                        switch (seleccionNoram)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "NEW YORK";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "VANCOUVER";
                                break;
                            default: 
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }

                        flag2 = false;
                        break;
                    
                    case "5":
                        pedido.PaisDestino = "EUROPA";
                        
                        var ubicacionesEuropa = UbicacionesEuropa();
                        int e = 1;

                        foreach (string item in ubicacionesEuropa)

                            Console.WriteLine("["+ e++ +"] "+ item);

                        var seleccionEuropa = Console.ReadLine();

                        switch (seleccionEuropa)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "MADRID";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "BERLÍN";
                                break;
                            default: 
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }

                        flag2 = false;
                        break;

                    case "6":
                        pedido.PaisDestino = "ASIA";
                        int j = 1;

                        var ubicacionesAsia = UbicacionesAsia();

                        foreach (string item in ubicacionesAsia)

                            Console.WriteLine("["+ j++ +"] "+ item);

                        var seleccionAsia = Console.ReadLine();

                        switch (seleccionAsia)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "BEIJING";
                                break;

                            case "2":
                                Console.Clear();
                                pedido.RegionDestino = " ";
                                pedido.ProvinciaDestino = " ";
                                pedido.LocalidadDestino = "TOKIO";
                                break;
                            
                            default:
                                Console.Clear();
                                Console.WriteLine("La opción ingresada es inválida.");
                                break;
                        }

                        flag2 = false;
                        break;
                    
                    default:
                        Console.WriteLine("La opción ingresada es inválida.");
                        break;
                }
            } while (flag2);

            pedido.DomicilioDestino = Validador.TextInput("Por favor ingrese Domicilio y altura de Destino");

            Console.Clear();
            pedido.PesoEncomienda = Validador.IngresarPeso("Ingrese el peso, máximo 30 kg");
            
            //SERVICIOS ADICIONALES
            {
                Console.Clear();
                bool avanzar = false;
                do
                {
                    Console.WriteLine("Por indique si el envío es urgente");
                    Console.WriteLine("[1] Urgente (Recargo 30%)");
                    Console.WriteLine("[2] No Urgente");

                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            pedido.Urgente = true;
                            avanzar = true;
                            break;

                        case "2":
                            Console.Clear();
                            pedido.Urgente = false;
                            avanzar = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("No ha ingresado una opcion correcta");
                            break;
                    }
                } while (!avanzar);

                bool avanzar2 = false;
                do
                {
                    Console.WriteLine("Por favor indique si desea solicitar retiro en puerta.");
                    Console.WriteLine("[1] Retiro en puerta (Recargo 15%)");
                    Console.WriteLine("[2] Entrega en sucursal");

                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            pedido.RetiroEnPuerta = true;
                            avanzar2 = true;
                            break;

                        case "2":
                            Console.Clear();
                            pedido.RetiroEnPuerta = false;
                            avanzar2 = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("No ha ingresado una opcion correcta");
                            break;
                    }
                } while (!avanzar2);

                bool avanzar3 = false;
                do
                {
                    Console.WriteLine("Por indique si se realizará la entrega en domicilio o en sucursal.");
                    Console.WriteLine("[1] Entrega a Domicilio (Recargo 5%)");
                    Console.WriteLine("[2] Entrega en Sucursal");

                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            pedido.EntregaDomicilio = true;
                            avanzar3 = true;
                            break;

                        case "2":
                            Console.Clear();
                            pedido.EntregaDomicilio = false;
                            avanzar3 = true;
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("No ha ingresado una opcion correcta");
                            break;
                    }
                } while (!avanzar3);
            }

            // DETERMINO QUÉ TIPO DE SERVICIO APLICA
            if (pedido.PaisOrigen == pedido.PaisDestino && pedido.RegionOrigen == pedido.RegionDestino &&
                pedido.ProvinciaOrigen == pedido.ProvinciaDestino && pedido.LocalidadOrigen == pedido.LocalidadDestino)
            {
                pedido.TipoServicio = "Local";
            }
            else if (pedido.PaisOrigen == pedido.PaisDestino && pedido.RegionOrigen == pedido.RegionDestino &&
                     pedido.ProvinciaOrigen == pedido.ProvinciaDestino &&
                     pedido.LocalidadOrigen != pedido.LocalidadDestino)
            {
                pedido.TipoServicio = "Provincial";
            }
            else if (pedido.PaisOrigen == pedido.PaisDestino && pedido.RegionOrigen == pedido.RegionDestino &&
                     pedido.ProvinciaOrigen != pedido.ProvinciaDestino)
            {
                pedido.TipoServicio = "Regional";
            }
            else if (pedido.PaisOrigen == pedido.PaisDestino && pedido.RegionOrigen != pedido.RegionDestino)
            {
                pedido.TipoServicio = "Nacional";
            }
            else if (pedido.PaisOrigen != pedido.PaisDestino && _ubicacionesLimitrofes.Contains(pedido.LocalidadDestino))
            {
                pedido.TipoServicio = "Plimit";
            }
            else if (pedido.PaisOrigen != pedido.PaisDestino && _ubicacionesLatam.Contains(pedido.LocalidadDestino))
            {
                pedido.TipoServicio = "Latam";
            }
            else if (pedido.PaisOrigen != pedido.PaisDestino && _ubicacionesNoram.Contains(pedido.LocalidadDestino))
            {
                pedido.TipoServicio = "Noram";
            }
            else if (pedido.PaisOrigen != pedido.PaisDestino && _ubicacionesEuropa.Contains(pedido.LocalidadDestino))
            {
                pedido.TipoServicio = "Europa";
            }
            else if (pedido.PaisOrigen != pedido.PaisDestino && _ubicacionesAsia.Contains(pedido.LocalidadDestino))
            {
                pedido.TipoServicio = "Asia";
            }
            else
            {
                pedido.TipoServicio = "Local";
            }

            //CÁLCULO PRECIO BASE 
            if (pedido.PesoEncomienda < 0.5M)
            {
                pedido.SubTotalCalculoPedido = TarifarioDiccionario.tarifarioDiccionario[pedido.TipoServicio].P500g;
            }
            else if (pedido.PesoEncomienda > 0.5M && pedido.PesoEncomienda < 10)
            {
                pedido.SubTotalCalculoPedido = TarifarioDiccionario.tarifarioDiccionario[pedido.TipoServicio].P10Kg;
            }
            else if (pedido.PesoEncomienda > 10 && pedido.PesoEncomienda < 20)
            {
                pedido.SubTotalCalculoPedido = TarifarioDiccionario.tarifarioDiccionario[pedido.TipoServicio].P20Kg;
            }
            else if (pedido.PesoEncomienda > 20)
            {
                pedido.SubTotalCalculoPedido = TarifarioDiccionario.tarifarioDiccionario[pedido.TipoServicio].P30Kg;
            }
            else
            {
                pedido.SubTotalCalculoPedido = TarifarioDiccionario.tarifarioDiccionario[pedido.TipoServicio].P500g;
            }

            //RECARGO SERVICIOS ADICIONALES 
            if (pedido.Urgente)
            {
                decimal cargo = RecargoUrgencia(pedido.Urgente);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido * cargo);
            }

            if (pedido.EntregaDomicilio)
            {
                decimal cargo = RecargoEntrega(pedido.EntregaDomicilio);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido * cargo);
            }

            if (pedido.RetiroEnPuerta)
            {
                decimal cargo = RecargoRetiro(pedido.RetiroEnPuerta);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido * cargo);
            }

            pedido.MostrarPedidoFinal();

            return pedido;
        }


        //NUEVO ID DE PEDIDO CON INCREMENTO RESPECTO AL ÚLTIMO GUARDADO
        public static int CrearIdPedido()
        {
            int newid = 0;
            string ultimaLinea = File.ReadLines("pedidoLista.txt").LastOrDefault();

            if (!string.IsNullOrEmpty(ultimaLinea))
            {
                var valores = ultimaLinea.Split(';');
                newid = int.Parse(valores[0]);
                newid++;
            }
            else
            {
                newid = new Random().Next(50000000, 99999999);
            }

            return newid;
        }

        public string ObtenerLineaDatos()
        {
            return
                $"{IdPedido};{EstadoPedido};{FechaPedido};{PaisOrigen};{RegionOrigen};{ProvinciaOrigen};{LocalidadOrigen};{DomicilioOrigen};{PaisDestino};{RegionDestino};{ProvinciaDestino};{LocalidadDestino};{DomicilioDestino};{PesoEncomienda};{CuitCorporativo};{RazonSocialCorporativo};{Urgente};{EntregaDomicilio};{RetiroEnPuerta};{SubTotalCalculoPedido};{TotalCalculoPedido};{Facturado};{TipoServicio}";
        }
        
        static List<string> UbicacionesGlobales()
        {
            List<string> list = new List<string>(ubicacionesGlobales);
            return list;
        }
        
        static List<string> UbicacionesArg()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[0];
                list.Add(datos);
            }
            return list;
        }

        static List<string> UbicacionesLimitrofes()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[1];
                list.Add(datos);
            }
            return list;
        }

        static List<string> UbicacionesLatam()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[2];
                list.Add(datos);
            }
            return list;
        }

        static List<string> UbicacionesNoram()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[3];
                list.Add(datos);
            }
            return list;
        }

        static List<string> UbicacionesEuropa()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[4];
                list.Add(datos);
            }
            return list;
        }

        static List<string> UbicacionesAsia()
        {
            List<string> list = new List<string>();
            foreach (var linea in ubicacionesLocales)
            {
                var datos = linea.Split(new [] {";"}, StringSplitOptions.RemoveEmptyEntries)[5];
                list.Add(datos);
            }
            return list;
        }

        public static Pedido CrearModeloBusqueda()
        {
            var modelo = new Pedido();
            modelo.IdPedido = Validador.IngresarEntero("\n Por favor ingrese el nro de ID");
            return modelo;
        }

        public bool CoincideCon(Pedido modelo)
        {
            if (modelo.IdPedido != 0 && IdPedido != modelo.IdPedido)
            {
                return false;
            }

            return true;
        }

        public static Pedido BusquedaCuitCorporativo(long clienteLogueado)
        {
            var modelo = new Pedido();
            modelo.CuitCorporativo = clienteLogueado;
            return modelo;
        }

        public static long UsuarioLogueado()
        {
            var usuario = DiccionarioUsuario.BuscarUsuarioDni();
            var clienteLogueado = usuario.CuitCorporativo;
            return clienteLogueado;
        }

        public void MostrarPedidoInicio()
        {
            Console.Clear();
            Console.WriteLine($"\n Su ingreso parcial");

            Console.WriteLine($"\n Id Pedido: EN CREACIÓN");
            Console.WriteLine($" Estado: EN CREACIÓN");
            Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

            Console.WriteLine($"\n País de Origen: {PaisOrigen}");
            Console.WriteLine($" Región de Origen: {RegionOrigen}");
            Console.WriteLine($" Provincia de Origen: {ProvinciaOrigen}");
            Console.WriteLine($" Localidad de Origen: {LocalidadOrigen}");
            Console.WriteLine($" DomicilioDeOrigen: {DomicilioOrigen}");
        }

        public void MostrarPedidoFinal()
        {

            Console.Clear();
            Console.WriteLine($"\n Estado del Pedido");

            Console.WriteLine($"\n Id Pedido: {IdPedido}");
            Console.WriteLine($" Estado: {EstadoPedido}");
            Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

            Console.WriteLine($"\n País de Origen: {PaisOrigen}");
            Console.WriteLine($" Ciudad de Origen: {LocalidadOrigen}");
            Console.WriteLine($" Domicilio de Origen: {DomicilioOrigen}");

            Console.WriteLine($"\n País de Destino: {PaisDestino}");
            Console.WriteLine($" Ciudad de Destino: {LocalidadDestino}");
            Console.WriteLine($" Domicilio de Destino: {DomicilioDestino}");

            Console.WriteLine($"\n Subtotal del Pedido: {SubTotalCalculoPedido}");

            Console.WriteLine($"\n Total del Pedido con el Recargo incluido: {TotalCalculoPedido}");

            Console.WriteLine("\n Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        private static decimal RecargoUrgencia(bool entrada)
        {
            decimal cargo = TarifarioDiccionario.EnvioUrgente(entrada);
            return cargo;
        }

        private static decimal RecargoEntrega(bool entrada)
        {
            decimal cargo = TarifarioDiccionario.EntregaDomicilio(entrada);
            return cargo;
        }

        private static decimal RecargoRetiro(bool entrada)
        {
            decimal cargo = TarifarioDiccionario.RetiroEnPuerta(entrada);
            return cargo;
        }

        private string ValidarSioNoPedidoInicial(string mensaje)
        {
            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *SI* ó" +
                                      "\n *NO*";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                MostrarPedidoInicio();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine()?.ToUpper();
                string opcionC = "SI";
                string opcionD = "NO";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
                {
                    continue;
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            return opcion;
        }
    }
}