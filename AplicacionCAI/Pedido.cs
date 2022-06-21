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

        public int IdPedido { get; set; }
        public long CuitCorporativo { get; set; }
        public string RazonSocialCorporativo { get; set; }
        public DateTime FechaPedido { get; set; }
        public string EstadoPedido { get; set; }
        public string ContinenteOrigen { get; set; }
        public string RegionOrigen { get; set; }
        public string ProvinciaOrigen { get; set; }
        public string LocalidadOrigen { get; set; }
        public string DomicilioOrigen { get; set; }
        public string PaisOrigen { get; set; }
        public string ContinenteDestino { get; set; }
        public string RegionDestino { get; set; }
        public string ProvinciaDestino { get; set; }
        public string LocalidadDestino { get; set; }
        public string DomicilioDestino { get; set; }
        public string PaisDestino { get; set; }
        public decimal PrecioEncomienda { get; set; }
        public bool Urgente { get; set; }
        public bool EntregaDomicilio { get; set; }
        public bool RetiroEnPuerta { get; set; }
        public decimal PesoEncomienda { get; set; }
        public decimal SubTotalCalculoPedido { get; set; }
        public decimal TotalCalculoPedido { get; set; }
        public bool Facturado { get; set; }
        public string TipoServicio { get; set; }


        //NUEVO ID DE PEDIDO CON INCREMENTO RESPECTO AL ÚLTIMO GUARDADO
        public static int newId = CrearIdPedido() + 1;

        public static int CrearIdPedido()
        {
            int newid = 0;
            string ultimaLinea = File.ReadLines("pedidoLista.txt").LastOrDefault();
            if(!string.IsNullOrEmpty(ultimaLinea))
            {
                var valores = ultimaLinea.Split(';');
                newid = int.Parse(valores[0]);
            }
            else
            {
                newid = new Random().Next(50000000, 99999999);
            }
            return newid;
        }

        public Pedido()
        {

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

        public string ObtenerLineaDatos()
        {
            return $"{IdPedido};{EstadoPedido};{FechaPedido};{PaisOrigen};{RegionOrigen};{ProvinciaOrigen};{LocalidadOrigen};{DomicilioOrigen};{ContinenteOrigen};{PaisDestino};{RegionDestino};{ProvinciaDestino};{LocalidadDestino};{DomicilioDestino};{ContinenteDestino};{PrecioEncomienda};{PesoEncomienda};{CuitCorporativo};{RazonSocialCorporativo};{Urgente};{EntregaDomicilio};{RetiroEnPuerta};{SubTotalCalculoPedido};{TotalCalculoPedido};{Facturado};{TipoServicio}";
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

        public static Pedido CrearPedido()
        {
            // COMIENZO DE SOLICITUD DE NUEVO PEDIDO
            var pedido = new Pedido();

            pedido.IdPedido = newId;
            
            //var servicioPrecio = TarifarioDiccionario.BuscarServicioIdPedido();

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

                string[] lineas = File.ReadAllLines("ciudadesLista.txt");
                foreach(var datos in lineas)
                {
                    var opciones = datos.Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries)[0];
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
                Console.WriteLine("\n Elija Argentina para envíos locales. Elija otra opción para envíos internacionales.");

                string[] lines = File.ReadAllLines("continentesLista.txt");
                    foreach(var line in lines)
                    {
                        var firstValue = line.Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries)[0];
                        Console.WriteLine(firstValue);
                    }
                
                    var InfoDestino = Console.ReadLine();

                    switch (InfoDestino)
                    {
                            case "1":
                            Console.Clear();
                            pedido.PaisDestino = "ARGENTINA";
                            
                            Console.WriteLine("\n Elija la ciudad de destino.");

                            string[] ciudades = File.ReadAllLines("ciudadesLista.txt");
                            foreach(var linea in ciudades)
                            {
                                var datos = linea.Split(new string[]{";"}, StringSplitOptions.RemoveEmptyEntries)[0];
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


            pedido.PesoEncomienda = Validador.IngresarPeso("Ingrese el peso, máximo 30 kg ");
            
            decimal peso;

            decimal peso500g = 0.5m;
            decimal peso10Kg = 10;
            decimal peso20Kg = 20;
            decimal peso30Kg = 30;
            
            
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
                            pedido.Urgente = true;
                            avanzar = true;
                            break;

                        case "2":
                            pedido.Urgente = false;
                            avanzar = true;
                            break;
                        
                        default:
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
                            pedido.RetiroEnPuerta = true;
                            avanzar2 = true;
                            break;

                        case "2":
                            pedido.RetiroEnPuerta = false;
                            avanzar2 = true;
                            break;
                        
                        default:
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
                            pedido.EntregaDomicilio = true;
                            avanzar3 = true;
                            break;

                        case "2":
                            pedido.EntregaDomicilio = false;
                            avanzar3 = true;
                            break;
                        
                        default:
                            Console.WriteLine("No ha ingresado una opcion correcta");
                            break;

                    }

                } while (!avanzar3);

            }
            
            //CALCULO COSTO DE ENVÍO 
            
            if (pedido.PaisOrigen == pedido.PaisDestino)
            {
                if (pedido.RegionOrigen == pedido.RegionDestino)
                {
                    if (pedido.ProvinciaOrigen == pedido.ProvinciaDestino)
                    {
                        if (pedido.LocalidadOrigen == pedido.LocalidadDestino)
                        {
                            var tipoPedido = "Local";
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
            
                
            if (pedido.Urgente == true)
            {
                decimal cargo = RecargoUrgencia(pedido.Urgente);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido*cargo);
               
            }
            if (pedido.EntregaDomicilio == true)
            {
                decimal cargo = RecargoEntrega(pedido.EntregaDomicilio);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido*cargo);
            }
            if (pedido.RetiroEnPuerta == true)
            {
                decimal cargo = RecargoRetiro(pedido.RetiroEnPuerta);
                pedido.TotalCalculoPedido = pedido.SubTotalCalculoPedido + (pedido.SubTotalCalculoPedido*cargo);
            }
            
            pedido.MostrarPedidoFinal();
            
            

            return pedido;
        }
        


        private static decimal RecargoUrgencia(bool entrada)
        {
            decimal cargo = TarifarioDiccionario.EnvioUrgente(entrada);
            return cargo;
        }

        //private static decimal TopeRecargo(bool entrada)
        //{
        //  decimal cargo = TarifarioDiccionario.TopeRecargo(entrada);
        //  return cargo;
        //}

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
                opcion = Console.ReadLine().ToUpper();
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