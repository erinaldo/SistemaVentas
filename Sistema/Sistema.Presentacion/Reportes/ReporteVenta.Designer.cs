namespace Sistema.Presentacion.Reportes
{
    partial class ReporteVenta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.venta_comprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsSistema = new Sistema.Presentacion.Reportes.DsSistema();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.venta_comprobanteTableAdapter = new Sistema.Presentacion.Reportes.DsSistemaTableAdapters.venta_comprobanteTableAdapter();
            this.VentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VentaTableAdapter = new Sistema.Presentacion.Reportes.DsSistemaTableAdapters.VentaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.venta_comprobanteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // venta_comprobanteBindingSource
            // 
            this.venta_comprobanteBindingSource.DataMember = "venta_comprobante";
            this.venta_comprobanteBindingSource.DataSource = this.DsSistema;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsVenta";
            reportDataSource1.Value = this.VentaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.Presentacion.Reportes.Venta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(993, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // venta_comprobanteTableAdapter
            // 
            this.venta_comprobanteTableAdapter.ClearBeforeFill = true;
            // 
            // VentaBindingSource
            // 
            this.VentaBindingSource.DataMember = "Venta";
            this.VentaBindingSource.DataSource = this.DsSistema;
            // 
            // VentaTableAdapter
            // 
            this.VentaTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteVenta";
            this.Text = "ReporteVenta";
            this.Load += new System.EventHandler(this.ReporteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.venta_comprobanteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource venta_comprobanteBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.venta_comprobanteTableAdapter venta_comprobanteTableAdapter;
        private System.Windows.Forms.BindingSource VentaBindingSource;
        private DsSistemaTableAdapters.VentaTableAdapter VentaTableAdapter;
    }
}