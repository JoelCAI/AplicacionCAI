using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionCAI
{
    internal class Item
    {
        private int _registroItem;
        private string _codigoItem;
        private string _nombreItem;
        private int _cantidadItem;
        private decimal _precioItem;
        private decimal _pesoItem;
        private string _distanciaItem;
        private long _cuitItem;

        public int RegistroItem
        {
            get { return this._registroItem; }
           
        }

        public string CodigoItem
        {
            get { return this._codigoItem; }
            
        }
        public string NombreItem
        {
            get { return this._nombreItem; }
            
        }

        public int CantidadItem
        {
            get { return this._cantidadItem; }
            
        }

        public decimal PrecioItem
        {
            get { return this._precioItem; }
            
        }

        public decimal PesoItem
        {
            get { return this._pesoItem; }
            
        }

        public string DistanciaItem
        {
            get { return this._distanciaItem; }

        }

        public long CuitItem
        {
            get { return this._cuitItem; }

        }

        public static int _registroItemContador = 1;
        public Item(string codigoItem, string nombreItem, int cantidadItem,
                    decimal precioItem, decimal pesoItem, string distanciaItem,
                    long cuitItem)
        {
            this._codigoItem = codigoItem;
            this._nombreItem = nombreItem;
            this._cantidadItem = cantidadItem;
            this._precioItem = precioItem;
            this._pesoItem = pesoItem;
            this._distanciaItem = distanciaItem;
            this._cuitItem = cuitItem;

            this._registroItem = _registroItemContador;
            _registroItemContador++;


        }
    }
}
