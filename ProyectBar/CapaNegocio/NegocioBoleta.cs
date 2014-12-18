using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioBoleta
    {
         private ConexionSQL cnn;
         string ruta = SystemInformation.UserName;

        public NegocioBoleta()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Boleta";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarBoleta(Boleta cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Boleta + ",'" +
                cli._Fecha + "'," +
                cli._Terminal + ",'" +
                cli._hora + "'," +
                cli._tipo_boleta +  ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getBoleta()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Boleta ca = new Boleta();
                ca._ID_Boleta = int.Parse(dr["ID_Boleta"].ToString());
                ca._Fecha = (string)dr["Fecha"];
                ca._Terminal = int.Parse(dr["Terminal"].ToString());
                ca._hora = (string)dr["hora"];
                ca._tipo_boleta = int.Parse(dr["tipo_boleta"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public System.Collections.ArrayList getBoletaxterminal(int id, string fech)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla +" where Terminal = " + id + " and Fecha < '" + DateTime.Parse(fech).ToShortDateString()+ "'";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Boleta ca = new Boleta();
                ca._ID_Boleta = int.Parse(dr["ID_Boleta"].ToString());
                ca._Fecha = Convert.ToDateTime(dr["Fecha"]).ToString();
                ca._Terminal = int.Parse(dr["Terminal"].ToString());
                ca._hora = dr["hora"] + "";
                ca._tipo_boleta = int.Parse(dr["tipo_boleta"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Boleta buscarBoleta(int idCliente)
        {

            Boleta cli = new Boleta();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Boleta = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Boleta = int.Parse(dt.Rows[0][0].ToString());
                cli._Fecha = (string)dt.Rows[0][1];
                cli._Terminal = int.Parse(dt.Rows[0][2].ToString());
                cli._hora = (string)dt.Rows[0][3];
                cli._tipo_boleta = int.Parse(dt.Rows[0][4].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Boleta = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarBoleta(Boleta cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Boleta=" + cli._ID_Boleta + "," +
                        "Fecha='" + cli._Fecha + "'," +
                        "Terminal=" + cli._Terminal + "," +
                        "hora='" + cli._hora + "'," +
                        "tipo_boleta=" + cli._tipo_boleta +
                        " where ID_Boleta=" + cli._ID_Boleta;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarBoleta(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Boleta=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
