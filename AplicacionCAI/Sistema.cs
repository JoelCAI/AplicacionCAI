using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    public class Sistema
    {
        private List<UsuarioMain> _usuarioMain;
        private List<UsuarioCorporativo> _usuarioCorporativo;

        private List<Producto> _producto;
        private List<Pedido> _pedido;
        private List<Factura> _factura;

        public Sistema()
        {
            this._usuarioMain = new List<UsuarioMain>();
            this._usuarioCorporativo = new List<UsuarioCorporativo>();
            this._producto = new List<Producto>();
            this._pedido = new List<Pedido>();
            this._factura = new List<Factura>();
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

		public int BuscarUsuarioMain(string nombre, string clave)
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

		public int BuscarUsuarioCorporativo(string nombre, string clave)
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
				opcion = Validador.PedirIntMenu("\n Menú Inicial del Sistema" +
									   "\n [1] Ingresar como UsuarioMain." +
									   "\n [2] Ingresar como UsuarioCorporativo." +
									   "\n [3] Registrar usuario (UsuarioMain, UsuarioCorporativo)." +
									   "\n [4] Salir del Sistema.", 1, 4);
				switch (opcion)
				{
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese su Usuario Main: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						if (posUsuarioM != -1)
						{
							Console.WriteLine(" El usuario *" + nombre + "* existe");
							clave = Validador.ValidarStringNoVacioSistema("\n Ingrese Clave: ");
							posUsuarioM = BuscarUsuarioMain(nombre, clave);
							if (posUsuarioM != -1)
							{
								/* Pasar el vector de productos como parametro */
								_usuarioMain[posUsuarioM].MenuMain(this._producto);
								/* Sincroniza los datos entre los objetos */
								this._producto = _usuarioMain[posUsuarioM].Producto; 
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

							Console.WriteLine("\n El Usuario *" + nombre + "* No existe");
							Console.WriteLine("\n Cuando vuelva al Menú Inicial elija la opción 3 y regístrese si lo desea");
							Validador.VolverMenu();

						}
						break;
					case 2:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\nIngrese Usuario Corporativo: ");
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);
						if (posUsuarioC != -1)
						{
							Console.WriteLine(" El usuario *" + nombre + "* existe");
							clave = Validador.ValidarStringNoVacioSistema("\n Ingrese Clave: ");
							posUsuarioC = BuscarUsuarioCorporativo(nombre, clave);
							if (posUsuarioC != -1)
							{
								_usuarioCorporativo[posUsuarioC].MenuCorporativo(this._producto,
									                             this._pedido, this._factura); 
								this._producto = _usuarioCorporativo[posUsuarioC].Producto;
								this._pedido = _usuarioCorporativo[posUsuarioC].Pedido;
								this._factura = _usuarioCorporativo[posUsuarioC].Factura;
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

							Console.WriteLine("\n El Usuario *" + nombre + "* No existe");
							Console.WriteLine("\n Cuando vuelva al Menú Principal elija la opción 3 y regístrese si desea");
							Validador.VolverMenu();

						}
						break;
					case 3:
						MenuRegistroUsuario();
						break;

				}
			} while (opcion != 4);

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
			UsuarioMain uM;
			UsuarioCorporativo uC;
			

			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú de Registro de nuevos Usuarios" +
									   "\n [1] Registrar Usuario Main." +
									   "\n [2] Registrar Usuario Corporativo." +
									   "\n [3] Volver al Menú Principal.", 1, 3);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese el Nombre del Usuario Main a crear: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);
						
						/* Si esto se cumple puedo crear un Usuario Main */
						if (posUsuarioM == -1 && posUsuarioC == -1)
						{
							clave = Validador.ValidarStringNoVacioSistema("\n\n Ingrese la Clave del Usuario Main a crear: ");
							/* Creo el nuevo usuario Main */
							uM = new UsuarioMain(nombre, clave, this._producto);
							/* Lo agrego a la lista de Usuarios Main */
							_usuarioMain.Add(uM);
							Console.Clear();
							Console.WriteLine("\n Usuario Main *" + nombre + "* y clave *" + clave + "* se ha creado exitósamente" +
											  "\n\n Presione cualquier tecla para volver al Menú");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("\n El Usuario *" + nombre + "* ya Existe " +
												  "\n Vuelva a intentarlo con un nombre Diferente");
							Validador.VolverMenu();
						}
						break;
					case 2:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese el Nombre del Usuario Corporativo a crear: ");
						posUsuarioM = BuscarUsuarioMainNombre(nombre);
						posUsuarioC = BuscarUsuarioCorporativoNombre(nombre);
						
						/* Si esto se cumple puedo crear un Usuario Corporativo */
						if (posUsuarioM == -1 && posUsuarioC == -1)
						{
							clave = Validador.ValidarStringNoVacioSistema("\n\n Ingrese la Clave del Usuario Corporativo a crear: ");
							/* Creo el nuevo usuario Corporativo */
							uC = new UsuarioCorporativo(nombre, clave, this._producto, this._pedido, this._factura);
							/* Lo agrego a la lista de Usuarios Corporativos */
							_usuarioCorporativo.Add(uC);
							Console.Clear();
							Console.WriteLine("\n Usuario Corporativo *" + nombre + "* y clave *" + clave + "* se ha creado exitósamente" +
											  "\n\n Presione cualquier tecla para volver al Menú");
							Console.ReadKey();
						}
						else
						{
							Console.WriteLine("\n El Usuario *" + nombre + "* ya Existe " +
												  "\n Vuelva a intentarlo con un nombre Diferente");
							Validador.VolverMenu();
						}
						break;
					
				}

			} while (opcion != 3);

		}

		public void Iniciar()
		{
			MenuInicial();
		}

	}
}
