using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class SistemaPrincipal 
    {
		private List<Usuario> _usuario;

		private List<Producto> _producto;
        private List<Pedido> _pedido;
        private List<Factura> _factura;
		
		private List<Reclamo> _reclamo;
		private List<Item> _item;

		public SistemaPrincipal()
        {
			this._usuario = new List<Usuario>();

			this._producto = new List<Producto>();
			this._pedido = new List<Pedido>();
			this._factura = new List<Factura>();
			
			this._reclamo = new List<Reclamo>();
			this._item = new List<Item>();

		}
		

		public int BuscarUsuarioNombre(string nombre)
		{
			for (int i = 0; i < this._usuario.Count; i++)
			{
				if (this._usuario[i].NombreUsuario == nombre)
				{
					return i;
				}
			}
			return -1;
		}


		public int BuscarUsuarioClave(string nombre, string clave)
		{
			for (int i = 0; i < this._usuario.Count; i++)
			{
				if (this._usuario[i].NombreUsuario == nombre)
				{
					if (this._usuario[i].ClaveUsuario == clave)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public int BuscarUsuarioCuit(string nombre, string clave)
		{
			for (int i = 0; i < this._usuario.Count; i++)
			{
				if (this._usuario[i].NombreUsuario == nombre)
				{
					if (this._usuario[i].ClaveUsuario == clave)
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
			int posUsuario;
			

			do
			{
				Console.Clear();
				Console.WriteLine("\n *** Bienvenido al Sistema de Clientes Corporativos *** \n");
				opcion = Validador.PedirIntMenu("\n Menú Inicial del Sistema" +
									   "\n [1] Ingresar como Usuario Corporativo." +
									   "\n [2] Salir del Sistema.", 1, 2);
				switch (opcion)
				{
				
					case 1:
						Console.Clear();
						nombre = Validador.ValidarStringNoVacioSistema("\n\n Ingrese Usuario Corporativo: ");
						posUsuario = BuscarUsuarioNombre(nombre);
						if (posUsuario != -1)
						{
							Console.Clear();
							Console.WriteLine(" El usuario *" + nombre + "* existe");
							clave = Validador.ValidarStringNoVacioSistema("\n Ingrese Clave: ");
							posUsuario = BuscarUsuarioClave(nombre, clave);
							if (posUsuario != -1)
							{
								_usuario[posUsuario].MenuUsuario(this._producto,
														  		 this._pedido, this._factura,
																 this._reclamo,
																 this._item); 
								this._producto = _usuario[posUsuario].Producto;
								this._pedido = _usuario[posUsuario].Pedido;
								this._factura = _usuario[posUsuario].Factura;
								
								this._reclamo = _usuario[posUsuario].Reclamo;
								this._item = _usuario[posUsuario].Item;
	
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
					

				}
			} while (opcion != 2);

			Validador.Despedida();
		}



		public void Iniciar()
		{
			MenuInicial();
		}



	}
}
