using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioUsuario
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioUsuario()
        {
            cnn = new ConexionSQL();
            
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Usuario";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarUsuario(Usuario cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values('" +
                cli._Contraseña + "','" +
                cli._nombre + "','" +
                cli._rut + "','" +
                cli._apellido + "','" +
                cli._privilegio + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getUsuarios()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Usuario cli = new Usuario();
                cli._Contraseña = (string)dr["Contraseña"];
                cli._nombre = (string)dr["nombre"];
                cli._rut = (string)dr["rut"];
                cli._apellido = (string)dr["apellido"];
                cli._privilegio = int.Parse(dr["privilegio"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Usuario buscarUsuario(string idCliente)
        {

            Usuario cli = new Usuario();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Contraseña = '" + idCliente+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._Contraseña = (string)dt.Rows[0][0];
                cli._nombre = (string)dt.Rows[0][1];
                cli._rut = (string)dt.Rows[0][2];
                cli._apellido = (string)dt.Rows[0][3];
                cli._privilegio = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._Contraseña = "";
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Usuario buscarUsuarioxnombre(string idCliente)
        {

            Usuario cli = new Usuario();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where nombre = '" + idCliente+"'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._Contraseña = (string)dt.Rows[0][0];
                cli._nombre = (string)dt.Rows[0][1];
                cli._rut = (string)dt.Rows[0][2];
                cli._apellido = (string)dt.Rows[0][3];
                cli._privilegio = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._Contraseña = "";
            }
            this.cnn.cerrarConexion();
            return cli;
        }


        public void modificarUsuario(Usuario cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set Contraseña='" + cli._Contraseña + "'," +
                        "nombre='" + cli._nombre + "'," +
                        "rut='" + cli._rut + "'," +
                        "apellido='" + cli._apellido + "'," +
                        "privilegio='" + cli._privilegio + "'" +
                        " where Contraseña='" + cli._Contraseña + "'";
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarUsuario(string idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where Contraseña=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
