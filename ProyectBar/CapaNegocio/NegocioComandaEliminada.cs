using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioComandaEliminada
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioComandaEliminada()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "ComandasEliminadas";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=192.168.100.125;Initial Catalog=ProyectoBarFinal;Persist Security Info=True;User ID=Mauricio;Password=Fivesides123";
            this.cnn._cadenaConexion = NegocioBarra.path;
            }

        public void insertarComandaEliminada(ComandasEliminadas cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Comanda + ",'" +
                cli._Razon + "','" +
                cli._Razon + "')";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getComandasEliminadas()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                ComandasEliminadas ca = new ComandasEliminadas();
                ca._ID_Comanda = int.Parse(dr["ID_Comanda"].ToString());
                ca._Razon = (string)dr["Razon"].ToString();
                ca._otro = (string)dr["otro"].ToString();
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public ComandasEliminadas buscarComandaEliminada(int idCliente)
        {

            ComandasEliminadas cli = new ComandasEliminadas();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Comanda = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Comanda = int.Parse(dt.Rows[0][0].ToString());
                cli._Razon = (string)dt.Rows[0][1].ToString();
                cli._otro = (string)dt.Rows[0][2].ToString();
            }
            catch (Exception e)
            {
                cli._ID_Comanda = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarComandaEliminada(ComandasEliminadas cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Comanda=" + cli._ID_Comanda + "," +
                        "Razon='" + cli._Razon + "'," +
                        "otro='" + cli._otro + "'" +
                        " where ID_Comanda=" + cli._ID_Comanda;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarComandaEliminada(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Comanda=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
