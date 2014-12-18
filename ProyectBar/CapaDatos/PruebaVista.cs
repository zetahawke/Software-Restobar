using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class PruebaVista
    {
        private int terminal;
        private int ID_Pedido;
        private int Mesa;
        private int sector;
        private string llegada;
        private string estadia;
        private string nombre;
        private string usunombre;
        private int producto;
        private string observacion;
        private int cantidad;

        public PruebaVista()
        {
            this.terminal = 0;
            this.ID_Pedido = 0;
            this.Mesa = 0;
            this.sector = 0;
            this.llegada = "";
            this.estadia = "";
            this.nombre = "";
            this.usunombre = "";
            this.producto = 0;
            this.observacion = "";
            this.cantidad = 0;
        }

         public PruebaVista(int terminal,int ID_Pedido,int Mesa,int sector,string llegada,string estadia,string nombre,
        string usunombre,int producto,string observacion,int cantidad)
        {
            this.terminal = terminal;
            this.ID_Pedido = ID_Pedido;
            this.Mesa = Mesa;
            this.sector = sector;
            this.llegada = llegada;
            this.estadia = estadia;
            this.nombre = nombre;
            this.usunombre = usunombre;
            this.producto = producto;
            this.observacion = observacion;
            this.cantidad = cantidad;
        }

         public int _terminal
        {
            set { this.terminal = value; }
            get { return terminal; }
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

         public int _sector
        {
            set { this.sector = value; }
            get { return sector; }
        }
         public string _llegada
        {
            set { this.llegada = value; }
            get { return llegada; }
        }

         public string _estadia
        {
            set { this.estadia = value; }
            get { return estadia; }
        }
         public string _nombre
        {
            set { this.nombre = value; }
            get { return nombre; }
        }
        
        public string _usunombre
        {
            set { this.usunombre = value; }
            get { return usunombre; }
        }

        public int _producto
        {
            set { this.producto = value; }
            get { return producto; }
        }
        public string _observacion
        {
            set { this.observacion = value; }
            get { return observacion; }
        }

        public int _cantidad
        {
            set { this.cantidad = value; }
            get { return cantidad; }
        }
    }
}
