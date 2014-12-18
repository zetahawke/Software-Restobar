using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioMesa
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioMesa()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Mesa";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarMesa(Mesa cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Mesa + "," +
                cli._sector + "," +
                cli._estado + ",'" +
                cli._llegada + "','" +
                cli._estadia + "','" +
                cli._salida +  "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getMesas()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Mesa cli = new Mesa();
                cli._ID_Mesa = int.Parse(dr["ID_Mesa"].ToString());
                cli._sector = int.Parse(dr["sector"].ToString());
                cli._estado = int.Parse(dr["estado"].ToString());
                cli._llegada = ((TimeSpan)dr["llegada"]) + "";
                cli._estadia = ((TimeSpan)dr["estadia"]) + "";
                cli._salida = ((TimeSpan)dr["salida"]) + "";
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Mesa buscarMesa(int idCliente)
        {

            Mesa cli = new Mesa();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Mesa = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Mesa = int.Parse(dt.Rows[0][0].ToString());
                cli._sector = int.Parse(dt.Rows[0][1].ToString());
                cli._estado = int.Parse(dt.Rows[0][2].ToString());
                cli._llegada = ((TimeSpan)dt.Rows[0][3]) + "";
                cli._estadia = ((TimeSpan)dt.Rows[0][4]) + "";
                cli._salida = ((TimeSpan)dt.Rows[0][5]) + "";
            }
            catch (Exception e)
            {
                cli._ID_Mesa = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarMesa(Mesa cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Mesa=" + cli._ID_Mesa + "," +
                        "sector=" + cli._sector + "," +
                        "estado=" + cli._estado + "," +
                        "llegada='" + DateTime.Parse(cli._llegada).ToShortTimeString()+ "'," +
                        "estadia='" + DateTime.Parse(cli._estadia).ToShortTimeString() + "'," +
                        "salida='" + DateTime.Parse(cli._salida).ToShortTimeString() + "'" +
                        " where ID_Mesa=" + cli._ID_Mesa;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarMesa(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Mesa=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
