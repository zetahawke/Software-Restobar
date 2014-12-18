using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class Cheques
    {
        private int idChequeaPago;
        private int boleta;
        private string banco;
        private string plaza;
        private string CuentaCorriente;
        private int MontoCheque;
        private int NumeroCheque;
        private string telefono;
        private string NombrePersona;
        private string rutPersona;
        private string Fecha;
        private int Cuenta;

        public Cheques()
        {
            this.idChequeaPago = 0;
            this.boleta = 0;
            this.banco = "";
            this.plaza = "";
            this.CuentaCorriente = "";
            this.MontoCheque = 0;
            this.NumeroCheque = 0;
            this.telefono = "";
            this.NombrePersona = "";
            this.rutPersona = "";
            this.Fecha = "";
            this.Cuenta = 0;
        }

        public Cheques(int idChequeaPago, int boleta, string banco, string plaza, string CuentaCorriente, int MontoCheque
            , int NumeroCheque, string telefono, string NombrePersona, string rutPersona, string Fecha, int Cuenta)
        {
            this.idChequeaPago = idChequeaPago;
            this.boleta = boleta;
            this.banco = banco;
            this.plaza = plaza;
            this.CuentaCorriente = CuentaCorriente;
            this.MontoCheque = MontoCheque;
            this.NumeroCheque = NumeroCheque;
            this.telefono = telefono;
            this.NombrePersona = NombrePersona;
            this.rutPersona = rutPersona;
            this.Fecha = Fecha;
            this.Cuenta = Cuenta;
        }

        public int _idChequeaPago
        {
            set { this.idChequeaPago = value; }
            get { return idChequeaPago; }
        }

        public int _boleta
        {
            set { this.boleta = value; }
            get { return boleta; } 
        }

        public string _banco
        {
            set { this.banco = value; }
            get { return banco; }
        }

        public string _plaza
        {
            set { this.plaza = value; }
            get { return plaza; }
        }

        public string _CuentaCorriente
        {
            set { this.CuentaCorriente = value; }
            get { return CuentaCorriente; }
        }

        public int _MontoCheque
        {
            set { this.MontoCheque = value; }
            get { return MontoCheque; }
        }

        public int _NumeroCheque
        {
            set { this.NumeroCheque = value; }
            get { return NumeroCheque; }
        }

        public string _telefono
        {
            set { this.telefono = value; }
            get { return telefono; }
        }

        public string _NombrePersona
        {
            set { this.NombrePersona = value; }
            get { return NombrePersona; }
        }

        public string _rutPersona
        {
            set { this.rutPersona = value; }
            get { return rutPersona; }
        }

        public string _Fecha
        {
            set { this.Fecha = value; }
            get { return Fecha; }
        }

        public int _Cuenta
        {
            set { this.Cuenta = value; }
            get { return Cuenta; }
        }
    }
}
