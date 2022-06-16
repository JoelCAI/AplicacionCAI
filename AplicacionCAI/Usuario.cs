using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Usuario
    {
		List<Usuario> usuarioLista;
		protected int dniUsuario;
        protected string nombreUsuario;
        protected string claveUsuario;
        protected long cuitCorporativo;

		public List<Usuario> UsuarioLista
		{
			get { return this.usuarioLista; }
			set { this.usuarioLista = value; }
		}

		public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { this.nombreUsuario = value; }
        }
        public string ClaveUsuario
        {
            get { return this.claveUsuario; }
            set { this.claveUsuario = value; }
        }

        public int DniUsuario
        {
            get { return this.dniUsuario; }
            set { this.dniUsuario = value; }
        }
        public long CuitCorporativo
        {
            get { return this.cuitCorporativo; }
            set { this.cuitCorporativo = value; }
        }

		public Usuario()
        {
			

		}

        public Usuario(string linea)
        {
			
			var datos = linea.Split(';');
            dniUsuario = int.Parse(datos[0]);
            nombreUsuario = datos[1];
            cuitCorporativo = long.Parse(datos[2]);
            claveUsuario = datos[3];
        }

		public static Usuario CrearNuevoUsuario()
        {
			var usuario = new Usuario();

			Console.WriteLine("Ingrese el Dni del Usuario");

			do
			{
				
				var ingreso = Console.ReadLine();

				if (!int.TryParse(ingreso, out var dni))
                {
					Console.Clear();
					Console.WriteLine("No ha ingresado un correcto DNI");
                }
				if (dni < 10_000_000 || dni > 99_999_999)
                {
					Console.WriteLine("Recuerde que debe el Dni solo puede tener 8 cifras ");
					Console.WriteLine("Vuelvalo a intentar considerando esta observación");
					continue;
				}
				if (DiccionarioUsuario.UsuarioExiste(dni))
                {
					Console.WriteLine("El usuario Dni: *" + dni + "* ya existe. Intente con otro DNI.");
					continue;
				}

			} while (usuario.DniUsuario == 0);

			do
			{
				Console.WriteLine("Ingrese el nombre de la persona");
				var ingreso = Console.ReadLine();

				if (string.IsNullOrWhiteSpace(ingreso))
                {
					Console.WriteLine(" Recuerde que no se admite valores vacios. Ingrese el nombre.");
					continue;
                }
				if (ingreso.Length < 6 || ingreso.Length > 9)
				{
					Console.Clear();
					Console.WriteLine("Debe contener entre 6 y 9 caracteres");
					continue;

				}

				bool ok = true;
				for	(int i = 0; i < 10; i++)
                {
					if(ingreso.Contains(i.ToString()))
                    {
						Console.WriteLine("El nombre no puede contener números");
						ok = false;
						break;
                    }
                }
				if (!ok)
                {
					continue;
                }

				usuario.NombreUsuario = ingreso;

			} while (string.IsNullOrWhiteSpace(usuario.NombreUsuario));				


			return usuario;


        }

		public static Usuario ValidarDni()
		{
			var dni = new Usuario();

			dni.DniUsuario = Validador.PedirIntMenuInicial("\n Por favor ingresar el numero de dni autorizado para continuar",10_000_000,99_999_999);
			

			return dni;
		}

		public static Usuario ValidarClave()
		{
			var clave = new Usuario();

			clave.ClaveUsuario = Validador.PedirCaracterString("\n Por favor ingresar la clave del Usuario",0,16);


			return clave;
		}

		public bool CompararDniCoincidencia(Usuario modelo)
		{

			if (modelo.DniUsuario != 0 && DniUsuario != modelo.DniUsuario)
			{
				return false;
			}
			

			return true;
		}

		public bool CompararClaveCoincidencia(Usuario clave)
		{

			if (clave.ClaveUsuario != "" && ClaveUsuario != clave.ClaveUsuario)
			{
				return false;
			}

			return true;
		}


		private static string IngresarString(string mensaje)
		{

			Console.WriteLine(mensaje);

			do
			{
				var ingreso = Console.ReadLine();

				if (string.IsNullOrEmpty(ingreso))
				{
					Console.Clear();
					Console.WriteLine("El ingreso no debe ser vacio");
					continue;
				}
	

				return ingreso;

			} while (true);
		}


		


	}

}
