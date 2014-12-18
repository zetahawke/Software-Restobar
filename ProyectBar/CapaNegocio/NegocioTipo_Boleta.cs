using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioTipo_Boleta
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioTipo_Boleta()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Tipo_Boleta";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarTipo_boleta(Tipo_Boleta cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._id_tipo + ",'" +
                cli. _tipo+ "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getTipo_Boleta()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Tipo_Boleta ca = new Tipo_Boleta();
                ca._id_tipo = int.Parse(dr["id_tipo"].ToString());
                ca._tipo = (string)dr["tipo"];
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Tipo_Boleta buscarTipo_Boleta(int idCliente)
        {

            Tipo_Boleta cli = new Tipo_Boleta();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where id_tipo = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._id_tipo = int.Parse(dt.Rows[0][0].ToString());
                cli._tipo = (string)dt.Rows[0][1];
            }
            catch (Exception e)
            {
                cli._id_tipo = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarTipo_Boleta(Tipo_Boleta cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set id_tipo=" + cli._id_tipo + "," +
                        "tipo='" + cli._tipo + "'" +
                        " where id_tipo=" + cli._id_tipo;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarTipo_Boleta(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where id_tipo=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
