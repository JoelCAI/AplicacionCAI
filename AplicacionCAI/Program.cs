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
           
           Menu();
           
         

        }

        public static void Menu()
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

                switch (ingreso)
                {
                    case 1:
                        Console.Clear();
                        var usuarioDni = DiccionarioUsuario.BuscarUsuarioDni();

                        if (usuarioDni != null)
                        {
                            var usuarioClave = DiccionarioUsuario.BuscarUsuarioClave();

                            if (usuarioClave != null)
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
                            else
                            {
                                
                                Console.WriteLine("Digitó una clave incorrecta, vuelvalo a intentar con los datos correctos");
                                Validador.VolverMenu();
                            }


                        }
                        else
                        {
                            
                            Console.WriteLine("No existe el usuario, intente con otro usuario");
                            usuarioDni = null;
                            Validador.VolverMenu();
                        }
                        
                        break;
                    case 2:
                        
                    break;

                }
            } while (ingreso != 2);

        }

        public static void Continuar()
        {

        }

        private static void GenerarSolicitudPedido()
        {
            var pedido = Pedido.CrearPedido();

            

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
            /*
            string valor = codigoProductoNuevo;
            var producto = Producto.CrearNuevoProducto(valor);
            DiccionarioProducto.AgregarProducto(producto);
            */
        }


        public static void EliminarProducto()
        {
            /*
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
            */
            
        }

       
        public static void EditarProducto()
        {
            /*
            var producto = DiccionarioProducto.SelecccionarProducto();
            producto.EditarProducto();
            */
        }

        public static void BuscarProducto()
        {

            
            //var producto = DiccionarioProducto.SelecccionarProducto();
            //producto.VerProducto();
            
        }


		

	}
}
