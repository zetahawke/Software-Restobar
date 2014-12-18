using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioTurno
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

        public NegocioTurno()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Turno";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarTurno(Turno cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values('" +
                cli._Usuario + "','" +
                cli._Inicio + "','" +
                cli._Fin + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getTurnos()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Turno ca = new Turno();
                ca._Usuario = (string)dr["Usuario"];
                ca._Inicio = (string)dr["Inicio"];
                ca._Fin = (string)dr["Fin"];
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Turno buscarTurno(string idCliente)
        {

            Turno cli = new Turno();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Usuario = '" + idCliente + "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._Usuario = (string)dt.Rows[0][0];
                cli._Inicio = (string)dt.Rows[0][1];
                cli._Fin = (string)dt.Rows[0][2];
            }
            catch (Exception e)
            {
                cli._Usuario = "";
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarTurno(Turno cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set Usuario='" + cli._Usuario + "'," +
                        "Inicio='" + cli._Inicio + "'," +
                        "Fin='" + cli._Fin + "'" +
                        " where Usuario='" + cli._Usuario+"'";
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarTurno(string idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where Usuario=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
