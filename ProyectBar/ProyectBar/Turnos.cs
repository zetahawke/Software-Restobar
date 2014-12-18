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

namespace ProyectBar
{
    public partial class Turnos : Form
    {
        public Turnos()
        {
            InitializeComponent();
        }

        public static bool inicioturno = false;
        public static string contr = "";

       
        public void InsertarLetra(string letra)
        {

            bool secuencia = false;

            try
            {
                if (secuencia == true)
                {
                    txtPassAdmin.Text = "";
                    txtPassAdmin.Text = letra;
                    secuencia = false;

                }
                else
                {
                    txtPassAdmin.Text = txtPassAdmin.Text + letra;
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
                if (txtPassAdmin.Text.Count() == 0)
                {
                    MessageBox.Show("El campo seleccionado no contiene caracteres para borrar", "Error");
                }
                else
                {
                    txtPassAdmin.Text = txtPassAdmin.Text.Substring(0, txtPassAdmin.Text.Count() - 1);
                }
            }
            catch
            {
                MessageBox.Show("Debe Seleccionar un campo antes de eliminar caracter", "Error");
            }
        }

        private void ContraseñaAdmin_Load(object sender, EventArgs e)
        {
            txtPassAdmin.Select();
        }

        private void btnComprobar_Click_1(object sender, EventArgs e)
        {
            string pass = this.txtPassAdmin.Text.ToString();
            if (pass == "" || pass == null)
            {
                MessageBox.Show("Por favor llene el campo password", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NegocioUsuario u = new NegocioUsuario();
                Usuario usu = u.buscarUsuario(pass);
                if (usu._Contraseña != "")
                {
                    contr = usu._Contraseña;
                    inicioturno = true;
                    MessageBox.Show("Autorizado!", "Permiso concedido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta, porfavor intente otra vez. " +
                    "Asegurese que los campos en mayusculas posean mayusculas al igual que la contraseña original " +
                   "(en caso de que sea necesario)", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassAdmin.Text = "";
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            contr = "";
            this.Close();
        }

        
        
    }
}
