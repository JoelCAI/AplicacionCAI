using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Cuenta
    {
        public int operacionCuenta;

        public long cuitCliente;
        public int numeroFactura;
        public decimal saldoCliente;
        public string estado;

        public DateTime fecha;
        public string razonSocial;

        public int OperacionCuenta
        {
            get { return this.operacionCuenta; }
            set { this.operacionCuenta = value; }
        }

        public long CuitCliente
        {
            get { return this.cuitCliente; }
            set { this.cuitCliente = value; }
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
        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public string RazonSocial
        {
            get { return this.razonSocial; }
            set { this.razonSocial = value; }
        }
        
        public Cuenta(string linea)
        {
            var datos = linea.Split(';');
            OperacionCuenta = int.Parse(datos[0]);
            CuitCliente = long.Parse(datos[1]);
            NumeroFactura = int.Parse(datos[2]);
            SaldoCliente = decimal.Parse(datos[3],new CultureInfo("es-ES"));
            Estado = datos[4];

            Fecha = DateTime.Parse(datos[5]);
            RazonSocial = datos[6];

        }

    }
}
