using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class UsuarioCorporativo : UsuarioMain
    {


		private List<Pedido> _pedido;
		private List<Factura> _factura;

		public UsuarioCorporativo(string nombre, string clave, List<Producto> producto,
								  List<Pedido> pedido, List<Factura> factura) : base(nombre, clave, producto)
        {
			this._pedido = pedido;
			this._factura = factura;
		}

		public List<Pedido> Pedido
		{
			get { return this._pedido; }
			set { this._pedido = value; }
		}

		public List<Factura> Factura
		{
			get { return this._factura; }
			set { this._factura = value; }
		}

		public void MenuCorporativo(List<Producto> producto, List<Pedido> pedido, List<Factura> factura)
		{
			/* Se reciben los productos de la Clase Producto a través de la herencia de UsuarioMain */
			Producto = producto;
			Pedido = pedido;
			Factura = factura;
			int opcion;
			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menu del Usuario Corporativo" +
									   "\n [1] Crear Pedido." +
									   "\n [2] Emitir Factura." +
									   "\n [3] ." +
									   "\n [4] ." +
									   "\n [5] ." +
									   "\n [6] Volver al menu Principal.", 1, 6);

				switch (opcion)
				{
					case 1:
						
						break;
					case 2:
						
						break;
					case 3:
						
						break;
					case 4:
						
						break;
					case 5:
						break;
					case 6:
						break;
				}
			} while (opcion != 6);

		}

		
    }
}
