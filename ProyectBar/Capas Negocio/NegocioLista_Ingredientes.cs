using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;

namespace CapaNegocio
{
    public class NegocioLista_Ingredientes
    {
        private ConexionSQL cnn;

        public NegocioLista_Ingredientes()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Lista_Ingredientes";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Mauricio\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
        }

        public void insertarLista_Ingredientes(Lista_Ingredientes cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Lista + "," +
                cli._producto + "," +
                cli._ingrediente + "," +
                cli._cantidad + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getLista_Ingredientes()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Lista_Ingredientes cli = new Lista_Ingredientes();
                cli._ID_Lista = int.Parse(dr["ID_Lista"].ToString());
                cli._producto = int.Parse(dr["producto"].ToString());
                cli._ingrediente = int.Parse(dr["ingrediente"].ToString());
                cli._cantidad = int.Parse(dr["cantidad"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }


        public System.Collections.ArrayList getLista_IngredientesXProducto(int producto)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where producto =" + producto;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Lista_Ingredientes cli = new Lista_Ingredientes();
                cli._ID_Lista = int.Parse(dr["ID_Lista"].ToString());
                cli._producto = int.Parse(dr["producto"].ToString());
                cli._ingrediente = int.Parse(dr["ingrediente"].ToString());
                cli._cantidad = int.Parse(dr["cantidad"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Lista_Ingredientes buscarLista_Ingredientes(int producto, int ingrediente)
        {

            Lista_Ingredientes cli = new Lista_Ingredientes();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where producto = " + producto +" and ingrediente=" + ingrediente ;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Lista = int.Parse(dt.Rows[0][0].ToString());
                cli._producto = int.Parse(dt.Rows[0][1].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][2].ToString());
                cli._cantidad = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Lista = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Lista_Ingredientes buscarLista_IngredientesString(int producto, string ingrediente)
        {

            Lista_Ingredientes cli = new Lista_Ingredientes();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where producto = " + producto + " and ingrediente=" + ingrediente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Lista = int.Parse(dt.Rows[0][0].ToString());
                cli._producto = int.Parse(dt.Rows[0][1].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][2].ToString());
                cli._cantidad = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Lista = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarLista_Ingredientes(Lista_Ingredientes cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Lista=" + cli._ID_Lista + "," +
                        "producto=" + cli._producto + "," +
                        "ingrediente=" + cli._ingrediente + "," +
                        "cantidad="+ cli._cantidad +
                        " where ID_lista=" + cli._ID_Lista;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarLista_Ingredientes(int producto, int ingrediente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where producto=" + producto + " and ingrediente=" + ingrediente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarLista_IngredientesxidLista(int lista)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Lista=" + lista;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
