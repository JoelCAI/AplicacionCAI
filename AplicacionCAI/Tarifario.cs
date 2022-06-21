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
	    public decimal P500g { get; }
	    public decimal P10Kg { get; }
	    public decimal P20Kg { get; }
	    public decimal P30Kg { get; }
	 
	    //public int PesoLimite { get; set; }
	    public decimal TarifaLocal { get; }
	    public decimal TarifaProvincial { get; }
	    public decimal PrecioServicioRestoAmerica { get; }
	    public decimal PrecioServicioAmericaNorte { get; }
	    public decimal PrecioServicioEuropa { get; }
	    public decimal PrecioServicioAsia { get; }
	    public decimal PrecioServicioRestoMundo { get; }

	    public bool Bool { get; set; }
	    public decimal RecargoUrgencia { get; }
	    public decimal RecargoRetiroPuerta { get; }
	    public decimal RecargoEntregaPuerta { get; }

	    public decimal TopeUrgente { get; set; }

	    
		public ServicioPrecio()
		{

		}

		public ServicioPrecio(string linea)
		{

			var datos = linea.Split(';');
			
			IdServicio = int.Parse(datos[0]);
			
			P500g = decimal.Parse(datos[1]); 
			P10Kg = decimal.Parse(datos[2]); 
			P20Kg = decimal.Parse(datos[3]);
			P30Kg = decimal.Parse(datos[4]);
			
			RecargoUrgencia = decimal.Parse(datos[5],new CultureInfo("es-ES"));
			RecargoRetiroPuerta = decimal.Parse(datos[6],new CultureInfo("es-ES"));
			RecargoEntregaPuerta = decimal.Parse(datos[7],new CultureInfo("es-ES"));
			TopeUrgente = decimal.Parse(datos[8],new CultureInfo("es-ES"));

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
