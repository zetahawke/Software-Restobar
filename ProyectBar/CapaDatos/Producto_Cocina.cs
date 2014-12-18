using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
  public class Producto_Cocina
    {
        private int ID_ProductoCocina;
        private int Cocina;
        private int cantidadCocina;
        private int ingrediente;
        private int bodegaCentral;

        public Producto_Cocina()
        {
            this.ID_ProductoCocina = 0;
            this.Cocina = 0;
            this.cantidadCocina = 0;
            this.ingrediente = 0;
            this.bodegaCentral = 0;
        }

        public Producto_Cocina(int ID_ProductoCocina, int Cocina, int cantidadCocina, int ingrediente, int bodegaCentral)
        {
            this.ID_ProductoCocina = ID_ProductoCocina;
            this.Cocina = Cocina;
            this.cantidadCocina = cantidadCocina;
            this.ingrediente = ingrediente;
        }

        public int _ID_ProductoCocina
        {
            set { this.ID_ProductoCocina = value; }
            get { return ID_ProductoCocina; }
        }

        public int _Cocina
        {
            set { this.Cocina = value; }
            get { return Cocina; }
        }

        public int _cantidadCocina
        {
            set { this.cantidadCocina = value; }
            get { return cantidadCocina; }
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
