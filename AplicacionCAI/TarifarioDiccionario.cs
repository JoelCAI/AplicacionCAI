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
        
        //private static readonly Dictionary<int, TarifaPorPeso> servicioPrecioDiccionario = new Dictionary<int, TarifaPorPeso>();
        public static Dictionary<string, TarifaPorPeso> tarifarioDiccionario = new Dictionary<string, TarifaPorPeso>();

        const string fileName = "tarifarioLista.txt";


        static TarifarioDiccionario()
        {
            tarifarioDiccionario = new Dictionary<string, TarifaPorPeso> ();

            if (File.Exists(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var servicioPrecio = new TarifaPorPeso(linea);
                        tarifarioDiccionario.Add(servicioPrecio.IdServicio, servicioPrecio);
                    }

                }
            }
        }
        
        public static decimal EnvioUrgente(bool entrada)
        {
            var modelo = TarifaPorPeso.Recargo(entrada);

            foreach (var tarifas in tarifarioDiccionario.Values)
            {

                return tarifas.RecargoUrgencia;

            }

            return 0;

        }

        public static decimal TopeRecargo(bool entrada)
        {
            var modelo = TarifaPorPeso.Recargo(entrada);

            foreach (var tarifas in tarifarioDiccionario.Values)
            {

                return tarifas.TopeUrgente;

            }

            return 0;

        }

        public static decimal RetiroEnPuerta (bool entrada)
        {
            var modelo = TarifaPorPeso.Recargo(entrada);

            foreach (var tarifas in tarifarioDiccionario.Values)
            {

                return tarifas.RecargoRetiroPuerta;

            }

            return 0;

        }

        public static decimal EntregaDomicilio (bool entrada)
        {
            var modelo = TarifaPorPeso.Recargo(entrada);

            foreach (var tarifas in tarifarioDiccionario.Values)
            {

                return tarifas.RecargoEntregaPuerta;

            }

            return 0;

        }
    }
}