using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Sector
    {
         private int ID_Sector;
        private string nombre;

        public Sector()
        {
            this.ID_Sector = 0;
            this.nombre = "";
        }

        public Sector(int ID_Sector, string nombre)
        {
            this.ID_Sector = ID_Sector;
            this.nombre = nombre;
        }

        public int _ID_Sector
        {
            set { this.ID_Sector = value; }
            get { return ID_Sector; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }
    }
}
