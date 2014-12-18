using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class ComandasEliminadas
    {
        private int ID_Comanda;
        private string Razon;
        private string otro;

        public ComandasEliminadas()
        {
            this.ID_Comanda = 0;
            this.Razon = "";
            this.otro = "";
        }

        public ComandasEliminadas(int ID_Comanda, string Razon, string otro)
        {
            this.ID_Comanda = ID_Comanda;
            this.Razon = Razon;
            this.otro = otro;
        }

        public int _ID_Comanda
        {
            set { this.ID_Comanda = value; }
            get { return ID_Comanda; }
        }

        public string _Razon
        {
            set { this.Razon = value; }
            get { return Razon; }
        }
        public string _otro
        {
            set { this.otro = value; }
            get { return otro; }
        }
    }
}
