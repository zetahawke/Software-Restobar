using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class NegocioBarra
    {
        private ConexionSQL cnn;

        public NegocioBarra()
        {
            cnn = new ConexionSQL();
        }
        public static string path = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Program Files (x86)\\Microsoft\\Setup\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
        //public static string path = "Data Source=192.168.100.133;Initial Catalog=ProyectoBarFinal;Persist Security Info=True;User ID=Mauricio;Password=Fivesides123";
        private void configConex()
        {
            string usuario = SystemInformation.UserName;
            this.cnn._nombreTabla = "Barra";
            this.cnn._user = "";
            this.cnn._password = "";
            this.cnn._cadenaConexion = path;
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Program Files (x86)\\Microsoft\\Setup\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+usuario+"\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
           
        }

        public void insertarBarra(Barra cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Barra + ",'" +
                cli._Nombre +  "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getBarra()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Barra ca = new Barra();
                ca._ID_Barra = int.Parse(dr["ID_Barra"].ToString());
                ca._Nombre = (string)dr["Nombre"];
            
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Barra buscarBarra(int idCliente)
        {

            Barra cli = new Barra();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Barra = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Barra = int.Parse(dt.Rows[0][0].ToString());
                cli._Nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Barra = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Barra buscarBarraString(string idCliente)
        {

            Barra cli = new Barra();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Nombre = '" + idCliente + "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Barra = int.Parse(dt.Rows[0][0].ToString());
                cli._Nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Barra = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarBarra(Barra cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Barra=" + cli._ID_Barra + "," +
                        "Nombre='" + cli._Nombre + "'" +
                        " where ID_Barra=" + cli._ID_Barra;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarBarra(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Barra=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarBarraString(string idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where Nombre='" + idCliente + "'";
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
