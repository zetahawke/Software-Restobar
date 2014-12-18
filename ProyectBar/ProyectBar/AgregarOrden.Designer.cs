namespace ProyectBar
{
    partial class AgregarOrden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMesa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGarzon = new System.Windows.Forms.Label();
            this.pnlOrden = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.HoraA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TiempoE = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HoraL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeshacerComanda = new System.Windows.Forms.Button();
            this.btnEliminarProd = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAgregarCuenta = new System.Windows.Forms.Button();
            this.btnObservacion = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnRestar = new System.Windows.Forms.Button();
            this.btnSumar = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.tcCuentas = new System.Windows.Forms.TabControl();
            this.Cuenta = new System.Windows.Forms.TabPage();
            this.dgvCuenta = new System.Windows.Forms.DataGridView();
            this.Column1Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7Cuenta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbl6Cuenta = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTurno = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbcProducts = new System.Windows.Forms.TabControl();
            this.lblComanda = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlOrden.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tcCuentas.SuspendLayout();
            this.Cuenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuenta)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Location = new System.Drawing.Point(49, 8);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(70, 13);
            this.lblMesa.TabIndex = 0;
            this.lblMesa.Text = "NombreLabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mesa: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Garzón:";
            // 
            // lblGarzon
            // 
            this.lblGarzon.AutoSize = true;
            this.lblGarzon.Location = new System.Drawing.Point(61, 31);
            this.lblGarzon.Name = "lblGarzon";
            this.lblGarzon.Size = new System.Drawing.Size(78, 13);
            this.lblGarzon.TabIndex = 3;
            this.lblGarzon.Text = "NombreGarzón";
            // 
            // pnlOrden
            // 
            this.pnlOrden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlOrden.Controls.Add(this.panel5);
            this.pnlOrden.Controls.Add(this.panel1);
            this.pnlOrden.Controls.Add(this.tcCuentas);
            this.pnlOrden.Controls.Add(this.label1);
            this.pnlOrden.Controls.Add(this.lblMesa);
            this.pnlOrden.Controls.Add(this.label2);
            this.pnlOrden.Controls.Add(this.lblGarzon);
            this.pnlOrden.Location = new System.Drawing.Point(12, 12);
            this.pnlOrden.Name = "pnlOrden";
            this.pnlOrden.Size = new System.Drawing.Size(685, 571);
            this.pnlOrden.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.HoraA);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.TiempoE);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.HoraL);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(413, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(261, 55);
            this.panel5.TabIndex = 15;
            // 
            // HoraA
            // 
            this.HoraA.AutoSize = true;
            this.HoraA.Location = new System.Drawing.Point(80, 31);
            this.HoraA.Name = "HoraA";
            this.HoraA.Size = new System.Drawing.Size(35, 13);
            this.HoraA.TabIndex = 5;
            this.HoraA.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hora Actual";
            // 
            // TiempoE
            // 
            this.TiempoE.AutoSize = true;
            this.TiempoE.Location = new System.Drawing.Point(215, 5);
            this.TiempoE.Name = "TiempoE";
            this.TiempoE.Size = new System.Drawing.Size(35, 13);
            this.TiempoE.TabIndex = 3;
            this.TiempoE.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiempo Estadia";
            // 
            // HoraL
            // 
            this.HoraL.AutoSize = true;
            this.HoraL.Location = new System.Drawing.Point(80, 5);
            this.HoraL.Name = "HoraL";
            this.HoraL.Size = new System.Drawing.Size(35, 13);
            this.HoraL.TabIndex = 1;
            this.HoraL.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Hora Llegada";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDeshacerComanda);
            this.panel1.Controls.Add(this.btnEliminarProd);
            this.panel1.Controls.Add(this.btnGrabar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(3, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(671, 165);
            this.panel1.TabIndex = 14;
            // 
            // btnDeshacerComanda
            // 
            this.btnDeshacerComanda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeshacerComanda.Location = new System.Drawing.Point(292, 96);
            this.btnDeshacerComanda.Name = "btnDeshacerComanda";
            this.btnDeshacerComanda.Size = new System.Drawing.Size(81, 38);
            this.btnDeshacerComanda.TabIndex = 17;
            this.btnDeshacerComanda.Text = "Deshacer Comanda";
            this.btnDeshacerComanda.UseVisualStyleBackColor = true;
            this.btnDeshacerComanda.Click += new System.EventHandler(this.btnDeshacerComanda_Click);
            // 
            // btnEliminarProd
            // 
            this.btnEliminarProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarProd.Location = new System.Drawing.Point(141, 96);
            this.btnEliminarProd.Name = "btnEliminarProd";
            this.btnEliminarProd.Size = new System.Drawing.Size(81, 38);
            this.btnEliminarProd.TabIndex = 16;
            this.btnEliminarProd.Text = "Eliminar Producto";
            this.btnEliminarProd.UseVisualStyleBackColor = true;
            this.btnEliminarProd.Click += new System.EventHandler(this.btnEliminarProd_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrabar.Location = new System.Drawing.Point(447, 96);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(92, 38);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "Grabar Comanda";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnAgregarCuenta);
            this.panel3.Controls.Add(this.btnObservacion);
            this.panel3.Controls.Add(this.lblCantidad);
            this.panel3.Controls.Add(this.btnRestar);
            this.panel3.Controls.Add(this.btnSumar);
            this.panel3.Controls.Add(this.btnPagar);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 77);
            this.panel3.TabIndex = 15;
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCuenta.Location = new System.Drawing.Point(425, 11);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(109, 23);
            this.btnAgregarCuenta.TabIndex = 25;
            this.btnAgregarCuenta.Text = "Agregar Cuenta";
            this.btnAgregarCuenta.UseVisualStyleBackColor = true;
            this.btnAgregarCuenta.Click += new System.EventHandler(this.btnAgregarCuenta_Click);
            // 
            // btnObservacion
            // 
            this.btnObservacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservacion.Location = new System.Drawing.Point(287, 11);
            this.btnObservacion.Name = "btnObservacion";
            this.btnObservacion.Size = new System.Drawing.Size(75, 23);
            this.btnObservacion.TabIndex = 17;
            this.btnObservacion.Text = "Observacion";
            this.btnObservacion.UseVisualStyleBackColor = true;
            this.btnObservacion.Click += new System.EventHandler(this.btnObservacion_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(123, 16);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(55, 13);
            this.lblCantidad.TabIndex = 16;
            this.lblCantidad.Text = "Cantidad: ";
            // 
            // btnRestar
            // 
            this.btnRestar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestar.Location = new System.Drawing.Point(213, 11);
            this.btnRestar.Name = "btnRestar";
            this.btnRestar.Size = new System.Drawing.Size(23, 23);
            this.btnRestar.TabIndex = 15;
            this.btnRestar.Text = "-";
            this.btnRestar.UseVisualStyleBackColor = true;
            this.btnRestar.Click += new System.EventHandler(this.btnRestar_Click);
            // 
            // btnSumar
            // 
            this.btnSumar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSumar.Location = new System.Drawing.Point(184, 11);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(23, 23);
            this.btnSumar.TabIndex = 14;
            this.btnSumar.Text = "+";
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.Location = new System.Drawing.Point(296, 40);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(54, 23);
            this.btnPagar.TabIndex = 13;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // tcCuentas
            // 
            this.tcCuentas.Controls.Add(this.Cuenta);
            this.tcCuentas.Location = new System.Drawing.Point(3, 89);
            this.tcCuentas.Name = "tcCuentas";
            this.tcCuentas.SelectedIndex = 0;
            this.tcCuentas.Size = new System.Drawing.Size(675, 304);
            this.tcCuentas.TabIndex = 12;
            // 
            // Cuenta
            // 
            this.Cuenta.BackColor = System.Drawing.Color.Silver;
            this.Cuenta.Controls.Add(this.dgvCuenta);
            this.Cuenta.Controls.Add(this.lbl6Cuenta);
            this.Cuenta.Controls.Add(this.label7);
            this.Cuenta.Location = new System.Drawing.Point(4, 22);
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.Padding = new System.Windows.Forms.Padding(3);
            this.Cuenta.Size = new System.Drawing.Size(667, 278);
            this.Cuenta.TabIndex = 1;
            this.Cuenta.Text = "Cuenta";
            // 
            // dgvCuenta
            // 
            this.dgvCuenta.AllowUserToAddRows = false;
            this.dgvCuenta.AllowUserToDeleteRows = false;
            this.dgvCuenta.AllowUserToResizeColumns = false;
            this.dgvCuenta.AllowUserToResizeRows = false;
            this.dgvCuenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1Cuenta,
            this.Column2Cuenta,
            this.Column3Cuenta,
            this.Column4Cuenta,
            this.Column5Cuenta,
            this.Column6Cuenta,
            this.Column7Cuenta});
            this.dgvCuenta.Location = new System.Drawing.Point(6, 6);
            this.dgvCuenta.Name = "dgvCuenta";
            this.dgvCuenta.Size = new System.Drawing.Size(655, 217);
            this.dgvCuenta.TabIndex = 6;
            // 
            // Column1Cuenta
            // 
            this.Column1Cuenta.HeaderText = "Descripcion";
            this.Column1Cuenta.Name = "Column1Cuenta";
            // 
            // Column2Cuenta
            // 
            this.Column2Cuenta.HeaderText = "Producto";
            this.Column2Cuenta.Name = "Column2Cuenta";
            this.Column2Cuenta.ReadOnly = true;
            // 
            // Column3Cuenta
            // 
            this.Column3Cuenta.HeaderText = "Cantidad";
            this.Column3Cuenta.Name = "Column3Cuenta";
            // 
            // Column4Cuenta
            // 
            this.Column4Cuenta.HeaderText = "Valor";
            this.Column4Cuenta.Name = "Column4Cuenta";
            this.Column4Cuenta.ReadOnly = true;
            // 
            // Column5Cuenta
            // 
            this.Column5Cuenta.HeaderText = "Total";
            this.Column5Cuenta.Name = "Column5Cuenta";
            this.Column5Cuenta.ReadOnly = true;
            // 
            // Column6Cuenta
            // 
            this.Column6Cuenta.HeaderText = "Observacion";
            this.Column6Cuenta.Name = "Column6Cuenta";
            this.Column6Cuenta.ReadOnly = true;
            // 
            // Column7Cuenta
            // 
            this.Column7Cuenta.HeaderText = "Estado";
            this.Column7Cuenta.Name = "Column7Cuenta";
            this.Column7Cuenta.ReadOnly = true;
            // 
            // lbl6Cuenta
            // 
            this.lbl6Cuenta.AutoSize = true;
            this.lbl6Cuenta.Location = new System.Drawing.Point(583, 247);
            this.lbl6Cuenta.Name = "lbl6Cuenta";
            this.lbl6Cuenta.Size = new System.Drawing.Size(73, 13);
            this.lbl6Cuenta.TabIndex = 5;
            this.lbl6Cuenta.Text = "$ Monto Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total a Pagar:";
            // 
            // btnTurno
            // 
            this.btnTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTurno.Location = new System.Drawing.Point(84, 7);
            this.btnTurno.Name = "btnTurno";
            this.btnTurno.Size = new System.Drawing.Size(75, 38);
            this.btnTurno.TabIndex = 7;
            this.btnTurno.Text = "Termino Turno";
            this.btnTurno.UseVisualStyleBackColor = true;
            this.btnTurno.Click += new System.EventHandler(this.btnTurno_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnTurno);
            this.panel2.Location = new System.Drawing.Point(226, 628);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 60);
            this.panel2.TabIndex = 8;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Location = new System.Drawing.Point(813, 651);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(112, 23);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "Imprimir Comanda";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtras.Location = new System.Drawing.Point(1117, 651);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 10;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Location = new System.Drawing.Point(966, 651);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 23);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Cerrar Aplicación";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Observacion
            // 
            this.Observacion.HeaderText = "Observacion";
            this.Observacion.Name = "Observacion";
            this.Observacion.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.tbcProducts);
            this.panel4.Location = new System.Drawing.Point(703, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(638, 571);
            this.panel4.TabIndex = 14;
            // 
            // tbcProducts
            // 
            this.tbcProducts.Location = new System.Drawing.Point(3, 3);
            this.tbcProducts.Multiline = true;
            this.tbcProducts.Name = "tbcProducts";
            this.tbcProducts.SelectedIndex = 0;
            this.tbcProducts.Size = new System.Drawing.Size(628, 561);
            this.tbcProducts.TabIndex = 0;
            // 
            // lblComanda
            // 
            this.lblComanda.AutoSize = true;
            this.lblComanda.Location = new System.Drawing.Point(1111, 660);
            this.lblComanda.Name = "lblComanda";
            this.lblComanda.Size = new System.Drawing.Size(0, 13);
            this.lblComanda.TabIndex = 15;
            this.lblComanda.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AgregarOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.lblComanda);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlOrden);
            this.Name = "AgregarOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarOrden";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AgregarOrden_Load);
            this.pnlOrden.ResumeLayout(false);
            this.pnlOrden.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tcCuentas.ResumeLayout(false);
            this.Cuenta.ResumeLayout(false);
            this.Cuenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuenta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGarzon;
        private System.Windows.Forms.Panel pnlOrden;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnObservacion;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnRestar;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.Button btnDeshacerComanda;
        private System.Windows.Forms.Button btnEliminarProd;
        private System.Windows.Forms.Button btnTurno;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregarCuenta;
        private System.Windows.Forms.TabControl tcCuentas;
        private System.Windows.Forms.TabPage Cuenta;
        private System.Windows.Forms.DataGridView dgvCuenta;
        private System.Windows.Forms.Label lbl6Cuenta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tbcProducts;
        private System.Windows.Forms.Label lblComanda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6Cuenta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7Cuenta;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label HoraA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TiempoE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label HoraL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
    }
}