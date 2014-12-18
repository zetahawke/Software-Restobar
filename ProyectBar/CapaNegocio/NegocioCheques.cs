using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioCheques
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

         public NegocioCheques()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Cheques";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarCheques(Cheques cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._idChequeaPago + "," +
                cli._boleta + ",'" +
                cli._banco + "','" +
                cli._plaza + "','" +
                cli._CuentaCorriente + "'," +
                cli._MontoCheque + "," +
                cli._NumeroCheque + ",'" +
                cli._telefono + "','" +
                cli._NombrePersona + "','" +
                cli._rutPersona + "','" +
                cli._Fecha + "'," +
                cli._Cuenta +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getCheques()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cheques ca = new Cheques();
                ca._idChequeaPago = int.Parse(dr["idChequeaPago"].ToString());
                ca._boleta = int.Parse(dr["boleta"].ToString());
                ca._banco = (string)dr["banco"];
                ca._plaza = (string)dr["plaza"];
                ca._CuentaCorriente = (string)dr["CuentaCorriente"];
                ca._MontoCheque = int.Parse(dr["MontoCheque"].ToString());
                ca._NumeroCheque = int.Parse(dr["NumeroCheque"].ToString());
                ca._telefono = (string)dr["telefono"];
                ca._NombrePersona = (string)dr["NombrePersona"];
                ca._rutPersona = (string)dr["rutPersona"];
                ca._Fecha = (string)dr["Fecha"];
                ca._Cuenta = int.Parse(dr["Cuenta"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getChequesxCuenta(int id)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Cuenta = " + id;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cheques ca = new Cheques();
                ca._idChequeaPago = int.Parse(dr["idChequeaPago"].ToString());
                ca._boleta = int.Parse(dr["boleta"].ToString());
                ca._banco = (string)dr["banco"];
                ca._plaza = (string)dr["plaza"];
                ca._CuentaCorriente = (string)dr["CuentaCorriente"];
                ca._MontoCheque = int.Parse(dr["MontoCheque"].ToString());
                ca._NumeroCheque = int.Parse(dr["NumeroCheque"].ToString());
                ca._telefono = (string)dr["telefono"];
                ca._NombrePersona = (string)dr["NombrePersona"];
                ca._rutPersona = (string)dr["rutPersona"];
                ca._Fecha = (string)dr["Fecha"];
                ca._Cuenta = int.Parse(dr["Cuenta"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Cheques buscarCheque(int idCliente)
        {

            Cheques cli = new Cheques();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where idChequeaPago = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._idChequeaPago = int.Parse(dt.Rows[0][0].ToString());
                cli._boleta = int.Parse(dt.Rows[0][1].ToString());
                cli._banco = (string)dt.Rows[0][2].ToString();
                cli._plaza = (string)dt.Rows[0][3].ToString();
                cli._CuentaCorriente = (string)dt.Rows[0][4].ToString();
                cli._MontoCheque = int.Parse(dt.Rows[0][5].ToString());
                cli._NumeroCheque = int.Parse(dt.Rows[0][6].ToString());
                cli._telefono = (string)dt.Rows[0][7].ToString();
                cli._NombrePersona = (string)dt.Rows[0][8].ToString();
                cli._rutPersona = (string)dt.Rows[0][9].ToString();
                cli._Fecha = (string)dt.Rows[0][10].ToString();
                cli._Cuenta = int.Parse(dt.Rows[0][11].ToString());
            }
            catch (Exception e)
            {
                cli._idChequeaPago = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarCheque(Cheques cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set idChequeaPago=" + cli._idChequeaPago + "," +
                        "boleta='" + cli._boleta + "'," +
                        "banco='" + cli._banco + "'," +
                        "plaza='" + cli._plaza + "'," +
                        "CuentaCorriente='" + cli._CuentaCorriente + "'," +
                        "MontoCheque=" + cli._MontoCheque + "," +
                        "NumeroCheque=" + cli._NumeroCheque + "," +
                        "telefono='" + cli._telefono + "'," +
                        "NombrePersona='" + cli._NombrePersona + "'," +
                        "rutPersona='" + cli._rutPersona + "'," +
                        "Fecha='" + cli._Fecha + "'," +
                        "Cuenta='" + cli._Cuenta +
                        "' where idChequeaPago=" + cli._idChequeaPago;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCheque(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where idChequeaPago=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
