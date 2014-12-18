using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class RazonesEliminacion
    {
        private string Razon;

        public RazonesEliminacion()
        {
            this.Razon = "";
        }

        public RazonesEliminacion(string Razon)
        {
            this.Razon = Razon;
        }

        public string _Razon
        {
            set { this.Razon = value; }
            get { return Razon; }
        }
    }
}
