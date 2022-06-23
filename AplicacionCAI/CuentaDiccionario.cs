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
        
        private static readonly Dictionary<int,Cuenta> cuentaDiccionario = new Dictionary<int, Cuenta>();

        const string nombreArchivo = "cuentaLista.txt";

        static DiccionarioCuenta()
        {

            cuentaDiccionario = new Dictionary<int, Cuenta>();

            if (File.Exists(nombreArchivo))

            {
                using (var reader = new StreamReader(nombreArchivo))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var cuenta = new Cuenta(linea);
                        cuentaDiccionario.Add(cuenta.operacionCuenta,cuenta);
                    }

                }

            }

        }
        
        public static void VerEstadoCuenta(long cuit)
        {
            long cuitLogueado = cuit;
            decimal facturaImpaga = 0;
 
            Console.Clear();
            Console.WriteLine("\n Facturas para el Cliente: " + cuitLogueado;
            
            
            using (var cuentaLista = new FileStream("cuentaLista.txt", FileMode.Open))
            {
                using (var archivoCuenta = new StreamReader(cuentaLista))
                {
                    foreach (var otro in cuentaDiccionario.Values)
                    {
                        
                        if (otro.CuitCliente == cuit)
                        {
                            Console.Write("\n");
                            Console.WriteLine(" Fecha\t\tRazón Social\t\tCuit\t\tN° Factura.\t\tSaldo.\t\tEstado.");


                            Console.Write(otro.Fecha.ToShortDateString());
                            Console.Write("\t");
                            Console.Write(otro.RazonSocial);
                            Console.Write("\t\t");
                            Console.Write(otro.CuitCliente);
                            Console.Write("\t");
                            Console.Write(otro.NumeroFactura);
                            Console.Write("\t\t\t");
                            Console.Write(otro.SaldoCliente);
                            Console.Write("\t\t");
                            Console.Write(otro.Estado);
                            Console.Write("\t\t");

                            Console.Write("\n");

                            

                        }
                        


                    }
                    foreach (var cuentaImpaga in cuentaDiccionario.Values)
                    {
                        if (cuentaImpaga.Estado == "IMPAGA" && cuentaImpaga.CuitCliente == cuit)
                        {
                            facturaImpaga = facturaImpaga + cuentaImpaga.SaldoCliente;

                        }

                    }

                    Console.WriteLine("\n Saldo de la Cuenta: ");
                    Console.WriteLine("\n Importe Total de las Facturas Sin pagar : " + facturaImpaga);

                }
            }
            
            Validador.VolverMenu();
        }
      
       
    }
}
