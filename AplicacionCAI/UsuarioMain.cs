using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class UsuarioMain : Usuario
    {
        public UsuarioMain(string nombre, string clave, List<Producto> producto) : base(nombre, clave)
        {
            this._producto = producto;
        }

        protected List<Producto> _producto;

        public List<Producto> Producto
        {
            get { return this._producto; }
            set { this._producto = value; }
        }


		public void MenuMain(List<Producto> producto)
		{
			Producto = producto; 
			int opcion;
			do
			{

				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menu del Sistema" +
									   "\n [1] Crear Producto." +
									   "\n [2] Eliminar Producto." +
									   "\n [3] Editar Producto." +
									   "\n [4] Ver Productos." +
									   "\n [5] Volver al menu Principal.", 1, 6);

				switch (opcion)
				{
					case 1:
						CrearProducto();
						break;
					case 2:
						
						break;
					case 3:
						
						break;
					case 4:
						
						break;
					case 5:
						break;
				}
			} while (opcion != 5);
		}

		protected override void CrearProducto()
        {

        }
	}
}
