using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioVentasXTerminal
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioVentasXTerminal()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "VentasXTerminal";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarVentasxTerminal(VentasXTerminal cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._id_Venta + ",'" +
                cli._FechaInicio + "'," +
                cli._totalVendido + "," +
                cli._totalInicial + ",'" +
                cli._FechaTermino + "'," +
                cli._efectivo + "," +
                cli._tarjetas + "," +
                cli._cheques + "," +
                cli._descuento + "," +
                cli._devoluciones + "," +
                cli._terminal +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getVentasXterminal(int id)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where terminal = " + id;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                VentasXTerminal ca = new VentasXTerminal();
                ca._id_Venta = int.Parse(dr["id_Venta"].ToString());
                ca._FechaInicio = (string)dr["FechaInicio"];
                ca._totalVendido = int.Parse(dr["totalVendido"].ToString());
                ca._totalInicial = int.Parse(dr["totalInicial"].ToString());
                ca._FechaTermino = (string)dr["_FechaTermino"];
                ca._efectivo = int.Parse(dr["efectivo"].ToString());
                ca._tarjetas = int.Parse(dr["tarjetas"].ToString());
                ca._cheques = int.Parse(dr["cheques"].ToString());
                ca._descuento = int.Parse(dr["descuento"].ToString());
                ca._devoluciones = int.Parse(dr["devoluciones"].ToString());
                ca._terminal = int.Parse(dr["terminal"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public VentasXTerminal buscarVentasXTerminal(int idCliente)
        {

            VentasXTerminal cli = new VentasXTerminal();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where terminal = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._id_Venta = int.Parse(dt.Rows[0][0].ToString());
                cli._FechaInicio = (string)dt.Rows[0][1].ToString();
                cli._totalVendido = int.Parse(dt.Rows[0][2].ToString());
                cli._totalInicial = int.Parse(dt.Rows[0][3].ToString());
                cli._FechaTermino = (string)dt.Rows[0][4].ToString();
                cli._efectivo = int.Parse(dt.Rows[0][5].ToString());
                cli._tarjetas = int.Parse(dt.Rows[0][6].ToString());
                cli._cheques = int.Parse(dt.Rows[0][7].ToString());
                cli._descuento = int.Parse(dt.Rows[0][8].ToString());
                cli._devoluciones = int.Parse(dt.Rows[0][9].ToString());
                cli._terminal = int.Parse(dt.Rows[0][10].ToString());
            }
            catch (Exception e)
            {
                cli._id_Venta = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarVentasXTerminal(VentasXTerminal cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set id_Venta=" + cli._id_Venta + "," +
                        "FechaInicio='" + cli._FechaInicio + "'," +
                        "totalVendido=" + cli._totalVendido + "," +
                        "totalInicial=" + cli._totalInicial + "," +
                        "FechaTermino='" + cli._FechaTermino + "'," +
                        "efectivo=" + cli._efectivo + "," +
                        "tarjetas=" + cli._tarjetas + "," +
                        "cheques=" + cli._cheques + "," +
                        "descuento=" + cli._descuento + "," +
                        "devoluciones=" + cli._devoluciones + "," +
                        "terminal=" + cli._terminal +
                        " where id_Venta=" + cli._id_Venta;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCheque(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where id_Venta=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
