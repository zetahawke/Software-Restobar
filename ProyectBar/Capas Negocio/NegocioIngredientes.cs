using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;

namespace CapaNegocio
{
    public class NegocioIngredientes
    {
        private ConexionSQL cnn;

        public NegocioIngredientes()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Ingredientes";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Mauricio\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
        }

        public void insertarIngredientes(Ingrediente cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Ingredientes + ",'" +
                cli._nombre +  "'," +
                cli._cantidad + ",'" +
                cli._tipoDato + "')";
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
                Ingrediente cli = new Ingrediente();
                cli._ID_Ingredientes = int.Parse(dr["ID_Ingredientes"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._cantidad = int.Parse(dr["cantidad"].ToString());
                cli._tipoDato = (string)dr["tipoDatos"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getIngredientesXtipoUnidad(string TipoUnidad)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where tipoDatos ='" + TipoUnidad + "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Ingrediente cli = new Ingrediente();
                cli._ID_Ingredientes = int.Parse(dr["ID_Ingredientes"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._cantidad = int.Parse(dr["cantidad"].ToString());
                cli._tipoDato = (string)dr["tipoDatos"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getIngredientessXProducto()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Ingrediente cli = new Ingrediente();
                cli._ID_Ingredientes = int.Parse(dr["ID_Ingredientes"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._cantidad = int.Parse(dr["cantidad"].ToString());
                cli._tipoDato = (string)dr["tipoDatos"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Ingrediente buscarIngredientes(int idCliente)
        {

            Ingrediente cli = new Ingrediente();
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
                cli._cantidad = int.Parse(dt.Rows[0][2].ToString());
                cli._tipoDato = (string)dt.Rows[0][3];
            }
            catch (Exception e)
            {
                cli._ID_Ingredientes = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Ingrediente buscarIngredientesString(String idCliente)
        {

            Ingrediente cli = new Ingrediente();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombre = '" + idCliente + "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Ingredientes = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
                cli._cantidad = int.Parse(dt.Rows[0][2].ToString());
                cli._tipoDato = (string)dt.Rows[0][3];
            }
            catch (Exception e)
            {
                cli._ID_Ingredientes = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarIngredientes(Ingrediente cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Ingredientes=" + cli._ID_Ingredientes + "," +
                        "nombre='" + cli._nombre + "'," +
                        "cantidad=" + cli._cantidad + "," +
                        "tipoDatos='" + cli._tipoDato + "'" +
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
