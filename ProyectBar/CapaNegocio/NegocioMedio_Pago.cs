using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioMedio_Pago
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioMedio_Pago()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Medio_Pago";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarMedio_Pago(Medio_Pago cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Medio + ",'" +
                cli._nombre + "','" +
                cli._descripcion + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getMedio_Pagos()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Medio_Pago cli = new Medio_Pago();
                cli._ID_Medio = int.Parse(dr["ID_Medio"].ToString());
                cli._nombre = (string)dr["nombre"];
                cli._descripcion = (string)dr["descripcion"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Medio_Pago buscarMedio_Pago(int idCliente)
        {

            Medio_Pago cli = new Medio_Pago();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Medio = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Medio = int.Parse(dt.Rows[0][0].ToString());
                cli._nombre = (string)dt.Rows[0][1];
                cli._descripcion = (string)dt.Rows[0][2];
            }
            catch (Exception e)
            {
                cli._ID_Medio = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarClientes(Medio_Pago cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Medio=" + cli._ID_Medio + "," +
                        "nombre='" + cli._nombre + "'," +
                        "descripcion='" + cli._descripcion + 
                        "' where ID_Medio=" + cli._ID_Medio;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarMedio_Pago(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Medio=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
