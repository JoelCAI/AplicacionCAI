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
		public int idPedido;

		public string estadoPedido;
		public DateTime fechaPedido;

		public string paisOrigen;
		public string regionOrigen;
		public string provinciaOrigen;
		public string localidadOrigen;
		public string domicilioOrigen;

		public string paisDestino;
		public string regionDestino;
		public string provinciaDestino;
		public string localidadDestino;
		public string domicilioDestino;

		public decimal precioEncomienda;
		public decimal pesoEncomienda;
		//public decimal ValorDeclarado;

		public long cuitCorporativo;
		public string razonSocialCorporativo;

		public string urgente;
		public string retiroEnSucursal;
		public string retiroEnPuerta;

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



		public Pedido()
		{
			

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


		}

		
		public void CalcularRecargo(string mensaje)
		{
			/*
			decimal urgente = 1.2m;
			decimal retiroenPuerta = 500;
			decimal internacional = 2000;
			decimal ninguno = 0;
			*/

			/*
			if (mensaje == "URGENTE")
			{
				this._recargo = this._recargo * urgente;
			}
			else if (mensaje == "RETIROENPUERTA")
			{
				this._recargo = this._recargo + retiroenPuerta;
			}
			else if (mensaje == "INTERNACIONAL")
			{
				this._recargo = this._recargo + internacional;
			}
			else if (mensaje == "NINGUNO")
			{
				this._recargo = this._recargo + ninguno;
			}
			*/
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

		public void MostrarPedido()
		{
			Console.WriteLine($"Id Pedido: {IdPedido}");
			Console.WriteLine($"Estado: {EstadoPedido}");

		}


		public static Pedido CrearPedido()
		{
			var pedido = new Pedido();

			//todo corregir pedido
			pedido.IdPedido = 1;
			pedido.EstadoPedido = "INICIADO";

			//testing metodo
			pedido.FechaPedido = DateTime.Now;
			pedido.PaisOrigen = "ARGENTINA";
			pedido.RegionOrigen = "CUYO";
			pedido.ProvinciaOrigen = "MENDOZA";
			pedido.LocalidadOrigen = "CAPITAL";
			pedido.DomicilioOrigen = "123";
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


			
			
			int opcion;


			do
			{
				Console.Clear();
				
				opcion = Validador.PedirIntMenu("\n Elegir la provincia" +
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
										"\n [25] VOLVER AL MENÚ ANTERIOR", 1, 25);


				switch (opcion)
				{

					case 1:
						string continuar1 = Validador.ValidarSioNo("Usted seleccionó BUENOS AIRES " +
																  "desea continuar?");
						if (continuar1 == "SI")
                        {
							pedido.ProvinciaOrigen = "BUENOS AIRES";
							break;
						}
                        else
                        {
							Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
							break;
                        }
						
					case 2:
						string continuar2 = Validador.ValidarSioNo("Usted seleccionó CABA " +
																  "desea continuar?");
						if (continuar2 == "SI")
						{
							pedido.ProvinciaOrigen = "CABA";
							break;
						}
						else
						{
							Console.WriteLine("Usted decidió no continuar, volvera al Menú Anterior");
							break;
						}
					

				}
			} while (opcion != 25);

			return pedido;
		}
		

	}
}
