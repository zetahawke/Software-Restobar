using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.Xml;
using System.IO;
using CapaDatos;
using CapaNegocio;
using System.Windows.Forms;


namespace ProyectBar
{
    
    public partial class Form1 : Form
    {
        static string rta = SystemInformation.UserName;
        private bool mover = false;
        Image imagen2 = Image.FromFile("C:/Program Files (x86)/Microsoft/Setup/img/mesita.png");
        //Image imagen2 = Image.FromFile("C:/Users/Administrador/Desktop/ProyectBar/ProyectBar/img/mesita.png");
        //Image imagen2 = Image.FromFile("C:/mesita.png");
        private ArrayList labels = new ArrayList();
        private ArrayList labels2 = new ArrayList();
        private ArrayList labels3 = new ArrayList();
        int numero;
        int i = 0;
        int top = 0;
        int nombre = 0;
        int numero2;
        int i2 = 0;
        int top3 = 0;
        int nombre2 = 0;
        public static string nombremesa = "";
        public static DateTime llegada;
        public static string nombreusu = "";
        bool cerrar = false;
        public static bool cerrarapl = false;

        public static bool estadocaja = false;
        public static bool estadoturno = false;
        int contadordemesas = 0;


        public static VentasXTerminal vxt = new VentasXTerminal();
        public Form1()
        {
            InitializeComponent();
            cargarMesas();

            NegocioTurno negtur = new NegocioTurno();

            Turno tur = negtur.buscarTurno(ContraseñaAdmin.contr);

            if(tur._Usuario != ""){
                tur._Inicio = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                negtur.modificarTurno(tur);
                estadoturno = true;
            }
            else{
                tur._Usuario = ContraseñaAdmin.contr;
                tur._Inicio = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                negtur.insertarTurno(tur);
                estadoturno = true;
            }
        }
        

        public void cargarMesas() {

            
            string ruta1 = @"PosicionMesasPrimerPiso.xml";
            string ruta2 = @"PosicionMesasSegundoPiso.xml";
            string ruta3 = @"PosicionMesasTerraza.xml";
            if (File.Exists(ruta1) && File.Exists(ruta2) && File.Exists(ruta3))
            {
                CargarMesasExistentesPrimerPiso(ruta1);
                CargarMesasExistentesSegundoPiso(ruta2);
                CargarMesasExistentesTerraza(ruta3);
            }
            else
            {
                if (File.Exists(ruta1) && File.Exists(ruta3))
                {
                    CargarMesasExistentesPrimerPiso(ruta1);
                    RefreshMesasSegundoPiso();
                    CargarMesasExistentesTerraza(ruta3);
                }
                else
                {
                    if (File.Exists(ruta1) && File.Exists(ruta2))
                    {
                        CargarMesasExistentesPrimerPiso(ruta1);
                        CargarMesasExistentesSegundoPiso(ruta2);
                        RefreshMesasTerraza();
                    }
                    else
                    {
                        if (File.Exists(ruta2) && File.Exists(ruta3))
                        {
                            CargarMesasExistentesSegundoPiso(ruta2);
                            CargarMesasExistentesTerraza(ruta3);
                            RefreshMesasPrimerPiso();
                        }
                        else {
                            if (File.Exists(ruta1))
                            {
                                CargarMesasExistentesPrimerPiso(ruta1);
                                RefreshMesasSegundoPiso();
                                RefreshMesasTerraza();
                            }
                            else {
                                if (File.Exists(ruta2))
                                {
                                    CargarMesasExistentesSegundoPiso(ruta2);
                                    RefreshMesasPrimerPiso();
                                    RefreshMesasTerraza();
                                }
                                else { 
                                    if(File.Exists(ruta3)){
                                        CargarMesasExistentesTerraza(ruta3);
                                        RefreshMesasPrimerPiso();
                                        RefreshMesasSegundoPiso();
                                    }
                                    else{
                                        RefreshMesasPrimerPiso();
                                        RefreshMesasSegundoPiso();
                                        RefreshMesasTerraza();
                                        MessageBox.Show("No se encuentra el archivo que contiene las pocisiones de las mesas."+
                                        "Se procedera a crear las mesas por defecto almacenadas en los archivos de cantidades.",
                                        "No se encuentra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool mensaje = false;
            GuardarPlanoPrimerPiso(mensaje);
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPlanoPrimerPiso();
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            bool mensaje = false;
            GuardarPlanoSegundoPiso(mensaje);
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void btnCargar2_Click(object sender, EventArgs e)
        {
            EliminarPlanoSegundoPiso();
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void AsignarEventos(Label label)
        {
            label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            label.DoubleClick += new System.EventHandler(this.agregarOrdenAMesa);

        }

        public static bool tienePedidos = false;

        private void agregarOrdenAMesa(object sender, EventArgs e)
        {
            if (estadoturno == true && estadocaja == true)
            {
                Control aki = (Control)sender;
                nombremesa = aki.Text;
                NegocioMesa negme = new NegocioMesa();
                Mesa me = negme.buscarMesa(int.Parse(nombremesa.ToString()));

                if (me._estado != 1)
                {
                    tienePedidos = true;
                    AgregarOrden arg = new AgregarOrden();
                    arg.ShowDialog();

                    if (Pagar.cerrarmesa == true)
                    {
                        aki.BackColor = Color.Transparent;
                    }

                    if (AgregarOrden.cerrarturno == true)
                    {
                        NegocioTurno negtur = new NegocioTurno();

                        Turno tur = negtur.buscarTurno(ContraseñaAdmin.contr);

                        tur._Fin = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                        negtur.modificarTurno(tur);
                        estadoturno = false;
                    }
                }
                else
                {
                    llegada = DateTime.Now;
                    AgregarOrden arg = new AgregarOrden();
                    arg.ShowDialog();
                    if (AgregarOrden.deshabilitarControl == true)
                    {

                        aki.BackColor = Color.Black;

                    }
                    else
                    {
                        aki.BackColor = Color.Transparent;
                    }
                    if (AgregarOrden.cerrarturno == true)
                    {
                        NegocioTurno negtur = new NegocioTurno();

                        Turno tur = negtur.buscarTurno(ContraseñaAdmin.contr);

                        tur._Fin = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                        negtur.modificarTurno(tur);
                        estadoturno = false;
                    }
                }
            }
            else {
                MessageBox.Show("Necesita iniciar turno y hacer apertura de caja para abrir mesas" , "Error de Apertura y turno");
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            mover = true;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (mover)
            {
                Point p1 = ctrl.PointToScreen(e.Location);
                Point p2 = ctrl.Parent.PointToClient(p1);
                ctrl.Location = p2;
            }
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }


        private void RefreshMesasPrimerPiso()
        {
            string namela = "lblMesaPrimer";
            int width = pnlPiso1.Width;
            int left = 0;
            int top2 = 0;
            int cantidad = 0;
            numero = 0;
            XmlTextReader reader = new XmlTextReader("CantidadPrimerPiso.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Cantidad")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "numero")
                                {
                                    cantidad = Convert.ToInt32(reader.Value);
                                    MessageBox.Show("la cantidad de mesas es: " + cantidad, "Cantidad de mesas");
                                }
                            }
                        }


                        break;
                }
            }
            reader.Close();

            for (int cont = 1; cont <= cantidad; cont++)
            {
                contadordemesas += 1;
                i = left + 40;
                top = top2;
                Label arg = new Label();
                arg.Name = namela + cont;
                arg.Image = imagen2;
                arg.Left = left;
                arg.Top = top2;
                arg.Height = 62;
                arg.Cursor = Cursors.NoMove2D;
                arg.Width = 62;
                arg.Text = contadordemesas+"";
                arg.TextAlign = ContentAlignment.MiddleCenter;

                
                //agregamos el label al panel

                pnlPiso1.Controls.Add(arg);

                //asignamos eventos al label

                AsignarEventos(arg);

                //Agregamos el label al arrayList

                this.labels.Add(arg);

            }
            foreach (Label e in labels)
            {
                if (left > pnlPiso1.Width)
                {
                    left = 0;
                    top2 = top2 + 70;
                }
                e.Left = left;
                e.Top = top2;
                left = left + 70;
            }
        }

        private void CargarMesasExistentesPrimerPiso(string ruta1)
        {
            string namela = "lblMesaPrimer";
            int width = pnlPiso1.Width;
            int left = 0;
            int top2 = 0;
            int estado = 0;
            numero = 0;
            XmlTextReader reader = new XmlTextReader("PosicionMesasPrimerPiso.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Posicion")
                        {
                            while (reader.MoveToNextAttribute())
                            { // lee los atributos.
                                if (reader.Name == "X")
                                {
                                    left = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Y")
                                {
                                    top2 = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Mesa_y_Numero")
                                {
                                    namela = reader.Value;
                                }
                                else if (reader.Name == "Texto")
                                {
                                    numero = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Estado")
                                {
                                    estado = Convert.ToInt16(reader.Value);
                                }
                            }
                            Label arg = new Label();
                            arg.Name = namela;
                            arg.Image = imagen2;
                            arg.Left = left;
                            arg.Top = top2;
                            arg.Height = 62;
                            arg.Cursor = Cursors.NoMove2D;
                            arg.Width = 62;
                            if(estado == 2){
                                arg.BackColor = Color.Black;
                            }
                            arg.Text = numero.ToString();
                            arg.TextAlign = ContentAlignment.MiddleCenter;


                            //agregamos el label al panel

                            pnlPiso1.Controls.Add(arg);

                            //asignamos eventos al label

                            AsignarEventos(arg);

                            //Agregamos el label al arrayList

                            this.labels.Add(arg);
                            i = left + 40;
                            top = top2;
                        }

                        break;
                }
            }
            reader.Close();
        }


        public void GuardarPlanoPrimerPiso(bool mensaje)
        {
            string ruta = @"PosicionMesasPrimerPiso.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
            XmlWriter xmlWriter = XmlWriter.Create("PosicionMesasPrimerPiso.xml");
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("PosicionMesas");


            //recorremos el array de label de la variable Labels
            foreach (Label label in this.labels)
            {
                NegocioMesa me = new NegocioMesa();
                Mesa mes = me.buscarMesa(int.Parse(label.Text));
                int estado = mes._estado;
                xmlWriter.WriteStartElement("Posicion");
                xmlWriter.WriteAttributeString("X", Convert.ToString(label.Location.X));
                xmlWriter.WriteAttributeString("Y", Convert.ToString(label.Location.Y));
                xmlWriter.WriteAttributeString("Mesa_y_Numero", label.Name);
                xmlWriter.WriteAttributeString("Texto", label.Text);
                xmlWriter.WriteAttributeString("Estado", ""+estado);
                xmlWriter.WriteString(label.Name);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            if(mensaje == false){
            MessageBox.Show("Plano Guardado!", "Plano Ingresado Correctamente");
            }
        }

        private void EliminarPlanoPrimerPiso()
        {
            string ruta = @"PosicionMesasPrimerPiso.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            pnlPiso1.Controls.Clear();
            pnlPiso1.Refresh();
            pnlPiso1.Update();
            i = 0;
            top = 0;
            nombre = 0;
            labels = new ArrayList();
            numero = 0;

            MessageBox.Show("Plano Eliminado!", "Plano Eliminado Correctamente");

            RefreshMesasPrimerPiso();
        }


        private void RefreshMesasSegundoPiso()
        {
            string namela = "lblMesaSegundo";
            int width = pnl2Piso.Width;
            int left = 0;
            int top2 = 0;
            int cantidad = 0;
            numero2 = 0;
            XmlTextReader reader = new XmlTextReader("CantidadSegundoPiso.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Cantidad")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "numero")
                                {
                                    cantidad = Convert.ToInt32(reader.Value);
                                    MessageBox.Show("la cantidad de mesas es: " + cantidad, "Cantidad de mesas");
                                }
                            }
                        }


                        break;
                }
            }
            reader.Close();

            for (int cont = 1; cont <= cantidad; cont++)
            {
                contadordemesas += 1;
                i2 = left + 40;
                top3 = top2;
                Label arg = new Label();
                arg.Name = namela + cont;
                arg.Image = imagen2;
                arg.Left = left;
                arg.Top = top2;
                arg.Height = 62;
                arg.Cursor = Cursors.NoMove2D;
                arg.Width = 62;
                arg.Text =contadordemesas + "";
                arg.TextAlign = ContentAlignment.MiddleCenter;


                //agregamos el label al panel

                pnl2Piso.Controls.Add(arg);

                //asignamos eventos al label

                AsignarEventos(arg);

                //Agregamos el label al arrayList

                this.labels2.Add(arg);

            }
            foreach (Label e in labels2)
            {
                if (left > pnl2Piso.Width)
                {
                    left = 0;
                    top2 = top2 + 70;
                }
                e.Left = left;
                e.Top = top2;
                left = left + 70;
            }
        }

        private void CargarMesasExistentesSegundoPiso(string ruta)
        {
            string namela = "lblMesaSegundo";
            int width = pnl2Piso.Width;
            int left = 0;
            int top2 = 0;
            int estado = 0;
            numero2 = 0;
            XmlTextReader reader = new XmlTextReader("PosicionMesasSegundoPiso.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Posicion")
                        {
                            while (reader.MoveToNextAttribute())
                            { // lee los atributos.
                                if (reader.Name == "X")
                                {
                                    left = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Y")
                                {
                                    top2 = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Mesa_y_Numero")
                                {
                                    namela = reader.Value;
                                }
                                else if (reader.Name == "Texto")
                                {
                                    numero2 = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Estado")
                                {
                                    estado = Convert.ToInt16(reader.Value);
                                }
                            }
                            Label arg = new Label();
                            arg.Name = namela;
                            arg.Image = imagen2;
                            arg.Left = left;
                            arg.Top = top2;
                            arg.Height = 62;
                            arg.Width = 62;
                            if(estado == 2){
                                arg.BackColor = Color.Black;
                            }
                            arg.Cursor = Cursors.NoMove2D;
                            arg.Text = numero2.ToString();
                            arg.TextAlign = ContentAlignment.MiddleCenter;


                            //agregamos el label al panel

                            pnl2Piso.Controls.Add(arg);

                            //asignamos eventos al label

                            AsignarEventos(arg);

                            //Agregamos el label al arrayList

                            this.labels2.Add(arg);
                            i2 = left + 40;
                            top3 = top2;
                        }

                        

                        break;
                }
            }
            reader.Close();
        }


        private void GuardarPlanoSegundoPiso(bool mensaje)
        {
            string ruta = @"PosicionMesasSegundoPiso.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
            XmlWriter xmlWriter = XmlWriter.Create("PosicionMesasSegundoPiso.xml");
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("PosicionMesas");


            //recorremos el array de label de la variable Labels
            foreach (Label label in this.labels2)
            {
                NegocioMesa me = new NegocioMesa();
                Mesa mes = me.buscarMesa(int.Parse(label.Text));
                int estado = mes._estado;
                xmlWriter.WriteStartElement("Posicion");
                xmlWriter.WriteAttributeString("X", Convert.ToString(label.Location.X));
                xmlWriter.WriteAttributeString("Y", Convert.ToString(label.Location.Y));
                xmlWriter.WriteAttributeString("Mesa_y_Numero", label.Name);
                xmlWriter.WriteAttributeString("Texto", label.Text);
                xmlWriter.WriteAttributeString("Estado", "" + estado);
                xmlWriter.WriteString(label.Name);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            if(mensaje == false){
            MessageBox.Show("Plano Guardado!", "Plano Ingresado Correctamente");
            }
        }

        private void EliminarPlanoSegundoPiso()
        {
            string ruta = @"PosicionMesasSegundoPiso.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            pnl2Piso.Controls.Clear();
            pnl2Piso.Refresh();
            pnl2Piso.Update();
            i2 = 0;
            top3 = 0;
            nombre2 = 0;
            labels2 = new ArrayList();
            numero2 = 0;

            MessageBox.Show("Plano Eliminado!", "Plano Eliminado Correctamente");

            RefreshMesasSegundoPiso();
        }


        private void RefreshMesasTerraza()
        {
            string namela = "lblMesaTerraza";
            int width = pnl2Piso.Width;
            int left = 0;
            int top2 = 0;
            int cantidad = 0;
            numero2 = 0;
            XmlTextReader reader = new XmlTextReader("CantidadTerraza.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Cantidad")
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                if (reader.Name == "numero")
                                {
                                    cantidad = Convert.ToInt32(reader.Value);
                                    MessageBox.Show("la cantidad de mesas es: " + cantidad, "Cantidad de mesas");
                                }
                            }
                        }


                        break;
                }
            }
            reader.Close();

            for (int cont = 1; cont <= cantidad; cont++)
            {
                contadordemesas += 1;
                i2 = left + 40;
                top3 = top2;
                Label arg = new Label();
                arg.Name = namela + cont;
                arg.Image = imagen2;
                arg.Left = left;
                arg.Top = top2;
                arg.Height = 62;
                arg.Cursor = Cursors.NoMove2D;
                arg.Width = 62;
                arg.Text = contadordemesas + "";
                arg.TextAlign = ContentAlignment.MiddleCenter;


                //agregamos el label al panel

                pnlTerraza.Controls.Add(arg);

                //asignamos eventos al label

                AsignarEventos(arg);

                //Agregamos el label al arrayList

                this.labels3.Add(arg);

            }
            foreach (Label e in labels3)
            {
                if (left > pnlTerraza.Width)
                {
                    left = 0;
                    top2 = top2 + 70;
                }
                e.Left = left;
                e.Top = top2;
                left = left + 70;
            }
        }

        private void CargarMesasExistentesTerraza(string ruta)
        {
            string namela = "lblMesaTerraza";
            int width = pnlTerraza.Width;
            int left = 0;
            int top2 = 0;
            int estado = 0;
            numero2 = 0;
            XmlTextReader reader = new XmlTextReader("PosicionMesasTerraza.xml");

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // El nodo es un elemento
                        if (reader.Name == "Posicion")
                        {
                            while (reader.MoveToNextAttribute())
                            { // lee los atributos.
                                if (reader.Name == "X")
                                {
                                    left = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Y")
                                {
                                    top2 = Convert.ToInt16(reader.Value);
                                }
                                else if (reader.Name == "Mesa_y_Numero")
                                {
                                    namela = reader.Value;
                                }
                                else if (reader.Name == "Texto")
                                {
                                    numero2 = Convert.ToInt16(reader.Value);
                                }
                                else if(reader.Name == "Estado"){
                                    estado = Convert.ToInt16(reader.Value);
                                }
                            }
                            Label arg = new Label();
                            arg.Name = namela;
                            arg.Image = imagen2;
                            arg.Left = left;
                            arg.Top = top2;
                            arg.Height = 62;
                            arg.Width = 62;
                            if(estado == 2){
                                arg.BackColor = Color.Black;
                            }
                            arg.Cursor = Cursors.NoMove2D;
                            arg.Text = numero2.ToString();
                            arg.TextAlign = ContentAlignment.MiddleCenter;


                            //agregamos el label al panel

                            pnlTerraza.Controls.Add(arg);

                            //asignamos eventos al label

                            AsignarEventos(arg);

                            //Agregamos el label al arrayList

                            this.labels3.Add(arg);
                            i2 = left + 40;
                            top3 = top2;
                        }

                        break;
                }
            }
            reader.Close();
        }


        private void GuardarPlanoTerraza(bool mensaje)
        {
            string ruta = @"PosicionMesasTerraza.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }
            XmlWriter xmlWriter = XmlWriter.Create("PosicionMesasTerraza.xml");
            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("PosicionMesas");


            //recorremos el array de label de la variable Labels
            foreach (Label label in this.labels3)
            {
                NegocioMesa me = new NegocioMesa();
                Mesa mes = me.buscarMesa(int.Parse(label.Text));
                int estado = mes._estado;
                xmlWriter.WriteStartElement("Posicion");
                xmlWriter.WriteAttributeString("X", Convert.ToString(label.Location.X));
                xmlWriter.WriteAttributeString("Y", Convert.ToString(label.Location.Y));
                xmlWriter.WriteAttributeString("Mesa_y_Numero", label.Name);
                xmlWriter.WriteAttributeString("Texto", label.Text);
                xmlWriter.WriteAttributeString("Estado", "" + estado);
                xmlWriter.WriteString(label.Name);
                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

            if(mensaje == false){
            MessageBox.Show("Plano Guardado!", "Plano Ingresado Correctamente");
            }
        }

        private void EliminarPlanoTerraza()
        {
            string ruta = @"PosicionMesasTerraza.xml";
            if (File.Exists(ruta))
            {
                File.Delete(ruta);
            }

            pnlTerraza.Controls.Clear();
            pnlTerraza.Refresh();
            pnlTerraza.Update();
            i2 = 0;
            top3 = 0;
            nombre2 = 0;
            labels3 = new ArrayList();
            numero2 = 0;

            MessageBox.Show("Plano Eliminado!", "Plano Eliminado Correctamente");

            RefreshMesasTerraza();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult opcion = 0;
            opcion = MessageBox.Show("Nesecita tener permiso del administrador, ¿Desea continuar?", "Permisos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                ContraseñaAdmin co = new ContraseñaAdmin("cierre");
                co.ShowDialog();
                string contra = ContraseñaAdmin.contraseñaAdmin.ToString();
                if (contra != "" && contra != null)
                {
                    Application.Exit();
                }
            }
        }

        private void btnGuardar3_Click(object sender, EventArgs e)
        {
            bool mensaje = false;
            GuardarPlanoTerraza(mensaje);
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void btnCargar3_Click(object sender, EventArgs e)
        {
            EliminarPlanoTerraza();
            numero = 0;
            i = 0;
            top = 0;
            nombre = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool mensaje = true;
            GuardarPlanoPrimerPiso(mensaje);
            GuardarPlanoSegundoPiso(mensaje);
            GuardarPlanoTerraza(mensaje);

            if(estadocaja == true)
            {
                CerrarCaja cerr = new CerrarCaja(vxt);
                cerr.ShowDialog();
                this.Close();

            }
           
            
            
        }


        private void btnInicio_Click(object sender, EventArgs e)
        {
            Turnos tu = new Turnos();
            tu.ShowDialog();

            if(Turnos.inicioturno == true){
                NegocioTurno negtur = new NegocioTurno();

                Turno tur = negtur.buscarTurno(Turnos.contr);

                if (tur._Usuario != "")
                {
                    tur._Inicio = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    negtur.modificarTurno(tur);
                    estadoturno = true;
                }
                else
                {
                    tur._Usuario = Turnos.contr;
                    tur._Inicio = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    negtur.insertarTurno(tur);
                    estadoturno = true;
                }
            }
        }

        private void btnTurno_Click_1(object sender, EventArgs e)
        {
            if(estadoturno == true){
                NegocioTurno negtur = new NegocioTurno();

                Turno tur = negtur.buscarTurno(ContraseñaAdmin.contr);

                tur._Fin = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                negtur.modificarTurno(tur);

                estadoturno = false;

                MessageBox.Show("Turno Finalizado: "+ tur._Fin, "Fin Turno");
            }
        }

        private void btnInformeX_Click(object sender, EventArgs e)
        {

            CerrarCaja cerr = new CerrarCaja(vxt);
            cerr.ShowDialog();

            if (estadocaja == true)
            {
                btnInformeX.Text = "Cerrar Caja";
            }
            else
            {
                btnInformeX.Text = "Abrir Caja";
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (estadocaja == true)
            {
                btnInformeX.Text = "Cerrar Caja";
            }
            else
            {
                btnInformeX.Text = "Abrir Caja";
            }
        }

       
        
    }
}
