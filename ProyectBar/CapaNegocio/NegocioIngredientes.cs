using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioIngredientes
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioIngredientes()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Ingredientes";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarIngredientes(Ingredientes cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Ingredientes + ",'" +
                cli._nombre +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getIngredientes()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Ingredientes cli = new Ingredientes();
                cli._ID_Ingredientes = int.Parse(dr["ID_Ingredientes"].ToString());
                cli._nombre = (string)dr["nombre"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Ingredientes buscarIngredientes(int idCliente)
        {

            Ingredientes cli = new Ingredientes();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Ingredientes = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Ingredientes = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Ingredientes = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarIngredientes(Ingredientes cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Ingredientes=" + cli._ID_Ingredientes + "," +
                        "nombre='" + cli._nombre +
                        " where ID_Ingredientes=" + cli._ID_Ingredientes;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarIngredientes(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Ingredientes=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
