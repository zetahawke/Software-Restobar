using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioCuenta_Producto
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

        public NegocioCuenta_Producto()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Cuenta_Producto";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
           // this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
            }

        public void insertarCuenta_Producto(Cuenta_Producto cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Lista + "," +
                cli._Cuenta + "," +
                cli._producto + ",'" +
                cli._observacion + "'," +
                cli._cantidad + "," +
                cli._expirada + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getCuenta_Producto()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cuenta_Producto ca = new Cuenta_Producto();
                ca._ID_Lista = int.Parse(dr["ID_Lista"].ToString());
                ca._Cuenta = int.Parse(dr["producto"].ToString());
                ca._producto = int.Parse(dr["Terminal"].ToString());
                ca._observacion = (string)dr["observacion"];
                ca._cantidad = int.Parse(dr["cantidad"].ToString());
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getCuenta_ProductoxCuenta1(int cuenta)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla+" where Cuenta = "+ cuenta + " and expirada = 1";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cuenta_Producto ca = new Cuenta_Producto();
                ca._ID_Lista = int.Parse(dr["ID_Lista"].ToString());
                ca._Cuenta = int.Parse(dr["Cuenta"].ToString());
                ca._producto = int.Parse(dr["producto"].ToString());
                ca._observacion = (string)dr["observacion"];
                ca._cantidad = int.Parse(dr["cantidad"].ToString());
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getCuenta_ProductoxCuenta2(int cuenta)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Cuenta = " + cuenta + " and expirada = 2";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cuenta_Producto ca = new Cuenta_Producto();
                ca._ID_Lista = int.Parse(dr["ID_Lista"].ToString());
                ca._Cuenta = int.Parse(dr["Cuenta"].ToString());
                ca._producto = int.Parse(dr["producto"].ToString());
                ca._observacion = (string)dr["observacion"];
                ca._cantidad = int.Parse(dr["cantidad"].ToString());
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Cuenta_Producto buscarCuenta_Producto(int idCliente)
        {

            Cuenta_Producto cli = new Cuenta_Producto();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Lista = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Lista = int.Parse(dt.Rows[0][0].ToString());
                cli._Cuenta = int.Parse(dt.Rows[0][1].ToString());
                cli._producto = int.Parse(dt.Rows[0][2].ToString());
                cli._observacion = (string)dt.Rows[0][3];
                cli._cantidad = int.Parse(dt.Rows[0][4].ToString());
                cli._expirada = int.Parse(dt.Rows[0][5].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Lista = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarCuenta_Producto(Cuenta_Producto cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Lista='" + cli._ID_Lista + "'," +
                        "Cuenta='" + cli._Cuenta + "'," +
                        "producto=" + cli._producto + "," +
                        "observacion='" + cli._observacion + "'," +
                        "cantidad=" + cli._cantidad + "," +
                        "expirada=" + cli._expirada + 
                        " where ID_Lista=" + cli._ID_Lista;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCuenta_Producto(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Lista=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
