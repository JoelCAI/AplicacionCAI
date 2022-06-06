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

        public static decimal CalcularPrecio(decimal pesoProducto, string distanciaProducto)
        {
            decimal precioProducto =0;

            decimal sobreHasta500g = 0.5m;
            decimal bultoHasta10Kg = 10;
            decimal bultoHasta20Kg = 20;
            decimal bultoHasta30Kg = 30;

            string local = "LOCAL";
            string provincial = "PROVINCIAL";
            string regional = "REGIONAL";
            string nacional = "NACIONAL";

            if (pesoProducto == sobreHasta500g && distanciaProducto == local)
            {
                precioProducto = 10;
               
            }
            else if (pesoProducto == sobreHasta500g && distanciaProducto == provincial)
            {
                precioProducto = 20;
                
            }
            else if (pesoProducto == sobreHasta500g && distanciaProducto == regional)
            {
                precioProducto = 40;
            }
            else if (pesoProducto == sobreHasta500g && distanciaProducto == nacional)
            {
                precioProducto = 80;
            }
            else if (pesoProducto == bultoHasta10Kg && distanciaProducto == local)
            {
                precioProducto = 20;
            }
            else if (pesoProducto == bultoHasta10Kg && distanciaProducto == provincial)
            {
                precioProducto = 40;
            }
            else if (pesoProducto == bultoHasta10Kg && distanciaProducto == regional)
            {
                precioProducto = 80;
            }
            else if (pesoProducto == bultoHasta10Kg && distanciaProducto == nacional)
            {
                precioProducto = 160;
            }
            else if (pesoProducto == bultoHasta20Kg && distanciaProducto == local)
            {
                precioProducto = 30;
            }
            else if (pesoProducto == bultoHasta20Kg && distanciaProducto == provincial)
            {
                precioProducto = 60;
            }
            else if (pesoProducto == bultoHasta20Kg && distanciaProducto == regional)
            {
                precioProducto = 120;
            }
            else if (pesoProducto == bultoHasta20Kg && distanciaProducto == nacional)
            {
                precioProducto = 240;
            }
            else if (pesoProducto == bultoHasta30Kg && distanciaProducto == local)
            {
                precioProducto = 40;
            }
            else if (pesoProducto == bultoHasta30Kg && distanciaProducto == provincial)
            {
                precioProducto = 80;
            }
            else if (pesoProducto == bultoHasta30Kg && distanciaProducto == regional)
            {
                precioProducto = 160;
            }
            else if (pesoProducto == bultoHasta30Kg && distanciaProducto == nacional)
            {
                precioProducto = 320;
            }

            return precioProducto;
            
        }

        public static decimal PedirDecimal(string mensaje, int min, int max)
        {
            decimal valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!decimal.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
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
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                valor = Console.ReadLine();


                if (valor.Length < min || valor.Length > max)
                {
                    Console.Clear();
                    Console.WriteLine(mensajeError);

                }
                else
                {

                    valido = true;

                }

            } while (!valido);


            return valor;

        }

        public static string ValidarTipoRecargo(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *URGENTE* ó" +
                                      "\n *RETIROENPUERTA* ó " +
                                      "\n *INTERNACIONAL* ó " +
                                      "\n *NINGUNO* ó ";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "URGENTE";
                string opcionD = "RETIROENPUERTA";
                string opcionE = "INTERNACIONAL";
                string opcionF = "NINGUNO";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD) & (opcion != opcionE)
                                & (opcion != opcionF))
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

        public static string ValidarDistanciaProducto(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *LOCAL* ó" +
                                      "\n *PROVINCIAL* ó " +
                                      "\n *REGIONAL* ó " +
                                      "\n *NACIONAL* ó ";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "LOCAL";
                string opcionD = "PROVINCIAL";
                string opcionE = "REGIONAL";
                string opcionF = "NACIONAL";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD) & (opcion != opcionE)
                                & (opcion != opcionF))
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

       

        public static string ValidarPesoProducto(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *0,5* ó" +
                                      "\n *10* ó " +
                                      "\n *20* ó " +
                                      "\n *30* ó ";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "0,5";
                string opcionD = "10";
                string opcionE = "20";
                string opcionF = "30";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD) & (opcion != opcionE)
                                & (opcion != opcionF))
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

        public static long PedirLongMenu(string mensaje, long min, long max)
        {

            long valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!long.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
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

        public static string ValidarSioNoProducto(string mensaje, string codigo, string nombre)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Valores permitidos:" +
                                      "\n *SI* ó" +
                                      "\n *NO*";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            string mensajeConfirmacion = "\n Producto a Borrar" +
                                         "\n Código de Producto: " + codigo +
                                         "\n Nombre de Producto: " + nombre;                                      

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                Console.WriteLine(mensajeConfirmacion);
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

        public static DateTime ValidarFechaIngresada(string mensaje)
        {
            bool ingresoCorrecto;
            DateTime fechaValida;

            do
            {
                Console.Clear();
                Console.WriteLine(mensaje);
                Console.WriteLine("\n Ingrese un formato válido.");
                Console.WriteLine("\n El formato correcto es *dd/mm/aaaa*.");
                Console.WriteLine("\n También puede ser *dd/mm/aaaa hh:mm:ss*.");

                string ingresoNacimiento = Console.ReadLine();

                ingresoCorrecto = DateTime.TryParse(ingresoNacimiento, out fechaValida);

                if (!ingresoCorrecto)
                {
                    continue;
                }


            } while (!ingresoCorrecto);

            return fechaValida;
        }

        public static int PedirIntMayor(string mensaje, int min)
        {

            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor mayor a " + min;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor <= min)
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
