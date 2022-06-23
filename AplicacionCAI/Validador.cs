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
            string mensajeError = "\n El valor no puede ser vacío y tiene que estar entre el rango solicitado. ";

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
        
        public static decimal PedirDecimal(int min, int max)
        {
            decimal valor;

            string valorUno;
            string opcion;

            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacío y tiene que estar dentro del rango solicitado. ";

            do
            {
                Console.Clear();
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

      
        public static string PedirCaracterString(string mensaje, int min, int max)
        {
            string valor;
            bool valido = false;
            string mensajeMenu = "\n El número de caracteres a ingresar es entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacío y tiene que estar dentro del rango solicitado. ";

            int contador = 2;
            
            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);
                Console.WriteLine(mensajeError);

                valor = Console.ReadLine().ToUpper();


                if (valor.Length < min || valor.Length > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n Usted ingresó caracteres o valores que no están en el rango solicitado");
                    Console.WriteLine(mensajeMenu);
                    VolverMenu();
                    //Program.Menu();

                    contador--;

                }
                if (contador == 0)
                {
                    Console.Clear();
                    VolverMenu();
                    //Program.Menu();

                    contador--;
                }
                if (valor == "")
                {
                    Console.Clear();
                    Console.WriteLine("\n Usted presionó solo la tecla Enter");
                    VolverMenu();
                    //Program.Menu();

                }
                else
                {

                    valido = true;

                }
                contador--;

            } while (!valido);


            return valor;

        }

        public static int IngresarPeso(string titulo)
        {

            Console.WriteLine(titulo);

            do
            {
                var ingreso = Console.ReadLine();

                if (string.IsNullOrEmpty(ingreso))
                {
                    Console.WriteLine("El ingreso no debe ser vacío");
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
            
            return valor;
            
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
            Console.WriteLine("\n\n Gracias por usar nuestro Sistema. Presione cualquier teclar para finalizar");
            Console.ReadKey();
        }


        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }

    }
}
