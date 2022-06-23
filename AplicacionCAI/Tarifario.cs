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
	    public string IdServicio { get; }
	    public decimal P500g { get; }
	    public decimal P10Kg { get; }
	    public decimal P20Kg { get; }
	    public decimal P30Kg { get; }
	    private bool Bool { get; set; }
	    public decimal RecargoUrgencia { get; }
	    public decimal RecargoRetiroPuerta { get; }
	    public decimal RecargoEntregaPuerta { get; }
	    public decimal TopeUrgente { get; }

	    
		public TarifaPorPeso()
		{

		}

		public TarifaPorPeso(string linea)
		{

			var datos = linea.Split(';');
			
			IdServicio = datos[0];
			
			P500g = decimal.Parse(datos[1],new CultureInfo("es-ES")); 
			P10Kg = decimal.Parse(datos[2],new CultureInfo("es-ES")); 
			P20Kg = decimal.Parse(datos[3],new CultureInfo("es-ES"));
			P30Kg = decimal.Parse(datos[4],new CultureInfo("es-ES"));
			
			RecargoUrgencia = decimal.Parse(datos[5],new CultureInfo("es-ES"));
			RecargoRetiroPuerta = decimal.Parse(datos[6],new CultureInfo("es-ES"));
			RecargoEntregaPuerta = decimal.Parse(datos[7],new CultureInfo("es-ES"));
			TopeUrgente = decimal.Parse(datos[8],new CultureInfo("es-ES"));

		}
		
		public static TarifaPorPeso Recargo(bool entrada)
		{
			var modelo = new TarifaPorPeso();
			modelo.Bool = entrada;
			return modelo;
		}
		public static TarifaPorPeso MaxRecargo()
		{
			var modelo = new TarifaPorPeso();
			return modelo;
		}

    }
}
