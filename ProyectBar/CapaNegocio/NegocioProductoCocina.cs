using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class NegocioProductoCocina
    {
         private ConexionSQL cnn;

        public NegocioProductoCocina()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            string usuario = SystemInformation.UserName;
            this.cnn._nombreTabla = "Producto_Cocina";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;       
        }

        public void insertarProductoCocina(Producto_Cocina cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_ProductoCocina + "," +
                cli._Cocina + "," +
                cli._cantidadCocina + "," +
                cli._ingrediente + "," +
                cli._bodegaCentral + ")"; 
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getProductosCocina()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto_Cocina cli = new Producto_Cocina();
                cli._ID_ProductoCocina = int.Parse(dr["ID_Producto"].ToString());
                cli._Cocina = int.Parse(dr["Cocina"].ToString());
                cli._cantidadCocina = int.Parse(dr["cantidadCocina"].ToString());
                cli._ingrediente = int.Parse(dr["Ingrediente"].ToString());
                cli._bodegaCentral = int.Parse(dr["BodegaCentral"].ToString());

                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getProductosCocinaXNombre(int Nombre)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where categoria =" + Nombre;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto_Cocina cli = new Producto_Cocina();
                cli._ID_ProductoCocina = int.Parse(dr["ID_ProductoCocina"].ToString());
                cli._Cocina = int.Parse(dr["Cocina"].ToString());
                cli._cantidadCocina = int.Parse(dr["cantidadCocina"].ToString());
                cli._ingrediente = int.Parse(dr["Ingrediente"].ToString());
                cli._bodegaCentral = int.Parse(dr["BodegaCentral"].ToString());
               
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Producto_Cocina buscarProductoCocina(int idCliente)
        {

            Producto_Cocina cli = new Producto_Cocina();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_ProductoCocina = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_ProductoCocina = int.Parse(dt.Rows[0][0].ToString());
                cli._Cocina = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidadCocina = int.Parse(dt.Rows[0][2].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][3].ToString());
                cli._bodegaCentral = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._ID_ProductoCocina = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Producto_Cocina buscarProductoCocinaxnombre(string idCliente)
        {

            Producto_Cocina cli = new Producto_Cocina();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombreCocina = '" + idCliente+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_ProductoCocina = int.Parse(dt.Rows[0][0].ToString());
                cli._Cocina = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidadCocina = int.Parse(dt.Rows[0][2].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][3].ToString());
                cli._bodegaCentral = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._ID_ProductoCocina = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarProductoCocina(Producto_Cocina cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_ProductoCocina=" + cli._ID_ProductoCocina + "," +
                        "Cocina=" + cli._Cocina + "," +
                        "cantidadCocina=" + cli._cantidadCocina + "," +
                        "Ingrediente=" + cli._ingrediente + "," +
                        "BodegaCentral=" + cli._bodegaCentral +
                        " where ID_Producto=" + cli._ID_ProductoCocina;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarProductoCocina(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_ProductoCocina=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

    }
}
