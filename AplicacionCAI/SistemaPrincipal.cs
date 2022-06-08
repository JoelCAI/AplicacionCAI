using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class SistemaPrincipal
    {
        private List<UsuarioMain> _usuarioMain;
        private List<UsuarioCorporativo> _usuarioCorporativo;

        private List<Producto> _producto;
        private List<Pedido> _pedido;
        private List<Factura> _factura;
		private List<ClienteCorporativo> _clienteCorporativo;
		private List<Reclamo> _reclamo;
		private List<Item> _item;

        public SistemaPrincipal()
        {
            this._usuarioMain = new List<UsuarioMain>();
            this._usuarioCorporativo = new List<UsuarioCorporativo>();

            this._producto = new List<Producto>();
            this._pedido = new List<Pedido>();
            this._factura = new List<Factura>();
			this._clienteCorporativo = new List<ClienteCorporativo>();
			this._reclamo = new List<Reclamo>();
			this._item = new List<Item>();
        }

		public int BuscarUsuarioMainNombre(string nombre)
		{
			for (int i = 0; i < this._usuarioMain.Count; i++)
			{
				if (this._usuarioMain[i].NombreUsuario == nombre)
				{
					return i;
				}
			}
			return -1;
		}

		public int BuscarUsuarioCorporativoNombre(string nombre)
		{
			for (int i = 0; i < this._usuarioCorporativo.Count; i++)
			{
				if (this._usuarioCorporativo[i].NombreUsuario == nombre)
				{
					return i;
				}
			}
			return -1;
		}

		public int BuscarUsuarioMainClave(string nombre, string clave)
		{
			for (int i = 0; i < this._usuarioMain.Count; i++)
			{
				if (this._usuarioMain[i].NombreUsuario == nombre)
				{
					if (this._usuarioMain[i].ClaveUsuario == clave)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public int BuscarUsuarioCorporativoClave(string nombre, string clave)
		{
			for (int i = 0; i < this._usuarioCorporativo.Count; i++)
			{
				if (this._usuarioCorporativo[i].NombreUsuario == nombre)
				{
					if (this._usuarioCorporativo[i].ClaveUsuario == clave)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public void ValidacionSupervisor()
		{
			string nombre;
			string clave;
			string nombreUsuarioGerente = "CAI";
			string claveusuarioGerente = "123";

			Console.Clear();
			nombre = Validador.ValidarStringNoVacioSistema("\n Ingrese el usuario del Supervisor de Operaciones");

			if (nombre != nombreUsuarioGerente)
			{
				Console.Clear();
				Console.WriteLine("\n Usuario Incorrecto");
				Validador.VolverMenu();
			}
			else
			{
				Console.Clear();
				clave = Validador.ValidarStringNoVacioSistema("\n Ingrese la clave del Supervisor de Operaciones");
				if (nombre != nombreUsuarioGerente || clave != claveusuarioGerente)
				{
					Console.Clear();
					Console.WriteLine("\n Usuario Incorrecto");
					Validador.VolverMenu();
				}
				else
				{
					MenuSupervisor();
				}
			}

		}

		
		public void MenuSupervisor()
		{
			Console.Clear();
			int opcion;
			string nombre;
			string clave;
			int posUsuarioM;
			int posUsuarioC;

			/* Para crear los objetos (Los Usuarios que tendran acceso a las listas) */
			UsuarioMain uM;
			
			do
			{
				Console.Clear();
				Console.WriteLine("\n *** Bienvenido Usuario Supervisor *** \n");
				opcion = Validador.PedirIntMenu("\n Menú del Supervisor" +
									   "\n [1] Registrar Usuario(s) Main." +
									   "\n [2] Volver al menu Principal.", 1, 2);

				switch (opcion)
				{
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese el Nombre del Usuario Main a crear: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);

						/* Si esto se cumple puedo crear un Usuario Main */
						if (posUsuarioM == -1 && posUsuarioC == -1)
						{
							Console.Clear();
							clave = Validador.ValidarStringNoVacioSistema("\n\n Ingrese la Clave del Usuario Main a crear: ");
							/* Creo el nuevo usuario Main */
							uM = new UsuarioMain(nombre, clave, this._producto,this._clienteCorporativo);
							/* Lo agrego a la lista de Usuarios Main */
							_usuarioMain.Add(uM);
							Console.Clear();
							Console.WriteLine("\n Usuario Main *" + nombre + "* y clave *" + clave + "* se ha creado exitósamente" +
											  "\n\n Presione cualquier tecla para volver al Menú");
							Console.ReadKey();
						}
						else
						{
							Console.Clear();
							Console.WriteLine("\n El Usuario *" + nombre + "* ya Existe " +
												  "\n Vuelva a intentarlo con un nombre Diferente");
							Validador.VolverMenu();
						}
						break;
					
				}
			} while (opcion != 2);
		}

		public void MenuInicial()
		{
			Console.Clear();
			int opcion;
			string nombre, clave;
			int posUsuarioM;
			int posUsuarioC;
			

			do
			{
				Console.Clear();
				Console.WriteLine("\n *** Bienvenido *** \n");
				opcion = Validador.PedirIntMenu("\n Menú Inicial del Sistema" +
									   "\n [1] Ingresar como Usuario Main." +
									   "\n [2] Ingresar como Usuario Corporativo." +
									   "\n [3] Ingresar como Usuario Supervisor." +
									   "\n [4] Registrar usuario (UsuarioCorporativo)." +
									   "\n [5] Salir del Sistema.", 1, 5);
				switch (opcion)
				{
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese su Usuario Main: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						if (posUsuarioM != -1)
						{
							Console.Clear();
							Console.WriteLine(" El usuario *" + nombre + "* existe");
							clave = Validador.ValidarStringNoVacioSistema("\n Ingrese Clave: ");
							posUsuarioM = BuscarUsuarioMainClave(nombre, clave);
							if (posUsuarioM != -1)
							{
								
								_usuarioMain[posUsuarioM].MenuMain(this._producto,this._clienteCorporativo);
								this._producto = _usuarioMain[posUsuarioM].Producto;
								this._clienteCorporativo = _usuarioMain[posUsuarioM].ClienteCorporativo;
							}
							else
							{
								Console.WriteLine("\n El Usuario *" + nombre + "* Existe pero la clave es incorrecta" +
												  "\n Vuelva a intentarlo cuando recuerde la clave");
								Validador.VolverMenu();
							}
						}
						else
						{
							Console.Clear();
							Console.WriteLine("\n El Usuario *" + nombre + "* No existe");
							Console.WriteLine("\n Cuando vuelva al Menú Inicial elija la opción 3 y regístrese si lo desea");
							Validador.VolverMenu();

						}
						break;
					case 2:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese Usuario Corporativo: ");
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);
						if (posUsuarioC != -1)
						{
							Console.Clear();
							Console.WriteLine(" El usuario *" + nombre + "* existe");
							clave = Validador.ValidarStringNoVacioSistema("\n Ingrese Clave: ");
							posUsuarioC = BuscarUsuarioCorporativoClave(nombre, clave);
							if (posUsuarioC != -1)
							{
								_usuarioCorporativo[posUsuarioC].MenuCorporativo(this._producto,
														  		 this._pedido, this._factura,
																 this._clienteCorporativo,this._reclamo,
																 this._item); 
								this._producto = _usuarioCorporativo[posUsuarioC].Producto;
								this._pedido = _usuarioCorporativo[posUsuarioC].Pedido;
								this._factura = _usuarioCorporativo[posUsuarioC].Factura;
								this._clienteCorporativo = _usuarioCorporativo[posUsuarioC].ClienteCorporativo;
								this._reclamo = _usuarioCorporativo[posUsuarioC].Reclamo;
								this._item = _usuarioCorporativo[posUsuarioC].Item;
	
							}
							else
							{
								Console.Clear();
								Console.WriteLine("\n El Usuario *" + nombre + "* Existe pero la clave es incorrecta" +
												  "\n Vuelva a intentarlo cuando recuerde la clave");
								Validador.VolverMenu();
							}
						}
						else
						{
							Console.Clear();
							Console.WriteLine("\n El Usuario *" + nombre + "* No existe");
							Console.WriteLine("\n Cuando vuelva al Menú Principal elija la opción 3 y regístrese si desea");
							Validador.VolverMenu();

						}
						break;
					case 3:
						ValidacionSupervisor();
						break;
					case 4:
						MenuRegistroUsuario();
						break;

				}
			} while (opcion != 5);

			Validador.Despedida();
		}

		public void MenuRegistroUsuario()
		{
			Console.Clear();
			int opcion;
			string nombre;
			string clave;
			int posUsuarioM ;
			int posUsuarioC;
			
			/* Para crear los objetos (Los Usuarios que tendran acceso a las listas) */
			
			UsuarioCorporativo uC;

			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú de Registro de nuevos Usuarios" +
									   "\n [1] Registrar Usuario Corporativo." +
									   "\n [2] Volver al Menú Principal.", 1, 2);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese el Nombre del Usuario Corporativo a crear: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);

						/* Si esto se cumple puedo crear un Usuario Corporativo */
						if (posUsuarioM == -1 && posUsuarioC == -1)
						{
							Console.Clear();
							clave = Validador.ValidarStringNoVacioSistema("\n\n Ingrese la Clave del Usuario Corporativo a crear: ");
							/* Creo el nuevo usuario Corporativo */
							uC = new UsuarioCorporativo(nombre, clave, this._producto, this._pedido, this._factura,
														this._clienteCorporativo,this._reclamo,this._item);
							/* Lo agrego a la lista de Usuarios Corporativos */
							_usuarioCorporativo.Add(uC);
							Console.Clear();
							Console.WriteLine("\n Usuario Corporativo *" + nombre + "* y clave *" + clave + "* se ha creado exitósamente" +
											  "\n\n Presione cualquier tecla para volver al Menú");
							Console.ReadKey();
						}
						else
						{
							Console.Clear();
							Console.WriteLine("\n El Usuario *" + nombre + "* ya Existe " +
												  "\n Vuelva a intentarlo con un nombre Diferente");
							Validador.VolverMenu();
						}
						break;
					
				}

			} while (opcion != 2);

		}

		public void Iniciar()
		{
			MenuInicial();
		}

	}
}
