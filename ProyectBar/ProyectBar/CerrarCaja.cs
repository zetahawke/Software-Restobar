using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using System.Collections;
using Microsoft.PointOfService;

namespace ProyectBar
{
    public partial class CerrarCaja : Form
    {
        public static TextBox elcontrol;
        VentasXTerminal vxt = new VentasXTerminal();

        public CerrarCaja(VentasXTerminal ft)
        {
            InitializeComponent();

            if (ft._id_Venta != 0)
            {
                btnOpenClose.Visible = false;
                btnCerrar.Visible = true;

                NegocioBoleta negbol = new NegocioBoleta();
                NegocioDetalleBoleta negde = new NegocioDetalleBoleta();

                vxt = ft;
                ArrayList listabol = negbol.getBoletaxterminal(vxt._terminal , vxt._FechaInicio);
                int totales = 0;
                int descuentos = 0;
                int devoluciones = 0;

                foreach(Boleta itbol in listabol){
                    ArrayList listadetalles = negde.getDetalleBoletaxBoleta(itbol._ID_Boleta);

                    foreach(DetalleBoleta itde in listadetalles){
                        totales += itde._total;
                        descuentos += itde._descuento;
                    }
                }


                txtID_Venta.Text = vxt._id_Venta + "";
                txtFechaInicial.Text = vxt._FechaInicio;
                txtTotalVentas.Text = totales + "";
                txtInicial.Text = vxt._totalInicial + "";
                txtInicial.ReadOnly = true;
                txtFechaTermino.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                txtEfectivo.Text = vxt._efectivo + "";
                txtTarjetas.Text = vxt._tarjetas + "";
                txtCheques.Text = vxt._cheques + "";
                txtDescuento.Text = descuentos + "";
                txtDevoluciones.Text = vxt._devoluciones + "";
                txtTerminal.Text = vxt._terminal + "";
            }
            else {
                btnOpenClose.Visible = true;
                btnCerrar.Visible = false;

                txtID_Venta.Text = int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString()) + "";
                txtFechaInicial.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                txtTotalVentas.Text = 0 + "";
                txtFechaTermino.Text = "";
                txtEfectivo.Text = 0 + "";
                txtTarjetas.Text = 0 + "";
                txtCheques.Text = 0 + "";
                txtDescuento.Text = 0 + "";
                txtDevoluciones.Text = 0 + "";
                txtTerminal.Text = 1 + "";
            }
        }

        public void InsertarLetra(string letra)
        {

            bool secuencia = false;
            
            try
            {
                if (elcontrol.ReadOnly != true)
                {

                    if (secuencia == true)
                    {
                        elcontrol.Text = "";
                        elcontrol.Text = letra;
                        secuencia = false;

                    }
                    else
                    {
                        elcontrol.Text = elcontrol.Text + letra;
                    }
                }
            }
            catch
            {

                MessageBox.Show("Debe Seleccionar un campo antes de ingresar datos", "Error");
            }
            

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            InsertarLetra("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            InsertarLetra("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            InsertarLetra("3");

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            InsertarLetra("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            InsertarLetra("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            InsertarLetra("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            InsertarLetra("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            InsertarLetra("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            InsertarLetra("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            InsertarLetra("0");
        }

      

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInicial.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    txtInicial.Text = txtInicial.Text.Substring(0, txtInicial.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
            }
        }

      

        private void txtInicial_Click(object sender, EventArgs e)
        {
            elcontrol = (TextBox)sender;
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            

            NegocioVentasXTerminal negvxt = new NegocioVentasXTerminal();

            vxt._id_Venta = int.Parse(txtID_Venta.Text);
            vxt._FechaInicio = txtFechaInicial.Text;
            vxt._totalVendido = int.Parse(txtTotalVentas.Text);
            try
            {
                vxt._totalInicial = int.Parse(txtInicial.Text);
            }
            catch {
                MessageBox.Show("Debe ingresar solo valores numéricos","Error de ingreso");
                return;
            }
            vxt._FechaTermino = txtFechaTermino.Text;
            vxt._efectivo = int.Parse(txtEfectivo.Text);
            vxt._tarjetas = int.Parse(txtTarjetas.Text);
            vxt._cheques = int.Parse(txtCheques.Text);
            vxt._descuento = int.Parse(txtDescuento.Text);
            vxt._devoluciones = int.Parse(txtDevoluciones.Text);
            vxt._terminal = 1;//int.Parse(txtTerminal.Text);

            negvxt.insertarVentasxTerminal(vxt);

            ArrayList imp = new ArrayList();
            imp.Add(" ===============================================\n");
            imp.Add("        X -Informe de Caja Parcial- X\n");
            imp.Add(" ===============================================\n");
            imp.Add("                Road House Bar\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("                    Cierre\n");
            imp.Add("  Punto de Venta: ...... " + txtTerminal.Text + "\n");
            imp.Add("  Codigo Único: ........ " + txtID_Venta.Text + "\n");
            imp.Add("  Fecha de Negocio: .... " + DateTime.Now.ToShortDateString() + "\n");
            imp.Add("  Desde: ............... " + txtFechaInicial.Text + "\n");
            imp.Add("  Hasta: ............... " + txtFechaTermino.Text + "\n");
            imp.Add(" ===============================================\n");
            imp.Add("  Saldo inicial: ....... $ " + txtInicial.Text + "\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Ventas Registradas:\n");
            imp.Add("    Efectivo: .......... $ " + txtEfectivo.Text + "\n");
            imp.Add("    Descuentos: ........ $ " + txtDescuento.Text + "\n");
            imp.Add("  Ingresos en caja:\n");
            imp.Add("  Gastos en caja:\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Saldo Final: ......... $ " + txtTotalVentas.Text + "\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Devoluciones: ........ $ " + txtDevoluciones.Text + "\n");
            imp.Add(" ===============================================\n\n\n\n\n\n\n\n");
            

            //Imprimir(imp);
            
            Form1.estadocaja = true;
            Form1.vxt = vxt;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            NegocioVentasXTerminal negvxt = new NegocioVentasXTerminal();
            vxt = new VentasXTerminal();
            vxt._id_Venta = int.Parse(txtID_Venta.Text);
            vxt._FechaInicio = txtFechaInicial.Text;
            vxt._totalVendido = int.Parse(txtTotalVentas.Text);
            vxt._totalInicial = int.Parse(txtInicial.Text);
            vxt._FechaTermino = txtFechaTermino.Text;
            vxt._efectivo = int.Parse(txtEfectivo.Text);
            vxt._tarjetas = int.Parse(txtTarjetas.Text);
            vxt._cheques = int.Parse(txtCheques.Text);
            vxt._descuento = int.Parse(txtDescuento.Text);
            vxt._devoluciones = int.Parse(txtDevoluciones.Text);
            vxt._terminal = 1;// int.Parse(txtTerminal.Text);

            negvxt.modificarVentasXTerminal(vxt);

            ArrayList imp = new ArrayList();
            imp.Add(" ===============================================\n");
            imp.Add("        X -Informe de Caja Parcial- X\n");
            imp.Add(" ===============================================\n");
            imp.Add("                Road House Bar\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("                    Cierre\n");
            imp.Add("  Punto de Venta: ...... " + txtTerminal.Text + "\n");
            imp.Add("  Codigo Único: ........ " + txtID_Venta.Text + "\n");
            imp.Add("  Fecha de Negocio: .... " + DateTime.Now.ToShortDateString() + "\n");
            imp.Add("  Desde: ............... " + txtFechaInicial.Text + "\n");
            imp.Add("  Hasta: ............... " + txtFechaTermino.Text + "\n");
            imp.Add(" ===============================================\n");
            imp.Add("  Saldo inicial: ....... $ " + txtInicial.Text + "\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Ventas Registradas:\n");
            imp.Add("    Efectivo: .......... $ " + txtEfectivo.Text + "\n");
            imp.Add("    Descuentos: ........ $ " + txtDescuento.Text + "\n");
            imp.Add("  Ingresos en caja:\n");
            imp.Add("  Gastos en caja:\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Saldo Final: ......... $ " + txtTotalVentas.Text + "\n");
            imp.Add(" -----------------------------------------------\n");
            imp.Add("  Devoluciones: ........ $ " + txtDevoluciones.Text + "\n");
            imp.Add(" ===============================================\n\n\n\n\n\n\n\n");

            //Imprimir(imp);

            Form1.estadocaja = false;
            Form1.vxt = new VentasXTerminal();
            this.Close();
        }

        private bool Imprimir(ArrayList lista)
        {
            bool impreso = false;
            try
            {
                PosExplorer explorer = new PosExplorer();
                PosPrinter MiImpresora;

                IEnumerator unidades = explorer.GetDevices(DeviceType.PosPrinter).GetEnumerator();

                while (unidades.MoveNext())
                {
                    DeviceInfo inf = (DeviceInfo)unidades.Current;
                    IEnumerator nombres = inf.LogicalNames.GetEnumerator();
                    while (nombres.MoveNext())
                    {
                        string logico = (string)nombres.Current;

                        MessageBox.Show("" + logico);
                    }
                }

                DeviceInfo unidadEpson = explorer.GetDevice(DeviceType.PosPrinter, "PosPrinter");

                MiImpresora = (PosPrinter)explorer.CreateInstance(unidadEpson);
                MiImpresora.Open();
                MiImpresora.Claim(1000);
                MiImpresora.DeviceEnabled = true;

                foreach (string item in lista)
                {
                    MiImpresora.PrintNormal(PrinterStation.Receipt, item);
                }
                MiImpresora.PrintNormal(PrinterStation.Receipt, "\n\n\n\n\n\n\n\n\n");
                MiImpresora.CutPaper(90);
                MiImpresora.Close();
                impreso = true;
            }
            catch
            {
                impreso = false;
            }
            return impreso;
        }

    }
}
