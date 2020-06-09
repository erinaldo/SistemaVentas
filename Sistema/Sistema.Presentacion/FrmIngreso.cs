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
    public partial class FrmIngreso : Form
    {
        private DataTable DtDetalle = new DataTable();
        public FrmIngreso()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NIngreso.Listar();
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
                DgvListado.DataSource = NArticulo.Buscar(txtBuscarArticulo.Text.Trim());
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
           
            btnInsertar.Visible = true;
           
            Erroricono.Clear();



            DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 
            btnAnular.Visible = false;
            chkSeleccionar.Checked = false;
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
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));


            DgvDetalle.DataSource = this.DtDetalle;

            DgvDetalle.Columns[0].Visible = false;
            DgvDetalle.Columns[1].HeaderText = "CODIGO";
            DgvDetalle.Columns[1].Width = 100;
            DgvDetalle.Columns[2].HeaderText = "ARTICULO";
            DgvDetalle.Columns[2].Width = 200;
            DgvDetalle.Columns[3].HeaderText = "CANTIDAD";
            DgvDetalle.Columns[3].Width = 70;
            DgvDetalle.Columns[4].HeaderText = "PRECIO";
            DgvDetalle.Columns[4].Width = 70;
            DgvDetalle.Columns[5].HeaderText = "IMPORTE";
            DgvDetalle.Columns[5].Width = 80;

            DgvDetalle.Columns[1].ReadOnly = true;
            DgvDetalle.Columns[2].ReadOnly = true;
            DgvDetalle.Columns[5].ReadOnly = true;



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

            private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CrearTabla();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtIdProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FrmVenta_ProveedorIngreso vista = new FrmVenta_ProveedorIngreso();
            vista.ShowDialog();
            txtIdProveedor.Text =Convert.ToString( Varriables.IdProveedor);
            txtNombreProveedor.Text = Varriables.NombreProveedor;
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode==Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = NArticulo.BuscarCodigo(txtCodigo.Text.Trim());

                    if (Tabla.Rows.Count <= 0)
                    {
                        this.MensajeError("No existe articulo con ese codigo de barras.");
                    }
                    else
                    {
                        //agregar al detalle
                        this.AgreagarDetalle(Convert.ToInt32(Tabla.Rows[0][0]), Convert.ToString(Tabla.Rows[0][1]), Convert.ToString(Tabla.Rows[0][2]),Convert.ToDecimal(Tabla.Rows[0][3]));
                    }
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void AgreagarDetalle(int IdArticulo, string Codigo, string Nombre, decimal precio)
        {
            bool Agregar = true;
            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if (Convert.ToInt32(FilaTemp["idarticulo"])== IdArticulo)
                {
                    Agregar = false;
                    this.MensajeError("El articulo ya ha sido agregado.");
                }
            }
            if (Agregar==true)
            {
                DataRow Fila = DtDetalle.NewRow();
                Fila["idarticulo"] = IdArticulo;
                Fila["codigo"] = Codigo;
                Fila["articulo"] = Nombre;
                Fila["cantidad"] = 1;
                Fila["precio"] = precio;
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
        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }

        private void BtnVerArticulo_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = true;
        }

        private void BtnFiltrarArticulos_Click(object sender, EventArgs e)
        {

            try
            {
                DgvArticulos.DataSource = NArticulo.Buscar(txtBuscarArticulo.Text);
                this.FormatoArticulo();
                lblTotalArticulo.Text = "Total Registros: " + Convert.ToString(DgvArticulos.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];// objeto tipo fila
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            int Cantidad = Convert.ToInt32(Fila["cantidad"]);
            Fila["importe"] = Precio * Cantidad;
            this.CalcularTotales();
        }

        private void DgvDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
