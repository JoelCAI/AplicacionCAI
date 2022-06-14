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

		public Producto()
        {

        }

		public Producto(string codigoProducto, string nombreProducto, decimal pesoProducto,
						decimal precioProducto, string distanciaProducto)
		{
			this._codigoProducto = codigoProducto;
			this._nombreProducto = nombreProducto;
			this._cantidadProducto = 1000;
			this._pesoProducto = pesoProducto;
			this._precioProducto = precioProducto;
			this._distanciaProducto = distanciaProducto;
		}

		public static Producto CrearNuevoProducto(string codigoNuevoProducto)
        {
			var producto = new Producto();
			return producto;
        }

		public void EditarProducto()
        {

        }

		public void BuscarProducto()
        {

        }

		public void VerProducto()
		{

		}

		public string DatosProducto
        {
			get
            {
				return $"\n Codigo de producto es: {CodigoProducto}," +
					   $"\n Nombre de Producto es: {NombreProducto},";
            }
        }



	}
}
