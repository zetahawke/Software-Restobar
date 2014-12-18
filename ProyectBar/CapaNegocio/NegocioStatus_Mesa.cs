using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class NegocioStatus_Mesa
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioStatus_Mesa()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Status_Mesa";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarStatus_Mesa(Status_Mesa cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Estado + ",'" +
                cli._Descripcion +  "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getStatus_Mesas()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Status_Mesa cli = new Status_Mesa();
                cli._ID_Estado = int.Parse(dr["id"].ToString());
                cli._Descripcion = (string)dr["Rut"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Status_Mesa buscarStatus_Mesa(int idCliente)
        {

            Status_Mesa cli = new Status_Mesa();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Estado = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Estado = int.Parse(dt.Rows[0][0].ToString());
                cli._Descripcion = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._ID_Estado = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarStatus_Mesa(Status_Mesa cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Estado='" + cli._ID_Estado + "'," +
                        "Descripcion='" + cli._Descripcion + "'" +
                        " where ID_Estado=" + cli._ID_Estado;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarStatus_Mesa(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Estado=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
