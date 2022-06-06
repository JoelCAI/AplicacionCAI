using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Producto
    {
		private string _codigoProducto;
		private string _nombreProducto;
		private int _cantidadProducto;
		private decimal _pesoProducto;
		private decimal _precioProducto;
		private string _distanciaProducto;

		public string CodigoProducto
		{
			get { return this._codigoProducto; }
			set { this._codigoProducto = value; }
		}
		public string NombreProducto
		{
			get { return this._nombreProducto; }
			set { this._nombreProducto = value; }
		}
		public int CantidadProducto
		{
			get { return this._cantidadProducto; }
			set { this._cantidadProducto = value; }
		}

		public decimal PesoProducto
		{
			get { return this._pesoProducto; }
			set { this._pesoProducto = value; }
		}

		public decimal PrecioProducto
		{
			get { return this._precioProducto; }
			set { this._precioProducto = value; }
		}
		public string DistanciaProducto
		{
			get { return this._distanciaProducto; }
			set { this._distanciaProducto = value; }
		}

		public Producto(string codigoProducto, string nombreProducto, decimal pesoProducto,
						decimal precioProducto, string distanciaProducto)
		{
			this._codigoProducto = codigoProducto;
			this._nombreProducto = nombreProducto;
			this._cantidadProducto = 1;
			this._pesoProducto = pesoProducto;
			this._precioProducto = precioProducto;
			this._distanciaProducto = distanciaProducto;
		}

		public void CalcularPeso(decimal pesoProducto)
        {
			decimal sobreHasta500g = 0.5m;
			decimal bultoHasta10Kg = 10;
			decimal bultoHasta20Kg = 20;
			decimal bultoHasta30Kg = 30;

			decimal precioSobreHasta500g = 100;
			decimal precioBultoHasta10Kg = 200;
			decimal precioBultoHasta20Kg = 300;
			decimal precioBultoHasta30Kg = 400;

			if (pesoProducto <= sobreHasta500g)
            {
				this._precioProducto = precioSobreHasta500g;
            }
			else if (pesoProducto > sobreHasta500g && pesoProducto <= bultoHasta10Kg )
            {
				this._precioProducto = precioBultoHasta10Kg;
			}
			else if (pesoProducto > bultoHasta10Kg && pesoProducto <= bultoHasta20Kg)
			{
				this._precioProducto = precioBultoHasta20Kg;
			}
			else if (pesoProducto > bultoHasta20Kg && pesoProducto <= bultoHasta30Kg)
			{
				this._precioProducto = precioBultoHasta30Kg;
			}

		}

		public void CalcularDistancia(string distanciaProducto)
		{
			if (distanciaProducto == "LOCAL")
			{
				this._precioProducto = this._precioProducto + 50;
			}
			else if (distanciaProducto == "PROVINCIAL")
			{
				this._precioProducto = this._precioProducto + 100;
			}
			else if (distanciaProducto == "REGIONAL")
			{
				this._precioProducto = this._precioProducto + 150;
			}
			else if (distanciaProducto == "NACIONAL")
			{
				this._precioProducto = this._precioProducto + 200;
			}
		}
	}
}
