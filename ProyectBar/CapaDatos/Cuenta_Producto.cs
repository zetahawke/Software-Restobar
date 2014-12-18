using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Cuenta_Producto
    {
         private int ID_Lista;
        private int Cuenta;
        private int producto;
        private string observacion;
        private int cantidad;
        private int expirada;

        public Cuenta_Producto()
        {
            this.ID_Lista = 0;
            this.Cuenta = 0;
            this.producto = 0;
            this.observacion = "";
            this.cantidad = 0;
            this.expirada = 0;
        }

        public Cuenta_Producto(int ID_Lista, int Cuenta, int producto, string observacion, int cantidad , int expirada)
        {
            this.ID_Lista = ID_Lista;
            this.Cuenta = Cuenta;
            this.producto = producto;
            this.observacion = observacion;
            this.cantidad = cantidad;
            this.expirada = expirada;
        }

        public int _ID_Lista
        {
            set { this.ID_Lista = value; }
            get { return ID_Lista; }
        }

        public int _Cuenta
        {
            set { this.Cuenta = value; }
            get { return Cuenta; } 
        }

        public int _producto
        {
            set { this.producto = value; }
            get { return producto; }
        }

        public string _observacion
        {
            set { this.observacion = value; }
            get { return observacion; }
        }

        public int _cantidad
        {
            set { this.cantidad = value; }
            get { return cantidad; }
        }

        public int _expirada
        {
            set { this.expirada = value; }
            get { return expirada; }
        }
    }
}
