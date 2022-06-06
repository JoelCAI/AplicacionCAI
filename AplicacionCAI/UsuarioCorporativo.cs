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
		public UsuarioCorporativo(string nombre, string clave, List<Producto> producto,
								  List<Pedido> pedido, List<Factura> factura, List<ClienteCorporativo>
								  clienteCorporativo, List<Reclamo> reclamo) : base(nombre, clave, producto,
								  clienteCorporativo)
		{
			this._pedido = pedido;
			this._factura = factura;
			this._reclamo = reclamo;
		}


		public void MenuCorporativo(List<Producto> producto, List<Pedido> pedido, List<Factura> factura,
									List<ClienteCorporativo> clienteCorporativo, List<Reclamo> reclamo)
		{
			/* Se reciben los productos de la Clase Producto a través de la herencia de UsuarioMain */
			Producto = producto;
			Pedido = pedido;
			Factura = factura;
			ClienteCorporativo = clienteCorporativo;
			Reclamo = reclamo;

			int opcion;
			do
			{
				Console.Clear();
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
						CrearPedido();
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

		public void AddPedido(Pedido pedido)
		{
			this._pedido.Add(pedido);
		}

		Dictionary<int, Pedido> pedidoLista = new Dictionary<int, Pedido>();

		public void VerPedidoDiccionario()
		{
			Console.WriteLine("\n Pedidos en el Diccionario");
			for (int i = 0; i < pedidoLista.Count; i++)
			{
				KeyValuePair<int, Pedido> pedido = pedidoLista.ElementAt(i);

				Console.WriteLine("\n Código Pedido: " + pedido.Key);
				Pedido pedidoValor = pedido.Value;

				Console.WriteLine(" Cuit del Cliente del Pedido: " + pedidoValor.CuitClienteCorporativo);
				Console.WriteLine(" Razón Social del Cliente del Pedido: " + pedidoValor.RazonSocialClienteCorporativo);
				Console.WriteLine(" Productos del Pedido: " + pedidoValor.Item[i].CodigoProducto);
				Console.WriteLine(" Subtotal del Pedido sin IVA: " + pedidoValor.SubTotal);
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

		public void CrearPedido()
		{
			long cuitCliente;
			string razonSocial;

			string codigoProducto;
			string nombreProducto;

			string tipodeRecargo;

			decimal precioProducto;
			int cantidadProducto;


			string opcion;
			string opcionDos;
			string opcionTres;

			Console.Clear();
			Console.WriteLine("\n Registrar Pedido:");

			VerClienteCorporativo();
			cuitCliente = Validador.PedirLongMenu("Ingrese el CUIT del Cliente Corporativo", 10000000000,
												  99999999999);

			if (BuscarClienteCorporativo(cuitCliente) != -1)
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Pedido para Cliente con CUIT: " +
									ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].Cuit +
								  "\n Razón Social del Cliente: " +
								  ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].RazonSocial); ;

				razonSocial = ClienteCorporativo[BuscarClienteCorporativo(cuitCliente)].RazonSocial;

				Console.Clear();

				opcion = ValidarSioNoContinuarCliente("\n Desea Continuar? ", cuitCliente, razonSocial);

				if (opcion == "SI")
				{
					Pedido pedido = new Pedido(cuitCliente, razonSocial);
					do
					{
						VerProducto();
						codigoProducto = ValidarStringNoVacioProducto("Ingrese el código del producto a vender");
						if (BuscarProductoCodigo(codigoProducto) != -1)
						{

							VerProducto();
							precioProducto = Producto[BuscarProductoCodigo(codigoProducto)].PrecioProducto;
							nombreProducto = Producto[BuscarProductoCodigo(codigoProducto)].NombreProducto;

							do
							{
								Console.Clear();
								Console.WriteLine("\n Cantidad del Producto a vender *" +
													Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto + "*");
								Console.WriteLine("\n No se puede vender más de lo que existe en el Stock");
								cantidadProducto = Validador.PedirIntMayor("\n Ingrese la cantidad a comprar", 0);

							} while (cantidadProducto > Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto);


							Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto =
							Producto[BuscarProductoCodigo(codigoProducto)].CantidadProducto - cantidadProducto;
							Item item = new Item(codigoProducto, nombreProducto, cantidadProducto, precioProducto);
							pedido.AddItem(item);

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
						Console.WriteLine("Pedido registrado exitósamente");
						


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
			else
			{
				VerClienteCorporativo();
				Console.WriteLine("\n Usted digitó un CUIT *" + cuitCliente + "*");
				Console.WriteLine("\n No existe una Razón Social con ese número de CUIT");
				Console.WriteLine("\n Será direccionado nuevamente al Menú para que pueda Crearlo");
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
					cantidadProductos = cantidadProductos + item.CantidadProducto;
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
								  "\n Cuit del Cliente Corporativo: " +
									cuit +
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
