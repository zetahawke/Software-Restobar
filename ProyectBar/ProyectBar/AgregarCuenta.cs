using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectBar
{
    public partial class AgregarCuenta : Form
    {
        public static string CuentaNueva = "";

        public AgregarCuenta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.txtCuentaNueva.Text != null || this.txtCuentaNueva.Text != ""){
                CuentaNueva = this.txtCuentaNueva.Text;
                this.Close();
            }else{
                MessageBox.Show("Porfavor ingrese un nombre para la cuenta.","Error de ingreso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void InsertarLetra(string letra)
        {

            bool secuencia = false;

            try
            {
                if (secuencia == true)
                {
                    txtCuentaNueva.Text = "";
                    txtCuentaNueva.Text = letra;
                    secuencia = false;

                }
                else
                {
                    txtCuentaNueva.Text = txtCuentaNueva.Text + letra;
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCuentaNueva.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    txtCuentaNueva.Text = txtCuentaNueva.Text.Substring(0, txtCuentaNueva.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
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
    }
}
