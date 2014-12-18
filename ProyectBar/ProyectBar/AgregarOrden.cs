using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProyectBar;
using System.Collections;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using CapaNegocio;
using CapaDatos;

namespace ProyectBar
{
    public partial class AgregarOrden : Form
    {
        public AgregarOrden()
        {
            InitializeComponent();
            if (Form1.tienePedidos == false)
            {
                HoraL.Text = DateTime.Now.ToLongTimeString();
                nombre();
            }
            else 
            {
                RescatarPedidos();
            }
            cargarProductos();
        }
        TimeSpan horaActual;
        TimeSpan horaLlegada;
        TimeSpan tiempoEstadia;

        int we = int.Parse(DateTime.Now.Millisecond.ToString());
        /*
        int producto = 0;
        string descripcion = "";
        string valor = "";
        int total = 0;
        int cantidad = 0;
        string observacion = "";
        string estado = "";
        */
        public static bool deshabilitarControl;
        string e = Form1.nombremesa.ToString();

        System.Collections.IEnumerator mostrar;
        ArrayList cuentas = new ArrayList();

        private void RescatarPedidos() {

            lblGarzon.Text = ContraseñaAdmin.contraseñaAdmin;
            lblMesa.Text = e;
            seguardo = true;
            NegocioMesa me = new NegocioMesa();
            Mesa mes = me.buscarMesa(int.Parse(lblMesa.Text));

            HoraL.Text = mes._llegada;

            NegocioCuenta cu = new NegocioCuenta();
            mostrar = cu.getCuentaxMesa(mes._ID_Mesa).GetEnumerator();
            bool borrarprimero = true;
            while (mostrar.MoveNext())
            {

                Cuenta cli = (Cuenta)mostrar.Current;
                if(borrarprimero == true){
                    tcCuentas.TabPages.Clear();
                }
                agregarCuenta(cli._nombre , cli._ID_Cuenta);
                cuentas.Add(cli._ID_Cuenta);
                borrarprimero = false;
            }
        
        }

        public void cargarProductos(){
            NegocioCategorias negCli = new NegocioCategorias();
            System.Collections.IEnumerator mostrar = negCli.getCate().GetEnumerator();

            while (mostrar.MoveNext())
            {
                Cate ca = (Cate)mostrar.Current;
                TabPage tab = new TabPage();
                tab.Text = ca._nombre;
                tab.Name = ca._ID_Cate + "";
                tbcProducts.Controls.Add(tab);
            }

            

            NegocioProducto negPro = new NegocioProducto();

            IEnumerator tabpages = tbcProducts.TabPages.GetEnumerator();

            while(tabpages.MoveNext()){
                int izq = 10;
                int ar = 10;

                TabPage tab = (TabPage)tabpages.Current;

                ArrayList productos = negPro.getProductosxcate(int.Parse(tab.Name));

                foreach(Producto itpro in productos){
                    Label lbl = new Label();
                    lbl.Name = itpro._ID_Producto + "";
                    lbl.Text = itpro._nombre;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Width = 50;
                    lbl.Left = izq;
                    if(izq > tab.Width){
                        izq = 0;
                        ar += 20;
                    }
                    lbl.Top = ar;
                    AsignarEventos(lbl);
                    tab.Controls.Add(lbl);

                    izq += 50;
                }

            }
            

            
        }




        private void nombre()
        {
            deshabilitarControl = false;
            lblMesa.Text = e;
            DateTime lle = Form1.llegada;
            DateTime act = DateTime.Now;
            TimeSpan est = lle.Subtract(act);
            lblGarzon.Text = ContraseñaAdmin.contraseñaAdmin;
        }


        private void AsignarEventos(Label label)
        {
            label.DoubleClick += new System.EventHandler(this.solicitarProducto);
        }

        private void solicitarProducto(object sender, EventArgs e)
        {
            Control aki = (Control)sender;
            Label lbl = (Label)aki;

            int id = int.Parse(lbl.Name.ToString());

            NegocioProducto neg = new NegocioProducto();
            Producto pro = neg.buscarProducto(id);

            TabPage tab = tcCuentas.SelectedTab;
            string nombre = tab.Name.ToString();

            Control[] ctl = tab.Controls.Find("dgv"+nombre , false);

            DataGridView dgv = (DataGridView)ctl[0];

            dgv.Rows.Add(pro._descripcion, pro._nombre, "1" , pro._precio , pro._precio, "" );

            calcularTotal(tab);
        }

        private void calcularTotal(TabPage tab) {
            string nombre = tab.Name.ToString();
            Control[] ctl = tab.Controls.Find("lbl6"+nombre , false);
            Control[] ctl2 = tab.Controls.Find("dgv"+nombre , false);
            DataGridView dgv = (DataGridView)ctl2[0];
            Label lbl = (Label)ctl[0];

            int suma = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                suma += Convert.ToInt32(row.Cells["Column5"+nombre].Value);
            }
            lbl.Text = suma+"";
        }

        private void btnPagar_Click(object sender, EventArgs er)
        {
            
            NegocioCuenta negcue = new NegocioCuenta();
            cuentas = negcue.getCuentaxMesa(int.Parse(e));
            if (cuentas.Count != 0)
            {
                Pagar pag = new Pagar();
                pag.ShowDialog(); 
                if(Pagar.cerrarmesa == true){
                    NegocioMesa negme = new NegocioMesa();

                    Mesa me = negme.buscarMesa(int.Parse(e));
                    me._estado = 1;
                    me._estadia = "00:00:00";
                    me._llegada = "00:00:00";
                    me._salida = "00:00:00";
                    negme.modificarMesa(me);
                    
                }
                this.Close();
            }
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
            ContraseñaAdmin co = new ContraseñaAdmin("cerrar");
            co.ShowDialog();
            string contra = ContraseñaAdmin.contraseñaAdmin.ToString();
            if (contra != "" && contra != null)
            {
                Application.Exit();
            }
            
        }

        System.Collections.IEnumerator mostrar2;

        private void agregarCuenta(string nombre, int idcuenta) {
            string cuentanueva = nombre;

            if (cuentanueva != null || cuentanueva != "")
            {

                DataGridView dg = new DataGridView();
                DataGridViewColumn re = new DataGridViewTextBoxColumn();
                re.Name = "Column1" + cuentanueva;
                re.HeaderText = "Descripcion";
                re.ReadOnly = true;
                DataGridViewColumn re1 = new DataGridViewTextBoxColumn();
                re1.Name = "Column2" + cuentanueva;
                re1.HeaderText = "Producto";
                re1.Visible = true;
                re1.ReadOnly = true;
                DataGridViewColumn re2 = new DataGridViewTextBoxColumn();
                re2.Name = "Column3" + cuentanueva;
                re2.HeaderText = "Cantidad";
                re2.ReadOnly = true;
                DataGridViewColumn re3 = new DataGridViewTextBoxColumn();
                re3.Name = "Column4" + cuentanueva;
                re3.HeaderText = "Valor";
                re3.ReadOnly = true;
                DataGridViewColumn re4 = new DataGridViewTextBoxColumn();
                re4.Name = "Column5" + cuentanueva;
                re4.HeaderText = "Total";
                re4.ReadOnly = true;
                DataGridViewColumn re5 = new DataGridViewTextBoxColumn();
                re5.Name = "Column6" + cuentanueva;
                re5.HeaderText = "Observacion";
                re5.ReadOnly = true;
                DataGridViewColumn re6 = new DataGridViewCheckBoxColumn();
                re6.Name = "Column7" + cuentanueva;
                re6.HeaderText = "Estado";
                dg.Name = "dgv" + cuentanueva;
                dg.Columns.Add(re);
                dg.Columns.Add(re1);
                dg.Columns.Add(re2);
                dg.Columns.Add(re3);
                dg.Columns.Add(re4);
                dg.Columns.Add(re5);
                dg.Columns.Add(re6);
                dg.Height = 217;
                dg.Width = 655;
                dg.AllowUserToAddRows = false;
                dg.AllowUserToDeleteRows = false;
                dg.BackgroundColor = Color.Silver;
                dg.Location = new System.Drawing.Point(6, 6);


                Label lb = new Label();
                lb.Name = "lbl7" + cuentanueva;
                lb.Text = "Total a Pagar: ";
                lb.Location = new System.Drawing.Point(489, 247);
                lb.AutoSize = true;
                Label lb2 = new Label();
                lb2.Text = "$ Monto Total ";
                lb2.Location = new System.Drawing.Point(583, 247);
                lb2.AutoSize = true;
                lb2.Name = "lbl6" + cuentanueva;


                TabPage tab = new TabPage();
                tab.Text = cuentanueva;
                tab.Name = cuentanueva;
                tab.Controls.Add(dg);
                tab.Controls.Add(lb);
                tab.Controls.Add(lb2);
                tab.BackColor = Color.Silver;

                tcCuentas.Controls.Add(tab);

                NegocioCuenta_Producto cp = new NegocioCuenta_Producto();
                mostrar2 = cp.getCuenta_ProductoxCuenta1(idcuenta).GetEnumerator();

                while (mostrar2.MoveNext())
                {
                    Cuenta_Producto cli2 = (Cuenta_Producto)mostrar2.Current;

                    NegocioProducto neg = new NegocioProducto();
                    Producto pro = neg.buscarProducto(cli2._producto);

                    string nombreTab = tab.Name.ToString();

                    Control[] ctl = tab.Controls.Find("dgv" + nombreTab, false);

                    DataGridView dgv = (DataGridView)ctl[0];

                    dgv.Rows.Add(pro._descripcion, pro._nombre, cli2._cantidad, pro._precio, cli2._cantidad * pro._precio, "");

                    calcularTotal(tab);
                }
            }
        
        }

        private void btnAgregarCuenta_Click(object sender, EventArgs e)
        {
            AgregarCuenta are = new AgregarCuenta();
            are.ShowDialog();

            string cuentanueva = AgregarCuenta.CuentaNueva.ToString();

            if(cuentanueva != null || cuentanueva != ""){

                DataGridView dg = new DataGridView();
                DataGridViewColumn re = new DataGridViewTextBoxColumn();
                 re.Name = "Column1" + cuentanueva;
                re.HeaderText = "Descripcion";
                re.ReadOnly = true;
                DataGridViewColumn re1 = new DataGridViewTextBoxColumn();
                re1.Name = "Column2" + cuentanueva;
                re1.HeaderText = "Producto";
                re1.Visible = true;
                re1.ReadOnly = true;
                DataGridViewColumn re2 = new DataGridViewTextBoxColumn();
                re2.Name = "Column3" + cuentanueva;
                re2.HeaderText = "Cantidad";
                re2.ReadOnly = true;
                DataGridViewColumn re3 = new DataGridViewTextBoxColumn();
                re3.Name = "Column4" + cuentanueva;
                re3.HeaderText = "Valor";
                re3.ReadOnly = true;
                DataGridViewColumn re4 = new DataGridViewTextBoxColumn();
                re4.Name = "Column5" + cuentanueva;
                re4.HeaderText = "Total";
                re4.ReadOnly = true;
                DataGridViewColumn re5 = new DataGridViewTextBoxColumn();
                re5.Name = "Column6" + cuentanueva;
                re5.HeaderText = "Observacion";
                re5.ReadOnly = true;
                DataGridViewColumn re6 = new DataGridViewCheckBoxColumn();
                re6.Name = "Column7" + cuentanueva;
                re6.HeaderText = "Estado";
                dg.Name = "dgv"+cuentanueva;
                dg.Columns.Add(re);
                dg.Columns.Add(re1);
                dg.Columns.Add(re2);
                dg.Columns.Add(re3);
                dg.Columns.Add(re4);
                dg.Columns.Add(re5);
                dg.Columns.Add(re6);
                dg.Height = 217;
                dg.Width = 655;
                dg.AllowUserToAddRows = false;
                dg.AllowUserToDeleteRows = false;
                dg.BackgroundColor = Color.Silver;
                dg.Location = new System.Drawing.Point(6,6);


                Label lb = new Label();
                lb.Name = "lbl7"+cuentanueva;
                lb.Text = "Total a Pagar: ";
                lb.Location = new System.Drawing.Point(489, 247);
                lb.AutoSize = true;
                Label lb2 = new Label();
                lb2.Text = "$ Monto Total ";
                lb2.Location = new System.Drawing.Point(583, 247);
                lb2.AutoSize = true;
                lb2.Name = "lbl6"+cuentanueva;


                TabPage tab = new TabPage();
                tab.Text = cuentanueva;
                tab.Name = cuentanueva;
                tab.Controls.Add(dg);
                tab.Controls.Add(lb);
                tab.Controls.Add(lb2);
                tab.BackColor = Color.Silver;

                tcCuentas.Controls.Add(tab);
            }
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            TabPage pag = tcCuentas.SelectedTab;
            string nombre = pag.Name.ToString();
            Control[] ctl = pag.Controls.Find("dgv" + nombre , false);
            DataGridView dgv = (DataGridView)ctl[0];
            try
            {
                int fila = dgv.CurrentRow.Index;
                dgv[2, fila].Value = Convert.ToInt32(dgv[2, fila].Value) + 1;
                dgv[4, fila].Value = Convert.ToInt32(dgv[3, fila].Value) * Convert.ToInt32(dgv[2, fila].Value);

                calcularTotal(pag);
            }
            catch {
                MessageBox.Show("Debe seleccionar una fila para aumentar la cantidad","Error de aumento");
            }
            
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {

            TabPage pag = tcCuentas.SelectedTab;
            string nombre = pag.Name.ToString();
            Control[] ctl = pag.Controls.Find("dgv" + nombre, false);
            DataGridView dgv = (DataGridView)ctl[0];
            try{
            int fila = dgv.CurrentRow.Index;
            if (Convert.ToInt32(dgv[2, fila].Value) != 1)
            {
                dgv[2, fila].Value = Convert.ToInt32(dgv[2, fila].Value) - 1;

                dgv[4, fila].Value = Convert.ToInt32(dgv[3, fila].Value) * Convert.ToInt32(dgv[2, fila].Value);
                calcularTotal(pag);
            }
            }
            catch {
                MessageBox.Show("Debe seleccionar una fila para disminuir la cantidad","Error de disminución");
            }
        }

        private void btnObservacion_Click(object sender, EventArgs e)
        {
            Observacion erb = new Observacion();
            erb.ShowDialog();

            string obs = erb.observacion.ToString();

            TabPage pag = tcCuentas.SelectedTab;
            string nombre = pag.Name.ToString();
            Control[] ctl = pag.Controls.Find("dgv" + nombre, false);
            DataGridView dgv = (DataGridView)ctl[0];

            try
            {
                int fila = dgv.CurrentRow.Index;
                dgv[5, fila].Value = obs;
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila para incluir una observación", "Error de observación");
            }
        }

        private void btnEliminarProd_Click(object sender, EventArgs e)
        {
           
            TabPage pag = tcCuentas.SelectedTab;
            string nombre = pag.Name.ToString();
            Control[] ctl = pag.Controls.Find("dgv" + nombre, false);
            DataGridView dgv = (DataGridView)ctl[0];

            try
            {
                int fila = dgv.CurrentRow.Index;
                dgv.Rows.RemoveAt(fila);
            }
            catch
            {
                MessageBox.Show("Debe seleccionar una fila para incluir una observación", "Error de observación");
            }
        }

        bool seguardo = false;

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (tcCuentas.TabCount == 1 && dgvCuenta.Rows.Count == 0)
            {
                return;
            }

            if (Form1.tienePedidos == false)
            {
                Grabar();
                seguardo = true;
                MessageBox.Show("Su comanda a sido guardada en la base de datos con exito", "Guardado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                deshabilitarControl = true;
                this.Close();
            }
            else
            {
                guardarexistente();
                MessageBox.Show("Se sobrescribio con exito", "Guardado",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form1.tienePedidos = true;
                seguardo = true;
                deshabilitarControl = true;
                this.Close();
            }
        }

        private void guardarexistente()
        {
            try
            {
                int iddecuenta = 0;

                NegocioCuenta_Producto cue = new NegocioCuenta_Producto();
                NegocioCuenta cu = new NegocioCuenta();
                NegocioProducto prod = new NegocioProducto();

                foreach (int item in cuentas)
                {
                    iddecuenta = item;
                    Cuenta cuent = cu.buscarCuenta(iddecuenta);
                    ArrayList cep = cue.getCuenta_ProductoxCuenta1(cuent._ID_Cuenta);

                    foreach (Cuenta_Producto cp in cep)
                    {
                        cue.eliminarCuenta_Producto(cp._ID_Lista);
                    }

                    cu.eliminarCuenta(cuent._ID_Cuenta);

                }
                Grabar();
            }
            catch
            {
                MessageBox.Show("Error de sobreescribir asegurece de que" +
                "todos los datos fueron ingresados correctamente.", "Error de comanda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grabar() {
            try
            {

                NegocioMesa me = new NegocioMesa();
                Mesa mesa = me.buscarMesa(int.Parse(lblMesa.Text.ToString()));
                
                mesa._llegada = horaLlegada.ToString();
                mesa._estadia = tiempoEstadia.ToString();
                mesa._estado = 2;
                me.modificarMesa(mesa);
                
                

                NegocioProducto prod = new NegocioProducto();
                NegocioCuenta cu = new NegocioCuenta();
                int contadorDeCuentas = 0;
                foreach (TabPage item in tcCuentas.TabPages)
                {
                    Cuenta cuen = new Cuenta();
                    int fecha = int.Parse(DateTime.Now.Hour.ToString());
                    int hora = int.Parse(DateTime.Now.Minute.ToString());
                    int mill = int.Parse(DateTime.Now.Second.ToString());
                    int ver= fecha * hora * mill;
                    cuen._ID_Cuenta = ver + contadorDeCuentas;
                    cuen._Mesa = mesa._ID_Mesa;
                    cuen._nombre = item.Text;
                    cuen._expirada = 1;
                    cu.insertarCuenta(cuen);

                    TabPage tab = item;
                    string nombre = tab.Name.ToString();
                    Control[] ctl = tab.Controls.Find("dgv" + nombre, false);
                    DataGridView dgv = (DataGridView)ctl[0];
                    NegocioCuenta_Producto cue = new NegocioCuenta_Producto();
                    int contadorDeCuePro = 0;
                    int numerodefilas = dgv.Rows.Count;
                    
                    foreach (DataGridViewRow item2 in dgv.Rows)
                    {
                        
                        Cuenta_Producto cp = new Cuenta_Producto();
                    
                        if (contadorDeCuePro < numerodefilas)
                        {
                        
                            cp = new Cuenta_Producto();
                            cp._ID_Lista = ver + contadorDeCuentas * contadorDeCuePro;
                            cp._Cuenta = cuen._ID_Cuenta;
                            string nompro = dgv["Column2"+nombre, item2.Index].Value.ToString();
                            Producto pro = prod.buscarProductoxnombre(nompro);
                            cp._producto = pro._ID_Producto;
                            cp._observacion = (string)dgv[5, item2.Index].Value;
                            cp._cantidad = int.Parse(dgv["Column3" + nombre, item2.Index].Value.ToString());
                            cp._expirada = 1;
                            cue.insertarCuenta_Producto(cp);
                            contadorDeCuePro++;
                        }
                        contadorDeCuentas++;
                    }
                }

                NegocioPedido pe = new NegocioPedido();
                Pedido pedi = new Pedido();
                pedi._ID_Pedido = we * int.Parse(DateTime.Now.Millisecond.ToString());
                pedi._Mesa = int.Parse(lblMesa.Text);
                string garxon = lblGarzon.Text;
                NegocioUsuario usu = new NegocioUsuario();
                Usuario usua = usu.buscarUsuarioxnombre(garxon);
                pedi._Garzon = usua._nombre;
                pedi._expirado = 1;
                lblComanda.Text = pedi._ID_Pedido+"";
                pe.insertarPedido(pedi);
            }
            catch {
                MessageBox.Show("Hubo un error al intentar guardar la comanda. Porfavor verifique que"+
                "todos los datos fueron ingresados correctamente.", "Error de comanda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeshacerComanda_Click(object sender, EventArgs en)
        {
            bool eliminar = deshacerComanda();

            if(eliminar != false ){
                lblGarzon.Text = ContraseñaAdmin.contraseñaAdmin;
                lblMesa.Text = e;
                NegocioMesa me = new NegocioMesa();
                Mesa mes = me.buscarMesa(int.Parse(lblMesa.Text));

                HoraL.Text = horaLlegada.ToString();

                NegocioCuenta cu = new NegocioCuenta();
                mostrar = cu.getCuentaxMesa(mes._ID_Mesa).GetEnumerator();
                while (mostrar.MoveNext())
                {

                    Cuenta cli = (Cuenta)mostrar.Current;
                    if (mostrar == null)
                    {
                        tcCuentas.TabPages.Clear();
                    }
                }
                Pagar.cerrarmesa = true;
            }
            this.Close();
        }

        private bool deshacerComanda() {
            bool eliminar = false;

            ContraseñaAdmin adm = new ContraseñaAdmin("deshacer");
            adm.ShowDialog();

            string cont = ContraseñaAdmin.contraseñaAdmin.ToString();
            if (cont != "")
            {
                Razones nera = new Razones();
                nera.ShowDialog();

                if(nera.razon != ""){


                    NegocioComandaEliminada negcoel = new NegocioComandaEliminada();
                    NegocioComanda negco = new NegocioComanda();
                    NegocioPedido negpe = new NegocioPedido();

                    ArrayList pedidos = negpe.getPedidosxMesa(int.Parse(e));
                    ArrayList comandas = new ArrayList();

                    foreach(Pedido pe in pedidos){
                        ArrayList cadaco = negco.getComandaxpedido(pe._ID_Pedido);

                        foreach(Comanda co in cadaco){
                            comandas.Add(co);
                        }

                        pe._expirado = 2;
                    }

                    foreach (Comanda co in comandas)
                    {
                        ComandasEliminadas coel = new ComandasEliminadas();
                        coel._ID_Comanda = co._ID_Comanda;
                        coel._Razon = nera.razon;
                        coel._otro = nera.otro;

                        negcoel.insertarComandaEliminada(coel);
                    }
                

                    NegocioCuenta negcu = new NegocioCuenta();
                    NegocioCuenta_Producto negcupro = new NegocioCuenta_Producto();

                    ArrayList cuent = negcu.getCuentaxMesa(int.Parse(lblMesa.Text));


                    foreach (Cuenta item2 in cuent)
                    {


                        item2._expirada = 2;
                        negcu.modificarCuenta(item2);
                    }

                    NegocioMesa negmesa = new NegocioMesa();
                    Mesa me = negmesa.buscarMesa(int.Parse(lblMesa.Text));

                    me._estadia = "00:00:00";
                    me._estado = 1;
                    me._llegada = "00:00:00";
                    me._salida = "00:00:00";

                    negmesa.modificarMesa(me);

                    

                    MessageBox.Show("Comanda eliminada correctamente", "Comanda Eliminada!", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    
                    

                    eliminar = true;
                }

                
            }
            return eliminar;
        }

      

        private void AgregarOrden_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HoraA.Text = DateTime.Now.ToLongTimeString();

            

            horaActual = TimeSpan.Parse(HoraA.Text);
            horaLlegada = TimeSpan.Parse(HoraL.Text);
            tiempoEstadia = horaActual - horaLlegada;
            TiempoE.Text = Convert.ToString(tiempoEstadia);

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimirComanda();
            this.Close();
        }

        private void ImprimirComanda() { 
            NegocioComanda negco = new NegocioComanda();
            NegocioCuenta negcu = new NegocioCuenta();
            NegocioCuenta_Producto negcupro = new NegocioCuenta_Producto();
            NegocioProducto negpro = new NegocioProducto();
            NegocioPedido negpe = new NegocioPedido();
            NegocioMesa negme = new NegocioMesa();
            NegocioIngredientes negIng = new NegocioIngredientes();
            NegocioLista_Ingredientes negLista = new NegocioLista_Ingredientes();
            NegocioBodegaCentral negBod = new NegocioBodegaCentral();


            
            ArrayList cuentas = negcu.getCuentaxMesa(int.Parse(e));

            foreach(Cuenta item in cuentas){
                ArrayList cuenta_productos = negcupro.getCuenta_ProductoxCuenta1(item._ID_Cuenta);

                Pedido pe = negpe.buscarPedidoxMesa(int.Parse(e));

                Comanda co = new Comanda();
                co._ID_Comanda = we ;
                co._Pedido = pe._ID_Pedido;
                int empezar = 0;
                foreach(Cuenta_Producto item2 in cuenta_productos){
                    
                    Producto pro = negpro.buscarProducto(item2._producto);
                    if(empezar == 0){
                        co._detalle += " Nom Cuenta | producto | observacion | cantidad \n ";
                        empezar++;
                    }
                    co._detalle += " " + item._nombre + " | " + pro._nombre + " | " + item2._observacion + " | "+ item2._cantidad +"\n ";

                    item2._expirada = 2;
                    negcupro.modificarCuenta_Producto(item2);

                    ArrayList listaingredientes = negLista.getLista_IngredientesxProducto(pro._ID_Producto);

                    foreach(Lista_Ingredientes lis in listaingredientes){

                        Bodega_Central bodega = negBod.buscarBodegaCentralxIngrediente(lis._ingrediente);

                        bodega._cantidad -= lis._cantidad;

                        negBod.modificarBodegaCentral(bodega);
                    }
                }

                co._expirada = 1;
                negco.insertarComanda(co);
            }



           Pedido pde = negpe.buscarPedidoxMesa(int.Parse(e));

           ArrayList coma = negco.getComandaxpedido(pde._ID_Pedido);

            if(coma.Count != 0){
               string detailsamostrar = "";

               foreach(Comanda it in coma){
                   detailsamostrar += it._detalle+"\n";
                   it._expirada = 2;
                   negco.modificarComanda(it);
               }
               ArrayList aimp = new ArrayList();
               aimp.Add(detailsamostrar);
               MessageBox.Show(detailsamostrar);
               Pagar.Imprimir(aimp);
            }

        }

        public static bool cerrarturno = false;

        private void btnTurno_Click(object sender, EventArgs e)
        {
            cerrarturno = true;

            if (Form1.estadoturno == true)
            {
                NegocioTurno negtur = new NegocioTurno();

                Turno tur = negtur.buscarTurno(ContraseñaAdmin.contr);

                tur._Fin = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();

                negtur.modificarTurno(tur);

                Form1.estadoturno = false;

                MessageBox.Show("Turno Finalizado: " + tur._Fin, "Fin Turno");
            }
            this.Close();
        }

        
    }
}
