using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Mesa
    {
         private int ID_Mesa;
        private int sector;
        private int estado;
        private string llegada;
        private string estadia;
        private string salida;

        public Mesa()
        {
            this.ID_Mesa = 0;
            this.sector = 0;
            this.estado = 0;
            this.llegada = "";
            this.estadia = "";
            this.salida = "";
        }

        public Mesa(int ID_Mesa, int sector, int estado, string llegada, string estadia, string salida)
        {
            this.ID_Mesa = ID_Mesa;
            this.sector = sector;
            this.estado = estado;
            this.llegada = llegada;
            this.estadia = estadia;
            this.salida = salida;
        }

        public int _ID_Mesa
        {
            set { this.ID_Mesa = value; }
            get { return ID_Mesa; }
        }

        public int _sector
        {
            set { this.sector = value; }
            get { return sector; } 
        }

        public int _estado
        {
            set { this.estado = value; }
            get { return estado; }
        }

        public string _llegada
        {
            set { this.llegada = value; }
            get { return llegada; }
        }

        public string _estadia
        {
            set { this.estadia = value; }
            get { return estadia; }
        }

        public string _salida
        {
            set { this.salida = value; }
            get { return salida; }
        }
    }
}
