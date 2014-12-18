using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class TarjetaCredito
    {
        private int idPagoTarjeta;
        private int boleta;
        private string tipoTarjeta;
        private int numeroTarjeta;
        private int transaccion;
        private string rut;
        private string nombreTitutar;
        private int MontoAtarjeta;
        private int Cuenta;

        public TarjetaCredito()
        {
            this.idPagoTarjeta = 0;
            this.boleta = 0;
            this.tipoTarjeta = "";
            this.numeroTarjeta = 0;
            this.transaccion = 0;
            this.rut = "";
            this.nombreTitutar = "";
            this.MontoAtarjeta = 0;
            this.Cuenta = 0;
        }

        public TarjetaCredito(int idPagoTarjeta, int boleta, string tipoTarjeta, int numeroTarjeta, int transaccion, string rut
            , string nombreTitutar, int MontoAtarjeta , int Cuenta)
        {
            this.idPagoTarjeta = idPagoTarjeta;
            this.boleta = boleta;
            this.tipoTarjeta = tipoTarjeta;
            this.numeroTarjeta = numeroTarjeta;
            this.transaccion = transaccion;
            this.rut = rut;
            this.nombreTitutar = nombreTitutar;
            this.MontoAtarjeta = MontoAtarjeta;
            this.Cuenta = Cuenta;
        }

        public int _idPagoTarjeta
        {
            set { this.idPagoTarjeta = value; }
            get { return idPagoTarjeta; }
        }

        public int _boleta
        {
            set { this.boleta = value; }
            get { return boleta; } 
        }

        public string _tipoTarjeta
        {
            set { this.tipoTarjeta = value; }
            get { return tipoTarjeta; }
        }

        public int _numeroTarjeta
        {
            set { this.numeroTarjeta = value; }
            get { return numeroTarjeta; }
        }

        public int _transaccion
        {
            set { this.transaccion = value; }
            get { return transaccion; }
        }

        public string _rut
        {
            set { this.rut = value; }
            get { return rut; }
        }

        public string _nombreTitutar
        {
            set { this.nombreTitutar = value; }
            get { return nombreTitutar; }
        }

        public int _MontoAtarjeta
        {
            set { this.MontoAtarjeta = value; }
            get { return MontoAtarjeta; }
        }

        public int _Cuenta
        {
            set { this.Cuenta = value; }
            get { return Cuenta; }
        }
    }
}
