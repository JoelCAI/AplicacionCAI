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
        private static readonly List<Cuenta> entradas;

        const string nombreArchivo = "cuentaLista.txt";

        static DiccionarioCuenta()
        {

            entradas = new List<Cuenta>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        entradas.Add(cuenta);
                    }

                }

            }

        }

        public static void Seleccionar(int codigoCliente)
        {
            var modelo = Cuenta.CrearModeloBusqueda(codigoCliente);

            bool found = false;

            foreach (var cuenta in entradas)
            {
                if (cuenta.CoincideCon(modelo))
                {
                    Console.WriteLine("\n El Numero de Factura es:{cuentas.codigoCliente}");
                    Console.WriteLine("\n El Saldo es: " + cuenta.saldoCliente);
                    Console.WriteLine("\n El Estado es: " + cuenta.estado);
                    found = true;
                }
            }

            if (found == false)
            {
                Console.WriteLine("No se encontraron registros para el Cliente solicitado");
            }
        }

        public static void CalcularSaldo(int codigoCliente, string estado)
        {
            var modelo = Cuenta.CrearModeloBusquedaClienteEstado(codigoCliente, estado);
            decimal total = 0;
            bool found = false;


            foreach (var cuenta in entradas)
            {
                if (cuenta.CoincideClienteEstado(modelo))
                {
                    var saldo = cuenta.saldoCliente;

                    total = total + saldo;
                    found = true;
                }


            }

            Console.WriteLine("El Saldo es: " + total);

            if (found == false)
            {
                Console.WriteLine("No se encontraron registros para el Cliente solicitado");
            }


        }
    }
}
