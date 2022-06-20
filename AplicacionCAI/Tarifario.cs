using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
     class ServicioPrecio
    {
	    public int IdServicio { get; set; }
	    public decimal PrecioServicioLocal{ get; set; }
	    public decimal PrecioServicioProvincial { get; set; }
	    public decimal PrecioServicioRegional { get; set; }
	    public decimal PrecioServicioNacional { get; set; }
	 
	    public int PesoLimite { get; set; }
	    public decimal PrecioServicioPaisLimitrofe { get; set; }
	    public decimal PrecioServicioRestoAmerica { get; set; }
	    public decimal PrecioServicioAmericaNorte { get; set; }
	    public decimal PrecioServicioEuropa { get; set; }
	    public decimal PrecioServicioAsia { get; set; }
	    public decimal PrecioServicioRestoMundo { get; set; }

	    public bool Bool { get; set; }
	    public decimal PrecioServicioUrgente { get; set; }

	    public decimal TopeUrgente { get; set; }
	    public decimal PrecioServicioEnPuerta { get; set; }
	    public decimal PrecioServicioEnSucursal { get; set; }

	    public decimal PrecioServicio500g { get; set; }	    
	    
	    public decimal PrecioServicio10Kg { get; set; }	    
	    public decimal PrecioServicio20Kg { get; set; }	    
	    public decimal PrecioServicio30Kg { get; set; }	    
	    
		public ServicioPrecio()
		{

		}

		public ServicioPrecio(string linea)
		{

			var datos = linea.Split(';');
			IdServicio = int.Parse(datos[0]);
			PrecioServicioLocal = decimal.Parse(datos[1]); 
			PrecioServicioProvincial = decimal.Parse(datos[2]); 
			PrecioServicioRegional = decimal.Parse(datos[3]);
			PrecioServicioNacional = decimal.Parse(datos[4]);

			PrecioServicioPaisLimitrofe = decimal.Parse(datos[5]);
			PrecioServicioRestoAmerica = decimal.Parse(datos[6]);
			PrecioServicioAmericaNorte = decimal.Parse(datos[7]);
			PrecioServicioEuropa = decimal.Parse(datos[8]);
			PrecioServicioAsia = decimal.Parse(datos[9]);
			PrecioServicioRestoMundo = decimal.Parse(datos[10]);

			PrecioServicioUrgente = decimal.Parse(datos[11],new CultureInfo("es-ES"));
			PrecioServicioEnPuerta = decimal.Parse(datos[12],new CultureInfo("es-ES"));
			PrecioServicioEnSucursal = decimal.Parse(datos[13],new CultureInfo("es-ES"));

			PrecioServicio500g = decimal.Parse(datos[14]);
			PrecioServicio10Kg = decimal.Parse(datos[15]);
			PrecioServicio20Kg = decimal.Parse(datos[16]);
			PrecioServicio30Kg = decimal.Parse(datos[17]);
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

		public static ServicioPrecio Recargo(bool entrada)
		{
			var modelo = new ServicioPrecio();
			modelo.Bool = entrada;
			return modelo;
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
