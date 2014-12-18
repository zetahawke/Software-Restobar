using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Boleta
    {
        private int ID_Boleta;
        private string Fecha;
        private int Terminal;
        private string hora;
        private int tipo_boleta;

        public Boleta()
        {
            this.ID_Boleta = 0;
            this.Fecha = "";
            this.Terminal = 0;
            this.hora = "";
            this.tipo_boleta = 0;
        }

        public Boleta(int ID_Boleta, string Fecha, int Terminal, string hora , int tipo_boleta)
        {
            this.ID_Boleta = ID_Boleta;
            this.Fecha = Fecha;
            this.Terminal = Terminal;
            this.hora = hora;
            this.tipo_boleta = tipo_boleta;
        }

        public int _ID_Boleta
        {
            set { this.ID_Boleta = value; }
            get { return ID_Boleta; }
        }

        public string _Fecha
        {
            set { this.Fecha = value; }
            get { return Fecha; } 
        }

        public int _Terminal
        {
            set { this.Terminal = value; }
            get { return Terminal; }
        }

        public string _hora
        {
            set { this.hora = value; }
            get { return hora; }
        }

        public int _tipo_boleta
        {
            set { this.tipo_boleta = value; }
            get { return tipo_boleta; }
        }
    }
}
