using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    static class DiccionarioServicioPrecio
    {
        
        private static readonly Dictionary<int, ServicioPrecio> servicioPrecioDiccionario = new Dictionary<int, ServicioPrecio>();


        const string archivoServicioPrecio = "servicioPrecioLista.txt";


        
        static DiccionarioServicioPrecio()
        {
            servicioPrecioDiccionario = new Dictionary<int, ServicioPrecio>();

            if (File.Exists(archivoServicioPrecio))

            {
                using (var reader = new StreamReader(archivoServicioPrecio))

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

        public static void AgregarServicio(ServicioPrecio servicio)

        {
            servicioPrecioDiccionario.Add(servicio.IdServicio, servicio);
        }

        public static void EliminarServicio(ServicioPrecio servicio)
        {
            servicioPrecioDiccionario.Remove(servicio.IdServicio);
        }

        public static bool ServicioExiste(int idServicio)
        {
            return servicioPrecioDiccionario.ContainsKey(idServicio);
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
