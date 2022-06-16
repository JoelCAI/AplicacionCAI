using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AplicacionCAI
{
	 class Pedido
	{
		private int idPedido;

		private string estadoPedido;
		private DateTime fechaPedido;

		private string paisOrigen;
		private string regionOrigen;
		private string provinciaOrigen;
		private string localidadOrigen;
		private string domicilioOrigen;

		private string paisDestino;
		private string regionDestino;
		private string provinciaDestino;
		private string localidadDestino;
		private string domicilioDestino;

		private decimal precioEncomienda;
		private decimal pesoEncomienda;
		//public decimal ValorDeclarado;

		private long cuitCorporativo;
		private string razonSocialCorporativo;

		private string urgente;
		private string retiroEnSucursal;
		private string retiroEnPuerta;

		private decimal calculoPedido;

		public int IdPedido
		{
			get { return this.idPedido; }
			set { this.idPedido = value; }
		}

		public string EstadoPedido
		{
			get { return this.estadoPedido; }
			set { this.estadoPedido = value; }
		}

		public DateTime FechaPedido
		{
			get { return this.fechaPedido; }
			set { this.fechaPedido = value; }
		}

		public string PaisOrigen
		{
			get { return this.paisOrigen; }
			set { this.paisOrigen = value; }
		}

		public string RegionOrigen
		{
			get { return this.regionOrigen; }
			set { this.regionOrigen = value; }
		}

		public string ProvinciaOrigen
		{
			get { return this.provinciaOrigen; }
			set { this.provinciaOrigen = value; }
		}

		public string LocalidadOrigen
		{
			get { return this.localidadOrigen; }
			set { this.localidadOrigen = value; }
		}

		public string DomicilioOrigen
		{
			get { return this.domicilioOrigen; }
			set { this.domicilioOrigen = value; }
		}

		public string PaisDestino
		{
			get { return this.paisDestino; }
			set { this.paisDestino = value; }
		}

		public string RegionDestino
		{
			get { return this.regionDestino; }
			set { this.regionDestino = value; }
		}

		public string ProvinciaDestino
		{
			get { return this.provinciaDestino; }
			set { this.provinciaDestino = value; }
		}

		public string LocalidadDestino
		{
			get { return this.localidadDestino; }
			set { this.localidadDestino = value; }
		}

		public string DomicilioDestino
		{
			get { return this.domicilioDestino; }
			set { this.domicilioDestino = value; }
		}


		public decimal PrecioEncomienda
		{
			get { return this.precioEncomienda; }
			set { this.precioEncomienda = value; }
		}

		public decimal PesoEncomienda
		{
			get { return this.pesoEncomienda; }
			set { this.pesoEncomienda = value; }
		}


		public long CuitCorporativo
		{
			get { return this.cuitCorporativo; }
			set { this.cuitCorporativo = value; }
		}

		public string RazonSocialCorporativo
		{
			get { return this.razonSocialCorporativo; }
			set { this.razonSocialCorporativo = value; }
		}


		public string Urgente
		{
			get { return this.urgente; }
			set { this.urgente = value; }
		}

		public string RetiroEnSucursal
		{
			get { return this.retiroEnSucursal; }
			set { this.retiroEnSucursal = value; }
		}

		public string RetiroEnPuerta
		{
			get { return this.retiroEnPuerta; }
			set { this.retiroEnPuerta = value; }
		}

		public decimal CalculoPedido
		{
			get { return this.calculoPedido; }
			set { this.calculoPedido = value; }
		}

		public static int idContador = 1;

		public Pedido()
		{
			idPedido = idContador;
			idContador++;

		}

		public Pedido(string linea)
		{

			var datos = linea.Split(';');
			IdPedido = int.Parse(datos[0]);
			EstadoPedido = datos[1];
			FechaPedido = DateTime.Parse(datos[2]);

			PaisOrigen = datos[3];
			RegionOrigen = datos[4];
			ProvinciaOrigen = datos[5];
			LocalidadOrigen = datos[6];
			DomicilioOrigen = datos[7];

			PaisDestino = datos[8];
			RegionDestino = datos[9];
			ProvinciaDestino = datos[10];
			LocalidadDestino = datos[11];
			DomicilioDestino = datos[12];

			PrecioEncomienda = decimal.Parse(datos[13]);
			PesoEncomienda = decimal.Parse(datos[14]);

			CuitCorporativo = long.Parse(datos[15]);
			RazonSocialCorporativo = datos[16];

			Urgente = datos[17];
			RetiroEnSucursal = datos[18];
			RetiroEnPuerta = datos[19];

			CalculoPedido = decimal.Parse(datos[20]);


		}

		
	

		public string ObtenerLineaDatos()
		{
			return $"{IdPedido} ; {EstadoPedido} ; {FechaPedido};{PaisOrigen};{RegionOrigen};{ProvinciaOrigen};{LocalidadOrigen};{DomicilioOrigen};{PaisDestino};{RegionDestino};{ProvinciaDestino};{LocalidadDestino} ; {DomicilioDestino} ; {PrecioEncomienda} ; {PesoEncomienda} ; {CuitCorporativo} ; {RazonSocialCorporativo} ; {Urgente} ; {RetiroEnSucursal} ; {RetiroEnPuerta}";
		}

		public static Pedido CrearModeloBusqueda()
		{
			var modelo = new Pedido();


			modelo.IdPedido = Validador.PedirIntMayor("Por favor ingrese el nro de ID",0);


			return modelo;
		}

		public bool CoincideCon(Pedido modelo)
		{
			if (modelo.IdPedido != 0 && IdPedido != modelo.IdPedido)
			{
				return false;
			}

			return true;
		}

		public void MostrarPedidoInicio()
		{
			Console.Clear();
			Console.WriteLine($"\n Estado del Pedido");

			Console.WriteLine($"\n Id Pedido: EN CREACIÓN");
			Console.WriteLine($" Estado: {IdPedido}");
			Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

			Console.WriteLine($"\n País de Origen: {PaisOrigen}");
			Console.WriteLine($" Región de Origen: {RegionOrigen}");
			Console.WriteLine($" Provincia de Origen: {ProvinciaOrigen}");
			Console.WriteLine($" Localidad de Origen: {LocalidadOrigen}");
			Console.WriteLine($" DomicilioDeOrigen: {DomicilioOrigen}");

			Console.WriteLine("\n Presione cualquier tecla para continuar");
			Console.ReadKey();

		}


		public static Pedido CrearPedido()
		{
			var pedido = new Pedido();

			var servicioPrecio = DiccionarioServicioPrecio.BuscarServicioIdPedido();

			
			pedido.EstadoPedido = "INICIADO";

			//testing metodo
			pedido.FechaPedido = DateTime.Now;
			//pedido.PaisOrigen = "ARGENTINA";
			//pedido.RegionOrigen = "CUYO";
			//pedido.ProvinciaOrigen = "MENDOZA";
			//pedido.LocalidadOrigen = "CAPITAL";
			//pedido.DomicilioOrigen = "123";
			pedido.PaisDestino = "URUGUAY";
			pedido.RegionDestino = "SUR";
			pedido.ProvinciaDestino = "ARTIGAZ";
			pedido.LocalidadDestino = "CANELONES";
			pedido.DomicilioDestino = "456";
			pedido.PrecioEncomienda = 1.65m;
			pedido.PesoEncomienda = 16.45m;
			pedido.CuitCorporativo = 123456789123;
			pedido.RazonSocialCorporativo = "ASD";
			pedido.Urgente = "SI";
			pedido.RetiroEnSucursal = "NO";
			pedido.RetiroEnPuerta = "SI";

			
			
			int opcion1;
			int opcion2;
			int opcion3;

			string continuar1;

			string direccion1;

			

			do
			{
				Console.Clear();
				
				opcion1 = Validador.PedirIntMenu("\n Elegir el País de Origen" +
									    "\n [1]  ARGENTINA" +
										"\n [2]  PAISES LIMÍTROFES" +
										"\n [3]  RESTO DE AMÉRICA LATINA" +
										"\n [4]  AMERICA DEL NORTE" +
										"\n [5]  EUROPA" +
										"\n [6]  ASIA" +
										"\n [7]  SALIR", 1, 7);


				switch (opcion1)
				{

					case 1:
						do
						{
							Console.Clear();
							opcion2 = Validador.PedirIntMenu("\n Elegir la Provincia de Origen" +
											"\n [1]  BUENOS AIRES" +
											"\n [2]  CABA" +
											"\n [3]  CATAMARCA" +
											"\n [4]  CHACO" +
											"\n [5]  CHUBUT" +
											"\n [6]  CORDOBA" +
											"\n [7]  CORRIENTES" +
											"\n [8]  ENTRE RIOS" +
											"\n [9]  FORMOSA" +
											"\n [10] JUJUY" +
											"\n [11] LA PAMPA" +
											"\n [12] LA RIOJA" +
											"\n [13] MENDOZA" +
											"\n [14] MISIONES" +
											"\n [15] NEUQUEN" +
											"\n [16] RIO NEGRO" +
											"\n [17] SALTA" +
											"\n [18] SAN JUAN" +
											"\n [19] LA RIOJA" +
											"\n [20] SAN LUIS" +
											"\n [21] SANTA FE" +
											"\n [22] SANTIAGO DEL ESTERO" +
											"\n [23] TIERRA DEL FUEGO" +
											"\n [24] TUCUMAN" +
											"\n [25] SALIR", 1, 25);

							switch (opcion2)
                            {
								case 1:
									
									do
									{

										Console.Clear();
										opcion3 = Validador.PedirIntMenu("\n Elegir la Localidad de Origen" +
														"\n [1]  QUILMES" +
														"\n [2]  MAR DEL PLATA" +
														"\n [3]  LOBOS" +
														"\n [4]  BAHIA BLANCA" +
														"\n [5]  SALIR", 1, 5);

										switch (opcion3)
										{
											case 1:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: QUILMES, \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "QUILMES";
													pedido.DomicilioOrigen = direccion1;

													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;

													break;
													
												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													Validador.VolverMenu();
													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;
													break;
												}
											
											case 2:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: MAR DEL PLATA, \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "MAR DEL PLATA";
													pedido.DomicilioOrigen = direccion1;

													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;

													break;

												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													break;
												}
											case 3:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: LOBOS \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "LOBOS";
													pedido.DomicilioOrigen = direccion1;

													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;

													break;

												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													break;
												}
											case 4:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: BAHIA BLANCA, \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "BAHIA BLANCA";
													pedido.DomicilioOrigen = direccion1;

													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;

													break;

												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													break;
												}



										}

									} while (opcion3 != 5);


									break;


								case 2:
									break;
									
									

                            }

						} while (opcion2 != 25);


					break;	
					case 2:
					break;
					case 3:
					break;
					case 4:
					do
						{
							Console.Clear();
							opcion2 = Validador.PedirIntMenu("\n Elegir el País de Origen" +
											"\n [1] USA" +
											"\n [2] MËXICO" +
											"\n [3] CANADA" +
											"\n [4] SALIR", 1, 4);

							switch (opcion2)
                            {
								case 1:
									
									do
									{

										Console.Clear();
										opcion3 = Validador.PedirIntMenu("\n Elegir el Estado de Origen" +
														"\n [1]  NUEVA YORK" +
														"\n [2]  LOS ANGELES" +
														"\n [3]  MIAMI" +
														"\n [4]  SALIR", 1, 4);

										switch (opcion3)
										{
											case 1:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n REGIÓN: AMERICA DEL NORTE \n PAÍS: USA \n ESTADO: NUEVA YORK " +
													"\n LOCALIDAD: QUEENS \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "USA";
													pedido.RegionOrigen = "AMERICA DEL NORTE";
													pedido.ProvinciaOrigen = "NUEVA YORK";
													pedido.LocalidadOrigen = "QUEENS";
													pedido.DomicilioOrigen = direccion1;

													opcion3 = 4;
													opcion2 = 4;
													opcion1 = 7;

													break;
													
												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													Validador.VolverMenu();
													opcion3 = 4;
													opcion2 = 4;
													opcion1 = 7;
													break;
												}
											
											case 2:
												Console.Clear();
												direccion1 = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuar1 = Validador.ValidarSioNo("\n Usted seleccionó: " +
													"\n REGIÓN: AMERICA DEL NORTE \n PAÍS: USA \n ESTADO: LOS ANGELES " +
													"\n LOCALIDAD: NORTH HOLLYWOOD \n DIRECCIÓN: *" + direccion1 + "* \n\n desea continuar?");
												if (continuar1 == "SI")
												{
													pedido.PaisOrigen = "USA";
													pedido.RegionOrigen = "AMERICA DEL NORTE";
													pedido.ProvinciaOrigen = "LOS ANGELES";
													pedido.LocalidadOrigen = "NORTH HOLLYWOOD";
													pedido.DomicilioOrigen = direccion1;


													opcion3 = 3;
													opcion2 = 4;
													opcion1 = 7;

													break;

												}
												else
												{
													Console.Clear();
													Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
													Validador.VolverMenu();
													opcion3 = 3;
													opcion2 = 4;
													opcion1 = 7;
													break;
												}
											case 3:
											break;
											



										}

									} while (opcion3 != 4);


									break;


								case 2:
									break;
									
									

                            }

						} while (opcion2 != 4);

					break;
					case 5:
					break;
					case 6:
					break;
					case 7:
					break;

				}

			} while (opcion1 != 7);


			pedido.MostrarPedidoInicio();

			string seguir = Validador.ValidarSioNo("\n Desea Continuar?");

			decimal peso;

			decimal peso500g = 0.5m;
			

			if (seguir == "SI")
            {
				peso = Validador.PedirDecimal("\n Ingrese el peso del bulto", 0, 30);

				if(pedido.PaisOrigen == "ARGENTINA" && (peso < peso500g))
                {
					pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioNacional;
					Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
					Validador.VolverMenu();
				}
                else
                {
					Console.Clear();
					Console.WriteLine("Usted decidió no continuar, volverá al Menú Anterior");
					Validador.VolverMenu();
				}
				

			}
			else
            {
				Console.Clear();
				Console.WriteLine("Usted decidió no continuar, volverá al Menú Anterior");
				Validador.VolverMenu();
			}

		
			
			



			return pedido;
		}

		
		
		

	}


}
