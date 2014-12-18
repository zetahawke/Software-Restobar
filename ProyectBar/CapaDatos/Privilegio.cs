using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    class Privilegio
    {

        int ID;
        string Nombre;
        int permitePago;
        int permiteEliminar;
        int permiteAnular;
        int permiteCambiarCuenta;
        int permiteDescuentos;
        int permiteIniciarSoftware;

        public Privilegio()
        {
            this.ID = 0;
            this.Nombre = "";
            this.permitePago = 0;
            this.permiteEliminar = 0;
            this.permiteAnular = 0;
            this.permiteCambiarCuenta = 0;
            this.permiteDescuentos = 0;
            this.permiteIniciarSoftware = 0;
        }

        public Privilegio(int id, string nombre, int permitePago, int permiteEliminar, int permiteAnular, int permiteCambiarCuenta, int permiteDescuentos, int permiteIniciarSoftware)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.permitePago = permitePago;
            this.permiteEliminar = permiteEliminar;
            this.permiteAnular = permiteAnular;
            this.permiteCambiarCuenta = permiteCambiarCuenta;
            this.permiteDescuentos = permiteDescuentos;
            this.permiteIniciarSoftware = permiteIniciarSoftware;
        }

        public int _ID
        {
            set { this.ID = value; }
            get { return ID; }
        }

        public string _Nombre
        {
            set { this.Nombre = value; }
            get { return Nombre; }
        }

        public int _PermitePago
        {
            set { this.permitePago = value; }
            get { return permitePago; }
        }

        public int _PermiteEliminar
        {
            set { this.permiteEliminar = value; }
            get { return permiteEliminar; }
        }

        public int _PermiteAnular
        {
            set { this.permiteAnular = value; }
            get { return permiteAnular; }
        }

        public int _PermiteCambiarCuenta
        {
            set { this.permiteCambiarCuenta = value; }
            get { return permiteCambiarCuenta; }
        }

        public int _PermiteDescuentos
        {
            set { this.permiteDescuentos = value; }
            get { return permiteDescuentos; }
        }

        public int _PermiteiniciarSoftware
        {
            set { this.permiteIniciarSoftware = value; }
            get { return permiteIniciarSoftware; }
        }
    }
}
