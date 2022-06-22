using System;
using System.Collections.Generic;
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
            ContinenteOrigen = datos[8];

            PaisDestino = datos[9];
            RegionDestino = datos[10];
            ProvinciaDestino = datos[11];
            LocalidadDestino = datos[12];
            DomicilioDestino = datos[13];
            ContinenteDestino = datos[14];

            PrecioEncomienda = decimal.Parse(datos[15]);
            PesoEncomienda = decimal.Parse(datos[16]);

            CuitCorporativo = long.Parse(datos[17]);
            RazonSocialCorporativo = datos[18];

            Urgente = bool.Parse(datos[19]);
            EntregaDomicilio = bool.Parse(datos[20]);
            RetiroEnPuerta = bool.Parse(datos[21]);

            SubTotalCalculoPedido = decimal.Parse(datos[22]);
            TotalCalculoPedido = decimal.Parse(datos[23]);

            Facturado = bool.Parse(datos[24]);
            TipoServicio = (datos[25]);
        }

        public int IdPedido { get; set; }
        private long CuitCorporativo { get; set; }
        private string RazonSocialCorporativo { get; }
        public DateTime FechaPedido { get; private set; }
        public string EstadoPedido { get; private set; }
        private string ContinenteOrigen { get; set; }
        private string RegionOrigen { get; set; }
        private string ProvinciaOrigen { get; set; }
        private string LocalidadOrigen { get; set; }
        private string DomicilioOrigen { get; set; }
        private string PaisOrigen { get; set; }
        private string ContinenteDestino { get; set; }
        private string RegionDestino { get; set; }
        private string ProvinciaDestino { get; set; }
        private string LocalidadDestino { get; set; }
        private string DomicilioDestino { get; set; }
        private string PaisDestino { get; set; }
        private decimal PrecioEncomienda { get; set; }
        private bool Urgente { get; set; }
        private bool EntregaDomicilio { get; set; }
        private bool RetiroEnPuerta { get; set; }
        private decimal PesoEncomienda { get; set; }
        private decimal SubTotalCalculoPedido { get; set; }
        public decimal TotalCalculoPedido { get; set; }
        public bool Facturado { get; set; }
        private string TipoServicio { get; set; }

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
                Console.WriteLine("\n Elija la ciudad de origen");

                string[] lineas = File.ReadAllLines("ubicacionesLocales.txt");
                foreach (var datos in lineas)
                {
                    var opciones = datos.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)[0];
                    Console.WriteLine(opciones);
                }

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
                Console.WriteLine(
                    "\n Elija Argentina para envíos locales. Elija otra opción para envíos internacionales.");

                string[] lines = File.ReadAllLines("ubicacionesGlobales.txt");
                foreach (var line in lines)
                {
                    var firstValue = line.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries)[0];
                    Console.WriteLine(firstValue);
                }

                var InfoDestino = Console.ReadLine();

                switch (InfoDestino)
                {
                    case "1":
                        Console.Clear();
                        pedido.PaisDestino = "ARGENTINA";

                        Console.WriteLine("\n Elija la ciudad de destino.");

                        string[] ciudades = File.ReadAllLines("ubicacionesLocales.txt");
                        foreach (var linea in ciudades)
                        {
                            var datos = linea.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries)[0];
                            Console.WriteLine(datos);
                        }

                        var seleccionArg = Console.ReadLine();

                        switch (seleccionArg)
                        {
                            case "1":
                                Console.Clear();
                                pedido.RegionDestino = "CENTRO";
                                pedido.ProvinciaDestino = "BUENOS AIRES";
                                pedido.LocalidadDestino = "CABA";
                                //flag2 = false;
                                break;
                        }

                        //var seleccionArg = Console.ReadLine();
                        //SubOpcionesArg(seleccionArg);

                        flag2 = false;
                        break;

                    default:
                        Console.WriteLine("La opción ingresada es inválida.");
                        break;
                }
            } while (flag2);

            pedido.DomicilioDestino = Validador.TextInput("Por favor ingrese Domicilio y altura de Destino");

            pedido.PesoEncomienda = Validador.IngresarPeso("Ingrese el peso, máximo 30 kg ");

            //SERVICIOS ADICIONALES
            {
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
            else if (pedido.PaisOrigen != pedido.PaisDestino && pedido.PaisDestino == "URUGUAY")
            {
                pedido.TipoServicio = "Plimit";
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
                $"{IdPedido};{EstadoPedido};{FechaPedido};{PaisOrigen};{RegionOrigen};{ProvinciaOrigen};{LocalidadOrigen};{DomicilioOrigen};{ContinenteOrigen};{PaisDestino};{RegionDestino};{ProvinciaDestino};{LocalidadDestino};{DomicilioDestino};{ContinenteDestino};{PrecioEncomienda};{PesoEncomienda};{CuitCorporativo};{RazonSocialCorporativo};{Urgente};{EntregaDomicilio};{RetiroEnPuerta};{SubTotalCalculoPedido};{TotalCalculoPedido};{Facturado};{TipoServicio}";
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
            var usuario = DiccionarioUsuario.BuscarUsuarioDniUnico();

            Console.Clear();
            Console.WriteLine($"\n Estado del Pedido");

            Console.WriteLine($"\n Id Pedido: {IdPedido}");
            Console.WriteLine($" Estado: {EstadoPedido}");
            Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

            Console.WriteLine($"\n País de Origen: {PaisOrigen}");
            Console.WriteLine($" Región de Origen: {RegionOrigen}");
            Console.WriteLine($" Provincia de Origen: {ProvinciaOrigen}");
            Console.WriteLine($" Localidad de Origen: {LocalidadOrigen}");
            Console.WriteLine($" Domicilio de Origen: {DomicilioOrigen}");

            Console.WriteLine($"\n País de Destino: {PaisDestino}");
            Console.WriteLine($" Región de Destino: {RegionDestino}");
            Console.WriteLine($" Provincia de Destino: {ProvinciaDestino}");
            Console.WriteLine($" Localidad de Destino: {LocalidadDestino}");
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