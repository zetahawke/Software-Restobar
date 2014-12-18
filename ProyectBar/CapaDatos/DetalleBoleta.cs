using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class DetalleBoleta
    {
         private int ID_Detalle;
        private int total;
        private int Cuenta;
        private string descripcion;
        private int Boleta;
        private int efectivo;
        private int subtotal;
        private int exento;
        private int descuento;
        private int propina;
        private int vuelto;

        public DetalleBoleta()
        {
            this.ID_Detalle = 0;
            this.total = 0;
            this.Cuenta = 0;
            this.descripcion = "";
            this.Boleta = 0;
            this.efectivo = 0;
            this.subtotal = 0;
            this.exento = 0;
            this.descuento = 0;
            this.propina = 0;
            this.vuelto = 0;
        }

        public DetalleBoleta(int ID_Detalle, int total, int Cuenta, string descripcion, int Boleta, int vuelto
            , int propina, int descuento, int exento, int efectivo, int subtotal)
        {
            this.ID_Detalle = ID_Detalle;
            this.total = total;
            this.Cuenta = Cuenta;
            this.descripcion = descripcion;
            this.Boleta = Boleta;
            this.efectivo = efectivo;
            this.subtotal = subtotal;
            this.exento = exento;
            this.descuento = descuento;
            this.propina = propina;
            this.vuelto = vuelto;
        }

        public int _ID_Detalle
        {
            set { this.ID_Detalle = value; }
            get { return ID_Detalle; }
        }

        public int _total
        {
            set { this.total = value; }
            get { return total; } 
        }

        public int _Cuenta
        {
            set { this.Cuenta = value; }
            get { return Cuenta; }
        }

        public string _descripcion
        {
            set { this.descripcion = value; }
            get { return descripcion; }
        }

        public int _Boleta
        {
            set { this.Boleta = value; }
            get { return Boleta; }
        }

        public int _efectivo
        {
            set { this.efectivo = value; }
            get { return efectivo; }
        }

        public int _subtotal
        {
            set { this.subtotal = value; }
            get { return subtotal; }
        }

        public int _exento
        {
            set { this.exento = value; }
            get { return exento; }
        }

        public int _descuento
        {
            set { this.descuento = value; }
            get { return descuento; }
        }

        public int _propina
        {
            set { this.propina = value; }
            get { return propina; }
        }

        public int _vuelto
        {
            set { this.vuelto = value; }
            get { return vuelto; }
        }
    }
}
