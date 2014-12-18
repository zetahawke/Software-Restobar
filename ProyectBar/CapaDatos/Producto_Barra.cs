using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Producto_Barra
    {
        private int ID_ProductoBarra;
        private int Barra;
        private int cantidadBarra;
        private int ingrediente;
        private int bodegaCentral;

        public Producto_Barra()
        {
            this.ID_ProductoBarra = 0;
            this.Barra = 0;
            this.cantidadBarra = 0;
            this.ingrediente = 0;
            this.bodegaCentral = 0;
        }

        public Producto_Barra(int ID_ProductoBarra, int Barra, int cantidadBarra, int ingrediente, int bodegaCentral)
        {
            this.ID_ProductoBarra = ID_ProductoBarra;
            this.Barra = Barra;
            this.cantidadBarra = cantidadBarra;
            this.ingrediente = ingrediente;
        }

        public int _ID_ProductoBarra
        {
            set { this.ID_ProductoBarra = value; }
            get { return ID_ProductoBarra; }
        }

        public int _Barra
        {
            set { this.Barra = value; }
            get { return Barra; }
        }

        public int _cantidadBarra
        {
            set { this.cantidadBarra = value; }
            get { return cantidadBarra; }
        }

        public int _ingrediente
        {
            set { this.ingrediente = value; }
            get { return ingrediente; }
        }

        public int _bodegaCentral
        {
            set { this.bodegaCentral = value; }
            get { return bodegaCentral; }
        }
    }
}
