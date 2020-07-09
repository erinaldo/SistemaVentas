namespace Sistema.Presentacion
{
    partial class FrmConsultas_VentasFechas
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
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.PanelMostrar = new System.Windows.Forms.Panel();
            this.txtTotalD = new System.Windows.Forms.TextBox();
            this.txtTotalImpuestoD = new System.Windows.Forms.TextBox();
            this.txtSubTotalD = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.DgvMostrarDetalle = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabcontrol1 = new System.Windows.Forms.TabControl();
            this.Erroricono = new System.Windows.Forms.ErrorProvider(this.components);
            this.TabGeneral.SuspendLayout();
            this.PanelMostrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMostrarDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.tabcontrol1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erroricono)).BeginInit();
            this.SuspendLayout();
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.label2);
            this.TabGeneral.Controls.Add(this.label1);
            this.TabGeneral.Controls.Add(this.DtpFechaFin);
            this.TabGeneral.Controls.Add(this.DtpFechaInicio);
            this.TabGeneral.Controls.Add(this.button2);
            this.TabGeneral.Controls.Add(this.PanelMostrar);
            this.TabGeneral.Controls.Add(this.btnBuscar);
            this.TabGeneral.Controls.Add(this.lblTotal);
            this.TabGeneral.Controls.Add(this.DgvListado);
            this.TabGeneral.Location = new System.Drawing.Point(4, 22);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(989, 554);
            this.TabGeneral.TabIndex = 0;
            this.TabGeneral.Text = "Listado";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Desde";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(314, 47);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaFin.TabIndex = 10;
            this.DtpFechaFin.ValueChanged += new System.EventHandler(this.DtpFechaFin_ValueChanged);
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaInicio.Location = new System.Drawing.Point(52, 47);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.DtpFechaInicio.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Comprobante";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // PanelMostrar
            // 
            this.PanelMostrar.BackColor = System.Drawing.Color.NavajoWhite;
            this.PanelMostrar.Controls.Add(this.txtTotalD);
            this.PanelMostrar.Controls.Add(this.txtTotalImpuestoD);
            this.PanelMostrar.Controls.Add(this.txtSubTotalD);
            this.PanelMostrar.Controls.Add(this.label14);
            this.PanelMostrar.Controls.Add(this.label13);
            this.PanelMostrar.Controls.Add(this.label12);
            this.PanelMostrar.Controls.Add(this.button1);
            this.PanelMostrar.Controls.Add(this.DgvMostrarDetalle);
            this.PanelMostrar.Location = new System.Drawing.Point(141, 172);
            this.PanelMostrar.Name = "PanelMostrar";
            this.PanelMostrar.Size = new System.Drawing.Size(833, 376);
            this.PanelMostrar.TabIndex = 7;
            this.PanelMostrar.Visible = false;
            // 
            // txtTotalD
            // 
            this.txtTotalD.Enabled = false;
            this.txtTotalD.Location = new System.Drawing.Point(733, 352);
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.Size = new System.Drawing.Size(89, 20);
            this.txtTotalD.TabIndex = 13;
            // 
            // txtTotalImpuestoD
            // 
            this.txtTotalImpuestoD.Enabled = false;
            this.txtTotalImpuestoD.Location = new System.Drawing.Point(733, 322);
            this.txtTotalImpuestoD.Name = "txtTotalImpuestoD";
            this.txtTotalImpuestoD.Size = new System.Drawing.Size(89, 20);
            this.txtTotalImpuestoD.TabIndex = 12;
            // 
            // txtSubTotalD
            // 
            this.txtSubTotalD.Enabled = false;
            this.txtSubTotalD.Location = new System.Drawing.Point(733, 296);
            this.txtSubTotalD.Name = "txtSubTotalD";
            this.txtSubTotalD.Size = new System.Drawing.Size(89, 20);
            this.txtSubTotalD.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(641, 298);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Subtotal";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(641, 326);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Total Impuesto";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(641, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Total";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(780, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // DgvMostrarDetalle
            // 
            this.DgvMostrarDetalle.AllowUserToAddRows = false;
            this.DgvMostrarDetalle.AllowUserToDeleteRows = false;
            this.DgvMostrarDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMostrarDetalle.Location = new System.Drawing.Point(16, 39);
            this.DgvMostrarDetalle.Name = "DgvMostrarDetalle";
            this.DgvMostrarDetalle.ReadOnly = true;
            this.DgvMostrarDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMostrarDetalle.Size = new System.Drawing.Size(806, 248);
            this.DgvMostrarDetalle.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(544, 44);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(808, 504);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total:";
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.AllowUserToDeleteRows = false;
            this.DgvListado.AllowUserToOrderColumns = true;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.DgvListado.Location = new System.Drawing.Point(3, 78);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListado.Size = new System.Drawing.Size(971, 423);
            this.DgvListado.TabIndex = 0;
            this.DgvListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellContentClick);
            this.DgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellDoubleClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            // 
            // tabcontrol1
            // 
            this.tabcontrol1.Controls.Add(this.TabGeneral);
            this.tabcontrol1.Location = new System.Drawing.Point(2, 3);
            this.tabcontrol1.Name = "tabcontrol1";
            this.tabcontrol1.SelectedIndex = 0;
            this.tabcontrol1.Size = new System.Drawing.Size(997, 580);
            this.tabcontrol1.TabIndex = 3;
            // 
            // Erroricono
            // 
            this.Erroricono.ContainerControl = this;
            // 
            // FrmConsultas_VentasFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 596);
            this.Controls.Add(this.tabcontrol1);
            this.Name = "FrmConsultas_VentasFechas";
            this.Text = "Consultas de ventas entre fechas";
            this.Load += new System.EventHandler(this.FrmConsultas_VentasFechas_Load);
            this.TabGeneral.ResumeLayout(false);
            this.TabGeneral.PerformLayout();
            this.PanelMostrar.ResumeLayout(false);
            this.PanelMostrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMostrarDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.tabcontrol1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Erroricono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelMostrar;
        private System.Windows.Forms.TextBox txtTotalD;
        private System.Windows.Forms.TextBox txtTotalImpuestoD;
        private System.Windows.Forms.TextBox txtSubTotalD;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DgvMostrarDetalle;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
        private System.Windows.Forms.TabControl tabcontrol1;
        private System.Windows.Forms.ErrorProvider Erroricono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
    }
}