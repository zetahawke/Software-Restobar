using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioTarjetaCredito
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

         public NegocioTarjetaCredito()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "TarjetaDeCredito";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarTarjeta(TarjetaCredito cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._idPagoTarjeta + "," +
                cli._boleta + ",'" +
                cli._tipoTarjeta + "'," +
                cli._numeroTarjeta + "," +
                cli._transaccion + ",'" +
                cli._rut + "','" +
                cli._nombreTitutar + "'," +
                cli._MontoAtarjeta + "," +
                cli._Cuenta +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getTarjetas()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                TarjetaCredito ca = new TarjetaCredito();
                ca._idPagoTarjeta = int.Parse(dr["idPagoTarjeta"].ToString());
                ca._boleta = int.Parse(dr["boleta"].ToString());
                ca._tipoTarjeta = (string)dr["tipoTarjeta"];
                ca._numeroTarjeta = int.Parse(dr["numeroTarjeta"].ToString());
                ca._transaccion = int.Parse(dr["transaccion"].ToString());
                ca._rut = (string)dr["rut"];
                ca._nombreTitutar = (string)dr["nombreTitutar"];
                ca._MontoAtarjeta = int.Parse(dr["MontoAtarjeta"].ToString());
                ca._Cuenta = int.Parse(dr["Cuenta"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public TarjetaCredito buscarTarjeta(int idCliente)
        {

            TarjetaCredito cli = new TarjetaCredito();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where idPagoTarjeta = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._idPagoTarjeta = int.Parse(dt.Rows[0][0].ToString());
                cli._boleta = int.Parse(dt.Rows[0][1].ToString());
                cli._tipoTarjeta = (string)dt.Rows[0][2].ToString();
                cli._numeroTarjeta = int.Parse(dt.Rows[0][3].ToString());
                cli._transaccion = int.Parse(dt.Rows[0][4].ToString());
                cli._rut = (string)dt.Rows[0][5].ToString();
                cli._nombreTitutar = (string)dt.Rows[0][6].ToString();
                cli._MontoAtarjeta = int.Parse(dt.Rows[0][7].ToString());
                cli._Cuenta = int.Parse(dt.Rows[0][8].ToString());
            }
            catch (Exception e)
            {
                cli._idPagoTarjeta = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarTarjeta(TarjetaCredito cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set idPagoTarjeta=" + cli._idPagoTarjeta + "," +
                        "boleta=" + cli._boleta + "," +
                        "tipoTarjeta='" + cli._tipoTarjeta + "'," +
                        "numeroTarjeta='" + cli._numeroTarjeta + "'," +
                        "transaccion='" + cli._transaccion + "'," +
                        "rut=" + cli._rut + "," +
                        "nombreTitutar=" + cli._nombreTitutar + "," +
                        "Cuenta=" + cli._Cuenta + 
                        " where idPagoTarjeta=" + cli._idPagoTarjeta;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarTarjeta(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where idPagoTarjeta=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
