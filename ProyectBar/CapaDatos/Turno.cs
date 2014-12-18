using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Turno
    {
        private string Usuario;
        private string Inicio;
        private string Fin;

        public Turno()
        {
            this.Usuario = "";
            this.Inicio = "";
            this.Fin = "";
        }

        public Turno(string Usuario, string Inicio, string Fin)
        {
            this.Usuario = Usuario;
            this.Inicio = Inicio;
            this.Fin = Fin;
        }

        public string _Usuario
        {
            set { this.Usuario = value; }
            get { return Usuario; }
        }

        public string _Inicio
        {
            set { this.Inicio = value; }
            get { return Inicio; }

        }

        public string _Fin
        {
            set { this.Fin = value; }
            get { return Fin; }

        }
    }
}
