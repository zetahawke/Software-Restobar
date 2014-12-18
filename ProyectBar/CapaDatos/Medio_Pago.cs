using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Medio_Pago
    {
         private int ID_Medio;
        private string nombre;
        private string descripcion;

        public Medio_Pago()
        {
            this.ID_Medio = 0;
            this.nombre = "";
            this.descripcion = "";
        }

        public Medio_Pago(int ID_Medio, string nombre, string descripcion)
        {
            this.ID_Medio = ID_Medio;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int _ID_Medio
        {
            set { this.ID_Medio = value; }
            get { return ID_Medio; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }

        public string _descripcion
        {
            set { this.descripcion = value; }
            get { return descripcion; }
        }
    }
}
