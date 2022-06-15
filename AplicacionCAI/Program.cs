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
            
            Console.WriteLine("\n Bienvenido a la Aplicación \n\n");
            

            bool seguir = true;
            int dni;
            string nombre = "";
            string clave;
            long cuit =0;
           
            //string estado = "IMPAGA";

            do
            {
                var usuario = DiccionarioUsuario.SeleccionarUsuario();
                
                if (usuario != null)
                {
                    dni = usuario.DniUsuario;
                    nombre = usuario.NombreUsuario;
                    clave = usuario.ClaveUsuario;
                    cuit = usuario.CuitCorporativo;
                    seguir = false;
                }

            } while (seguir);

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("\n Bienvenid@ " + nombre + "\n Su Cuit es: " + cuit.ToString());
                opcion = Validador.PedirIntMenu("\n Menú del Usuario Corporativo" +
                                       "\n [1] Generar Solicitud de Pedido. " +
                                       "\n [2] Consultar Estado del Pedido. " +
                                       "\n [3] Consultar Estado de Cuenta. " +
                                       "\n [4] Salir del Sistema.", 1, 4);

                switch (opcion)
                {
                    case 1:
                            GenerarSolicitudPedido();
                        //Program.CrearProducto(codigoProducto);
                        break;
                    case 2:
                        ConsultarEstadoPedido();
                        //Program.EliminarProducto();
                        break;
                    case 3:
                        ConsultarEstadoCuenta();
                        //Program.EditarProducto();
                        break;

                }
            } while (opcion != 4);

            

        }




        private static void GenerarSolicitudPedido()
        {
            var pedido = Pedido.CrearPedido();

            Console.WriteLine("\n El costo total por el pedido es: " + pedido.PrecioEncomienda);

            do
            {
                string opcion1 = Validador.ValidarSioNo("¿Confirma Operacion de acuerdo a valor generado? Responder S/N");
                

                if (opcion1 == "SI")
                {
                    DiccionarioPedido.AgregarPedido(pedido);
                    break;
                }
                if (opcion1 == "NO")
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

        private static void ConsultaPedido()
        {
            var pedido = DiccionarioPedido.SeleccionarPedido();
            if (pedido != null)
            {
                Console.Clear();
                pedido.MostrarPedido();
            }
            Console.WriteLine("Pulse una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }


        public static void ConsultarEstadoPedido()
        {


        }

        public static void ConsultarEstadoCuenta()
        {


        }





        /* Alta Nuevo Producto */
        public static void CrearProducto(string codigoProductoNuevo)
        {
            string valor = codigoProductoNuevo;
            var producto = Producto.CrearNuevoProducto(valor);
            DiccionarioProducto.AgregarProducto(producto);
        }


        public static void EliminarProducto()
        {
            var producto = DiccionarioProducto.SelecccionarProducto();
            producto.VerProducto();
            Console.WriteLine("\n Usted va a eliminar a " + producto.DatosProducto);
            string opcion = Validador.ValidarSioNo("Esta Seguro?"); 

            if (opcion == "SI")
            {
                DiccionarioProducto.EliminarProducto(producto);
                Console.WriteLine("\n Se elimino a " + producto.DatosProducto);
            }
            else
            {
                producto.VerProducto();
                Console.WriteLine("\n Como puede ver no se eliminó ningún Producto");
            }
            
        }

       
        public static void EditarProducto()
        {
            var producto = DiccionarioProducto.SelecccionarProducto();
            producto.EditarProducto();
        }

        public static void BuscarProducto()
        {
            
            var producto = DiccionarioProducto.SelecccionarProducto();
            producto.VerProducto();
        }


		

	}
}
