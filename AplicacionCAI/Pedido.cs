using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Pedido
    {
        private int _codigoPedido;
        private decimal _recargoUrgente;
        private decimal _retiroPuertaSucursal;
        private decimal _recargoEnvioInternacional;
        private decimal _subTotal;
        private decimal _total;

        private int _cartaPorteCodigo;
        private string _cartaPorteContenido;

        private int _hojaRutaCodigo;
        private string _hojaRutaContenido;

        private int cuitClienteCorporativo;
        private string nombreClienteCorporativo;

        public const string _estadoRecibido = "R";
        public const string _estadoEnTransito = "T";
        public const string _estadoCerrado = "C";

        

        public int CodigoPedido
        {
            get { return this._codigoPedido; }
            set { this._codigoPedido = value; }
        }

        public decimal RecargoUrgente
        {
            get { return this._recargoUrgente; }
            set { this._recargoUrgente = value; }
        }

        public decimal RetiroPuertaSucursal
        {
            get { return this._retiroPuertaSucursal; }
            set { this._retiroPuertaSucursal = value; }
        }

        public decimal RecargoEnvioInternacional
        {
            get { return this._recargoEnvioInternacional; }
            set { this._recargoEnvioInternacional = value; }
        }

        public decimal Subtotal
        {
            get { return this._subTotal; }
            set { this._subTotal = value; }
        }

        public decimal Total
        {
            get { return this._total; }
            set { this._total = value; }
        }

        public string EstadoPedido
        {
            set
            {
                if(value == _estadoRecibido || value == _estadoEnTransito || value == _estadoCerrado)
                {
                    EstadoPedido = value;
                }
            }
        }

        public void MostrarPedido()
        {

        }

        public void CalcularRecargo()
        {

        }

        public void CalcularTotal()
        {

        }
    }
}
