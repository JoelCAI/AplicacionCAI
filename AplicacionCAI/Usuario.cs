using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Usuario
    {
		private List<Pedido> _pedido;
		private List<Factura> _factura;
		private List<Reclamo> _reclamo;
		private List<Item> _item;
		private List<Producto> _producto;

		protected int _dniUsuario;
        protected string _nombreUsuario;
        protected string _claveUsuario;
        protected long _cuitCorporativo;

		public List<Pedido> Pedido
		{
			get { return this._pedido; }
			set { this._pedido = value; }
		}

		public List<Factura> Factura
		{
			get { return this._factura; }
			set { this._factura = value; }
		}

		public List<Reclamo> Reclamo
		{
			get { return this._reclamo; }
			set { this._reclamo = value; }
		}

		public List<Item> Item
		{
			get { return this._item; }
			set { this._item = value; }
		}

		public List<Producto> Producto
		{
			get { return this._producto; }
			set { this._producto = value; }
		}

		public string NombreUsuario
        {
            get { return this._nombreUsuario; }
            set { this._nombreUsuario = value; }
        }
        public string ClaveUsuario
        {
            get { return this._claveUsuario; }
            set { this._claveUsuario = value; }
        }

        public int DniUsuario
        {
            get { return this._dniUsuario; }
            set { this._dniUsuario = value; }
        }
        public long CuitCorporativo
        {
            get { return this._cuitCorporativo; }
            set { this._cuitCorporativo = value; }
        }

		public Usuario()
        {

        }

        public Usuario(string linea)
        {

            var datos = linea.Split(';');
            _dniUsuario = int.Parse(datos[0]);
            _nombreUsuario = datos[1];
            _cuitCorporativo = long.Parse(datos[2]);
            _claveUsuario = datos[3];
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



		public void MenuUsuario(List<Producto> producto, List<Pedido> pedido, List<Factura> factura,
								List<Reclamo> reclamo, List<Item> item)
		{
			
			Producto = producto;
			Pedido = pedido;
			Factura = factura;
			
			Reclamo = reclamo;
			Item = item;

			/* Ojo ver esto*/
			string codigoProducto ="";

			Console.Clear();
			Console.WriteLine(" \n Bienvenido Usuario: " + NombreUsuario);

					int opcion;
					do
					{
						Console.Clear();
						Console.WriteLine(" \n Bienvenido Usuario: " + NombreUsuario);
						opcion = Validador.PedirIntMenu("\n Menu del Usuario Corporativo" +
											   "\n [1] Generar Solicitud. " +
											   "\n [2] Consultar Estado de Servicio. " +
											   "\n [3] Consultar Estado de Cuenta. " +
											   "\n [4] Emitir Factura. " +
											   "\n [5] Generar Reclamo. " +
											   "\n [6] Volver al Menú Inicial.", 1, 6);

						switch (opcion)
						{
							case 1:
							Program.CrearProducto(codigoProducto);
								break;
							case 2:
							Program.EliminarProducto();
							break;
							case 3:
							Program.EditarProducto();
							break;
							case 4:
							Program.BuscarProducto();
							break;
							case 5:
								break;

						}
					} while (opcion != 6);



			
			


		}


	}

}
