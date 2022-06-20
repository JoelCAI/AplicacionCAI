using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    static class DiccionarioPedido
    {
        
        private static readonly Dictionary<int, Pedido> items;

        const string fileName = "pedidoLista.txt";


        static DiccionarioPedido()
        {
            items = new Dictionary<int, Pedido>();

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var pedido = new Pedido(linea);
                        items.Add(pedido.IdPedido, pedido);
                    }

                }

            }
        }
        public static void AgregarPedido(Pedido pedido)
        {
            items.Add(pedido.IdPedido, pedido);
            GrabarPedido();
        }
		
        public static Pedido SeleccionarPedido()
        {
            var modelo = Pedido.CrearModeloBusqueda();

            foreach (var pedido in items.Values)
            {
                if (pedido.CoincideCon(modelo))
                {
                    return pedido;
                }
            }
            Console.WriteLine("No se ha encontrado el pedido");
            return null;
        }
        
        public static void PedidosSinFacturar(long clienteLogueado)
        {
            var modelo = Pedido.BusquedaCuitCorporativo(clienteLogueado);

            bool match = false;
            
                    foreach (var pedido in items.Values)
                    {
                        if (pedido.Facturado == false)
                        {

                            Console.Write("\n");
                            Console.WriteLine("Fecha\t\tID\t\t\tEstado\t\t\tTotal");
                            
                            Console.Write(pedido.FechaPedido.ToShortDateString());
                            Console.Write("\t");
                            Console.Write(pedido.IdPedido);
                            Console.Write("\t\t");
                            Console.Write(pedido.EstadoPedido);
                            Console.Write("\t\t");
                            Console.Write(pedido.TotalCalculoPedido);
                            Console.Write("\t\t");

                            Console.Write("\n");                                
                            
                        }
                    }

                    match = true;
                    

            if (match == false)
            {
                Console.WriteLine("No se encontraron registros");
            }
        }        

        public static void GrabarPedido()
        {
            using (var writer = new StreamWriter(fileName, append: false))
            {

                foreach (var pedido in items.Values)
                {
                    var linea = pedido.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }

            }

        }

    }

}