using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Pedido
    {
        private int ID_Pedido;
        private int Mesa;
        private string Garzon;
        private int expirado;

        public Pedido()
        {
            this.ID_Pedido = 0;
            this.Mesa = 0;
            this.Garzon = "";
            this.expirado = 0;
        }

        public Pedido(int ID_Pedido, int Mesa, string Garzon , int expirado)
        {
            this.ID_Pedido = ID_Pedido;
            this.Mesa = Mesa;
            this.Garzon = Garzon;
            this.expirado = expirado;
        }

        public int _ID_Pedido
        {
            set { this.ID_Pedido = value; }
            get { return ID_Pedido; }
        }

        public int _Mesa
        {
            set { this.Mesa = value; }
            get { return Mesa; } 
        }

        public string _Garzon
        {
            set { this.Garzon = value; }
            get { return Garzon; }
        }

        public int _expirado
        {
            set { this.expirado = value; }
            get { return expirado; }
        }
    }
}
