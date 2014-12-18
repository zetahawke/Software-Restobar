using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Usuario
    {
         private string Contraseña;
        private string nombre;
        private string rut;
        private string apellido;
        private int privilegio;

        public Usuario()
        {
            this.Contraseña = "";
            this.nombre = "";
            this.rut = "";
            this.apellido = "";
            this.privilegio = 0;
        }

        public Usuario(string Contraseña, string nombre, string rut, string apellido, int privilegio)
        {
            this.Contraseña = Contraseña;
            this.nombre = nombre;
            this.rut = rut;
            this.apellido = apellido;
            this.privilegio = privilegio;
        }

        public string _Contraseña
        {
            set { this.Contraseña = value; }
            get { return Contraseña; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }

        public string _rut
        {
            set { this.rut = value; }
            get { return rut; }
        }

        public string _apellido
        {
            set { this.apellido = value; }
            get { return apellido; }
        }

        public int _privilegio
        {
            set { this.privilegio = value; }
            get { return privilegio; }
        }
    }
}
