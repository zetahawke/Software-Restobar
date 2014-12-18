using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioTerminal
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioTerminal()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Terminal";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarTerminal(Terminal cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Terminal + "," +
                cli._sector + ",'" +
                cli._descripcion + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getTerminales()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Terminal cli = new Terminal();
                cli._ID_Terminal = int.Parse(dr["ID_Terminal"].ToString());
                cli._sector = int.Parse(dr["sector"].ToString());
                cli._descripcion = (string)dr["descripcion"];
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Terminal buscarTerminal(int idCliente)
        {

            Terminal cli = new Terminal();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Terminal = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Terminal = int.Parse(dt.Rows[0][0].ToString());
                cli._sector = int.Parse(dt.Rows[0][1].ToString());
                cli._descripcion = (string)dt.Rows[0][2];
            }
            catch (Exception e)
            {
                cli._ID_Terminal = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarTerminal(Terminal cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Terminal='" + cli._ID_Terminal + "'," +
                        "sector='" + cli._sector + "'," +
                        "descripcion='" + cli._descripcion + "'" +
                        " where ID_Terminal=" + cli._ID_Terminal;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarTerminal(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Terminal=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
