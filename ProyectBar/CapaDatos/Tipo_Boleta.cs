using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Tipo_Boleta
    {
         private int id_tipo;
        private string tipo;

        public Tipo_Boleta()
        {
            this.id_tipo = 0;
            this.tipo = "";
        }

        public Tipo_Boleta(int id_tipo, string tipo)
        {
            this.id_tipo = id_tipo;
            this.tipo = tipo;
        }

        public int _id_tipo
        {
            set { this.id_tipo = value; }
            get { return id_tipo; }
        }

        public string _tipo
        {
            set { this.tipo = value; }
            get { return tipo; }
        }
    }
}
