using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    static class DiccionarioCuenta
    {
        private static readonly List<Cuenta> cuentaDiccionario;

        //private static readonly Dictionary<int, Cuenta> cuentaDiccionario = new Dictionary<int, Cuenta>();

        const string nombreArchivo = "cuentaLista.txt";
        
        static DiccionarioCuenta()
        {

            cuentaDiccionario = new List<Cuenta>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        cuentaDiccionario.Add(cuenta);
                    }

                }

            }

        }

        public static void SeleccionarCuenta(long cuit)
        {
            var modelo = Cuenta.CrearModeloBusqueda(cuit);

            bool found = false;

            foreach (var cuentas in cuentaDiccionario)
            {
                if (cuentas.CoincideCuenta(modelo))
                {
                    Console.WriteLine("\n Numero de la Factura es: " + cuentas.NumeroFactura +
                                      "\n El Saldo es de: " + cuentas.SaldoCliente+
                                      "\n El Estado es: " + cuentas.Estado);
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No se encontraron registros para el Cliente solicitado");
            }
        }
        
        public static void CalculaSaldoCuenta (long cuit, string estado)
        {
            var modelo = Cuenta.CrearModeloBusquedaClienteEstado(cuit, estado);
            decimal total = 0;
            bool found = false;


            foreach (var cuenta in cuentaDiccionario)
            {
                if (cuenta.CoincideClienteEstado(modelo))
                {
                    var saldo = cuenta.saldoCliente;

                    total = total + saldo;
                    found = true;
                }


            }

            Console.WriteLine($"Saldo: ${total}");

            if (found == false)
            {
                Console.WriteLine("No se encontraron registros");
            }
        }
    }
}
