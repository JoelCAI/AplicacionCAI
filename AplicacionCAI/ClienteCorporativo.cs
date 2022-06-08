using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class ClienteCorporativo
    {
		private long _cuit;
		private string _razonSocial;
		private string _clave;

		public long Cuit
		{
			get { return this._cuit; }
			set { this._cuit = value; }
		}

		public string RazonSocial
		{
			get { return this._razonSocial; }
			set { this._razonSocial = value; }
		}
		public string Clave
		{
			get { return this._clave; }
			set { this._clave = value; }
		}

		public ClienteCorporativo(long cuit, string razonSocial, string clave)
		{
			this._cuit = cuit;
			this._razonSocial = razonSocial;
			this._clave = clave;
		}
	}
}
