using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    internal class DiccionarioUsuario
    {
        /* esto va a estar disponible para cada uno de los metodos de la clase */
        /* Readonly significa que una vez que se crea el diccionario ya no se modifica los datos. */
        private static readonly Dictionary<int, Usuario> usuarioDiccionario = new Dictionary<int, Usuario>();

        const string archivoUsuario = "usuarioLista.txt";


        static DiccionarioUsuario()
        {
            usuarioDiccionario = new Dictionary<int, Usuario>();

            if (File.Exists(archivoUsuario))

            {
                using (var reader = new StreamReader(archivoUsuario))

                {

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var usuario = new Usuario(linea);
                        usuarioDiccionario.Add(usuario.DniUsuario, usuario);
                    }

                }

            }

        }

        public static void AgregarUsuario(Usuario usuario)

        {
            usuarioDiccionario.Add(usuario.DniUsuario, usuario);
        }

        public static void EliminarUsuario(Usuario usuario)
        {
            usuarioDiccionario.Remove(usuario.DniUsuario);
        }

        public static bool UsuarioExiste(int dni)
        {
            return usuarioDiccionario.ContainsKey(dni);
        }

        public static Usuario SeleccionarUsuario()
        {
            var modelo = Usuario.CrearModeloBusqueda();

            foreach (var usuarios in usuarioDiccionario.Values)
            {
                if (usuarios.CoincideCon(modelo))
                {
                    return usuarios;
                }
            }
            Console.WriteLine("No se ha encontrado el usuario ingresado");
            return null;
        }

       



    }
}
