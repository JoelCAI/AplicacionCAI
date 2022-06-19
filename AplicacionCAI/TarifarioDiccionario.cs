using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    static class TarifarioDiccionario
    {
        
        private static readonly Dictionary<int, ServicioPrecio> servicioPrecioDiccionario = new Dictionary<int, ServicioPrecio>();

        const string fileName = "servicioPrecioLista.txt";
        
        
        static TarifarioDiccionario()
        {
            servicioPrecioDiccionario = new Dictionary<int, ServicioPrecio>();

            if (File.Exists(fileName))

            {
                using (var reader = new StreamReader(fileName))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var servicioPrecio = new ServicioPrecio(linea);
                        servicioPrecioDiccionario.Add(servicioPrecio.IdServicio, servicioPrecio);
                    }

                }

            }

        }


        public static ServicioPrecio BuscarServicioIdPedido()
        {
            var idServicio = ServicioPrecio.ValidarServicio();

            foreach (var servicio in servicioPrecioDiccionario.Values)
            {
                if (servicio.CompararServicioCoincidencia(idServicio))
                {
                    return servicio;
                }
            }
            Console.Clear();
            Console.WriteLine("\n No se ha encontrado el servicio ingresado");
 
            return null;
        }
        
        
        
    }
}
