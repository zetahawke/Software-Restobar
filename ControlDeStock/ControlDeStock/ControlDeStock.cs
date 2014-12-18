using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControlDeStock;

namespace ControlDeStock
{
    public partial class ControlDeStock : Form
    {
        public ControlDeStock()
        {
            InitializeComponent();
            HoraL.Text = DateTime.Now.ToLongTimeString();
            

        }

        private void ControlDeStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult opcion = 0;
            opcion = MessageBox.Show("¿Desea Salir de la Aplicación?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (opcion == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ControlDeStock_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HoraA.Text = DateTime.Now.ToLongTimeString();

            TimeSpan horaActual;
            TimeSpan horaLlegada;
            TimeSpan tiempoEstadia;

            horaActual = TimeSpan.Parse(HoraA.Text);
            horaLlegada = TimeSpan.Parse(HoraL.Text);
            tiempoEstadia = horaActual - horaLlegada;
            TiempoE.Text = Convert.ToString(tiempoEstadia);


        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Categoria ca = new Categoria();
            ca.ShowDialog();
        }

        

   

        
      

       
    }
}
