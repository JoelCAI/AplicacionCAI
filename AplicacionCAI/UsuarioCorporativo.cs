using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
	internal class UsuarioCorporativo : UsuarioMain
	{

		private List<Pedido> _pedido;
		private List<Factura> _factura;
		private List<Reclamo> _reclamo;
		private List<Item> _item;

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
		public UsuarioCorporativo(string nombre, string clave, List<Producto> producto,
								  List<Pedido> pedido, List<Factura> factura, List<ClienteCorporativo>
								  clienteCorporativo, List<Reclamo> reclamo, List<Item> item
								  ) : base(nombre, clave, producto,
								  clienteCorporativo)
		{
			this._pedido = pedido;
			this._factura = factura;
			this._reclamo = reclamo;
			this._item = item;
		}


		public void MenuCorporativo(List<Producto> producto, List<Pedido> pedido, List<Factura> factura,
									List<ClienteCorporativo> clienteCorporativo, List<Reclamo> reclamo,
									List<Item> item)
		{
			/* Se reciben los productos de la Clase Producto a través de la herencia de UsuarioMain */
			Producto = producto;
			Pedido = pedido;
			Factura = factura;
			ClienteCorporativo = clienteCorporativo;
			Reclamo = reclamo;
			Item = item;

			long cuitClienteIngresado;
	
			string claveClienteCorporativo;

			Console.Clear();
			Console.WriteLine(" \n Bienvenido Usuario: " + NombreUsuario);

			int codigoCuitPrimero;
			int codigoCuitSegundo;
			int codigoCuitTercero;
			string cuitString;

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

			if (BuscarClienteCorporativo(cuit) != -1)
			{
				Console.Clear();
				Console.WriteLine("\n Cliente con CUIT: " +
									ClienteCorporativo[BuscarClienteCorporativo(cuit)].Cuit +
								  "\n Razón Social del Cliente: " +
								  ClienteCorporativo[BuscarClienteCorporativo(cuit)].RazonSocial); ;

				claveClienteCorporativo = Validador.ValidarStringNoVacioSistema("\n Ingrese la Clave de la razón Social");

				if (BuscarClienteCorporativoClave(claveClienteCorporativo) != -1)
                {
					cuitClienteIngresado = ClienteCorporativo[BuscarClienteCorporativo(cuit)].Cuit;
					
					int opcion;
					do
					{
						Console.Clear();
						Console.WriteLine(" \n Bienvenido Usuario: " + NombreUsuario);
						opcion = Validador.PedirIntMenu("\n Menu del Usuario Corporativo" +
											   "\n [1] Crear Pedido. " +
											   "\n [2] Grabar Pedido. " +
											   "\n [3] Leer Pedido. " +
											   "\n [4] Emitir Factura. " +
											   "\n [5] Generar Reclamo. " +
											   "\n [6] Volver al Menú Inicial.", 1, 6);

						switch (opcion)
						{
							case 1:
								CrearPedido(cuitClienteIngresado);
								break;
							case 2:
								GrabarPedido();
								break;
							case 3:
								LeerPedido();
								break;
							case 4:

								break;
							case 5:
								break;

						}
					} while (opcion != 6);


				}
				else
                {
					Console.Clear();
					Console.WriteLine("\n Usted digitó la clave *" + claveClienteCorporativo + "*");
					Console.WriteLine("\n No existe una Razón Social con esa clave");
					Console.WriteLine("\n Vuelvalo a intentar con la clave correcta o " +
								      "\n Contacte al Supervisor para que pueda brindarsela si está como Empleado activo en su Organización");
					Validador.VolverMenu();
				}



			}
			else
            {
				Console.Clear();
				Console.WriteLine("\n Usted digitó el CUIT *" + cuit + "*");
				Console.WriteLine("\n No existe una Razón Social con ese número de CUIT");
				Console.WriteLine(" Vuelvalo a intentar con uno existente o");
				Console.WriteLine("\n Contacte al Supervisor para que pueda dar de Alta el CUIT y Razón Social");
				Validador.VolverMenu();
			}

			

		}

		public int BuscarItemAntes(int pedido)
		{
			for (int i = 0; i < this._item.Count; i++)
			{
				if (this._item[i].RegistroItem == pedido)
				{
					return i + 1;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public int BuscarPedidoUltimo(int pedidoUltimo)
		{
			for (int i = 0; i < this._pedido.Count; i++)
			{
				if (this._pedido[i].IdPedido == pedidoUltimo)
				{
					return i;
				}
			}
			/* si no encuentro el producto retorno una posición invalida */
			return -1;
		}

		public void AddPedido(Pedido pedido)
		{
			this._pedido.Add(pedido);
		}

		Dictionary<int, Pedido> pedidoLista = new Dictionary<int, Pedido>();

		public void VerPedidoDiccionario()
		{
			Console.Clear();
			Console.WriteLine("\n Pedidos en el Diccionario");
			for (int i = 0; i < pedidoLista.Count; i++)
			{
				KeyValuePair<int, Pedido> pedido = pedidoLista.ElementAt(i);

				Console.WriteLine("\n Código Pedido: " + pedido.Key);
				Pedido pedidoValor = pedido.Value;

				Console.WriteLine("\n Cuit del Cliente del Pedido: " + pedidoValor.CuitClienteCorporativo);
				Console.WriteLine(" Razón Social del Cliente del Pedido: " + pedidoValor.RazonSocialClienteCorporativo);

				Console.WriteLine("\n Productos : ");
				Console.WriteLine(" Código del Producto del Pedido: " + pedidoValor.Item[i].CodigoItem);
				Console.WriteLine(" Nombre del Producto del Pedido: " + pedidoValor.Item[i].NombreItem);
				Console.WriteLine(" Cantidad del Producto del Pedido: " + pedidoValor.Item[i].CantidadItem);
				Console.WriteLine(" Precio Unitario del Pedido: " + pedidoValor.Item[i].PrecioItem);

				Console.WriteLine("\n Subtotal del Pedido sin IVA: " + pedidoValor.SubTotal);
				Console.WriteLine(" Recargo del Pedido: " + pedidoValor.Recargo);
				Console.WriteLine(" Total del Pedido sin IVA: " + pedidoValor.TotalSinIva);

			}


		}

		protected void GrabarPedido()
		{
			using (var archivoPedido = new FileStream("pedidoLista.txt", FileMode.Create))
			{
				using (var archivoEscrituraPedido = new StreamWriter(archivoPedido))
				{
					foreach (var pedido in pedidoLista.Values)
					{

						var linea =
									"\n Id del Pedido: " + pedido.IdPedido +
									"\n Cuit del Cliente del Pedido: " + pedido.CuitClienteCorporativo +
									"\n Razón Social del Cliente del Pedido: " + pedido.RazonSocialClienteCorporativo +
									"\n Productos del Pedido: " + pedido.Item +
									"\n Subtotal del Pedido sin IVA: " + pedido.SubTotal +
									"\n Recargo del Pedido: " + pedido.Recargo +
									"\n Total del Pedido sin IVA: " + pedido.TotalSinIva;

						archivoEscrituraPedido.WriteLine(linea);

					}

				}
			}
			VerProducto();
			Console.WriteLine("Se ha grabado los datos del Pedido correctamente");
			Validador.VolverMenu();

		}

		protected void LeerPedido()
		{
			Console.Clear();
			Console.WriteLine("\n Pedido(s): ");
			using (var archivoPedido = new FileStream("pedidoLista.txt", FileMode.Open))
			{
				using (var archivoLecturaPedido = new StreamReader(archivoPedido))
				{
					foreach (var pedido in pedidoLista.Values)
					{

						Console.WriteLine(archivoLecturaPedido.ReadToEnd());

					}

				}
			}
			Validador.VolverMenu();

		}

		public void CrearPedido(long cuitIngresado)
		{
			string razonSocialCliente;

			string codigoProducto;
			

			string tipodeRecargo;

			decimal peso;
			string distancia;

			string codigoItem;
			string nombreItem;
			int cantidadItem;
			decimal precioItem;
			
			long cuitItem;

			string opcion;
			string opcionDos;
			string opcionTres;

			Console.Clear();
			Console.WriteLine("\n Registrar Pedido:");
			Console.WriteLine("\n Nombre del Usuario Autorizado: " + NombreUsuario);

			razonSocialCliente = ClienteCorporativo[BuscarClienteCorporativo(cuitIngresado)].RazonSocial;
						
			opcion = ValidarSioNoContinuarCliente("\n Desea Continuar? ", cuitIngresado, razonSocialCliente);

			if (opcion == "SI")
			{
				Pedido pedido = new Pedido(cuitIngresado, razonSocialCliente);
				
				do
				{
					
					peso = Validador.PedirDecimal("\n Ingrese el peso del Producto",0,30);

					distancia = Validador.ValidarDistanciaProducto("\n Ingrese la distancia a Recorrer");

					codigoProducto = Validador.ExtraerCodigoProducto(peso, distancia);

					if (BuscarProductoCodigo(codigoProducto) != -1)
					{
						
						cantidadItem = Validador.PedirIntMayor("\n Ingrese Cantidad de este Producto", 0);

						int codigoPedido = Pedido[_pedido.Count-1].IdPedido;


						codigoItem = Producto[BuscarProductoCodigo(codigoProducto)].CodigoProducto;
						nombreItem = Producto[BuscarProductoCodigo(codigoProducto)].NombreProducto;
						precioItem = Producto[BuscarProductoCodigo(codigoProducto)].PrecioProducto;
						cuitItem = ClienteCorporativo[BuscarClienteCorporativo(cuitIngresado)].Cuit;
						

						Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto =
						Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto - cantidadItem;
						Item item = new Item(codigoItem, nombreItem, cantidadItem, precioItem,
											 peso,distancia,cuitItem);
						pedido.AddItem(item);
						VerItemPedido(codigoPedido);
					}
						
					opcionDos = Validador.ValidarSioNo("\n Desea Continuar cargando productos?");
					

				} while (opcionDos == "SI");

				opcionTres = Validador.ValidarSioNo("\n Desea suspender todo o continuar con el pedido?");

				if (opcionTres == "NO")
				{
					tipodeRecargo = Validador.ValidarTipoRecargo("Ingrese el tipo de Recargo");
					pedido.CalcularRecargo(tipodeRecargo);
					pedido.CalcularTotalSinIVA();
					AddPedido(pedido);

					pedidoLista.Add(pedido.IdPedido, pedido);
					VerPedidoDiccionario();
					Console.WriteLine("\n Pedido registrado exitósamente");

					Validador.VolverMenu();

				}
				else
				{

					Console.WriteLine("No se generó ningún pedido");
					Validador.VolverMenu();
				}

			}
			else
			{
				Console.WriteLine("\n Eligió no generar ningún Pedido.");
				Validador.VolverMenu();

			}

			
			
		}


		public void VerPedidoCuenta()
		{

			Console.Clear();
			Console.WriteLine("Pedidos del día");
			Console.WriteLine("#\tSubTototal.\tRecargo.\tTotal");
			for (int i = 0; i < Pedido.Count; i++)
			{
				Console.Write(i + 1);
				Console.Write("\t");
				Console.Write(Pedido[i].SubTotal);
				Console.Write("\t");
				Console.Write(Pedido[i].Recargo);
				Console.Write("\t");
				Console.Write(Pedido[i].TotalSinIva);
				Console.Write("\n");
			}

			decimal totalCobradoSinIVA = 0;
			int cantidadProductos = 0;
			int cantidadRecargos = 0;
			decimal totalRecargos = 0;

			/* Los Pedidos realizados estan en la lista de Pedidos así que recorremos esa lista */
			foreach (Pedido pedido in Pedido)
			{
				totalCobradoSinIVA = totalCobradoSinIVA + pedido.TotalSinIva;
			}

			/* cantidad de Pedidos emitidos */
			foreach (Pedido pedido in Pedido)
			{
				foreach (Item item in pedido.Item)
				{
					cantidadProductos = cantidadProductos + item.CantidadItem;
				}

			}
			/* Cantidad de Recargos aplicados */
			foreach (Pedido pedido in Pedido)
			{
				if (pedido.Recargo > 0)
				{
					cantidadRecargos = cantidadRecargos + 1;
				}
			}
			/* Total de Recargos aplicados */
			foreach (Pedido pedido in Pedido)
			{
				if (pedido.Recargo > 0)
				{
					totalRecargos = totalRecargos + pedido.Recargo;
				}
			}
			Console.WriteLine("Total cobrado sin IVA: " + totalCobradoSinIVA.ToString());
			Console.WriteLine("Cantidad de productos vendidos: " + cantidadProductos.ToString());
			Console.WriteLine("Cantidad de Recargos aplicados: " + cantidadRecargos.ToString());
			Console.WriteLine("Total de Recargos aplicados: " + totalRecargos.ToString());

			Console.ReadLine();
		}

		protected string ValidarSioNoContinuarCliente(string mensaje, long cuit, string razonSocial)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{

				Console.WriteLine(
								  "\n Cuit del Cliente Corporativo: " +	cuit +
								  "\n Razón social del Cliente Corporativo: " + razonSocial);

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

		protected void VerItemPedido(int ultimo)
		{
			Console.Clear();
			Console.WriteLine("\n Productos en el Pedido");
			Console.WriteLine(" #\t\tCódigo.\t\tPeso.\t\tDistancia.\t\tPrecio.\t\tCantidad.");
			for (int i = 0; i < Item.Count; i++)
			{
				Console.Write(" " + (i + 1));

				Console.Write("\t\t");
				Console.Write(Item[(BuscarItemAntes(ultimo))].CodigoItem);
				Console.Write("\t\t");
				Console.Write(Item[(BuscarItemAntes(ultimo))].PesoItem);
				Console.Write("\t\t");
				Console.Write(Item[(BuscarItemAntes(ultimo))].DistanciaItem);
				Console.Write("\t\t");
				Console.Write(Item[(BuscarItemAntes(ultimo))].PrecioItem);
				Console.Write("\t\t");
				Console.Write(Item[(BuscarItemAntes(ultimo))].CantidadItem);
				Console.Write("\t\t");

				Console.Write("\n");
			}

		}

		public void CrearPedidoSioNo()
		{
			/* Ingresar datos de la cuenta */
		}

		public void EmitirFactura()
		{
			/* Ingresar datos de la cuenta */
		}

		public void GenerarReclamo()
		{
			/* Ingresar datos de la cuenta */
		}

		public void MostrarUsuarioCorporativo()
		{
			/* Ingresar datos de la cuenta */
		}

		public void MostrarFacturaEmitidaCorporativo()
		{
			/* Historial de Facturas */
		}

		public void MostrarListaPedido()
		{

		}

		public void MostrarHistorialEnvioCorporativo()
		{

		}

		public void GrabarFactura()
		{

		}

		public void ImprimirFactura()
		{

		}

		

		public void ImprimirPedido()
		{

		}

	}
}
