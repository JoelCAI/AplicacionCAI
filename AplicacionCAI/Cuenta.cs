using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Cuenta
    {
        public int codigoCliente;
        public int numeroFactura;
        public decimal saldoCliente;
        public string estado;
        public long cuitCliente;

        public int CodigoCliente
        {
            get { return this.codigoCliente; }
            set { this.codigoCliente = value; }
        }

        public int NumeroFactura
        {
            get { return this.numeroFactura; }
            set { this.numeroFactura = value; }
        }

        public decimal SaldoCliente
        {
            get { return this.saldoCliente; }
            set { this.saldoCliente = value; }
        }

        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public Cuenta()
        {

        }

        public Cuenta(string linea)
        {
            var datos = linea.Split(';');
            CodigoCliente = int.Parse(datos[0]);
            NumeroFactura = int.Parse(datos[1]);
            SaldoCliente = decimal.Parse(datos[2]);
            Estado = datos[3];
        }

        public static Cuenta CrearModeloBusqueda(long cuit)
        {
            var modelo = new Cuenta();


            modelo.cuitCliente = cuit;


            return modelo;
        }

        public static Cuenta CrearModeloBusquedaClienteEstado(long cuitCliente, string estado)
        {
            var modelo = new Cuenta();


            modelo.cuitCliente = cuitCliente;
            modelo.estado = estado;


            return modelo;
        }


        public bool CoincideCuenta(Cuenta modelo)
        {
            if (modelo.cuitCliente != 0 && cuitCliente != modelo.cuitCliente)
            {
                return false;
            }

            return true;
        }

        public bool CoincideClienteEstado(Cuenta modelo)
        {

            if (cuitCliente != modelo.cuitCliente || estado != modelo.estado)
            {
                return false;
            }

            return true;
        }
        
    }
}