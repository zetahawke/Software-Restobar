using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaNegocio
{
    public class NegocioBodegaCentral
    {
        private ConexionSQL cnn;

        public NegocioBodegaCentral()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            string usuario = SystemInformation.UserName;
            this.cnn._nombreTabla = "Bodega_Central";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Zeine\\documents\\visual studio 2010\\Projects\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Fivesides\\Desktop\\ControlDeStock\\ControlDeStock\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarBodegaCentral(Bodega_Central cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_BodegaCentral + "," +
                cli._ingrediente + "," +
                cli._cantidad + ")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getBodegaCentral()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                Bodega_Central ca = new Bodega_Central();
                ca._ID_BodegaCentral = int.Parse(dr["ID_Bodega_Central"].ToString());
                ca._ingrediente = int.Parse(dr["Ingrediente"].ToString());
                ca._cantidad = int.Parse(dr["Cantidad"].ToString());
                lista.Add(ca);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public Bodega_Central buscarBodegaCentral(int idCliente)
        {

            Bodega_Central cli = new Bodega_Central();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Bodega_Central = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_BodegaCentral = int.Parse(dt.Rows[0][0].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidad = int.Parse(dt.Rows[0][2].ToString());
            }
            catch (Exception e)
            {
                cli._ID_BodegaCentral = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public Bodega_Central buscarBodegaCentralxIngrediente(int ingrediente)
        {

            Bodega_Central cli = new Bodega_Central();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Ingrediente = " + ingrediente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_BodegaCentral = int.Parse(dt.Rows[0][0].ToString());
                cli._ingrediente = int.Parse(dt.Rows[0][1].ToString());
                cli._cantidad = int.Parse(dt.Rows[0][2].ToString());
            }
            catch (Exception e)
            {
                cli._ID_BodegaCentral = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarBodegaCentral(Bodega_Central cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Bodega_Central=" + cli._ID_BodegaCentral + "," +
                        "Ingrediente=" + cli._ingrediente + "," +
                        "Cantidad=" + cli._cantidad +
                        " where ID_Bodega_Central=" + cli._ID_BodegaCentral;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarBodegaCentral(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Bodega_Central=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

    }
}
