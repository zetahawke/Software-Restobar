using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;

namespace CapaNegocio
{
    public class NegocioProducto
    {
        private ConexionSQL cnn;

        public NegocioProducto()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Producto";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Mauricio\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
        }

        public void insertarProducto(Producto cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Producto + ",'" +
                cli._nombre + "','" +
                cli._descripcion + "'," +
                cli._precio + "," +
                cli._categoria + ",'" +
                cli._InicioHappyHour + "','" +
                cli._FinHappyHour + "',"+
                cli._descuento + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getProductos()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto cli = new Producto();
                cli._ID_Producto = int.Parse(dr["ID_Producto"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._descripcion = (string)dr["descripcion"];
                cli._precio = int.Parse(dr["precio"].ToString());
                cli._categoria = int.Parse(dr["categoria"].ToString());
                cli._InicioHappyHour = ((TimeSpan)dr["InicioHappyHour"]) + "";
                cli._FinHappyHour = ((TimeSpan)dr["FinHappyHour"]) + "";
                cli._descuento = int.Parse(dr["Descuento"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getProductosXCategoria(int Categoria)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where categoria =" + Categoria;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Producto cli = new Producto();
                cli._ID_Producto = int.Parse(dr["ID_Producto"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._descripcion = (string)dr["descripcion"];
                cli._precio = int.Parse(dr["precio"].ToString());
                cli._categoria = int.Parse(dr["categoria"].ToString());
                cli._InicioHappyHour = ((TimeSpan)dr["InicioHappyHour"]) + "";
                cli._FinHappyHour = ((TimeSpan)dr["FinHappyHour"]) + "";
                cli._descuento = int.Parse(dr["Descuento"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Producto buscarProducto(int idCliente)
        {

            Producto cli = new Producto();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Producto = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Producto = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
                cli._descripcion = (string)dt.Rows[0][2];
                cli._precio = int.Parse(dt.Rows[0][3].ToString());
                cli._categoria = int.Parse(dt.Rows[0][4].ToString());
                cli._InicioHappyHour = ((TimeSpan)dt.Rows[0][5]) + "";
                cli._FinHappyHour = ((TimeSpan)dt.Rows[0][6]) + "";
                cli._descuento = int.Parse(dt.Rows[0][7].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Producto = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Producto buscarProductoxnombre(string idCliente)
        {

            Producto cli = new Producto();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombre = '" + idCliente+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Producto = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
                cli._descripcion = (string)dt.Rows[0][2];
                cli._precio = int.Parse(dt.Rows[0][3].ToString());
                cli._categoria = int.Parse(dt.Rows[0][4].ToString());
                cli._InicioHappyHour = ((TimeSpan)dt.Rows[0][5]) + "";
                cli._FinHappyHour = ((TimeSpan)dt.Rows[0][6]) + "";
                cli._descuento = int.Parse(dt.Rows[0][7].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Producto = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarProducto(Producto cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Producto=" + cli._ID_Producto + "," +
                        "nombre='" + cli._nombre + "'," +
                        "descripcion='" + cli._descripcion + "'," +
                        "precio=" + cli._precio + "," +
                        "categoria=" + cli._categoria + "," +
                        "InicioHappyHour='" + DateTime.Parse(cli._InicioHappyHour).ToShortTimeString() + "'," +
                        "FinHappyHour='" + DateTime.Parse(cli._FinHappyHour).ToShortTimeString() + "'," +
                        "Descuento=" + cli._descuento +
                        " where ID_Producto=" + cli._ID_Producto;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarProducto(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Producto=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
