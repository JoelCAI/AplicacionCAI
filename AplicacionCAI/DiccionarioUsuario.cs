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
            throw new NotImplementedException();
        }


    }
}
