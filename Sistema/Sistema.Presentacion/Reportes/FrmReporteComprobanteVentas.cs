using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Reportes
{
    public partial class FrmReporteComprobanteVentas : Form
    {
        public FrmReporteComprobanteVentas()
        {
            InitializeComponent();
        }

        private void FrmReporteComprobanteVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.articulo_listar' Puede moverla o quitarla según sea necesario.
          //  this.articulo_listarTableAdapter.Fill(this.DsSistema.articulo_listar);
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.venta_comprobante' Puede moverla o quitarla según sea necesario.
            this.venta_comprobanteTableAdapter.Fill(this.DsSistema.venta_comprobante, Varriables.IdVenta);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
