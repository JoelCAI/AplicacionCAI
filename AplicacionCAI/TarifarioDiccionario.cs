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
        
        public class RangoPeso{
            public decimal Desde;
            public decimal Hasta;
            public decimal Precio;
        }

        //public class TarifaXPeso
        //{
        //    public string Tipo;
        //    List<RangoPeso> Rangos;
        //          private decimal peso;
            //public decimal PrecioPeso(peso){
            //      foreach(var r in Rangos){
            //      if(peso >= r.Desde && peso <= r.Hasta){
            //          return r.Precio;
            //      }
            //  }
            //  return -1; //indicando que el usuario ingreso un pedido fuera del tarifario
            //}
            //}


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
    
        public static decimal EnvioUrgente(bool entrada)
        {
            var modelo = ServicioPrecio.Recargo(entrada);
            foreach (var tarifas in servicioPrecioDiccionario.Values)
            {
                return tarifas.PrecioServicioUrgente;
            }
            return 0;
        }

        public static decimal TopeRecargo(bool entrada)
        {
            var modelo = ServicioPrecio.Recargo(entrada);
            foreach (var tarifas in servicioPrecioDiccionario.Values)
            {
                return tarifas.TopeUrgente;
            }
            return 0;
        }

        public static decimal RetiroEnPuerta (bool entrada)
        {
            var modelo = ServicioPrecio.Recargo(entrada);
            foreach (var tarifas in servicioPrecioDiccionario.Values)
            {
                return tarifas.PrecioServicioEnPuerta;
            }
            return 0;
        }

        public static decimal EntregaDomicilio (bool entrada)
        {
            var modelo = ServicioPrecio.Recargo(entrada);
            foreach (var tarifas in servicioPrecioDiccionario.Values)
            {
                return tarifas.PrecioServicioEnSucursal;
            }
            return 0;
        }
    }
}
