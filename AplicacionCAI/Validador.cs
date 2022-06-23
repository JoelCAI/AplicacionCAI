using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Validador
    {
        public static int PedirIntMenu(string mensaje, int min, int max)
        {
            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirIntParaSistema(string mensaje)
        {
            int valor;
            bool valido = false;
        
            string dato;

            do
            {

                Console.WriteLine(mensaje);

                dato = Console.ReadLine();

                if (!int.TryParse(dato, out valor))
                {
                    
                    valor = 3;
                    break;

                }
                if (string.IsNullOrEmpty(dato))
                {
                    
                    valor = 3;
                    break;

                }
                if (dato == "")
                {
                    
                    valor = 3;
                    break;


                }

                else
                {
                    valido = true;
                }
                


            } while (!valido);

            return valor;

        }
        
        public static decimal PedirDecimal(string mensaje, int min, int max)
        {
            decimal valor;

            string valorUno;
            string opcion;

            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                valorUno = Console.ReadLine();
                opcion = valorUno.Replace('.', ',');

                if (!decimal.TryParse(opcion, out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }
        
        public static string ValidarSioNo(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *SI* ó" +
                                      "\n *NO*";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "SI";
                string opcionD = "NO";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
                {
                    continue;

                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }
        
        public static string ValidarStringNoVacioSistema(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Puede ser combinación de minúsculas, MAYÚSCULAS y caracteres";
            string mensajeError = "\n Por favor ingrese un valor no vacio para que pueda continuar. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeValidador);

                opcion = Console.ReadLine().ToUpper();

                if (opcion == "")
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }
        
        
        
        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }
        
        public static void Despedida()
        {
            Console.Clear();
            Console.WriteLine("\n\n Gracias por usar nuestro Sistema presione cualquier teclar para finalizar");
            Console.ReadKey();
        }
        
        public static int IngresarEntero(string titulo)
        {

            Console.WriteLine(titulo);

            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacio");
                    continue;
                }

                if (!Int32.TryParse(ingreso, out var salida))
                {
                    Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                    continue;
                }

                if (salida <= 0)
                {
                    Console.WriteLine("El valor ingresado debe ser mayor a cero");
                    continue;
                }

                return salida;

            } while (true);
        }
        
        public static int IngresarPeso(string titulo)
        {

            Console.WriteLine(titulo);

            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacio");
                    continue;
                }

                if (!Int32.TryParse(ingreso, out var salida))
                {
                    Console.WriteLine("El dato ingresado es incorrecto, ingrese nuevamente");
                    continue;
                }

                if (salida <= 0 || salida >= 30000)
                {
                    Console.WriteLine("El valor ingresado debe ser mayor a cero y menor o igual a 30000");
                    continue;
                }

                return salida;

            } while (true);
        }
        
        public static string TextInput(string titulo, bool permiteNumeros = false)
        {
            string ingreso;
            do
            {

                Console.WriteLine(titulo);

                ingreso = Console.ReadLine();
                

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un valor");
                    continue;
                }

                if (permiteNumeros && !ingreso.Any(Char.IsDigit))
                {
                    Console.WriteLine("El valor ingresado debe contener numeros");
                    continue;
                }

                string ingreso1 = ingreso.ToUpper();
                return ingreso1;
            } while (true);

        }
        

        public static void Despedida()
        {
            Console.Clear();
            Console.WriteLine("\n\n Gracias por usar nuestro Sistema presione cualquier teclar para finalizar");
            Console.ReadKey();
        }


        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }

    }
}
