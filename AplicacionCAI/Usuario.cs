using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Usuario
    {
	    private int dniUsuario;
		private string nombreUsuario;
	    private long cuitCorporativo;
		private string claveUsuario;
		private string razonSocial;

		public int DniUsuario
		{
			get { return this.dniUsuario; }
			set { this.dniUsuario = value; }
		}

		public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { this.nombreUsuario = value; }
        }

		public long CuitCorporativo
		{
			get { return this.cuitCorporativo; }
			set { this.cuitCorporativo = value; }
		}

		public string ClaveUsuario
        {
            get { return this.claveUsuario; }
            set { this.claveUsuario = value; }
        }
		public string RazonSocial
		{
			get { return this.razonSocial; }
			set { this.razonSocial = value; }
		}
		
		public Usuario()
        {

        }

        public Usuario(string linea)
        {
			
			var datos = linea.Split(';');
            dniUsuario = int.Parse(datos[0]);
            nombreUsuario = datos[1];
            cuitCorporativo = long.Parse(datos[2]);
            claveUsuario = datos[3];
			razonSocial = datos[4];

		}

		

		public static Usuario ValidarDni()
		{
			var dni = new Usuario();

			dni.DniUsuario = Validador.PedirIntMenuInicial("\n Por favor ingresar el numero de dni autorizado para continuar",1,99_999_999);
			
			return dni;
		}

		public static Usuario ValidarDniUnico()
		{
			var dni = new Usuario();

			dni.DniUsuario = 12345678;

			return dni;
		}

		public static Usuario ValidarClave()
		{
			var clave = new Usuario();

			clave.ClaveUsuario = Validador.PedirCaracterString("\n Por favor ingresar la clave del Usuario",0,16);


			return clave;
		}

		public bool CompararDniCoincidencia(Usuario modelo)
		{

			if (modelo.DniUsuario != 0 && DniUsuario != modelo.DniUsuario)
			{
				return false;
			}
			

			return true;
		}

		public bool CompararClaveCoincidencia(Usuario clave)
		{

			if (clave.ClaveUsuario != "" && ClaveUsuario != clave.ClaveUsuario)
			{
				return false;
			}

			return true;
		}

    }

}
