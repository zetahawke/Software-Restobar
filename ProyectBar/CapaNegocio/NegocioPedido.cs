using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioPedido
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioPedido()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Pedido";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarPedido(Pedido cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Pedido + "," +
                cli._Mesa + ",'" +
                cli._Garzon + "'," +
                cli._expirado + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getPedidos()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Pedido cli = new Pedido();
                cli._ID_Pedido = int.Parse(dr["ID_Pedido"].ToString());
                cli._Mesa = int.Parse(dr["Mesa"].ToString());
                cli._Garzon = (string)dr["Garzon"].ToString();
                cli._expirado = int.Parse(dr["expirado"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getPedidosxMesa(int mesa)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where mesa = "+ mesa +" and expirado = 1" ;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Pedido cli = new Pedido();
                cli._ID_Pedido = int.Parse(dr["ID_Pedido"].ToString());
                cli._Mesa = int.Parse(dr["Mesa"].ToString());
                cli._Garzon = (string)dr["Garzon"].ToString();
                cli._expirado = int.Parse(dr["expirado"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Pedido buscarPedido(int idCliente)
        {

            Pedido cli = new Pedido();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Pedido = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Pedido = int.Parse(dt.Rows[0][0].ToString());
                cli._Mesa = int.Parse(dt.Rows[0][1].ToString());
                cli._Garzon = (string)dt.Rows[0][2].ToString();
                cli._expirado = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Pedido = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Pedido buscarPedidoxMesa(int idCliente)
        {

            Pedido cli = new Pedido();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Mesa = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Pedido = int.Parse(dt.Rows[0][0].ToString());
                cli._Mesa = int.Parse(dt.Rows[0][1].ToString());
                cli._Garzon = (string)dt.Rows[0][2].ToString();
                cli._expirado = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Pedido = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarPedido(Pedido cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Pedido=" + cli._ID_Pedido + "," +
                        "Mesa=" + cli._Mesa + "," +
                        "expirado=" + cli._expirado + "," +
                        " Garzon='" + cli._Garzon +
                        "' where ID_Pedido=" + cli._ID_Pedido;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarPedido(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Pedido=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
