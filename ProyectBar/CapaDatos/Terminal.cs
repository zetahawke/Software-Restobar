using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Terminal
    {
         private int ID_Terminal;
        private int sector;
        private string descripcion;

        public Terminal()
        {
            this.ID_Terminal = 0;
            this.sector = 0;
            this.descripcion = "";
        }

        public Terminal(int ID_Terminal, int sector, string descripcion)
        {
            this.ID_Terminal = ID_Terminal;
            this.sector = sector;
            this.descripcion = descripcion;
        }

        public int _ID_Terminal
        {
            set { this.ID_Terminal = value; }
            get { return ID_Terminal; }
        }

        public int _sector
        {
            set { this.sector = value; }
            get { return sector; } 
        }

        public string _descripcion
        {
            set { this.descripcion = value; }
            get { return descripcion; }
        }
    }
}
