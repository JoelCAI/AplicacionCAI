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

		private string continenteOrigen;
		private string paisOrigen;
		private string regionOrigen;
		private string provinciaOrigen;
		private string localidadOrigen;
		private string domicilioOrigen;

		private string continenteDestino;
		private string paisDestino;
		private string regionDestino;
		private string provinciaDestino;
		private string localidadDestino;
		private string domicilioDestino;

		private decimal precioEncomienda;
		private decimal pesoEncomienda;


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

		public string ContinenteOrigen
		{
			get { return this.continenteOrigen; }
			set { this.continenteOrigen = value; }
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

		public string ContinenteDestino
		{
			get { return this.continenteDestino; }
			set { this.continenteDestino = value; }
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

			ContinenteOrigen = datos[3];
			PaisOrigen = datos[4];
			RegionOrigen = datos[5];
			ProvinciaOrigen = datos[6];
			LocalidadOrigen = datos[7];
			DomicilioOrigen = datos[8];

			ContinenteDestino = datos[9];
			PaisDestino = datos[10];
			RegionDestino = datos[11];
			ProvinciaDestino = datos[12];
			LocalidadDestino = datos[13];
			DomicilioDestino = datos[14];

			PrecioEncomienda = decimal.Parse(datos[15]);
			PesoEncomienda = decimal.Parse(datos[16]);

			CuitCorporativo = long.Parse(datos[17]);
			RazonSocialCorporativo = datos[18];

			Urgente = datos[19];
			RetiroEnSucursal = datos[20];
			RetiroEnPuerta = datos[21];

			CalculoPedido = decimal.Parse(datos[22]);


		}




		public string ObtenerLineaDatos()
		{
			return $"{IdPedido} ; {EstadoPedido} ; {FechaPedido};{PaisOrigen};{RegionOrigen};{ProvinciaOrigen};{LocalidadOrigen};{DomicilioOrigen};{PaisDestino};{RegionDestino};{ProvinciaDestino};{LocalidadDestino} ; {DomicilioDestino} ; {PrecioEncomienda} ; {PesoEncomienda} ; {CuitCorporativo} ; {RazonSocialCorporativo} ; {Urgente} ; {RetiroEnSucursal} ; {RetiroEnPuerta}";
		}

		public static Pedido CrearModeloBusqueda()
		{
			var modelo = new Pedido();


			modelo.IdPedido = Validador.PedirIntMayor("\n Por favor ingrese el nro de ID", 0);


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
			Console.WriteLine($" Estado: EN CREACIÓN");
			Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

			Console.WriteLine($"\n País de Origen: {PaisOrigen}");
			Console.WriteLine($" Región de Origen: {RegionOrigen}");
			Console.WriteLine($" Provincia de Origen: {ProvinciaOrigen}");
			Console.WriteLine($" Localidad de Origen: {LocalidadOrigen}");
			Console.WriteLine($" DomicilioDeOrigen: {DomicilioOrigen}");



		}

		public void MostrarPedidoFinal()
		{
			var usuario = DiccionarioUsuario.BuscarUsuarioDniUnico();

			Console.Clear();
			Console.WriteLine($"\n Estado del Pedido");

			Console.WriteLine("\n Cuit: " + usuario.CuitCorporativo);
			Console.WriteLine(" Razón Social: " + usuario.RazonSocial);

			Console.WriteLine($"\n Id Pedido: {IdPedido}");
			Console.WriteLine($" Estado: {EstadoPedido}");
			Console.WriteLine($" Fecha de Pedido: {FechaPedido.ToLongDateString()}");

			Console.WriteLine($"\n País de Origen: {PaisOrigen}");
			Console.WriteLine($" Región de Origen: {RegionOrigen}");
			Console.WriteLine($" Provincia de Origen: {ProvinciaOrigen}");
			Console.WriteLine($" Localidad de Origen: {LocalidadOrigen}");
			Console.WriteLine($" Domicilio de Origen: {DomicilioOrigen}");

			Console.WriteLine($"\n País de Destino: {PaisDestino}");
			Console.WriteLine($" Región de Destino: {RegionDestino}");
			Console.WriteLine($" Provincia de Destino: {ProvinciaDestino}");
			Console.WriteLine($" Localidad de Destino: {LocalidadDestino}");
			Console.WriteLine($" Domicilio de Destino: {DomicilioDestino}");

			Console.WriteLine($"\n Monto del Pedido: {CalculoPedido}");

			Console.WriteLine("\n Presione cualquier tecla para continuar");
			Console.ReadKey();

		}


		public static Pedido CrearPedido()
		{
			var pedido = new Pedido();

			var servicioPrecio = DiccionarioServicioPrecio.BuscarServicioIdPedido();


			pedido.EstadoPedido = "INICIADO";


			pedido.FechaPedido = DateTime.Now;

			int opcion1;
			int opcion2;
			int opcion3;

			string continuarUno;
			string continuarDos;

			string direccionUno;
			string direccionDos;

			string seguirUno;
			string seguirDos;
			//string seguirTres;

			int validar = 0;


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
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: QUILMES, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "QUILMES";
													pedido.DomicilioOrigen = direccionUno;

													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;



													break;

												}
												else

												{
													Console.Clear();
													Console.WriteLine("\n Usted decidió no continuar, volvera al Menú Anterior");
													Validador.VolverMenu();
													opcion3 = 5;
													opcion2 = 25;
													opcion1 = 7;
													break;
												}

											case 2:
												Console.Clear();
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: MAR DEL PLATA, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "MAR DEL PLATA";
													pedido.DomicilioOrigen = direccionUno;

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
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: LOBOS \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "LOBOS";
													pedido.DomicilioOrigen = direccionUno;

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
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
													"\n REGION: CENTRO \n LOCALIDAD: BAHIA BLANCA, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.PaisOrigen = "ARGENTINA";
													pedido.RegionOrigen = "CENTRO";
													pedido.ProvinciaOrigen = "BUENOS AIRES";
													pedido.LocalidadOrigen = "BAHIA BLANCA";
													pedido.DomicilioOrigen = direccionUno;

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
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n REGIÓN: AMERICA DEL NORTE \n PAÍS: USA \n ESTADO: NUEVA YORK " +
													"\n LOCALIDAD: QUEENS \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.ContinenteOrigen = "AMERICA DEL NORTE";
													pedido.PaisOrigen = "USA";
													pedido.RegionOrigen = "AMERICA DEL NORTE";
													pedido.ProvinciaOrigen = "NUEVA YORK";
													pedido.LocalidadOrigen = "QUEENS";
													pedido.DomicilioOrigen = direccionUno;

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
												direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
													"dirección");
												continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Origen: " +
													"\n REGIÓN: AMERICA DEL NORTE \n PAÍS: USA \n ESTADO: LOS ANGELES " +
													"\n LOCALIDAD: NORTH HOLLYWOOD \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
												if (continuarUno == "SI")
												{
													pedido.ContinenteOrigen = "AMERICA DEL NORTE";
													pedido.PaisOrigen = "USA";
													pedido.RegionOrigen = "AMERICA DEL NORTE";
													pedido.ProvinciaOrigen = "LOS ANGELES";
													pedido.LocalidadOrigen = "NORTH HOLLYWOOD";
													pedido.DomicilioOrigen = continuarUno;


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


			seguirUno = pedido.ValidarSioNoPedidoInicial("\n Desea Continuar?");


			if (seguirUno == "SI" && pedido.PaisOrigen != null)
			{
				do
				{
					Console.Clear();

					opcion1 = Validador.PedirIntMenu("\n Elegir el País de Destino" +
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
								opcion2 = Validador.PedirIntMenu("\n Elegir la Provincia de Destino" +
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
											opcion3 = Validador.PedirIntMenu("\n Elegir la Localidad de Destino" +
															"\n [1]  QUILMES" +
															"\n [2]  MAR DEL PLATA" +
															"\n [3]  LOBOS" +
															"\n [4]  BAHIA BLANCA" +
															"\n [5]  SALIR", 1, 5);

											switch (opcion3)
											{
												case 1:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
														"\n REGION: CENTRO \n LOCALIDAD: QUILMES, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisDestino = "ARGENTINA";
														pedido.RegionDestino = "CENTRO";
														pedido.ProvinciaDestino = "BUENOS AIRES";
														pedido.LocalidadDestino = "QUILMES";
														pedido.DomicilioDestino = direccionUno;

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
														validar = 1;
														break;
													}

												case 2:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
														"\n REGION: CENTRO \n LOCALIDAD: MAR DEL PLATA, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisDestino = "ARGENTINA";
														pedido.RegionDestino = "CENTRO";
														pedido.ProvinciaDestino = "BUENOS AIRES";
														pedido.LocalidadDestino = "MAR DEL PLATA";
														pedido.DomicilioDestino = direccionUno;

														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;

														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;
														validar = 1;
														break;
													}
												case 3:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
														"\n REGION: CENTRO \n LOCALIDAD: LOBOS \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisDestino = "ARGENTINA";
														pedido.RegionDestino = "CENTRO";
														pedido.ProvinciaDestino = "BUENOS AIRES";
														pedido.LocalidadDestino = "LOBOS";
														pedido.DomicilioDestino = direccionUno;

														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;

														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;
														validar = 1;
														break;
													}
												case 4:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: BUENOS AIRES, " +
														"\n REGION: CENTRO \n LOCALIDAD: BAHIA BLANCA, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisOrigen = "ARGENTINA";
														pedido.RegionOrigen = "CENTRO";
														pedido.ProvinciaOrigen = "BUENOS AIRES";
														pedido.LocalidadOrigen = "BAHIA BLANCA";
														pedido.DomicilioOrigen = direccionUno;

														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;

														break;

													}
													else
													{
														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;
														validar = 1;
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														break;
													}



											}

										} while (opcion3 != 5);


										break;


									case 2:
										break;
									case 24:
										do
										{

											Console.Clear();
											opcion3 = Validador.PedirIntMenu("\n Elegir la Localidad de Destino" +
															"\n [1]  SAN MIGUEL DE TUCUMAN" +
															"\n [2]  TAFI VIEJO" +
															"\n [3]  VILLA NOUGUES" +
															"\n [4]  BAHIA BLANCA" +
															"\n [5]  YERBA BUENA", 1, 5);

											switch (opcion3)
											{
												case 1:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: SAN MIGUEL, " +
														"\n REGION: NORTE \n LOCALIDAD: SAN MIGUEL DE TUCUMAN, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisDestino = "ARGENTINA";
														pedido.RegionDestino = "NORTE";
														pedido.ProvinciaDestino = "SAN MIGUEL";
														pedido.LocalidadDestino = "SAN MIGUEL DE TUCUMAN";
														pedido.DomicilioDestino = direccionUno;

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
														validar = 1;
														break;
													}

												case 2:
													Console.Clear();
													direccionUno = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarUno = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: ARGENTINA, \n PROVINCIA: SAN MIGUEL, " +
														"\n REGION: NORTE \n LOCALIDAD: SAN MIGUEL DE TUCUMAN, \n DIRECCIÓN: *" + direccionUno + "* \n\n desea continuar?");
													if (continuarUno == "SI")
													{
														pedido.PaisDestino = "ARGENTINA";
														pedido.RegionDestino = "NORTE";
														pedido.ProvinciaDestino = "SAN MIGUEL";
														pedido.LocalidadDestino = "TAFI VIEJO";
														pedido.DomicilioDestino = direccionUno;

														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;

														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														opcion3 = 5;
														opcion2 = 25;
														opcion1 = 7;
														validar = 1;
														break;
													}



											}

										} while (opcion3 != 5);

										break;


								}

							} while (opcion2 != 25);
							break;


						case 2:
							do
							{
								Console.Clear();
								opcion2 = Validador.PedirIntMenu("\n Elegir País Limítrofe de Destino" +
												"\n [1]  BOLIVIA" +
												"\n [2]  BRASIL" +
												"\n [3]  CHILE" +
												"\n [4]  PARAGUAY" +
												"\n [5]  URUGUAY" +
												"\n [6]  SALIR"
												, 1, 6);

								switch (opcion2)
								{
									case 1:
										break;

									case 2:
										do
										{

											Console.Clear();
											opcion3 = Validador.PedirIntMenu("\n Elegir la ciudad de Destino" +
															"\n [1]	 SAO PAULO" +
															"\n [2]  PORTO ALEGRE" +
															"\n [3]  BRASILIA" +
															"\n [4]  SALIR", 1, 4);

											switch (opcion3)
											{
												case 1:
													Console.Clear();
													direccionDos = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarDos = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: BRASIL, \n PROVINCIA: ESTADO SAO PAULO, " +
														"\n REGION: CENTRO \n LOCALIDAD: SAO PAULO, \n DIRECCIÓN: *" + direccionDos + "* \n\n desea continuar?");
													if (continuarDos == "SI")
													{
														pedido.ContinenteDestino = "PAISES LIMITROFES";
														pedido.PaisDestino = "BRASIL";
														pedido.RegionDestino = "CENTRO";
														pedido.ProvinciaDestino = "ESTADO SAO PAULO";
														pedido.LocalidadDestino = "SAO PAULO";
														pedido.DomicilioDestino = direccionDos;

														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;


														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														Validador.VolverMenu();
														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;
														validar = 1;
														break;
													}

												case 2:
													Console.Clear();
													direccionDos = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarDos = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: BRASIL, \n PROVINCIA: RIO GRANDE DEL SUR, " +
														"\n REGION: SUR\n LOCALIDAD: PORTO ALEGRE, \n DIRECCIÓN: *" + direccionDos + "* \n\n desea continuar?");
													if (continuarDos == "SI")
													{
														pedido.ContinenteDestino = "PAISES LIMITROFES";
														pedido.PaisDestino = "BRASIL";
														pedido.RegionDestino = "SUR";
														pedido.ProvinciaDestino = "RIO GRANDE DEL SUR";
														pedido.LocalidadDestino = "PORTO ALEGRE";
														pedido.DomicilioDestino = direccionDos;

														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;

														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														Validador.VolverMenu();
														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;
														validar = 1;
														break;
													}
												case 3:
													Console.Clear();
													direccionDos = Validador.ValidarStringNoVacioSistema("\n Ingresar " +
														"dirección");
													continuarDos = Validador.ValidarSioNo("\n Usted seleccionó como Destino: " +
														"\n PAIS: BRASIL, \n PROVINCIA: BRASILIA, " +
														"\n REGION: CENTRO \n LOCALIDAD: BRASILIA \n DIRECCIÓN: *" + direccionDos + "* \n\n desea continuar?");
													if (continuarDos == "SI")
													{
														pedido.ContinenteDestino = "PAISES LIMITROFES";
														pedido.PaisDestino = "BRASIL";
														pedido.RegionDestino = "CENTRO";
														pedido.ProvinciaDestino = "BRASILIA";
														pedido.LocalidadDestino = "BRASILIA";
														pedido.DomicilioDestino = direccionDos;

														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;

														break;

													}
													else
													{
														Console.Clear();
														Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
														Validador.VolverMenu();
														opcion3 = 4;
														opcion2 = 6;
														opcion1 = 7;
														validar = 1;
														break;
													}

											}

										} while (opcion3 != 4);

										break;

								}

							} while (opcion2 != 6);


							break;

						case 3:
							break;
						case 4:
							break;

					}

				} while (opcion1 != 7);

			}

			else if (seguirUno == "NO")
			{
				Console.Clear();
				Console.WriteLine("\n Usted decidió no continuar, volverá al Menú Anterior");
				validar = 1;
				Validador.VolverMenu();

			}
			else if (pedido.PaisOrigen == null)
			{
				Console.Clear();
				Console.WriteLine("\n Usted decidió continuar pero no ingresó ningún destino de Origen," +
								  "\n Volverá al Menú para que vuelva a intentarlo.");
				validar = 1;
				Validador.VolverMenu();

			}


			decimal peso;

			decimal peso500g = 0.5m;
			decimal peso10Kg = 10;
			decimal peso20Kg = 20;
			decimal peso30Kg = 30;

			if (validar != 1)
			{
				peso = Validador.PedirDecimal("\n Por favor ingrese el peso del bulto", 0, 30);

				if (pedido.PaisOrigen == "ARGENTINA" && pedido.PaisDestino == "ARGENTINA")
				{
					if (pedido.RegionOrigen == pedido.RegionDestino)
					{
						if (pedido.ProvinciaOrigen == pedido.ProvinciaDestino)
						{
							if (pedido.LocalidadOrigen == pedido.LocalidadDestino)
							{
								if (peso <= peso500g)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioLocal;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();

								}
								else if (peso > peso500g && peso <= peso10Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioLocal;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}
								else if (peso > peso10Kg && peso <= peso20Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioLocal;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}
								else if (peso > peso20Kg && peso <= peso30Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioLocal;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}

							}
							else
							{
								if (peso <= peso500g)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioProvincial;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();

								}
								else if (peso > peso500g && peso <= peso10Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioProvincial;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}
								else if (peso > peso10Kg && peso <= peso20Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioProvincial;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}
								else if (peso > peso20Kg && peso <= peso30Kg)
								{
									pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioProvincial;
									Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
									Validador.VolverMenu();
								}

							}

						}
						else
						{
							if (peso <= peso500g)
							{
								pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioRegional;
								Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
								Validador.VolverMenu();

							}
							else if (peso > peso500g && peso <= peso10Kg)
							{
								pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioRegional;
								Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
								Validador.VolverMenu();
							}
							else if (peso > peso10Kg && peso <= peso20Kg)
							{
								pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioRegional;
								Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
								Validador.VolverMenu();
							}
							else if (peso > peso20Kg && peso <= peso30Kg)
							{
								pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioRegional;
								Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
								Validador.VolverMenu();
							}

						}
					}
					else
					{
						if (peso <= peso500g)
						{
							pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioNacional;
							Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
							Validador.VolverMenu();

						}
						else if (peso > peso500g && peso <= peso10Kg)
						{
							pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioNacional;
							Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
							Validador.VolverMenu();
						}
						else if (peso > peso10Kg && peso <= peso20Kg)
						{
							pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioNacional;
							Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
							Validador.VolverMenu();
						}
						else if (peso > peso20Kg && peso <= peso30Kg)
						{
							pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioNacional;
							Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
							Validador.VolverMenu();
						}

					}

				}

				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "PAISES LIMITROFES")
						|| (pedido.PaisOrigen == "PAISES LIMITROFES" && pedido.ContinenteDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioPaisLimitrofe;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioPaisLimitrofe;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioPaisLimitrofe;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioPaisLimitrofe;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
				}
				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "RESTO DE AMERICA LATINA")
						|| (pedido.PaisOrigen == "RESTO DE AMERICA LATINA" && pedido.ContinenteDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioRestoAmerica;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioRestoAmerica;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioRestoAmerica;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioRestoAmerica;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}

				}
				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "AMERICA DEL NORTE")
					|| (pedido.ContinenteOrigen == "AMERICA DEL NORTE" && pedido.PaisDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioAmericaNorte;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioAmericaNorte;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioAmericaNorte;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioAmericaNorte;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}

				}
				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "EUROPA")
						|| (pedido.PaisOrigen == "EUROPA" && pedido.ContinenteDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioEuropa;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioEuropa;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioEuropa;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioEuropa;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}

				}
				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "ASIA")
						|| (pedido.PaisOrigen == "ASIA" && pedido.ContinenteDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioAsia;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioAsia;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioAsia;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioAsia;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}

				}
				else if ((pedido.PaisOrigen == "ARGENTINA" && pedido.ContinenteDestino == "RESTO DEL MUNDO")
						|| (pedido.PaisOrigen == "RESTO DEL MUNDO" && pedido.ContinenteDestino == "ARGENTINA"))
				{
					if (peso <= peso500g)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio500g + servicioPrecio.PrecioServicioRestoMundo;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();

					}
					else if (peso > peso500g && peso <= peso10Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio10Kg + servicioPrecio.PrecioServicioRestoMundo;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso10Kg && peso <= peso20Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio20Kg + servicioPrecio.PrecioServicioRestoMundo;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}
					else if (peso > peso20Kg && peso <= peso30Kg)
					{
						pedido.CalculoPedido = servicioPrecio.PrecioServicio30Kg + servicioPrecio.PrecioServicioRestoAmerica;
						Console.WriteLine("El monto total es: " + pedido.CalculoPedido);
						Validador.VolverMenu();
					}

				}

			}
			else if (validar == 1)
			{

			}
			else
			{
				Console.Clear();

				Console.WriteLine("Usted decidió no continuar, volverá al Menú Anterior");
				Validador.VolverMenu();
			}



			if (pedido.CalculoPedido != 0)
			{
		
				seguirDos = pedido.ValidarSioNoPedidoFinal("¿Desea generar el Pedido?");

			}






			return pedido;
		}


		private string ValidarSioNoPedidoInicial(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Valores permitidos:" +
									  "\n *SI* ó" +
									  "\n *NO*";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				Console.Clear();
				MostrarPedidoInicio();
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

		private string ValidarSioNoPedidoFinal(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Valores permitidos:" +
									  "\n *SI* ó" +
									  "\n *NO*";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				Console.Clear();
				MostrarPedidoFinal();
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


	}


}
