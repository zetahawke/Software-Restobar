using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Lista_Ingredientes
    {
        private int ID_Lista;
        private int producto;
        private int ingrediente;
        private int cantidad;

        public Lista_Ingredientes()
        {
            this.ID_Lista = 0;
            this.producto = 0;
            this.ingrediente = 0;
            this.cantidad = 0;
        }

        public Lista_Ingredientes(int ID_Lista, int producto, int ingrediente, int cantidad)
        {
            this.ID_Lista = ID_Lista;
            this.producto = producto;
            this.ingrediente = ingrediente;
            this.cantidad = cantidad;
        }

        public int _ID_Lista
        {
            set { this.ID_Lista = value; }
            get { return ID_Lista; }
        }

        public int _producto
        {
            set { this.producto = value; }
            get { return producto; } 
        }

        public int _ingrediente
        {
            set { this.ingrediente = value; }
            get { return ingrediente; }
        }

        public int _cantidad
        {
            set { this.cantidad = value; }
            get { return cantidad; }
        }
    }
}
