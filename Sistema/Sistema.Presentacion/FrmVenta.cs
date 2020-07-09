using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmVenta : Form
    {

        private DataTable DtDetalle = new DataTable();
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NVenta.Listar();
                this.Formato();
                this.Limpiar();
                lblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = NVenta.Buscar(txtBuscarArticulo.Text.Trim());
                this.Formato();
                lblTotalArticulo.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[4].Width = 150;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Documento";
            DgvListado.Columns[6].Width = 70;
            DgvListado.Columns[6].HeaderText = "Serie";
            DgvListado.Columns[7].Width = 70;
            DgvListado.Columns[7].HeaderText = "Numero";
            DgvListado.Columns[8].Width = 60;
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;
            DgvListado.Columns[11].Width = 100; ;


        }

        private void Limpiar()
        {
            txtBuscar.Clear();
            txtId.Clear();
            txtCodigo.Clear();
            txtIdCliente.Clear();
            txtNombreCliente.Clear();
            txtSerieComprobante.Clear();
            txtNumeroComprobante.Clear();
            DtDetalle.Clear();
            txtSubTotal.Text = "0.00";
            txtTotalImpuesto.Text = "0.00";
            txtTotal.Text = "0.00";

            Erroricono.Clear();



            DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 
            BtnAnular.Visible = false;
            ChkSeleccionar.Checked = false;
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CrearTabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("stock", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));


            DgvDetalle.DataSource = this.DtDetalle;

            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].HeaderText = "CODIGO";
            DgvDetalle.Columns[1].Width = 100;
            DgvDetalle.Columns[2].HeaderText = "ARTICULO";
            DgvDetalle.Columns[2].Width = 200;
            DgvDetalle.Columns[3].HeaderText = "STOCK";
            DgvDetalle.Columns[3].Width = 60;
            DgvDetalle.Columns[4].HeaderText = "CANTIDAD";
            DgvDetalle.Columns[4].Width = 50;
            DgvDetalle.Columns[5].HeaderText = "PRECIO";
            DgvDetalle.Columns[5].Width = 70;
            DgvDetalle.Columns[6].HeaderText = "DESCUENTO";
            DgvDetalle.Columns[6].Width = 60;
            DgvDetalle.Columns[7].HeaderText = "IMPORTE";
            DgvDetalle.Columns[7].Width = 80;

            DgvDetalle.Columns[1].ReadOnly = true;
            DgvDetalle.Columns[2].ReadOnly = true;
            DgvDetalle.Columns[3].ReadOnly = true;
            DgvDetalle.Columns[7].ReadOnly = true;



        }
        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearTabla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVista_Cliente_Venta Vista = new FrmVista_Cliente_Venta();
            Vista.ShowDialog();
            txtIdCliente.Text = Convert.ToString(Varriables.IdCliente);
            txtNombreCliente.Text = Varriables.NombreCliente;
        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = NArticulo.BuscarCodigoVenta(txtCodigo.Text.Trim());

                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("No existe articulo con ese codigo de barras o no hay stock.");
                    }
                    else
                    {
                        //agregar al detalle
                        this.AgreagarDetalle(Convert.ToInt32(Tabla.Rows[0][0]), Convert.ToString(Tabla.Rows[0][1]), Convert.ToString(Tabla.Rows[0][2]), Convert.ToInt32(Tabla.Rows[0][4]), Convert.ToDecimal(Tabla.Rows[0][3]));
                    }
                }


            }
            catch
            {

            }
        }
        private void AgreagarDetalle(int IdArticulo, string Codigo, string Nombre, int Stock, decimal precio)
        {
            bool Agregar = true;
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false;
                    this.MensajeError("El articulo ya ha sido agregado.");
                }
            }
            if (Agregar)
            {
                DataRow Fila = DtDetalle.NewRow();
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["stock"] = Stock;
                Fila["cantidad"] = 1;
                Fila["precio"] = precio;
                Fila["descuento"] = 0; ;
                Fila["importe"] = precio;
                this.DtDetalle.Rows.Add(Fila);
                this.CalcularTotales();
            }

        }
        private void CalcularTotales()
        {

            decimal Total = 0;
            decimal SubTotal = 0;
            if (DgvDetalle.Rows.Count == 0)
            {
                Total = 0;
            }
            else
            {
                foreach (DataRow FilaTemp in DtDetalle.Rows)
                {
                    Total = Total + Convert.ToDecimal(FilaTemp["importe"]);
                }
            }

            SubTotal = Total / (1 + Convert.ToDecimal(txtImpuesto.Text));
            txtTotal.Text = Total.ToString("#0.00#");
            txtSubTotal.Text = SubTotal.ToString("#0.00#");
            txtTotalImpuesto.Text = (Total - SubTotal).ToString("#0.00#");
        }

        private void BtnVerArticulo_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = true;
        }

        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }
        private void FormatoArticulo()
        {
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 100;
            DgvListado.Columns[2].HeaderText = "Categoria";
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[3].HeaderText = "Codigo";
            DgvListado.Columns[4].Width = 150;
            DgvListado.Columns[5].Width = 100;
            DgvListado.Columns[5].HeaderText = "Precio Venta";
            DgvListado.Columns[6].Width = 60;
            DgvListado.Columns[7].Width = 200;
            DgvListado.Columns[7].HeaderText = "Descripcion";
            DgvListado.Columns[8].Width = 100;

        }

        private void BtnFiltrarArticulos_Click(object sender, EventArgs e)
        {

            try
            {
                DgvArticulos.DataSource = NArticulo.BuscarVenta(txtBuscarArticulo.Text);
                this.FormatoArticulo();
                lblTotalArticulo.Text = "Total Registros: " + Convert.ToString(DgvArticulos.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo;
            string Codigo, Nombre;
            decimal Precio;
            int Stock;
            IdArticulo = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["ID"].Value);
            Nombre = Convert.ToString(DgvArticulos.CurrentRow.Cells["Nombre"].Value);
            Codigo = Convert.ToString(DgvArticulos.CurrentRow.Cells["Codigo"].Value);
            Stock = Convert.ToInt32(DgvArticulos.CurrentRow.Cells["Stock"].Value);
            Precio = Convert.ToDecimal(DgvArticulos.CurrentRow.Cells["Precio_Venta"].Value);
            this.AgreagarDetalle(IdArticulo, Codigo, Nombre, Stock, Precio);

        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            string Articulo = Convert.ToString(Fila["articulo"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            int Stock = Convert.ToInt32(Fila["stock"]);
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            decimal Descuento = Convert.ToDecimal(Fila["descuento"]);
            if (Cantidad > Stock)
            {
                Cantidad = Stock;
                this.MensajeError("La cantidad de venta del artículo " + Articulo + " supera el stock diponible " + Stock);
                Fila["cantidad"] = Cantidad;
            }
            Fila["importe"] = (Precio * Cantidad) - Descuento;
            this.CalcularTotales();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtIdCliente.Text == string.Empty || txtImpuesto.Text == string.Empty || txtNumeroComprobante.Text == string.Empty || DtDetalle.Rows.Count == 0)
                {
                    this.MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    Erroricono.SetError(txtIdCliente, "Seleccione un cliente.");
                    Erroricono.SetError(txtImpuesto, "Ingrese un impuesto.");
                    Erroricono.SetError(txtNumeroComprobante, "Ingrese el número del comprobante.");
                    Erroricono.SetError(DgvDetalle, "Debe tener al menos un detalle.");
                }
                else
                {
                    Rpta = NVenta.Insertar(Convert.ToInt32(txtIdCliente.Text), Varriables.IdUsuario, CboComprobante.Text, txtSerieComprobante.Text.Trim(), txtNumeroComprobante.Text.Trim(), Convert.ToDecimal(txtImpuesto.Text), Convert.ToDecimal(txtTotal.Text), DtDetalle);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se insertó de forma correcta el registro");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabcontrol1.SelectedIndex = 0;

        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DgvMostrarDetalle.DataSource = NVenta.ListarDetalle(Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value));
                decimal Total, SubTotal;
                //decimal Impuesto = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Impuesto"].Value);
                Total = Convert.ToDecimal(DgvListado.CurrentRow.Cells["Total"].Value);
                SubTotal = Total ;
                txtSubTotalD.Text = SubTotal.ToString("#0.00#");
                txtTotalImpuestoD.Text = (Total - SubTotal).ToString("#0.00#");
                txtTotalD.Text = Total.ToString("#0.00#");
                PanelMostrar.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PanelMostrar.Visible = false;
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                BtnAnular.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                BtnAnular.Visible = false;
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas anular el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NVenta.Anular(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se anuló el registro: " + Convert.ToString(row.Cells[6].Value) + "-" + Convert.ToString(row.Cells[7].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }



}

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Varriables.IdVenta = Convert.ToInt32(DgvListado.CurrentRow.Cells["ID"].Value);
                Reportes.FrmReporteCompribanteVenta reporte = new Reportes.FrmReporteCompribanteVenta();
                reporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void DgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TxtImpuesto_TextChanged(object sender, EventArgs e)
        {

        }
    } }
