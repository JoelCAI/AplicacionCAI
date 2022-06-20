using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    static class DiccionarioUsuario
    {
        
        private static readonly Dictionary<int, Usuario> usuarioDiccionario = new Dictionary<int, Usuario>();
        
        const string fileName = "usuarioLista.txt";
        
        
        static DiccionarioUsuario()
        {
            usuarioDiccionario = new Dictionary<int, Usuario>();

 
            if (File.Exists(fileName))

            {
                using (var reader = new StreamReader(fileName))

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
        
        public static Usuario BuscarUsuarioDni()
        {
            var dni = Usuario.ValidarDni();
  
            foreach (var usuario in usuarioDiccionario.Values)
            {
                if (usuario.CompararDniCoincidencia(dni))
                {
                    return usuario;
                }
            }
            Console.Clear();
            Console.WriteLine("\n No se ha encontrado el usuario ingresado");
            Validador.VolverMenu();
            //Program.Menu();
            
            return null;
        }
        
        public static Usuario BuscarUsuarioDniUnico()
        {
            var dni = Usuario.ValidarDniUnico();

            foreach (var usuario in usuarioDiccionario.Values)
            {
                if (usuario.CompararDniCoincidencia(dni))
                {
                    return usuario;
                }
            }
  
            return null;
        }
        
        public static Usuario BuscarUsuarioClave()
        {
            var clave = Usuario.ValidarClave();

            foreach (var usuario in usuarioDiccionario.Values)
            {
                if (usuario.CompararClaveCoincidencia(clave))
                {
                    return usuario;
                }
            }
            Console.Clear();
            Console.WriteLine("\n No se ha encontrado el usuario ingresado");
            Validador.VolverMenu();
            //Program.Menu();
            return null;
        }
        
    }
}