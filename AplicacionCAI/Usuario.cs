using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal abstract class Usuario
    {
        protected int _registroUsuario;
        protected string _nombreUsuario;
        protected string _claveUsuario;

        public string NombreUsuario
        {
            get { return this._nombreUsuario; }
            set { this._nombreUsuario = value; }
        }
        public string ClaveUsuario
        {
            get { return this._claveUsuario; }
            set { this._claveUsuario = value; }
        }

        public int RegistroUsuario
        {
            get { return this._registroUsuario; }
        }

        public static int _registroUsuarioContador = 1;

        public Usuario(string nombre, string clave)
        {
            this._nombreUsuario = nombre;
            this._claveUsuario = clave;

            this._registroUsuario = _registroUsuarioContador;
            _registroUsuarioContador++;

        }

        protected abstract void CrearProducto();
    }
}
