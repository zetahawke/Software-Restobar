using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using CapaDatos;
using System.Collections;
using Microsoft.PointOfService;

namespace ProyectBar
{
    public partial class Pagar : Form
    {

        public Pagar()
        {
            InitializeComponent();

            cargarCuentas();

            txtPropina.Text = ((int.Parse(txtTotal.Text) * 10) / 100) + "";
        }

        int subtotal = 0;
        int exento = 0;
        int Descuento = 0;
        Double total = 0;
        int efectivo = 0;
        int propina = 0;
        int vuelto = 0;

        int ancho = 61;
        int alto = 155;
        int alto2 = 155;
        int ancho2 = 3;

        int ide = 0;
        ArrayList boletasgeneradas = new ArrayList();

        public static bool cerrarmesa = false;

        private void cargarCuentas() {
            
            foreach(CheckBox it in gbCuentas.Controls){
                if(it != rbTodos){
                    gbCuentas.Controls.Remove(it);
                }
                rbTodos.Checked = true;
            }

            int posicion = 20;
            int mesa = int.Parse(Form1.nombremesa.ToString());
            NegocioCuenta negcue = new NegocioCuenta();
            ArrayList cuentas = negcue.getCuentaxMesa(mesa);

            foreach(Cuenta item in cuentas){
                posicion += 20;
                CheckBox check = new CheckBox();
                check.Text = item._nombre;
                check.Name = item._ID_Cuenta + "";
                check.Location = new System.Drawing.Point(7, posicion);
                AsignarEventos(check);

                gbCuentas.Controls.Add(check);
            }
            rbTodos.Checked = true;
            calculartotal();


        }

        private void AsignarEventos(CheckBox chk)
        {
            chk.CheckedChanged += new System.EventHandler(this.ControldeSeleccion);
        }

        private void ControldeSeleccion(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            rbTodos.Checked = false;
            NegocioCuenta_Producto negcuepro = new NegocioCuenta_Producto();
            NegocioCuenta negcue = new NegocioCuenta();
            NegocioProducto negpro = new NegocioProducto();

            ArrayList cuenpro = new ArrayList();

            if(chk.Checked == true){
                Label lbl = new Label();
                lbl.Width = 60;
                lbl.Name = "lblSubTotal" + chk.Text;
                lbl.Text = "" + chk.Text;
                TextBox txt = new TextBox();
                txt.Name = "txtSubtotal" + chk.Text;

                IEnumerator mostrar = negcuepro.getCuenta_ProductoxCuenta2(int.Parse(chk.Name.ToString())).GetEnumerator();
                int sub = 0;
                while (mostrar.MoveNext())
                {
                    Cuenta_Producto cp = (Cuenta_Producto)mostrar.Current;

                    cuenpro.Add(cp);
                }

                foreach (Cuenta_Producto cupr in cuenpro)
                {
                    Producto pro = negpro.buscarProducto(cupr._producto);

                    sub += pro._precio * cupr._cantidad;


                }

                txt.Text = ""+sub ;
                txt.TextAlign = HorizontalAlignment.Center;
                txt.Width = 104;
                txt.ReadOnly = true;

                gbTotal.Controls.Add(lbl);
                gbTotal.Controls.Add(txt);
            }
            else
            {
                Control[] df = gbTotal.Controls.Find("txtSubtotal" + chk.Text,false);
                Control er = df[0];
                gbTotal.Controls.Remove(er);
                Control[] df2 = gbTotal.Controls.Find("lblSubTotal" + chk.Text, false);
                Control er2 = df2[0];
                gbTotal.Controls.Remove(er2);
            }
            recalculartotalxcuentas();

        }
        

        private void calculartotal() {
            subtotal = 0;
            exento = 0;
            Descuento = 0;
            total = 0;
            efectivo = 0;
            propina = 0;
            vuelto = 0;
            if(rbTodos.Checked == true){
                NegocioCuenta negcue = new NegocioCuenta();
                NegocioCuenta_Producto negcuepro = new NegocioCuenta_Producto();
                NegocioProducto negpro = new NegocioProducto();

                ArrayList cuentas = new ArrayList();
                ArrayList cuenpro = new ArrayList();

                foreach (CheckBox item in gbCuentas.Controls)
                {
                    if (item != rbTodos)
                    {
                        cuentas.Add(negcue.buscarCuenta(int.Parse(item.Name.ToString())));
                    }
                }



                foreach (Cuenta cue in cuentas)
                {
                    IEnumerator mostrar = negcuepro.getCuenta_ProductoxCuenta2(cue._ID_Cuenta).GetEnumerator();
                    int sub = 0;
                    while (mostrar.MoveNext())
                    {
                        Cuenta_Producto cp = (Cuenta_Producto)mostrar.Current;

                        cuenpro.Add(cp);
                    }

                    foreach (Cuenta_Producto cupr in cuenpro)
                    {
                        Producto pro = negpro.buscarProducto(cupr._producto);

                        subtotal += pro._precio * cupr._cantidad;


                    }
                    sub = subtotal;
                    cuenpro.Clear();
                    total = sub - ((sub * Descuento) / 100);
                }
            }


            txtSubTotal.Text = "" + subtotal;
            txtTotal.Text = "" + total;
            txtVuelto.Text = "" + vuelto;
            txtExento.Text = exento + "";
            txtDescuento.Text = Descuento + "";
            txtEfectivo.Text = efectivo + "";
            txtPropina.Text = propina + "";
        
        }

        private void recalculartotalxcuentas(){
            subtotal = 0;
            exento = 0;
            Descuento = 0;
            total = 0;
            efectivo = 0;
            propina = 0;
            vuelto = 0;

            NegocioCuenta negcue = new NegocioCuenta();
            NegocioCuenta_Producto negcuepro = new NegocioCuenta_Producto();
            NegocioProducto negpro = new NegocioProducto();

            ArrayList cuentas = new ArrayList();
            ArrayList numcue = new ArrayList();
            ArrayList cuenpro = new ArrayList();

            ArrayList cuanAlto = new ArrayList();

            foreach (CheckBox item in gbCuentas.Controls)
            {
                if(item.Checked == true){
                    cuanAlto.Add(1);
                }
            }
            

            foreach (CheckBox item in gbCuentas.Controls)
            {
                int suman = 0;
                foreach(int it in cuanAlto){
                    suman += 25;
                }

                alto = 155 + suman;
                alto2 = 155 + suman;

                if (item.Checked == true)
                {
                    alto += 25;
                    alto2 += 25;

                    numcue.Add(int.Parse(item.Name.ToString()));
                    string nombre = "SubTotal" ;
                    IEnumerator controles = gbTotal.Controls.GetEnumerator();

                    

                    while(controles.MoveNext()){
                        TextBox txt = new TextBox();
                        if (controles.Current.GetType() == txt.GetType())
                        {
                            Control ctl = (Control)controles.Current;

                            ctl.Location = new System.Drawing.Point(ancho, alto);
                            alto -= 25;
                        }
                        else {
                            Control ctl = (Control)controles.Current;

                            ctl.Location = new System.Drawing.Point(ancho2, alto2);
                            alto2 -= 25;
                        }
                        
                    }


                }
            }

            foreach (int ide in numcue)
            {
                cuentas.Add(negcue.buscarCuenta(ide));
            }



            foreach (Cuenta cue in cuentas)
            {
                IEnumerator mostrar = negcuepro.getCuenta_ProductoxCuenta2(cue._ID_Cuenta).GetEnumerator();
                int sub = 0;
                while (mostrar.MoveNext())
                {
                    Cuenta_Producto cp = (Cuenta_Producto)mostrar.Current;

                    cuenpro.Add(cp);
                }

                foreach (Cuenta_Producto cupr in cuenpro)
                {
                    Producto pro = negpro.buscarProducto(cupr._producto);

                    subtotal += pro._precio * cupr._cantidad;


                }
                sub = subtotal;
                cuenpro.Clear();
                total = sub - ((sub * Descuento) / 100);
            }

            txtSubTotal.Text = "" + subtotal;
            txtTotal.Text = "" + total;
            txtVuelto.Text = "" + vuelto;
            txtExento.Text = exento + "";
            txtDescuento.Text = Descuento + "";
            txtEfectivo.Text = efectivo + "";
            txtPropina.Text = propina + "";
        }

        /*
         * e
        TextBox global = null;

        private void TextBox_Seleccionado()
        {
            
        }
         * */

        public static Control elControl;

        private void chkContado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContado.Checked)
            {
                gbTotal.Location = new System.Drawing.Point(537, 12);
                pnlTecladoNumerico.Location = new System.Drawing.Point(754, 16);
                tcCheque.Visible = false;
                gbTarjetaDeCredito.Visible = false;
            }
        }

        private void rbCheque_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheque.Checked)
            {
                tcCheque.Visible = true;
                gbTarjetaDeCredito.Visible = false;
                gbTotal.Location = new System.Drawing.Point(810, 12);
                pnlTecladoNumerico.Location = new System.Drawing.Point(1030, 19);

            }
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTarjetaCredito.Checked)
            {
                gbTarjetaDeCredito.Visible = true;
                tcCheque.Visible = false;
                gbTotal.Location = new System.Drawing.Point(775, 12);
                pnlTecladoNumerico.Location = new System.Drawing.Point(993, 19);
            }
        }

        private void chkConvenio_Forma_Pago_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConvenio_Forma_Pago.Checked)
            {
                gbTotal.Location = new System.Drawing.Point(537, 12);
                pnlTecladoNumerico.Location = new System.Drawing.Point(754, 16);
                tcCheque.Visible = false;
                gbTarjetaDeCredito.Visible = false;
            }
        }

        private void chkPagoFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPagoFecha.Checked)
            {
                gbTotal.Location = new System.Drawing.Point(537, 12);
                pnlTecladoNumerico.Location = new System.Drawing.Point(754, 16);
                tcCheque.Visible = false;
                gbTarjetaDeCredito.Visible = false;
            }
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtRutTarjeta_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnKRut.Enabled = true;
            btnGuion.Enabled = true;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtRut_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnKRut.Enabled = true;
            btnGuion.Enabled = true;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            pnlTecladoNumerico.Enabled = false;
            elControl = (Control)sender;

            if (esVisible == false)
            {
                pnlTeclado.Enabled = true;
            }
            else
            {
                pnlTeclado.Enabled = false;
            }
        }

        private void txtTelefono_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtMontoCheque_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtRut2_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnKRut.Enabled = true;
            btnGuion.Enabled = true;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtNombre2_Click(object sender, EventArgs e)
        {
            pnlTecladoNumerico.Enabled = false;
            elControl = (Control)sender;

            if (esVisible == false)
            {
                pnlTeclado.Enabled = true;
            }
            else
            {
                pnlTeclado.Enabled = false;
            }
        }

        private void txtTelefono2_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtMontoCheque2_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtRut3_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnKRut.Enabled = true;
            btnGuion.Enabled = true;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtNombre3_Click(object sender, EventArgs e)
        {
            pnlTecladoNumerico.Enabled = false;
            elControl = (Control)sender;

            if (esVisible == false)
            {
                pnlTeclado.Enabled = true;
            }
            else
            {
                pnlTeclado.Enabled = false;
            }
        }

        private void txtTelefono3_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtMontoCheque3_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtRut4_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnKRut.Enabled = true;
            btnGuion.Enabled = true;
            pnlTecladoNumerico.Enabled = true;

        }

        private void txtNombre4_Click(object sender, EventArgs e)
        {
            pnlTecladoNumerico.Enabled = false;
            elControl = (Control)sender;

            if (esVisible == false)
            {
                pnlTeclado.Enabled = true;
            }
            else
            {
                pnlTeclado.Enabled = false;
            }
        }

        private void txtTelefono4_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtMontoCheque4_Click(object sender, EventArgs e)
        {
            pnlTeclado.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
            btnKRut.Enabled = false;
            btnGuion.Enabled = false;
        }

        private void txtNombreTarjeta_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = true;
            pnlTecladoNumerico.Enabled = false;
        }

        private void txtMontoTarjeta_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnGuion.Enabled = false;
            btnKRut.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
        }

        private void txtDescuento_Click(object sender, EventArgs e)
        {
            elControl = (Control)sender;
            pnlTeclado.Enabled = false;
            btnGuion.Enabled = false;
            btnKRut.Enabled = false;
            pnlTecladoNumerico.Enabled = true;
        }



        private void InsertarNumero(string numero)
        {
            bool secuencia = false;

            try
            {
                if (secuencia == true)
                {
                    elControl.Text = "";
                    elControl.Text = numero;
                    secuencia = false;

                }
                else
                {
                    elControl.Text = elControl.Text + numero;
                }
            }
            catch
            {

                MessageBox.Show("Debe Seleccionar un campo antes de ingresar datos", "Error");
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            InsertarNumero("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            InsertarNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            InsertarNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            InsertarNumero("3");

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            InsertarNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            InsertarNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            InsertarNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            InsertarNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            InsertarNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            InsertarNumero("9");
        }

        private void btnGuion_Click(object sender, EventArgs e)
        {
            InsertarLetra("-");
        }

        private void btnKRut_Click(object sender, EventArgs e)
        {
            InsertarLetra("K");
        }

        //Oculta Teclado
        bool esVisible = false;



        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (elControl.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    elControl.Text = elControl.Text.Substring(0, elControl.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
            }
        }

        private void InsertarLetra(string letra)
        {

            bool secuencia = false;

            try
            {
                if (secuencia == true)
                {
                    elControl.Text = "";
                    elControl.Text = letra;
                    secuencia = false;

                }
                else
                {
                    elControl.Text = elControl.Text + letra;
                }
            }
            catch
            {

                MessageBox.Show("Debe Seleccionar un campo antes de ingresar datos", "Error");
            }


        }

        private void btnQ_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("Q");
            }
            else
            {
                InsertarLetra("q");
            }
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("W");
            }
            else
            {
                InsertarLetra("w");
            }
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("E");
            }
            else
            {
                InsertarLetra("e");
            }
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("R");
            }
            else
            {
                InsertarLetra("r");
            }
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("T");
            }
            else
            {
                InsertarLetra("t");
            }
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("Y");
            }
            else
            {
                InsertarLetra("y");
            }
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("U");
            }
            else
            {
                InsertarLetra("u");
            }
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("I");
            }
            else
            {
                InsertarLetra("i");
            }
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("O");
            }
            else
            {
                InsertarLetra("o");
            }
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("P");
            }
            else
            {
                InsertarLetra("p");
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("A");
            }
            else
            {
                InsertarLetra("a");
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("S");
            }
            else
            {
                InsertarLetra("s");
            }
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("D");
            }
            else
            {
                InsertarLetra("d");
            }
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("F");
            }
            else
            {
                InsertarLetra("f");
            }
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("G");
            }
            else
            {
                InsertarLetra("g");
            }
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("H");
            }
            else
            {
                InsertarLetra("h");
            }
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("J");
            }
            else
            {
                InsertarLetra("j");
            }
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("K");
            }
            else
            {
                InsertarLetra("k");
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("L");
            }
            else
            {
                InsertarLetra("l");
            }
        }

        private void btnÑ_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("Ñ");
            }
            else
            {
                InsertarLetra("ñ");
            }
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("Z");
            }
            else
            {
                InsertarLetra("z");
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("X");
            }
            else
            {
                InsertarLetra("x");
            }
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("C");
            }
            else
            {
                InsertarLetra("c");
            }
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("V");
            }
            else
            {
                InsertarLetra("v");
            }
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("B");
            }
            else
            {
                InsertarLetra("b");
            }
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("N");
            }
            else
            {
                InsertarLetra("n");
            }
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            if (Estado == false)
            {
                InsertarLetra("M");
            }
            else
            {
                InsertarLetra("m");
            }
        }

        private void btnEspacio_Click(object sender, EventArgs e)
        {
            InsertarLetra(" ");
        }

        //Variable estado Teclado
        bool Estado = true;

        private void btnBloqMayus_Click(object sender, EventArgs e)
        {
            if (Estado == true)
            {

                btnA.Text = "A";
                btnB.Text = "B";
                btnC.Text = "C";
                btnD.Text = "D";
                btnE.Text = "E";
                btnF.Text = "F";
                btnG.Text = "G";
                btnH.Text = "H";
                btnI.Text = "I";
                btnJ.Text = "J";
                btnK.Text = "L";
                btnM.Text = "M";
                btnN.Text = "N";
                btnÑ.Text = "Ñ";
                btnO.Text = "O";
                btnP.Text = "P";
                btnQ.Text = "Q";
                btnR.Text = "R";
                btnS.Text = "S";
                btnT.Text = "T";
                btnU.Text = "U";
                btnV.Text = "V";
                btnW.Text = "W";
                btnX.Text = "X";
                btnY.Text = "Y";
                btnZ.Text = "Z";
                Estado = false;
            }
            else
            {
                Estado = true;
                this.btnBloqMayus.UseVisualStyleBackColor = true;

                btnA.Text = "a";
                btnB.Text = "b";
                btnC.Text = "c";
                btnD.Text = "d";
                btnE.Text = "e";
                btnF.Text = "f";
                btnG.Text = "g";
                btnH.Text = "h";
                btnI.Text = "i";
                btnJ.Text = "j";
                btnK.Text = "l";
                btnM.Text = "m";
                btnN.Text = "n";
                btnÑ.Text = "ñ";
                btnO.Text = "o";
                btnP.Text = "p";
                btnQ.Text = "q";
                btnR.Text = "r";
                btnS.Text = "s";
                btnT.Text = "t";
                btnU.Text = "u";
                btnV.Text = "v";
                btnW.Text = "w";
                btnX.Text = "x";
                btnY.Text = "y";
                btnZ.Text = "z";

            }
        }

        private void btnBorrarTeclado_Click(object sender, EventArgs e)
        {
            try
            {
                if (elControl.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    elControl.Text = elControl.Text.Substring(0, elControl.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
            }
        }

        private void chkBoleta_Click(object sender, EventArgs e)
        {
            tipoboleta = 1;
        }

        private void chkFactura_Click(object sender, EventArgs e)
        {
            tipoboleta = 2;
        }

        private void chkGuia_Click(object sender, EventArgs e)
        {
            tipoboleta = 3;
        }

        private void chkGentileza_Click(object sender, EventArgs e)
        {
            tipoboleta = 4;
        }

        private void chkConvenio_Click(object sender, EventArgs e)
        {
            tipoboleta = 5;
        }

        private void chkChequeRestaurant_Click(object sender, EventArgs e)
        {
            tipoboleta = 6;
        }

        private void chkContado_Click(object sender, EventArgs e)
        {
            mediopago = 1;
        }

        private void chkCheque_Click(object sender, EventArgs e)
        {
            mediopago = 2;
        }

        private void chkTarjetaCredito_Click(object sender, EventArgs e)
        {
            mediopago = 3;
        }

        private void chkConvenio_Forma_Pago_Click(object sender, EventArgs e)
        {
            mediopago = 4;
        }

        private void chkPagoFecha_Click(object sender, EventArgs e)
        {
            mediopago = 5;
        }


        private void Pagar_Click(object sender, EventArgs e)
        {
            if (esVisible == true)
            {
                pnlTeclado.Enabled = true;
            }

            else
            {
                pnlTeclado.Enabled = false;
            }
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        int mediopago = 1;
        int tipoboleta = 1;

        private void lblPagar_Click(object sender, EventArgs e)
        {
            if (txtSubTotal.Text.Length == 0)
            {
                return;
            }
            if (txtExento.Text.Length == 0)
            {
                return;
            }
            if (txtDescuento.Text.Length == 0)
            {
                return;
            }
            if (txtTotal.Text.Length == 0)
            {
                return;
            }
            if (txtEfectivo.Text.Length == 0)
            {
                return;
            }
            if (txtPropina.Text.Length == 0)
            {
                return;
            }
            if (txtVuelto.Text.Length == 0)
            {
                return;
            }

            ide = int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());

            int numeromesa = int.Parse(Form1.nombremesa.ToString());

            NegocioCuenta negcue = new NegocioCuenta();
            NegocioCuenta_Producto negcp = new NegocioCuenta_Producto();
            NegocioTipo_Boleta negti = new NegocioTipo_Boleta();
            NegocioBoleta negbo = new NegocioBoleta();
            NegocioDetalleBoleta negdet = new NegocioDetalleBoleta();
            NegocioProducto negpro = new NegocioProducto();
            NegocioTarjetaCredito negtar = new NegocioTarjetaCredito();
            NegocioCheques negcheq = new NegocioCheques();

            int vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());


            switch(mediopago){
                case 2:
                    if(txtPlaza.Text.Length == 0 || txtPlaza.Text.Length == 0 || txtCuentaCorriente.Text.Length == 0
                        || txtMontoCheque.Text.Length == 0 || txtNumeroCheque.Text.Length == 0 || txtTelefono.Text.Length == 0
                        || txtNombre.Text.Length == 0 || txtRut.Text.Length == 0){
                            return;
                    }

                    
            

                    if(rbTodos.Checked != true){
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;

                        negbo.insertarBoleta(bo);

                        

                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();

                        foreach(CheckBox chk in gbCuentas.Controls){
                            if(chk.Checked == true){
                                numcuen.Add(int.Parse(chk.Name.ToString()));
                            }
                        }

                        foreach(int item in numcuen){
                            cuentas.Add(negcue.buscarCuenta(item));
                        }

                        foreach (Cuenta item in cuentas)
                        {

                            vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                            Cheques che = new Cheques();
                            che._idChequeaPago = vae;
                            che._boleta = bo._ID_Boleta;
                            che._banco = cmbBanco.SelectedItem.ToString();
                            che._plaza = txtPlaza.Text.ToString();
                            che._CuentaCorriente = txtCuentaCorriente.Text.ToString();
                            che._MontoCheque = int.Parse(txtMontoCheque.Text.ToString());
                            che._NumeroCheque = int.Parse(txtNumeroCheque.Text.ToString());
                            che._telefono = txtTelefono.Text.ToString();
                            che._NombrePersona = txtNombre.Text.ToString();
                            che._rutPersona = txtRut.Text.ToString();
                            che._Fecha = dtpFecha.Text.ToString();
                            che._Cuenta = item._ID_Cuenta;

                            negcheq.insertarCheques(che);
                            /*
                            if (chkPagoAFecha2.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco2.SelectedItem.ToString();
                                che._plaza = txtPlaza2.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente2.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque2.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque2.Text.ToString());
                                che._telefono = txtTelefono2.Text.ToString();
                                che._NombrePersona = txtNombre2.Text.ToString();
                                che._rutPersona = txtRut2.Text.ToString();
                                che._Fecha = dtpFecha2.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            if (chkPagoAFecha3.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco3.SelectedItem.ToString();
                                che._plaza = txtPlaza3.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente3.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque3.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque3.Text.ToString());
                                che._telefono = txtTelefono3.Text.ToString();
                                che._NombrePersona = txtNombre3.Text.ToString();
                                che._rutPersona = txtRut3.Text.ToString();
                                che._Fecha = dtpFecha3.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            if (chkPagoAFecha4.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco4.SelectedItem.ToString();
                                che._plaza = txtPlaza4.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente4.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque4.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque4.Text.ToString());
                                che._telefono = txtTelefono4.Text.ToString();
                                che._NombrePersona = txtNombre4.Text.ToString();
                                che._rutPersona = txtRut4.Text.ToString();
                                che._Fecha = dtpFecha4.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            */

                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;

                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);



                            item._expirada = 2;
                            negcue.modificarCuenta(item);
                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                        }
                        MessageBox.Show(""+ detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }
                    }
                    else
                    {
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;

                        negbo.insertarBoleta(bo);

                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();
                        cuentas = negcue.getCuentaxMesa(numeromesa);

                        foreach(Cuenta item in cuentas){

                            vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                            Cheques che = new Cheques();
                            che._idChequeaPago = vae;
                            che._boleta = bo._ID_Boleta;
                            che._banco = cmbBanco.SelectedItem.ToString();
                            che._plaza = txtPlaza.Text.ToString();
                            che._CuentaCorriente = txtCuentaCorriente.Text.ToString();
                            che._MontoCheque = int.Parse(txtMontoCheque.Text.ToString());
                            che._NumeroCheque = int.Parse(txtNumeroCheque.Text.ToString());
                            che._telefono = txtTelefono.Text.ToString();
                            che._NombrePersona = txtNombre.Text.ToString();
                            che._rutPersona = txtRut.Text.ToString();
                            che._Fecha = dtpFecha.Text.ToString();
                            che._Cuenta = item._ID_Cuenta;

                            negcheq.insertarCheques(che);
                            /*
                            if (chkPagoAFecha2.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco2.SelectedItem.ToString();
                                che._plaza = txtPlaza2.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente2.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque2.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque2.Text.ToString());
                                che._telefono = txtTelefono2.Text.ToString();
                                che._NombrePersona = txtNombre2.Text.ToString();
                                che._rutPersona = txtRut2.Text.ToString();
                                che._Fecha = dtpFecha2.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            if (chkPagoAFecha3.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco3.SelectedItem.ToString();
                                che._plaza = txtPlaza3.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente3.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque3.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque3.Text.ToString());
                                che._telefono = txtTelefono3.Text.ToString();
                                che._NombrePersona = txtNombre3.Text.ToString();
                                che._rutPersona = txtRut3.Text.ToString();
                                che._Fecha = dtpFecha3.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            if (chkPagoAFecha4.Checked == true)
                            {
                                che = new Cheques();
                                vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                                che._idChequeaPago = vae;
                                che._boleta = bo._ID_Boleta;
                                che._banco = cmbBanco4.SelectedItem.ToString();
                                che._plaza = txtPlaza4.Text.ToString();
                                che._CuentaCorriente = txtCuentaCorriente4.Text.ToString();
                                che._MontoCheque = int.Parse(txtMontoCheque4.Text.ToString());
                                che._NumeroCheque = int.Parse(txtNumeroCheque4.Text.ToString());
                                che._telefono = txtTelefono4.Text.ToString();
                                che._NombrePersona = txtNombre4.Text.ToString();
                                che._rutPersona = txtRut4.Text.ToString();
                                che._Fecha = dtpFecha4.Text.ToString();
                                che._Cuenta = item._ID_Cuenta;

                                negcheq.insertarCheques(che);
                            }
                            */

                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;
                
                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);

                            item._expirada = 2;
                            negcue.modificarCuenta(item);

                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                        }
                        MessageBox.Show(""+ detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }
                        
                    }
                    cargarCuentas();
                    this.Close();
                    break;
                case 3:
                    if(txtNumeroTarjeta.Text.Length == 0 || txtTransaccion.Text.Length == 0 || txtRutTarjeta.Text.Length == 0
                        || txtNombreTarjeta.Text.Length == 0 || txtMontoTarjeta.Text.Length == 0)
                    {
                        return;
                    }

            

                    if(rbTodos.Checked != true){
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;
                        negbo.insertarBoleta(bo);

                        
                        
                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();

                        foreach(CheckBox chk in gbCuentas.Controls){
                            if(chk.Checked == true){
                                numcuen.Add(int.Parse(chk.Name.ToString()));
                            }
                        }

                        foreach(int item in numcuen){
                            cuentas.Add(negcue.buscarCuenta(item));
                        }

                        foreach (Cuenta item in cuentas)
                        {
                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;

                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);



                            item._expirada = 2;
                            negcue.modificarCuenta(item);

                            TarjetaCredito tar = new TarjetaCredito();
                            tar._idPagoTarjeta = bo._ID_Boleta + vae;
                            tar._boleta = bo._ID_Boleta;
                            tar._tipoTarjeta = cmbTarjeta.SelectedItem.ToString();
                            tar._numeroTarjeta = int.Parse(txtNumeroTarjeta.Text.ToString());
                            tar._transaccion = int.Parse(txtTransaccion.Text.ToString());
                            tar._rut = txtRutTarjeta.Text.ToString();
                            tar._nombreTitutar = txtNombreTarjeta.Text.ToString();
                            tar._MontoAtarjeta = int.Parse(txtMontoTarjeta.Text.ToString());
                            tar._Cuenta = item._ID_Cuenta;
                            negtar.insertarTarjeta(tar);

                            vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                        }
                        MessageBox.Show(""+ detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }
                    }
                    else
                    {
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;
                        negbo.insertarBoleta(bo);
                                                
                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();
                        cuentas = negcue.getCuentaxMesa(numeromesa);

                        foreach(Cuenta item in cuentas){
                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;

                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);

                            item._expirada = 2;
                            negcue.modificarCuenta(item);

                            TarjetaCredito tar = new TarjetaCredito();
                            tar._idPagoTarjeta = bo._ID_Boleta + vae;
                            tar._boleta = bo._ID_Boleta;
                            tar._tipoTarjeta = cmbTarjeta.SelectedItem.ToString();
                            tar._numeroTarjeta = int.Parse(txtNumeroTarjeta.Text.ToString());
                            tar._transaccion = int.Parse(txtTransaccion.Text.ToString());
                            tar._rut = txtRutTarjeta.Text.ToString();
                            tar._nombreTitutar = txtNombreTarjeta.Text.ToString();
                            tar._MontoAtarjeta = int.Parse(txtMontoTarjeta.Text.ToString());
                            tar._Cuenta = item._ID_Cuenta;
                            negtar.insertarTarjeta(tar);

                            vae = ide + int.Parse(DateTime.Now.Hour.ToString()) * int.Parse(DateTime.Now.Millisecond.ToString());
                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                        }
                        MessageBox.Show(""+ detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }
                    }
                    cargarCuentas();
                    this.Close();
                    break;
                default:


                    ArrayList lista = new ArrayList();
            

                    if(rbTodos.Checked != true){
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;

                        negbo.insertarBoleta(bo);
                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();

                        foreach(CheckBox chk in gbCuentas.Controls){
                            if(chk.Checked == true){
                                numcuen.Add(int.Parse(chk.Name.ToString()));
                            }
                        }

                        foreach(int item in numcuen){
                            cuentas.Add(negcue.buscarCuenta(item));
                        }

                        foreach (Cuenta item in cuentas)
                        {
                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;

                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);



                            item._expirada = 2;
                            negcue.modificarCuenta(item);
                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                            lista.Add(it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n");
                        }
                        MessageBox.Show(""+ detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }

                        Imprimir(lista);
                    }
                    else
                    {
                        Boleta bo = new Boleta();
                        bo._ID_Boleta = ide;
                        bo._hora = DateTime.Now.ToLongTimeString();
                        bo._Fecha = DateTime.Now.ToShortDateString();
                        bo._tipo_boleta = tipoboleta;
                        bo._Terminal = 1;

                        negbo.insertarBoleta(bo);
                        ArrayList cuentas = new ArrayList();
                        ArrayList numcuen = new ArrayList();
                        cuentas = negcue.getCuentaxMesa(numeromesa);

                        foreach(Cuenta item in cuentas){
                            ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);

                            DetalleBoleta detalle = new DetalleBoleta();
                            detalle._ID_Detalle = item._ID_Cuenta + ide;
                            detalle._Cuenta = item._ID_Cuenta;

                            detalle._Boleta = bo._ID_Boleta;
                            foreach (Cuenta_Producto item2 in cuenta_productos)
                            {

                                Producto pro = negpro.buscarProducto(item2._producto);
                                detalle._total += int.Parse(txtTotal.Text.ToString());
                                detalle._descripcion += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                                    "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                            }

                            detalle._subtotal = int.Parse(txtSubTotal.Text.ToString());
                            detalle._exento = int.Parse(txtExento.Text.ToString());
                            detalle._descuento = int.Parse(txtDescuento.Text.ToString());
                            detalle._efectivo = int.Parse(txtEfectivo.Text.ToString());
                            detalle._propina = int.Parse(txtPropina.Text.ToString());
                            detalle._vuelto = int.Parse(txtVuelto.Text.ToString());
                            negdet.insertarDetalleBoleta(detalle);

                            item._expirada = 2;
                            negcue.modificarCuenta(item);
                        }

                        ArrayList bol = negdet.getDetalleBoletaxBoleta(ide);
                        string detailsamostrar = "";
                        foreach (DetalleBoleta it in bol)
                        {
                            detailsamostrar += it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n";
                            lista.Add(it._descripcion +
                                "   Subtotal: $ " + it._subtotal + "\n" +
                                "   Exento:   $ " + it._subtotal + "\n" +
                                "   Descuento:$ " + it._subtotal + "\n" +
                                "   Efectivo: $ " + it._subtotal + "\n" +
                                "   Propina:  $ " + it._subtotal + "\n" +
                                "   Vuelto:   $ " + it._subtotal + "\n");
                        }
                        MessageBox.Show("" + detailsamostrar);

                        cuentas = negcue.getCuentaxMesa(numeromesa);
                        if (cuentas.Count == 0)
                        {
                            NegocioMesa negme = new NegocioMesa();
                            Mesa me = negme.buscarMesa(numeromesa);
                            me._estado = 1;
                            me._estadia = "00:00:00";
                            me._llegada = "00:00:00";
                            me._salida = "00:00:00";
                            negme.modificarMesa(me);
                            cerrarmesa = true;
                        }

                        Imprimir(lista);
                    }
                    cargarCuentas();
                    this.Close();
                    break;
            }

            
        }





        private void lblImprimir_Click(object sender, EventArgs e)
        {
            int numeromesa = int.Parse(Form1.nombremesa.ToString());

            NegocioCuenta negcue = new NegocioCuenta();
            NegocioCuenta_Producto negcp = new NegocioCuenta_Producto();
            NegocioTipo_Boleta negti = new NegocioTipo_Boleta();
            NegocioBoleta negbo = new NegocioBoleta();
            NegocioDetalleBoleta negdet = new NegocioDetalleBoleta();
            NegocioProducto negpro = new NegocioProducto();



            ArrayList lista = new ArrayList();

            if (rbTodos.Checked != true)
            {
                
                ArrayList cuentas = new ArrayList();
                ArrayList numcuen = new ArrayList();

                foreach (CheckBox chk in gbCuentas.Controls)
                {
                    if (chk.Checked == true)
                    {
                        numcuen.Add(int.Parse(chk.Name.ToString()));
                    }
                }

                foreach (int item in numcuen)
                {
                    cuentas.Add(negcue.buscarCuenta(item));
                }

                string detailsamostrar = "";

                foreach (Cuenta item in cuentas)
                {
                    ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);


                    foreach (Cuenta_Producto item2 in cuenta_productos)
                    {

                        Producto pro = negpro.buscarProducto(item2._producto);
                        detailsamostrar += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                            "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                    }

                    detailsamostrar += "   Subtotal: $ " + int.Parse(txtSubTotal.Text.ToString()) + "\n";
                    detailsamostrar += "   Exento:   $ " + int.Parse(txtExento.Text.ToString()) + "\n";
                    detailsamostrar += "   Descuento:$ " + int.Parse(txtDescuento.Text.ToString()) + "\n";
                    detailsamostrar +=  "   Efectivo: $ " + int.Parse(txtEfectivo.Text.ToString() + "\n");
                    detailsamostrar += "   Propina:  $ " + int.Parse(txtPropina.Text.ToString()) + "\n";
                    detailsamostrar += "   Vuelto:   $ " + int.Parse(txtVuelto.Text.ToString()) + "\n";



                }

                
                MessageBox.Show("" + detailsamostrar);

                lista.Add(detailsamostrar);
                Imprimir(lista);
            }
            else
            {
                
                ArrayList cuentas = new ArrayList();
                ArrayList numcuen = new ArrayList();
                cuentas = negcue.getCuentaxMesa(numeromesa);

                string detailsamostrar = "";

                foreach (Cuenta item in cuentas)
                {
                    ArrayList cuenta_productos = negcp.getCuenta_ProductoxCuenta2(item._ID_Cuenta);


                    foreach (Cuenta_Producto item2 in cuenta_productos)
                    {

                        Producto pro = negpro.buscarProducto(item2._producto);
                        detailsamostrar += item._nombre + "    " + item._Mesa + "\n" + pro._nombre +
                            "    " + item2._cantidad + "     " + pro._precio + "\n\n";
                    }

                    detailsamostrar += "   Subtotal: $ " + int.Parse(txtSubTotal.Text.ToString()) + "\n";
                    detailsamostrar += "   Exento:   $ " + int.Parse(txtExento.Text.ToString()) + "\n";
                    detailsamostrar += "   Descuento:$ " + int.Parse(txtDescuento.Text.ToString()) + "\n";
                    detailsamostrar += "   Efectivo: $ " + int.Parse(txtEfectivo.Text.ToString() + "\n");
                    detailsamostrar += "   Propina:  $ " + int.Parse(txtPropina.Text.ToString()) + "\n";
                    detailsamostrar += "   Vuelto:   $ " + int.Parse(txtVuelto.Text.ToString()) + "\n";



                }


                MessageBox.Show("" + detailsamostrar);
                lista.Add(detailsamostrar);
                Imprimir(lista);
            }
            
            this.Close();
        }

        private void rbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(rbTodos.Checked == true){
                foreach(CheckBox item in gbCuentas.Controls){
                    if(item != rbTodos){
                        item.Checked = false;
                    }
                }
                calculartotal();
                rbTodos.Checked = true;

                alto = 180;
                alto2 = 180;

                IEnumerator controles = gbTotal.Controls.GetEnumerator();



                while (controles.MoveNext())
                {
                    TextBox txt = new TextBox();
                    if (controles.Current.GetType() == txt.GetType())
                    {
                        Control ctl = (Control)controles.Current;

                        ctl.Location = new System.Drawing.Point(ancho, alto);
                        alto -= 25;
                    }
                    else
                    {
                        Control ctl = (Control)controles.Current;

                        ctl.Location = new System.Drawing.Point(ancho2, alto2);
                        alto2 -= 25;
                    }

                }
            }
        }

        private void Pagar_Load(object sender, EventArgs e)
        {

        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar)){
                e.Handled = false;
            }
            else if(Char.IsControl(e.KeyChar)){
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
            
        }

        private void txtExento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPropina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static bool Imprimir(ArrayList lista) {
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
            catch {
                impreso = false;
            }
            return impreso;
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            txtExento.Text = int.Parse(txtSubTotal.Text) - ((int.Parse(txtSubTotal.Text) * 19) / 100) +"";

        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text != "")
            {
                txtTotal.Text = int.Parse(txtSubTotal.Text) - ((int.Parse(txtSubTotal.Text) * int.Parse(txtDescuento.Text)) / 100) + "";

                if (int.Parse(txtTotal.Text) < 0)
                {
                    txtTotal.Text = 0 + "";
                }
            }
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                int vueltoaprox = int.Parse(txtEfectivo.Text) - int.Parse(txtTotal.Text);
                if(vueltoaprox >= 0){
                    txtVuelto.Text = vueltoaprox + "";
                }
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            txtPropina.Text = ((int.Parse(txtTotal.Text) * 10) / 100) + "";
        }

        


    }
}
