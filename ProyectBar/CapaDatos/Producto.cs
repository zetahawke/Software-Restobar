using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Producto
    {
         private int ID_Producto;
        private string nombre;
        private string descripcion;
        private int precio;
        private int categoria;
        private string InicioHappyHour;
        private string FinHappyHour;

        public Producto()
        {
            this.ID_Producto = 0;
            this.nombre = "";
            this.descripcion = "";
            this.precio = 0;
            this.categoria = 0;
            this.InicioHappyHour = "";
            this.FinHappyHour = "";
        }

        public Producto(int ID_Producto, string nombre, string descripcion, int precio, int categoria, string InicioHappyHour, string FinHappyHour)
        {
            this.ID_Producto = ID_Producto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.categoria = categoria;
            this.InicioHappyHour = InicioHappyHour;
            this.FinHappyHour = FinHappyHour;
        }

        public int _ID_Producto
        {
            set { this.ID_Producto = value; }
            get { return ID_Producto; }
        }

        public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; } 
        }

        public string _descripcion
        {
            set { this.descripcion = value; }
            get { return descripcion; }
        }

        public int _precio
        {
            set { this.precio = value; }
            get { return precio; }
        }

        public int _categoria
        {
            set { this.categoria = value; }
            get { return categoria; }
        }

        public string _InicioHappyHour
        {
            set { this.InicioHappyHour = value; }
            get { return InicioHappyHour; }
        }

        public string _FinHappyHour
        {
            set { this.FinHappyHour = value; }
            get { return FinHappyHour; }
        }
    }
}
