using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;

namespace CapaNegocio
{
   public class NegocioProductoBarra
    {
         private ConexionSQL cnn;

        public NegocioProductoBarra()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Producto_Barra";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Mauricio\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
        }

        public void insertarProductoBarra(Producto_Barra cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_ProductoBarra + "," +
                cli._Barra + "," +
                cli._cantidadBarra + "," +
                cli._ingrediente + "," +
                cli._bodegaCentral + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getProductosBarra()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto_Barra cli = new Producto_Barra();
                cli._ID_ProductoBarra = int.Parse(dr["ID_Producto"].ToString());
                cli._Barra = int.Parse(dr["Barra"].ToString());
                cli._cantidadBarra = int.Parse(dr["cantidadBarra"].ToString());
                cli._ingrediente = int.Parse(dr["Ingrediente"].ToString());
                cli._bodegaCentral = int.Parse(dr["BodegaCentral"].ToString());
                
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getProductosBarraXNombre(int Nombre)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where categoria =" + Nombre;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto_Barra cli = new Producto_Barra();
                cli._ID_ProductoBarra = int.Parse(dr["ID_ProductoBarra"].ToString());
                cli._Barra = int.Parse(dr["Barra"].ToString());
                cli._cantidadBarra = int.Parse(dr["cantidadBarra"].ToString());
                cli._ingrediente = int.Parse(dr["Ingrediente"].ToString());
                cli._bodegaCentral = int.Parse(dr["BodegaCentral"].ToString());
               
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Producto_Barra buscarProductoBarra(int idCliente)
        {

            Producto_Barra cli = new Producto_Barra();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_ProductoBarra = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_ProductoBarra = int.Parse(dt.Rows[0][0].ToString());
                cli._Barra = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidadBarra = int.Parse(dt.Rows[0][2].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][3].ToString());
                cli._bodegaCentral = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._ID_ProductoBarra = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Producto_Barra buscarProductoBarraxnombre(string idCliente)
        {

            Producto_Barra cli = new Producto_Barra();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombreBarra = '" + idCliente+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_ProductoBarra = int.Parse(dt.Rows[0][0].ToString());
                cli._Barra = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidadBarra = int.Parse(dt.Rows[0][2].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][3].ToString());
                cli._bodegaCentral = int.Parse(dt.Rows[0][4].ToString());
      
            }
            catch (Exception e)
            {
                cli._ID_ProductoBarra = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarProductoBarra(Producto_Barra cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_ProductoBarra=" + cli._ID_ProductoBarra + "," +
                        "Barra=" + cli._Barra + "," +
                        "cantidadBarra=" + cli._cantidadBarra + "," +
                        "Ingrediente=" + cli._ingrediente + "," +
                        "BodegaCentral=" + cli._bodegaCentral +
                        " where ID_Producto=" + cli._ID_ProductoBarra;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarProductoBarra(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_ProductoBarra=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
