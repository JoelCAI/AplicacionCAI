using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
     class TarifaPorPeso
    {
	    public string IdServicio { get; set; }
	    public decimal P500g { get; }
	    public decimal P10Kg { get; }
	    public decimal P20Kg { get; }
	    public decimal P30Kg { get; }
	    public bool Bool { get; set; }
	    public decimal RecargoUrgencia { get; }
	    public decimal RecargoRetiroPuerta { get; }
	    public decimal RecargoEntregaPuerta { get; }
	    public decimal TopeUrgente { get; set; }

	    
		public TarifaPorPeso()
		{

		}

		public TarifaPorPeso(string linea)
		{

			var datos = linea.Split(';');
			
			IdServicio = datos[0];
			
			P500g = decimal.Parse(datos[1]); 
			P10Kg = decimal.Parse(datos[2]); 
			P20Kg = decimal.Parse(datos[3]);
			P30Kg = decimal.Parse(datos[4]);
			
			RecargoUrgencia = decimal.Parse(datos[5],new CultureInfo("es-ES"));
			RecargoRetiroPuerta = decimal.Parse(datos[6],new CultureInfo("es-ES"));
			RecargoEntregaPuerta = decimal.Parse(datos[7],new CultureInfo("es-ES"));
			TopeUrgente = decimal.Parse(datos[8],new CultureInfo("es-ES"));

		}
		
		public static TarifaPorPeso CrearNuevoServicio(string codigoNuevoProducto)
		{
			var producto = new TarifaPorPeso();
			return producto;
		}

		public string DatoServicioPrecio
		{
			get
			{
				return $"\n Código de Servicio es: {IdServicio},";
			}
		}

		public static TarifaPorPeso ValidarServicio()
		{
			var idServicio = new TarifaPorPeso();

			idServicio.IdServicio = "Local";

			return idServicio;
		}

		
		public static TarifaPorPeso Recargo(bool entrada)
		{
			var modelo = new TarifaPorPeso();
			modelo.Bool = entrada;
			return modelo;
		}
		
		public bool CompararServicioCoincidencia(TarifaPorPeso tarifaPorPeso)
		{

			if (tarifaPorPeso.IdServicio != "Local" && IdServicio != tarifaPorPeso.IdServicio)
			{
				return false;
			}

			return true;
		}
		


	}
}
