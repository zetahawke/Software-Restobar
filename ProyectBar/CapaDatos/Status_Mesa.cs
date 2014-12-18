using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Status_Mesa
    {
         private int ID_Estado;
        private string Descripcion;

        public Status_Mesa()
        {
            this.ID_Estado = 0;
            this.Descripcion = "";
        }

        public Status_Mesa(int ID_Estado, string Descripcion)
        {
            this.ID_Estado = ID_Estado;
            this.Descripcion = Descripcion;
        }

        public int _ID_Estado
        {
            set { this.ID_Estado = value; }
            get { return ID_Estado; }
        }

        public string _Descripcion
        {
            set { this.Descripcion = value; }
            get { return Descripcion; } 
        }
    }
}
