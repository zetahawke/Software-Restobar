using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Cuenta
    {
         private int ID_Cuenta;
        private int Mesa;
        private string nombre;
        private int expirada;

        public Cuenta()
        {
            this.ID_Cuenta = 0;
            this.Mesa = 0;
            this.nombre = "";
            this.expirada = 0;
        }

        public Cuenta(int ID_Cuenta, int Mesa, string nombre,int expirada)
        {
            this.ID_Cuenta = ID_Cuenta;
            this.Mesa = Mesa;
            this.nombre = nombre;
            this.expirada = expirada;
        }

        public int _ID_Cuenta
        {
            set { this.ID_Cuenta = value; }
            get { return ID_Cuenta; }
        }

        public int _Mesa
        {
            set { this.Mesa = value; }
            get { return Mesa; } 
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; }
        }

        public int _expirada
        {
            set { this.expirada = value; }
            get { return expirada; }
        }
    }
}
