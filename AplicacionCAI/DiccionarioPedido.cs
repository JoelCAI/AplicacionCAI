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

        private static readonly Dictionary<int, Pedido> pedidoDiccionario = new Dictionary<int, Pedido>();

        const string archivoPedido = "pedidoLista.txt";


        static DiccionarioPedido()
        {
            pedidoDiccionario = new Dictionary<int, Pedido>();

            if (File.Exists(archivoPedido))

            {
                using (var reader = new StreamReader(archivoPedido))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var pedido = new Pedido(linea);
                        pedidoDiccionario.Add(pedido.IdPedido, pedido);
                    }

                }

            }

        }

        public static void AgregarPedido(Pedido pedido)
        {
            pedidoDiccionario.Add(pedido.IdPedido, pedido);
            GrabarPedido();
        }

        public static Pedido SeleccionarPedido()
        {
            var modelo = Pedido.CrearModeloBusqueda();

            foreach (var pedido in pedidoDiccionario.Values)
            {
                if (pedido.CoincideCon(modelo))
                {
                    return pedido;
                }
            }
            Console.WriteLine("No se ha encontrado el servicio");
            return null;
        }



        public static void GrabarPedido()
        {
            using (var writer = new StreamWriter(archivoPedido, append: false))
            {

                foreach (var servicio in pedidoDiccionario.Values)
                {
                    var linea = servicio.ObtenerLineaDatos();
                    writer.WriteLine(linea);
                }

            }

        }
    }

}