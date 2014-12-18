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

namespace ProyectBar
{
    public partial class Razones : Form
    {
        public Razones()
        {
            InitializeComponent();
            llenarData();
        }

        public string razon = "";
        public string otro = "";

        public void llenarData() {
            NegocioRazones negra = new NegocioRazones();

            ArrayList razones = negra.getRazones();

            foreach(RazonesEliminacion ra in razones){
                dataGridView1.Rows.Add(""+ra._Razon);
            }
            

        }

        private void Razones_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NegocioRazones negra = new NegocioRazones();
            int fila = dataGridView1.CurrentRow.Index;
            razon = dataGridView1["columnRazon", fila].Value.ToString();

            if (razon.Equals("describir otro motivo") || razon.Equals("problemas con la cuenta (describir motivos)") || razon.Equals("rompimiento (describir situacion)"))
            {
                Observacion ob = new Observacion();
                ob.ShowDialog();

                if(ob.observacion != ""){
                    otro = ob.observacion;
                }
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            razon = "";
            this.Close();
        }
    }
}
