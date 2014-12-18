using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioComanda
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioComanda()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Comanda";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
           // this.cnn._cadenaConexion = NegocioBarra.path;
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarComanda(Comanda cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Comanda + "," +
                cli._Pedido + ",'" +
                cli._detalle + "'," +
                cli._expirada +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getComanda()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Comanda ca = new Comanda();
                ca._ID_Comanda = int.Parse(dr["ID_Comanda"].ToString());
                ca._Pedido = int.Parse(dr["Pedido"].ToString());
                ca._detalle = (string)dr["detalle"].ToString();
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getComandaxpedido(int idpedido)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Pedido=" + idpedido + " and expirada = 1";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Comanda ca = new Comanda();
                ca._ID_Comanda = int.Parse(dr["ID_Comanda"].ToString());
                ca._Pedido = int.Parse(dr["Pedido"].ToString());
                ca._detalle = (string)dr["detalle"].ToString();
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Comanda buscarComanda(int idCliente)
        {

            Comanda cli = new Comanda();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Comanda = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Comanda = int.Parse(dt.Rows[0][0].ToString());
                cli._Pedido = int.Parse(dt.Rows[0][1].ToString());
                cli._detalle = (string)dt.Rows[0][2].ToString();
                cli._expirada = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Comanda = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarComanda(Comanda cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Comanda=" + cli._ID_Comanda + "," +
                        "Pedido=" + cli._Pedido + "," +
                        "detalle='" + cli._detalle + "'," +
                        "expirada=" + cli._expirada + 
                        " where ID_Comanda=" + cli._ID_Comanda;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarComanda(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Comanda=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
