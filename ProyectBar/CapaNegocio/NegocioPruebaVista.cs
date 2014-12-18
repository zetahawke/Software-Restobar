using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaConexion2;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
   public class NegocioPruebaVista
    {
        private ConexionSQL cnn;
        string ruta = SystemInformation.UserName;

        public NegocioPruebaVista()
        {
            cnn = new ConexionSQL();
        }

        private void configConex()
        {
            this.cnn._nombreTabla = "Boleta";
            this.cnn._user = "";
            this.cnn._password = "";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Administrador\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            //this.cnn._cadenaConexion = "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\"+ruta+"\\desktop\\ProyectBar\\ProyectBar\\ProyectoBar.mdf\";Integrated Security=True;User Instance=True";
            this.cnn._cadenaConexion = NegocioBarra.path;
        }

        public PruebaVista buscarBoleta()
        {

            PruebaVista cli = new PruebaVista();
            this.configConex();
            this.cnn._sentenciaSQL = "SELECT        dbo.Terminal.ID_Terminal, dbo.Pedido.ID_Pedido, dbo.Pedido.Mesa, dbo.Mesa.sector, dbo.Mesa.llegada, dbo.Mesa.estadia, dbo.Cuenta.nombre, "+
                         "dbo.Usuario.nombre AS Expr1, dbo.Cuenta_Producto.producto, dbo.Cuenta_Producto.observacion, dbo.Cuenta_Producto.cantidad "+
"FROM            dbo.Usuario INNER JOIN "+
 "                        dbo.Pedido INNER JOIN "+
  "                       dbo.Comanda ON dbo.Pedido.ID_Pedido = dbo.Comanda.Pedido ON dbo.Usuario.nombre = dbo.Pedido.Garzon CROSS JOIN "+
   "                      dbo.Terminal CROSS JOIN "+
    "                     dbo.Producto INNER JOIN "+
     "                    dbo.Cuenta_Producto INNER JOIN "+
      "                   dbo.Cuenta ON dbo.Cuenta_Producto.Cuenta = dbo.Cuenta.ID_Cuenta INNER JOIN "+
       "                  dbo.Mesa ON dbo.Cuenta.Mesa = dbo.Mesa.ID_Mesa ON dbo.Producto.ID_Producto = dbo.Cuenta_Producto.producto where dbo.Pedido.Mesa = 1";
            this.cnn._esSelect = true;
            this.cnn.conectar();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = cnn._dbDataSet.Tables[0];
            try
            {
                cli._terminal = int.Parse(dt.Rows[0][0].ToString());
                cli._ID_Pedido = int.Parse(dt.Rows[0][1].ToString());
                cli._Mesa = int.Parse(dt.Rows[0][2].ToString());
                cli._sector = int.Parse(dt.Rows[0][3].ToString());
                cli._llegada = (string)dt.Rows[0][4];
                cli._estadia = (string)dt.Rows[0][5];
                cli._nombre = (string)dt.Rows[0][6];
                cli._usunombre = (string)dt.Rows[0][7];
                cli._producto = int.Parse(dt.Rows[0][8].ToString());
                cli._observacion = (string)dt.Rows[0][9];
                cli._cantidad = int.Parse(dt.Rows[0][10].ToString());
            }
            catch (Exception e)
            {
                cli._ID_Pedido = 0;
            }
            this.cnn.cerrarConexion();
            return cli;
        }

    }
}
