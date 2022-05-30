using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Pedido
    {
        
        private decimal _recargoUrgente;
        private decimal _retiroPuertaSucursal;
        private decimal _recargoEnvioInternacional;
        private decimal _subTotal;
        private decimal _total;

        private int _cartaPorteNumero;
        private string _cartaPorteContenido;

        private int _HojaRutaNumero;
        private string _HojaRutaContenido;

        private string nombreClienteCorporativo;



        public const string estadoRecibido = "R";
        public const string estadoEnTransito = "T";
        public const string estadoCerrado = "C";

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

        public string Estado
        {
            set
            {
                if(value == estadoRecibido || value == estadoEnTransito || value == estadoCerrado)
                {
                    Estado = value;
                }
            }
        }

        public void CalcularRecargo()
        {

        }

        public void CalcularTotal()
        {

        }
    }
}
