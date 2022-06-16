using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
     class ServicioPrecio
    {
		
		private int idServicio;
		private decimal precioServicioLocal;
		private decimal precioServicioProvincial;
		private decimal precioServicioRegional;
		private decimal precioServicioNacional;

		private decimal precioServicioPaisLimitrofe;
		private decimal precioServicioRestoAmerica;
		private decimal precioServicioAmericaNorte;
		private decimal precioServicioEuropa;
		private decimal precioServicioAsia;
		private decimal precioServicioRestoMundo;

		private decimal precioServicioUrgente;
		private decimal precioServicioEnPuerta;
		private decimal precioServicioEnSucursal;

		private decimal precioServicio500g;
		private decimal precioServicio10Kg;
		private decimal precioServicio20Kg;
		private decimal precioServicio30Kg;

		public int IdServicio
		{
			get { return this.idServicio; }
			set { this.idServicio = value; }
		}
		public decimal PrecioServicioLocal
		{
			get { return this.precioServicioLocal; }
			set { this.precioServicioLocal = value; }
		}

		public decimal PrecioServicioProvincial
		{
			get { return this.precioServicioProvincial; }
			set { this.precioServicioProvincial = value; }
		}

		public decimal PrecioServicioRegional
		{
			get { return this.precioServicioRegional; }
			set { this.precioServicioRegional = value; }
		}

		public decimal PrecioServicioNacional
		{
			get { return this.precioServicioNacional; }
			set { this.precioServicioNacional = value; }
		}

		public decimal PrecioServicioPaisLimitrofe
		{
			get { return this.precioServicioPaisLimitrofe; }
			set { this.precioServicioPaisLimitrofe = value; }
		}

		public decimal PrecioServicioRestoAmerica
		{
			get { return this.precioServicioRestoAmerica; }
			set { this.precioServicioRestoAmerica = value; }
		}

		public decimal PrecioServicioAmericaNorte
		{
			get { return this.precioServicioAmericaNorte; }
			set { this.precioServicioAmericaNorte = value; }
		}

		public decimal PrecioServicioEuropa
		{
			get { return this.precioServicioEuropa; }
			set { this.precioServicioEuropa = value; }
		}

		public decimal PrecioServicioAsia
		{
			get { return this.precioServicioAsia; }
			set { this.precioServicioAsia = value; }
		}

		public decimal PrecioServicioRestoMundo
		{
			get { return this.precioServicioRestoMundo; }
			set { this.precioServicioRestoMundo = value; }
		}

		public decimal PrecioServicioUrgente
		{
			get { return this.precioServicioUrgente; }
			set { this.precioServicioUrgente = value; }
		}

		public decimal PrecioServicioEnSucursal
		{
			get { return this.precioServicioEnSucursal; }
			set { this.precioServicioEnSucursal = value; }
		}

		public decimal PrecioServicioEnPuerta
		{
			get { return this.precioServicioEnPuerta; }
			set { this.precioServicioEnPuerta = value; }
		}

		public decimal PrecioServicio500g
		{
			get { return this.precioServicio500g; }
			set { this.precioServicio500g = value; }
		}

		public decimal PrecioServicio10Kg
		{
			get { return this.precioServicio10Kg; }
			set { this.precioServicio10Kg = value; }
		}

		public decimal PrecioServicio20Kg
		{
			get { return this.precioServicio20Kg; }
			set { this.precioServicio20Kg = value; }
		}

		public decimal PrecioServicio30Kg
		{
			get { return this.precioServicio30Kg; }
			set { this.precioServicio30Kg = value; }
		}



		public ServicioPrecio()
		{

		}

		public ServicioPrecio(string linea)
		{

			var datos = linea.Split(';');
			IdServicio = int.Parse(datos[0]);
			precioServicioLocal = decimal.Parse(datos[1]); 
			precioServicioProvincial = decimal.Parse(datos[2]); 
			precioServicioRegional = decimal.Parse(datos[3]);
			precioServicioNacional = decimal.Parse(datos[4]);

			precioServicioPaisLimitrofe = decimal.Parse(datos[5]);
			precioServicioRestoAmerica = decimal.Parse(datos[6]);
			precioServicioAmericaNorte = decimal.Parse(datos[7]);
			precioServicioEuropa = decimal.Parse(datos[8]);
			precioServicioAsia = decimal.Parse(datos[9]);
			precioServicioRestoMundo = decimal.Parse(datos[10]);

			precioServicioUrgente = decimal.Parse(datos[11]);
			precioServicioEnPuerta = decimal.Parse(datos[12]);
			precioServicioEnSucursal = decimal.Parse(datos[13]);


			precioServicio500g = decimal.Parse(datos[14]);
			precioServicio10Kg = decimal.Parse(datos[15]);
			precioServicio20Kg = decimal.Parse(datos[16]);
			precioServicio30Kg = decimal.Parse(datos[17]);

		
		}


		public static ServicioPrecio CrearNuevoServicio(string codigoNuevoProducto)
		{
			var producto = new ServicioPrecio();
			return producto;
		}

		
		public string DatoServicioPrecio
		{
			get
			{
				return $"\n Código de Servicio es: {IdServicio},";
			}
		}

		public static ServicioPrecio ValidarServicio()
		{
			var idServicio = new ServicioPrecio();

			idServicio.IdServicio = 1;

			return idServicio;
		}

		public bool CompararServicioCoincidencia(ServicioPrecio servicioPrecio)
		{

			if (servicioPrecio.IdServicio != 0 && IdServicio != servicioPrecio.IdServicio)
			{
				return false;
			}

			return true;
		}

	}
}
