using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class VentasXTerminal
    {
        private int id_Venta;
        private string FechaInicio;
        private int totalVendido;
        private int totalInicial;
        private string FechaTermino;
        private int efectivo;
        private int tarjetas;
        private int cheques;
        private int descuento;
        private int devoluciones;
        private int terminal;

        public VentasXTerminal()
        {
            this.id_Venta = 0;
            this.FechaInicio = "";
            this.totalVendido = 0;
            this.totalInicial = 0;
            this.FechaTermino = "";
            this.efectivo = 0;
            this.tarjetas = 0;
            this.cheques = 0;
            this.descuento = 0;
            this.devoluciones = 0;
            this.terminal = 0;
        }

        public VentasXTerminal(int id_Venta, string FechaInicio, int totalVendido, int totalInicial, string FechaTermino, int efectivo, int tarjetas
            , int cheques, int descuento, int devoluciones, int terminal)
        {
            this.id_Venta = id_Venta;
            this.FechaInicio = FechaInicio;
            this.totalVendido = totalVendido;
            this.totalInicial = totalInicial;
            this.FechaTermino = FechaTermino;
            this.efectivo = efectivo;
            this.tarjetas = tarjetas;
            this.cheques = cheques;
            this.descuento = descuento;
            this.devoluciones = devoluciones;
            this.terminal = terminal;
        }

        public int _id_Venta
        {
            set { this.id_Venta = value; }
            get { return id_Venta; }
        }

        public string _FechaInicio
        {
            set { this.FechaInicio = value; }
            get { return FechaInicio; } 
        }

        public int _totalVendido
        {
            set { this.totalVendido = value; }
            get { return totalVendido; }
        }

        public int _totalInicial
        {
            set { this.totalInicial = value; }
            get { return totalInicial; }
        }

        public string _FechaTermino
        {
            set { this.FechaTermino = value; }
            get { return FechaTermino; }
        }

        public int _efectivo
        {
            set { this.efectivo = value; }
            get { return efectivo; }
        }

        public int _tarjetas
        {
            set { this.tarjetas = value; }
            get { return tarjetas; }
        }

        public int _cheques
        {
            set { this.cheques = value; }
            get { return cheques; }
        }

        public int _descuento
        {
            set { this.descuento = value; }
            get { return descuento; }
        }

        public int _devoluciones
        {
            set { this.devoluciones = value; }
            get { return devoluciones; }
        }

        public int _terminal
        {
            set { this.terminal = value; }
            get { return terminal; }
        }
    }
}
