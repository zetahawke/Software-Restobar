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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
            crearBotones();
        }
        public static int seleccion = 0;
        private void crearBotones() {
            NegocioCategorias negCat = new NegocioCategorias();
            ArrayList categorias = negCat.getCate();
            
            foreach(Cate item in categorias){

                Button e = new Button();
                int width = panel1.Width;

                if (i > width)
                {
                    i = 0;
                    top += 70;
                }

                e.Name = item._ID_Cate + "";
                e.Text = item._nombre;
                e.Left = i;
                e.Top = top;
                e.Height = 62;
                e.Width = 62;
                e.TextAlign = ContentAlignment.MiddleCenter;
                i += 70;

               

                panel1.Controls.Add(e);
            }
            top = 0;
            i = 0;
            
        }

        private ArrayList Botones = new ArrayList();
       

        public static string nombreCategoria = "";
        public static int top = 0;
        public static int i = 0;
        public static int width = 0;
        public void agregarCategoria(string texto)
        {
            if (texto != "")
            {

                string namela = "btnCategoria " + texto;
                width = panel1.Width;
                //si el left que se aplica al label supera el width del label (ancho) lo reseteamos a 0 y empezamos acrear labels desde la izquierda.
                if (i > width)
                {
                    i = 0;
                    top += 70;
                }
                Button arg = new Button();
                arg.Name = namela;
                arg.Left = i;
                arg.Top = top;
                arg.Height = 62;
                arg.Width = 62;
                arg.Text = texto;


                arg.TextAlign = ContentAlignment.MiddleCenter;
                i += 70;

                //agregamos el label al panel

                panel1.Controls.Add(arg);

                //Agregamos el label al arrayList

                this.Botones.Add(arg);


            }

            i = 0;
            top = 0;
        }

        public static ArrayList nombotones = new ArrayList();
        private void botones() { 
            foreach(Button item in panel1.Controls){
                nombotones.Add(item.Text);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            seleccion = 1;
            NombreCategoria nomCate = new NombreCategoria();
            nomCate.ShowDialog();
            agregarCategoria(NombreCategoria.nombreCategoria);
            NombreCategoria.nombreCategoria = "";
            panel1.Controls.Clear();
            crearBotones();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
           seleccion = 2;
            NombreCategoria nomCate = new NombreCategoria();
            nomCate.ShowDialog();
            panel1.Controls.Clear();
            crearBotones();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            seleccion = 3;
            NombreCategoria nomCate = new NombreCategoria();
            nomCate.ShowDialog();
            panel1.Controls.Clear();
            crearBotones();
        }

      

    
    }
}
