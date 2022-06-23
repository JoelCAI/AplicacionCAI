using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Program
    {
       

        static void Main(string[] args)
        {

             MenuPrincipal();
             Validador.Despedida();
 
        }

        public static void MenuPrincipal()
        {

            int ingreso;
            int dni = 0;
            string nombre = "";
            string clave = "";
            long cuit;

            do
            {
                Console.Clear();

                ingreso = Validador.PedirIntMenu("\n Aplicación Corporativa." +
                                       "\n [1] Ingresar Como Usuario Corporativo. " +
                                       "\n [2] Salir del Sistema.", 1, 2);

                if (ingreso == 1)
                {
                    Console.Clear();
                    var usuarioDni = DiccionarioUsuario.BuscarUsuarioDni();

                    if (usuarioDni != null && ingreso != 3)
                    {
                        Console.Clear();
                        Console.WriteLine("\n Ingrese su Clave");
                        string validacion = Console.ReadLine().ToUpper();

                        if (validacion == usuarioDni.ClaveUsuario)
                        {
                            dni = usuarioDni.DniUsuario;
                            nombre = usuarioDni.NombreUsuario;
                            clave = usuarioDni.ClaveUsuario;
                            cuit = usuarioDni.CuitCorporativo;

                            int opcion;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("\n Bienvenid@ " + nombre + "\n Su Cuit es: " + cuit.ToString());
                                opcion = Validador.PedirIntMenu("\n Menú del Usuario Corporativo" +
                                                       "\n [1] Solicitar un Pedido de correspondencia o Encomienda. " +
                                                       "\n [2] Consultar el Estado de un Pedido. " +
                                                       "\n [3] Consultar Estado de Cuenta. " +
                                                       "\n [4] Salir del Sistema.", 1, 4);

                                switch (opcion)
                                {
                                    case 1:
                                        Console.Clear();
                                        GenerarSolicitudPedido();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        ConsultarEstadoPedido();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        ConsultarCuenta(cuit);
                                        break;

                                }
                            } while (opcion != 4);

                        } 
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n Ingresó una clave incorrecta, presione cualquier tecla para volver al Menú Principal");
                            Console.ReadKey();
                        }
                        

                    }
                    

                }

            } while (ingreso != 2);

        }


        private static void GenerarSolicitudPedido()
        {
            var pedido = Pedido.CrearPedido();
            Console.WriteLine($"El costo total por el servicio es: {pedido.TotalCalculoPedido}");

            do
            {
                Console.WriteLine("¿Desea confirmar? Responder S/N");
                string ingreso = Console.ReadLine();
                string opcion = ingreso.ToUpper();

                if (opcion == "S")
                {
                    DiccionarioPedido.AgregarPedido(pedido);
                    Console.WriteLine("Su pedido se generó correctamente.");
                    break;
                }

                if (opcion == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor introducir un valor correcto");
                }
            } while (true);

            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }


        private static void ConsultarEstadoPedido()
        {
            var pedido = DiccionarioPedido.SeleccionarPedido();
            if (pedido != null)
            {
                Console.Clear();
                pedido.MostrarPedidoFinal();
            }

            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ConsultarCuenta(long cuit)
        {
            Console.WriteLine("");
            Console.WriteLine(":::::FACTURAS DISPONIBLES:::::");
            DiccionarioCuenta.VerEstadoCuenta(cuit);
            Console.WriteLine("");
            Console.WriteLine(":::::PEDIDOS PENDIENTES DE FACTURACIÓN:::::");
            DiccionarioPedido.PedidosSinFacturar(cuit);
            Console.WriteLine("");
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }
        
    }
}
