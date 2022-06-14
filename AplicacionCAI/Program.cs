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

            SistemaPrincipal s = new SistemaPrincipal();
            s.Iniciar();

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
