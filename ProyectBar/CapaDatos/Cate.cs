using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Cate
    {
         private int ID_Cate;
        private string nombre;


        public Cate()
        {
            this.ID_Cate = 0;
            this.nombre = "";
        }

        public Cate(int ID_Cate, string nombre)
        {
            this.ID_Cate = ID_Cate;
            this.nombre = nombre;
        }

        public int _ID_Cate
        {
            set { this.ID_Cate = value; }
            get { return ID_Cate; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }
    }
}
