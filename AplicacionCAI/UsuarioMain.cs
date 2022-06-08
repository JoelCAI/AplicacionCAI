using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
    internal class UsuarioMain : Usuario
    {
        public UsuarioMain(string nombre, string clave, List<Producto> producto,
							List<ClienteCorporativo> clienteCorporativo) : base(nombre, clave)
        {
            this._producto = producto;
			this._clienteCorporativo = clienteCorporativo;
        }

        protected List<Producto> _producto;
		protected List<ClienteCorporativo> _clienteCorporativo;

        public List<Producto> Producto
        {
            get { return this._producto; }
            set { this._producto = value; }
        }

		public List<ClienteCorporativo> ClienteCorporativo
		{
			get { return this._clienteCorporativo; }
			set { this._clienteCorporativo = value; }
		}

		public void MenuMain(List<Producto> producto,List<ClienteCorporativo> clienteCorporativo)
		{
			Producto = producto;
			ClienteCorporativo = clienteCorporativo;
			int opcion;
			do
			{

				Console.Clear();
				Console.WriteLine("\n Hola Usuario *" + NombreUsuario +"*" );
				opcion = Validador.PedirIntMenu("\n Menu del Sistema" +
									   "\n [1] Crear Producto." +
									   "\n [2] Eliminar Producto." +
									   "\n [3] Grabar Producto(s)." +
									   "\n [4] Leer Producto(s)." +
									   "\n [5] Crear Cliente Corporativo." +
									   "\n [6] Grabar Clientes Corporativo(s)." +
									   "\n [7] Leer Clientes Corporativo(s)." +
									   "\n [8] Volver al menu Principal.", 1, 8);

				switch (opcion)
				{
					case 1:
						CrearProducto();
						break;
					case 2:
						EliminarProducto();
						break;
					case 3:
						GrabarProducto();
						break;
					case 4:
						LeerProducto();
						break;
					case 5:
						CrearClienteCorporativo();
						break;
					case 6:
						GrabarClienteCorporativo();
						break;
					case 7:
						LeerClienteCorporativo();
						break;
					
				}
			} while (opcion != 8);
		}

		public int BuscarProductoCodigo(string codigo)
		{
			for (int i = 0; i < this._producto.Count; i++)
			{
				if (this._producto[i].CodigoProducto == codigo)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

	

		public int BuscarClienteCorporativo(long cuit)
		{
			for (int i = 0; i < this._clienteCorporativo.Count; i++)
			{
				if (this._clienteCorporativo[i].Cuit == cuit)
				{
					return i;
				}
			}
			
			return -1;
		}

		public int BuscarClienteCorporativoClave(string clave)
		{
			for (int i = 0; i < this._clienteCorporativo.Count; i++)
			{
				if (this._clienteCorporativo[i].Clave == clave)
				{
					return i;
				}
			}

			return -1;
		}

		Dictionary<string, Producto> productoLista = new Dictionary<string, Producto>();
		
		protected void VerProductoDiccionario()
		{
			Console.WriteLine("\n Productos en el Diccionario");
			for (int i = 0; i < productoLista.Count; i++)
			{
				KeyValuePair<string, Producto> producto = productoLista.ElementAt(i);

				Console.WriteLine("\n Código: " + producto.Key);
				Producto productoValor = producto.Value;

				Console.WriteLine(" Nombre del Producto: " + productoValor.NombreProducto);
				Console.WriteLine(" Cantidad del Producto: " + productoValor.CantidadProducto);
				Console.WriteLine(" Peso del Producto: " + productoValor.PesoProducto);
				Console.WriteLine(" Precio del Producto: " + productoValor.PrecioProducto);
				Console.WriteLine(" Distancia del Producto: " + productoValor.DistanciaProducto);

			}


		}

		protected void GrabarProducto()
		{
			using (var archivoProducto = new FileStream("productoLista.txt", FileMode.Create))
			{
				using (var archivoEscrituraProducto = new StreamWriter(archivoProducto))
				{
					foreach (var producto in productoLista.Values)
					{

						var linea =
									"\n Código del Producto: " + producto.CodigoProducto +
									"\n Nombre del Producto: " + producto.NombreProducto +
									"\n Cantidad del Producto: " + producto.CantidadProducto +
									"\n Peso del Producto: " + producto.PesoProducto +
									"\n Precio del Producto: " + producto.PrecioProducto +
									"\n Distancia del Producto: " + producto.DistanciaProducto;

						archivoEscrituraProducto.WriteLine(linea);

					}

				}
			}
			VerProducto();
			Console.WriteLine("Se ha grabado los datos de los Productos correctamente");
			Validador.VolverMenu();

		}

		protected void LeerProducto()
		{
			Console.Clear();
			Console.WriteLine("\n Productos: ");
			using (var archivoProducto = new FileStream("productoLista.txt", FileMode.Open))
			{
				using (var archivoLecturaProducto = new StreamReader(archivoProducto))
				{
					foreach (var producto in productoLista.Values)
					{

						Console.WriteLine(archivoLecturaProducto.ReadToEnd());

					}

				}
			}
			Validador.VolverMenu();

		}


		Dictionary<long, ClienteCorporativo> clienteCorporativoLista = new Dictionary<long, ClienteCorporativo>();

		protected void VerClienteCorporativoDiccionario()
		{
			Console.WriteLine("\n Productos en el Diccionario");
			for (int i = 0; i < clienteCorporativoLista.Count; i++)
			{
				KeyValuePair<long, ClienteCorporativo> persona = clienteCorporativoLista.ElementAt(i);

				Console.WriteLine("\n CUIT Cliente Corporativo: " + persona.Key);
				ClienteCorporativo personaValor = persona.Value;

				Console.WriteLine(" Razón Social Cliente Corporativo: " + personaValor.RazonSocial);

			}

		}

		protected void GrabarClienteCorporativo()
		{
			using (var archivoClienteCorporativo = new FileStream("clienteCorporativoLista.txt", FileMode.Create))
			{
				using (var archivoEscrituraClienteCorporativo = new StreamWriter(archivoClienteCorporativo))
				{
					foreach (var cliente in clienteCorporativoLista.Values)
					{

						var linea =
									"\n Cuit del Cliente Corporativo: " + cliente.Cuit +
									"\n Razón Social del Cliente Corporativo: " + cliente.RazonSocial;

						archivoEscrituraClienteCorporativo.WriteLine(linea);

					}

				}
			}
			VerProducto();
			Console.WriteLine("Se ha grabado los datos de los Clientes Corporativos correctamente");
			Validador.VolverMenu();

		}

		protected void LeerClienteCorporativo()
		{
			Console.Clear();
			Console.WriteLine("\n Cliente(s) Corporativo(s): ");
			using (var archivoClienteCorporativo = new FileStream("clienteCorporativoLista.txt", FileMode.Open))
			{
				using (var archivoLecturaClienteCorporativo = new StreamReader(archivoClienteCorporativo))
				{
					foreach (var cliente in clienteCorporativoLista.Values)
					{

						Console.WriteLine(archivoLecturaClienteCorporativo.ReadToEnd());

					}

				}
			}
			Validador.VolverMenu();

		}

		public void AddProducto(Producto producto)
		{
			this._producto.Add(producto);
		}

		public void AddClienteCorporativo(ClienteCorporativo clienteCorporativo)
		{
			this._clienteCorporativo.Add(clienteCorporativo);
		}

		public void RemoverProducto(int pos)
		{
			this._producto.RemoveAt(pos);
		}

		protected override void CrearProducto()
        {
			string codigo;
			string nombre;

			decimal precioProducto;

			string peso;
			bool pesoProducto;
			decimal pesoConvertido;

			string distanciaProducto;

			string opcion;

			Console.Clear();
			codigo = Validador.PedirCaracterString(" Ingrese el Código " +
											  "\n El Código debe estar entre este rango de caracteres.", 6, 6);
			if (BuscarProductoCodigo(codigo) == -1)
			{
				VerProducto();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Nombre para crear un Producto Nuevo");
				nombre = Validador.PedirCaracterString("\n Ingrese el nombre del Producto", 1, 15);
				
				Console.Clear();
				peso = Validador.ValidarPesoProducto("\n Ingrese el peso del Producto");
				pesoProducto = decimal.TryParse(peso, out pesoConvertido);
				Console.Clear();
				distanciaProducto = Validador.ValidarDistanciaProducto("\n Ingrese la distancia.");

				precioProducto = Validador.CalcularPrecio(pesoConvertido,distanciaProducto);

				opcion = ValidarSioNoProductoNoCreado("\n Está seguro que desea crear este producto? ", 
													 codigo, nombre,pesoConvertido,distanciaProducto,
													 precioProducto);

				if (opcion == "SI")
				{
					Producto p = new Producto(codigo, nombre, pesoConvertido, precioProducto,
											  distanciaProducto);
	
					AddProducto(p);
					productoLista.Add(codigo, p);
					VerProducto();
					VerProductoDiccionario();
					Console.WriteLine("\n Producto con nombre *" + nombre + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerProducto();
					Console.WriteLine("\n Como puede verificar no se creo ninguna Persona");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerProducto();
				Console.WriteLine("\n Usted digitó el Documento *" + codigo + "*");
				Console.WriteLine("\n Ya existe una persona con ese Documento");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
				Validador.VolverMenu();

			}

		}

		protected void EditarProducto()
        {

        }

		protected void EliminarProducto()
        {
			string codigo;
			string nombre;
			string confirmacion;

			VerProducto();
			codigo = ValidarStringNoVacioProducto("\n Ingrese el código del producto a eliminar");

			/* Mientras el producto no exista seguire en esto */
			if (BuscarProductoCodigo(codigo) != -1)
			{
				nombre = Producto[BuscarProductoCodigo(codigo)].NombreProducto;

				VerProducto();
				Console.WriteLine("\n Código de Producto a Eliminar: " + Producto[BuscarProductoCodigo(codigo)].CodigoProducto +
								  "\n Nombre de Producto a Eliminar: " + Producto[BuscarProductoCodigo(codigo)].NombreProducto);
				confirmacion = Validador.ValidarSioNoProducto("\n\n Está seguro que desea eliminar este Producto?", codigo,nombre);

				if (confirmacion == "SI")
				{
					RemoverProducto(BuscarProductoCodigo(codigo));
					VerProducto();
					Console.WriteLine("\n Producto eliminado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerProducto();
					Console.WriteLine("\n Como puede apreciar el Producto no ha sido eliminado");
					Validador.VolverMenu();
				}

			}
			else
			{
				Console.Clear();
				VerProducto();
				Console.WriteLine("\n No existe un producto con el código *" + codigo + "*. " +
								  "\n\n Vuelva a intentarlo ingresando el valor de uno de los codigos que ve en la lista " +
								  "la siguiente vez");
				Validador.VolverMenu();
			}
		}

		private void CrearClienteCorporativo()
		{

			string razonSocial;
			string cuitString;
			string claveClienteCorporativo;

			int codigoCuitPrimero;
			int codigoCuitSegundo;
			int codigoCuitTercero;

			VerClienteCorporativo();
			codigoCuitPrimero = Validador.PedirIntMenu("\n Ingrese los dos primeros dígitos del CUIT", 10, 99);
			Console.Clear();
			codigoCuitSegundo = Validador.PedirIntMenu("\n Ingrese los 8 digitos del Cuit" +
													   "\n " + codigoCuitPrimero + "-", 10000000, 99999999);
			Console.Clear();
			codigoCuitTercero = Validador.PedirIntMenu("\n Ingrese el último digito: " +
													   "\n " + codigoCuitPrimero + "-" +
													   codigoCuitSegundo + "-", 0, 9);

			cuitString = codigoCuitPrimero.ToString() + codigoCuitSegundo.ToString() +
						codigoCuitTercero.ToString();
			bool cuitConvertido = long.TryParse(cuitString, out long cuit);

			string opcion;

			Console.Clear();

			if (BuscarClienteCorporativo(cuit) == -1)
			{
				VerClienteCorporativo();
				Console.WriteLine("\n ¡En hora buena! Puede utilizar este Nombre para crear un Producto Nuevo");
				razonSocial = Validador.PedirCaracterString("\n Ingrese el nombre de la Razón Social", 1, 30);
				Console.Clear();

				claveClienteCorporativo = Validador.ValidarStringNoVacioSistema("Ingrese la clave de la Razón Social");

				opcion = ValidarSioNoClienteNoCreado("\n Está seguro que desea crear este Cliente Corporativo? ",
													codigoCuitPrimero, codigoCuitSegundo, codigoCuitTercero,
													razonSocial);

				if (opcion == "SI")
				{
					ClienteCorporativo p = new ClienteCorporativo(cuit, razonSocial,claveClienteCorporativo);
					AddClienteCorporativo(p);
					clienteCorporativoLista.Add(cuit, p);
					VerClienteCorporativo();
					VerClienteCorporativoDiccionario();
					Console.WriteLine("\n Cliente Corporativo con Razón Social *" + razonSocial + "* agregado exitósamente");
					Validador.VolverMenu();
				}
				else
				{
					VerClienteCorporativo();
					Console.WriteLine("\n Como puede verificar no se creo ningún Cliente Corporativo");
					Validador.VolverMenu();

				}

			}
			else
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Usted digitó un CUIT *" + cuit + "*");
				Console.WriteLine("\n Ya existe una Razón Social con ese número de CUIT");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
				Validador.VolverMenu();

			}

		}


		protected string ValidarStringNoVacioProducto(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerProducto();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoProductoNoCreado(string mensaje, string codigo, string nombre,
													  decimal pesoConvertido, string distanciaProducto,
													  decimal precioProducto)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerProducto();

				Console.WriteLine(
								  "\n Codigo del Producto a Crear: " + codigo +
								  "\n Nombre del Producto a Crear: " + nombre +
								  "\n Peso del Producto a Crear: " + pesoConvertido +
								  "\n Distancia del Producto a Crear: " + distanciaProducto +
								  "\n Precio del Producto a Crear: " + precioProducto);

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

		protected string ValidarSioNoClienteNoCreado(string mensaje, int uno, int dos, int tres,
													string razonSocial)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerClienteCorporativo();

				Console.WriteLine(
								  "\n Cuit del Cliente Corporativo a Crear: " +
									uno + "-" + dos + "-" + tres +
								  "\n Razón social del Cliente Corporativo a Crear: " + razonSocial);

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

		protected void VerProducto()
		{
			Console.Clear();
			Console.WriteLine("\n Productos");
			Console.WriteLine(" #\t\tCódigo.\t\tPeso.\t\tDistancia.\t\tPrecio.");
			for (int i = 0; i < Producto.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(Producto[i].CodigoProducto);
				Console.Write("\t\t");
				Console.Write(Producto[i].PesoProducto);
				Console.Write("\t\t");
				Console.Write(Producto[i].DistanciaProducto);
				Console.Write("\t\t");
				Console.Write(Producto[i].PrecioProducto);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		protected void VerClienteCorporativo()
		{
			Console.Clear();
			Console.WriteLine("\n Clientes Corporativos ");
			Console.WriteLine(" #\t\tCuit.\t\t\tRazón Social.");
			for (int i = 0; i < ClienteCorporativo.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(ClienteCorporativo[i].Cuit);
				Console.Write("\t\t\t");
				Console.Write(ClienteCorporativo[i].RazonSocial);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}



	}
}
