namespace ProyectBar
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tcPestañas = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlPiso1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCargar2 = new System.Windows.Forms.Button();
            this.btnGuardar2 = new System.Windows.Forms.Button();
            this.pnl2Piso = new System.Windows.Forms.Panel();
            this.tpTerraza = new System.Windows.Forms.TabPage();
            this.btnCargar3 = new System.Windows.Forms.Button();
            this.btnGuardar3 = new System.Windows.Forms.Button();
            this.pnlTerraza = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnTurno = new System.Windows.Forms.Button();
            this.btnInformeX = new System.Windows.Forms.Button();
            this.tcPestañas.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tpTerraza.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPestañas
            // 
            this.tcPestañas.Controls.Add(this.tabPage1);
            this.tcPestañas.Controls.Add(this.tabPage2);
            this.tcPestañas.Controls.Add(this.tpTerraza);
            this.tcPestañas.Location = new System.Drawing.Point(12, 12);
            this.tcPestañas.Name = "tcPestañas";
            this.tcPestañas.SelectedIndex = 0;
            this.tcPestañas.Size = new System.Drawing.Size(1093, 495);
            this.tcPestañas.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.pnlPiso1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1085, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1er Piso";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Location = new System.Drawing.Point(6, 35);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Cargar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Location = new System.Drawing.Point(6, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Posiciones";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlPiso1
            // 
            this.pnlPiso1.AutoScroll = true;
            this.pnlPiso1.BackColor = System.Drawing.Color.Transparent;
            this.pnlPiso1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPiso1.BackgroundImage")));
            this.pnlPiso1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlPiso1.Location = new System.Drawing.Point(99, 6);
            this.pnlPiso1.Name = "pnlPiso1";
            this.pnlPiso1.Size = new System.Drawing.Size(977, 453);
            this.pnlPiso1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.btnCargar2);
            this.tabPage2.Controls.Add(this.btnGuardar2);
            this.tabPage2.Controls.Add(this.pnl2Piso);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1085, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2do Piso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCargar2
            // 
            this.btnCargar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar2.Location = new System.Drawing.Point(6, 36);
            this.btnCargar2.Name = "btnCargar2";
            this.btnCargar2.Size = new System.Drawing.Size(75, 23);
            this.btnCargar2.TabIndex = 3;
            this.btnCargar2.Text = "Cargar";
            this.btnCargar2.UseVisualStyleBackColor = true;
            this.btnCargar2.Click += new System.EventHandler(this.btnCargar2_Click);
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar2.Location = new System.Drawing.Point(6, 6);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar2.TabIndex = 2;
            this.btnGuardar2.Text = "Guardar";
            this.btnGuardar2.UseVisualStyleBackColor = true;
            this.btnGuardar2.Click += new System.EventHandler(this.btnGuardar2_Click);
            // 
            // pnl2Piso
            // 
            this.pnl2Piso.BackColor = System.Drawing.Color.Transparent;
            this.pnl2Piso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl2Piso.BackgroundImage")));
            this.pnl2Piso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl2Piso.Location = new System.Drawing.Point(99, 6);
            this.pnl2Piso.Name = "pnl2Piso";
            this.pnl2Piso.Size = new System.Drawing.Size(976, 453);
            this.pnl2Piso.TabIndex = 1;
            // 
            // tpTerraza
            // 
            this.tpTerraza.Controls.Add(this.btnCargar3);
            this.tpTerraza.Controls.Add(this.btnGuardar3);
            this.tpTerraza.Controls.Add(this.pnlTerraza);
            this.tpTerraza.Location = new System.Drawing.Point(4, 22);
            this.tpTerraza.Name = "tpTerraza";
            this.tpTerraza.Padding = new System.Windows.Forms.Padding(3);
            this.tpTerraza.Size = new System.Drawing.Size(1085, 469);
            this.tpTerraza.TabIndex = 2;
            this.tpTerraza.Text = "Terraza";
            this.tpTerraza.UseVisualStyleBackColor = true;
            // 
            // btnCargar3
            // 
            this.btnCargar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargar3.Location = new System.Drawing.Point(8, 38);
            this.btnCargar3.Name = "btnCargar3";
            this.btnCargar3.Size = new System.Drawing.Size(75, 23);
            this.btnCargar3.TabIndex = 6;
            this.btnCargar3.Text = "Cargar";
            this.btnCargar3.UseVisualStyleBackColor = true;
            this.btnCargar3.Click += new System.EventHandler(this.btnCargar3_Click);
            // 
            // btnGuardar3
            // 
            this.btnGuardar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar3.Location = new System.Drawing.Point(8, 8);
            this.btnGuardar3.Name = "btnGuardar3";
            this.btnGuardar3.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar3.TabIndex = 5;
            this.btnGuardar3.Text = "Guardar";
            this.btnGuardar3.UseVisualStyleBackColor = true;
            this.btnGuardar3.Click += new System.EventHandler(this.btnGuardar3_Click);
            // 
            // pnlTerraza
            // 
            this.pnlTerraza.BackColor = System.Drawing.Color.Transparent;
            this.pnlTerraza.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTerraza.BackgroundImage")));
            this.pnlTerraza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTerraza.Location = new System.Drawing.Point(101, 8);
            this.pnlTerraza.Name = "pnlTerraza";
            this.pnlTerraza.Size = new System.Drawing.Size(976, 453);
            this.pnlTerraza.TabIndex = 4;
            // 
            // btnSalir
            // 
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Location = new System.Drawing.Point(24, 550);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 23);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Cerrar Aplicación";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnInicio);
            this.panel2.Controls.Add(this.btnTurno);
            this.panel2.Location = new System.Drawing.Point(834, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 60);
            this.panel2.TabIndex = 14;
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Location = new System.Drawing.Point(33, 7);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(75, 38);
            this.btnInicio.TabIndex = 8;
            this.btnInicio.Text = "Iniciar turno";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnTurno
            // 
            this.btnTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTurno.Location = new System.Drawing.Point(171, 7);
            this.btnTurno.Name = "btnTurno";
            this.btnTurno.Size = new System.Drawing.Size(75, 38);
            this.btnTurno.TabIndex = 7;
            this.btnTurno.Text = "Termino Turno";
            this.btnTurno.UseVisualStyleBackColor = true;
            this.btnTurno.Click += new System.EventHandler(this.btnTurno_Click_1);
            // 
            // btnInformeX
            // 
            this.btnInformeX.Location = new System.Drawing.Point(169, 550);
            this.btnInformeX.Name = "btnInformeX";
            this.btnInformeX.Size = new System.Drawing.Size(75, 23);
            this.btnInformeX.TabIndex = 19;
            this.btnInformeX.Text = "Abrir Caja";
            this.btnInformeX.UseVisualStyleBackColor = true;
            this.btnInformeX.Click += new System.EventHandler(this.btnInformeX_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1117, 585);
            this.Controls.Add(this.btnInformeX);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tcPestañas);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Resto-bar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcPestañas.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tpTerraza.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcPestañas;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlPiso1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnl2Piso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCargar2;
        private System.Windows.Forms.Button btnGuardar2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTurno;
        private System.Windows.Forms.TabPage tpTerraza;
        private System.Windows.Forms.Button btnCargar3;
        private System.Windows.Forms.Button btnGuardar3;
        private System.Windows.Forms.Panel pnlTerraza;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnInformeX;
    }
}

