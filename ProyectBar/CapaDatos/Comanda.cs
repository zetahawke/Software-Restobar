using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Comanda
    {
         private int ID_Comanda;
        private int Pedido;
        private string detalle;
        private int expirada;

        public Comanda()
        {
            this.ID_Comanda = 0;
            this.Pedido = 0;
            this.detalle = "";
            this.expirada = 0;
        }

        public Comanda(int ID_Comanda, int Pedido, string detalle , int expirada)
        {
            this.ID_Comanda = ID_Comanda;
            this.Pedido = Pedido;
            this.detalle = detalle;
            this.expirada = expirada;
        }

        public int _ID_Comanda
        {
            set { this.ID_Comanda = value; }
            get { return ID_Comanda; }
        }

        public int _Pedido
        {
            set { this.Pedido = value; }
            get { return Pedido; } 
        }

        public string _detalle
        {
            set { this.detalle = value; }
            get { return detalle; }
        }

        public int _expirada
        {
            set { this.expirada = value; }
            get { return expirada; }
        }
    }
}
