using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Collections;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioCuenta
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

        public NegocioCuenta()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Cuenta";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;

        }

        public void insertarCuenta(Cuenta cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Cuenta + "," +
                cli._Mesa + ",'" +
                cli._nombre + "'," +
                cli._expirada + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getCuenta()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cuenta ca = new Cuenta();
                ca._ID_Cuenta = int.Parse(dr["ID_Cuenta"].ToString());
                ca._Mesa = int.Parse(dr["Mesa"].ToString());
                ca._nombre = (string)dr["nombe"].ToString();
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getCuentaxMesa(int Mesa)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Mesa = " + Mesa +" and expirada = 1";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Cuenta ca = new Cuenta();
                ca._ID_Cuenta = int.Parse(dr["ID_Cuenta"].ToString());
                ca._Mesa = int.Parse(dr["Mesa"].ToString());
                ca._nombre = (string)dr["nombre"].ToString();
                ca._expirada = int.Parse(dr["expirada"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Cuenta buscarCuenta(int idCliente)
        {

            Cuenta cli = new Cuenta();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Cuenta = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Cuenta = int.Parse(dt.Rows[0][0].ToString());
                cli._Mesa = int.Parse(dt.Rows[0][1].ToString());
                cli._nombre = (string)dt.Rows[0][2];
                cli._expirada = int.Parse(dt.Rows[0][3].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Cuenta = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarCuenta(Cuenta cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Cuenta=" + cli._ID_Cuenta + "," +
                        "Mesa=" + cli._Mesa + "," +
                        "nombre='" + cli._nombre + "'," +
                        "expirada=" + cli._expirada + 
                        " where ID_Cuenta=" + cli._ID_Cuenta;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarCuenta(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Cuenta=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
