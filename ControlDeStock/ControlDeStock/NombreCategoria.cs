using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using CapaNegocio;
using CapaDatos;

namespace ControlDeStock
{
    public partial class NombreCategoria : Form
    {
        public static int i = 0;
        

        public NombreCategoria()
        {
            InitializeComponent();
            llenarCombo();
        }

        private void llenarCombo() {

            NegocioCategorias negCat = new NegocioCategorias();

            ArrayList cat = negCat.getCate();

            foreach(Cate item in cat){
                cmbCategoria.Items.Add(item._nombre);
            }
        }

        public static string nombreCategoria = "";
   

        private void InsertarLetra(string letra)
        {

            bool secuencia = false;

            try
            {
                if (secuencia == true)
                {
                    txtNombreCategoria.Text = "";
                    txtNombreCategoria.Text = letra;
                    secuencia = false;

                }
                else
                {
                    txtNombreCategoria.Text = txtNombreCategoria.Text + letra;
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
                if (txtNombreCategoria.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    txtNombreCategoria.Text = txtNombreCategoria.Text.Substring(0, txtNombreCategoria.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
            }
        }
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreCategoria.Text.Equals(""))
            {
                MessageBox.Show("Debe Ingresar un nombre para la categoria","Error de Ingreso");
            }
            else
            {
                
                lblID.Text = (i).ToString();

                NegocioCategorias negCategoria = new NegocioCategorias();
                NegocioProducto negProducto = new NegocioProducto();

                Cate categoria = negCategoria.buscarCategoriaString(txtNombreCategoria.Text.Trim());

                if(categoria._nombre.Equals(txtNombreCategoria.Text.Trim()))
                {
                    MessageBox.Show("Ya existe una categoria con el nombre " + txtNombreCategoria.Text);
               
                }
                else
                {
                    Cate cate = new Cate();
                    Producto pro = new Producto();

                    nombreCategoria = txtNombreCategoria.Text.Trim();
                    MessageBox.Show(nombreCategoria);
                    cate._nombre = nombreCategoria;
                    cate._ID_Cate = Convert.ToInt32(lblID.Text);
                    pro._categoria = Convert.ToInt32(lblID.Text);

                    negCategoria.insertarCategoria(cate);

                    this.Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NombreCategoria_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.txtNombreCategoria.Select();

            switch(Categoria.seleccion)
            {
                    //Agregar Nueva Categoria
                case 1:
                    cmbCategoria.Visible = false;
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                break;

                    //Modificar Categoria
                case 2:
                    cmbCategoria.Visible = true;
                    btnModificar.Visible = true;
                    btnAceptar.Visible = false;
                    btnEliminar.Visible = false;
                    NegocioCategorias negCategoria = new NegocioCategorias();
                    Cate categoria = negCategoria.buscarCategoria(Convert.ToInt32(lblID.Text));
                    cmbCategoria.SelectedValue = categoria;
                break;

                    //Eliminar Categoria
                case 3:
                    cmbCategoria.Visible = true;
                    btnAceptar.Visible = false;
                    btnModificar.Visible = false;
                    NegocioCategorias negCategorias = new NegocioCategorias();
                    Cate categorias = negCategorias.buscarCategoria(Convert.ToInt32(lblID.Text));
                    cmbCategoria.SelectedValue = categorias;

                break;
            }

          

            ArrayList nombreBotones = Categoria.nombotones;
       
            foreach(string item in nombreBotones)
            {
                cmbCategoria.Items.Add(item);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i = DateTime.Now.Minute * DateTime.Now.Millisecond;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            NegocioCategorias negCate = new NegocioCategorias();
            Cate categoria = negCate.buscarCategoriaString(txtNombreCategoria.Text);

            if (categoria._nombre.Equals(txtNombreCategoria.Text))
            {
                MessageBox.Show("Ya existe una categoria con el nombre " + txtNombreCategoria.Text);

            }
            else
            {
                if (cmbCategoria.SelectedItem != null)
                {
                     DialogResult opcion = 0;
                    opcion = MessageBox.Show("¿Estás Seguro Que Quieres Eliminar Esta Categoría?", "Confirmación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (opcion == DialogResult.Yes)
                    {
                        NegocioCategorias negCategoria = new NegocioCategorias();
                        Cate cate = negCategoria.buscarCategoriaString(cmbCategoria.SelectedItem.ToString());
                        nombreCategoria = txtNombreCategoria.Text.Trim();
                        cate._nombre = nombreCategoria;
                        negCategoria.modificarCategoria(cate);
                        this.Close();
                        MessageBox.Show("La Categoría Fue Modificada Correctamente", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else 
                {
                    MessageBox.Show("Error Debe Seleccionar Una Categoría Antes de Modificar el Nombre", "Error");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            NegocioCategorias negCate = new NegocioCategorias();
            Cate categoria = negCate.buscarCategoriaString(cmbCategoria.SelectedItem.ToString());

          
                if (cmbCategoria.SelectedItem != null)
                {             
                    DialogResult opcion = 0;
                    opcion = MessageBox.Show("¿Estás Seguro Que Quieres Eliminar Esta Categoría?", "Confirmación",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(opcion == DialogResult.Yes)
                    {
                    
                    NegocioCategorias negCategoria = new NegocioCategorias();
                    Cate cate = negCategoria.buscarCategoriaString(cmbCategoria.SelectedItem.ToString());
                    negCategoria.eliminarCategoria(cate._ID_Cate);
                    this.Close();

                    MessageBox.Show("La Categoría Fue Eliminada Correctamente", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error Debe Seleccionar Una Categoría Antes de Modificar el Nombre", "Error");
                }
            
        }

        }

      

    }

