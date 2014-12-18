using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Ingredientes
    {
         private int ID_Ingredientes;
        private string nombre;

        public Ingredientes()
        {
            this.ID_Ingredientes = 0;
            this.nombre = "";
        }

        public Ingredientes(int ID_Ingredientes, string nombre)
        {
            this.ID_Ingredientes = ID_Ingredientes;
            this.nombre = nombre;
        }

        public int _ID_Ingredientes
        {
            set { this.ID_Ingredientes = value; }
            get { return ID_Ingredientes; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }
    }
}
