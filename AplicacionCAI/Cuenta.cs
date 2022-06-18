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

        public static Cuenta CrearModeloBusqueda(int codigoCliente)
        {
            var modelo = new Cuenta();


            modelo.CodigoCliente = codigoCliente;


            return modelo;
        }

        public static Cuenta CrearModeloBusquedaClienteEstado(int codigoCliente, string estado)
        {
            var modelo = new Cuenta();


            modelo.codigoCliente = codigoCliente;
            modelo.estado = estado;


            return modelo;
        }

        public bool CoincideCon(Cuenta modelo)
        {
            if (modelo.codigoCliente != 0 && codigoCliente != modelo.codigoCliente)
            {
                return false;
            }

            return true;
        }


        public bool CoincideClienteEstado(Cuenta modelo)
        {

            if (codigoCliente != modelo.codigoCliente || estado != modelo.estado)
            {
                return false;
            }

            return true;
        }





    }
}
