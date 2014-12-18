using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using CapaConexion2;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NegocioDetalleBoleta
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioDetalleBoleta()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "DetalleBoleta";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
           // this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public void insertarDetalleBoleta(DetalleBoleta cli)
        {
            this.configConex();
            this.cnn._esSelect = true;
            this.cnn._sentenciaSQL = "insert into " + this.cnn._nombreTabla + " values(" +
                cli._ID_Detalle + "," +
                cli._total + "," +
                cli._Cuenta + "," +
                cli._Boleta + ",'" +
                cli._descripcion + "'," +
                cli._subtotal + "," +
                cli._exento + "," +
                cli._descuento + "," +
                cli._efectivo + "," +
                cli._propina + "," +
                cli._vuelto +")";
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public System.Collections.ArrayList getDetalleBoleta()
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                DetalleBoleta cli = new DetalleBoleta();
                cli._ID_Detalle = int.Parse(dr["ID_Detalle"].ToString());
                cli._total = int.Parse(dr["total"].ToString());
                cli._Cuenta = int.Parse(dr["Cuenta"].ToString());
                cli._Boleta = int.Parse(dr["Boleta"].ToString());
                cli._descripcion = (string)dr["descripcion"];
                cli._subtotal = int.Parse(dr["subtotal"].ToString());
                cli._exento = int.Parse(dr["exento"].ToString());
                cli._descuento = int.Parse(dr["descuento"].ToString());
                cli._efectivo = int.Parse(dr["efectivo"].ToString());
                cli._propina = int.Parse(dr["propina"].ToString());
                cli._vuelto = int.Parse(dr["vuelto"].ToString());
                
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }


        public System.Collections.ArrayList getDetalleBoletaxBoleta(int id)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList();

            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where Boleta = " + id;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            foreach (System.Data.DataRow dr in
                        this.cnn._dbDataSet.Tables[this.cnn._nombreTabla].Rows)
            {
                DetalleBoleta cli = new DetalleBoleta();
                cli._ID_Detalle = int.Parse(dr["ID_Detalle"].ToString());
                cli._total = int.Parse(dr["total"].ToString());
                cli._Cuenta = int.Parse(dr["Cuenta"].ToString());
                cli._Boleta = int.Parse(dr["Boleta"].ToString());
                cli._descripcion = (string)dr["descripcion"];
                cli._subtotal = int.Parse(dr["subtotal"].ToString());
                cli._exento = int.Parse(dr["exento"].ToString());
                cli._descuento = int.Parse(dr["descuento"].ToString());
                cli._efectivo = int.Parse(dr["efectivo"].ToString());
                cli._propina = int.Parse(dr["propina"].ToString());
                cli._vuelto = int.Parse(dr["vuelto"].ToString());
                lista.Add(cli);
            }
            this.cnn.cerrarConexion();
            return lista;
        }

        public DetalleBoleta buscarDetalleBoleta(int idCliente)
        {

            DetalleBoleta cli = new DetalleBoleta();
            this.configConex();
            this.cnn._sentenciaSQL = "Select * from " + cnn._nombreTabla + " where ID_Detalle = " + idCliente;
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._ID_Detalle = int.Parse(dt.Rows[0][0].ToString());
                cli._total = int.Parse(dt.Rows[0][1].ToString());
                cli._Cuenta = int.Parse(dt.Rows[0][2].ToString());
                cli._Boleta = int.Parse(dt.Rows[0][3].ToString());
                cli._descripcion = (string)dt.Rows[0][4];
                cli._subtotal = int.Parse(dt.Rows[0][5].ToString());
                cli._exento = int.Parse(dt.Rows[0][6].ToString());
                cli._descuento = int.Parse(dt.Rows[0][7].ToString());
                cli._efectivo = int.Parse(dt.Rows[0][8].ToString());
                cli._propina = int.Parse(dt.Rows[0][9].ToString());
                cli._vuelto = int.Parse(dt.Rows[0][10].ToString());
                
            }
            catch (Exception e)
            {
                cli._ID_Detalle = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

        public void modificarDetalleBoleta(DetalleBoleta cli)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "update " + cnn._nombreTabla +
                        " set ID_Detalle=" + cli._ID_Detalle + "," +
                        "total=" + cli._total + "," +
                        "Cuenta=" + cli._Cuenta + "," +
                        "Boleta=" + cli._Boleta + "," +
                        "descripcion='" + cli._descripcion + "'," +
                        "subtotal=" + cli._subtotal + "," +
                        "exento=" + cli._exento + "," +
                        "descuento=" + cli._descuento + "," +
                        "efectivo=" + cli._efectivo + "," +
                        "propina=" + cli._propina + "," +
                        "vuelto=" + cli._vuelto +
                        " where ID_Detalle=" + cli._ID_Detalle;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }

        public void eliminarDetalleBoleta(int idCliente)
        {
            this.configConex();
            this.cnn._sentenciaSQL = "Delete from " + cnn._nombreTabla +
                        " where ID_Detalle=" + idCliente;
            this.cnn._esSelect = false;
            this.cnn.conectar();
            this.cnn.cerrarConexion();
        }
    }
}
