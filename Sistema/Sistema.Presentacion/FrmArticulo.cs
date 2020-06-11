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
using System.IO;//para copiar archivos en el disco

namespace Sistema.Presentacion
{
    public partial class FrmArticulo : Form
    {
        private string RutaOrigen;// para cargar la ruta de la imagen
        private string RutaDestino;
        private string Directorio = "D:\\SistemaVentas\\";//Direccion de donde esta la carpeta
        private string NombreAnt;




        public FrmArticulo()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NArticulo.Listar();
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
                DgvListado.DataSource = NArticulo.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[2].Visible = false;
            DgvListado.Columns[0].Width = 100;
            DgvListado.Columns[1].Width = 50;
            DgvListado.Columns[3].Width = 100;
            DgvListado.Columns[3].HeaderText = "Categoria";
            DgvListado.Columns[4].Width = 100;
            DgvListado.Columns[4].HeaderText = "Codigo";
            DgvListado.Columns[5].Width = 150;
            DgvListado.Columns[6].Width = 100;
            DgvListado.Columns[6].HeaderText = "Precio Venta";
            DgvListado.Columns[7].Width = 60;
            DgvListado.Columns[8].Width = 200;
            DgvListado.Columns[8].HeaderText = "Descripcion";
            DgvListado.Columns[9].Width = 100;
            DgvListado.Columns[10].Width = 100;

        }

        private void Limpiar()
        {
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            txtCodigo.Clear();
            panelCodigo.BackgroundImage = null;
            btnGuardarCodigo.Enabled = true;
            txtPrecioVenta.Clear();
            txtStock.Clear();
            txtImagen.Clear();
            picImagen.Image = null;
            txtDescripcion.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            Erroricono.Clear();
            this.RutaDestino = "";
            this.RutaOrigen = "";



            DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            chkSeleccionar.Checked = false;
        }

        private void CargarCategoria()
        {
            try
            {
                cboCategoria.DataSource = NCategoria.Seleccionar();//fuente de datos es clase ncategoria
                cboCategoria.ValueMember = "idcategoria"; //El valor de los item se va a obtener de la columna codigo
                cboCategoria.DisplayMember = "nombre"; // El texto a mostrar de cada item se va a obtener ddel campo nombre
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
        }

        private void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas desactivar el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NArticulo.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se activó el registro: " + Convert.ToString(row.Cells[2].Value));
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();// instancia a la clase openfiledialog
            file.Filter = "Image files(*.jpg,*.jpeg,*.jpe,*.jfif,*.png)| *.jpg; *.jpeg; *.jpe;*.jfif;*.png";// Para que solo visualize imagenes 
            if (file.ShowDialog() == DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(file.FileName);// Para mostrar la imagen selecionada en el picturebox
                txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1);//Para obtener el nombre de la imagen con substring
                this.RutaOrigen = file.FileName;// para guardar el origen de las fotos

            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            panelCodigo.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, txtCodigo.Text, Color.Black, Color.White, 400, 100);
            btnGuardarCodigo.Enabled = true;

        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (cboCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecioVenta.Text == string.Empty || txtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresa algunos datos, seran remarcados.");
                    Erroricono.SetError(cboCategoria, "Seleccione una categoria.");
                    Erroricono.SetError(txtNombre, "Ingrese un nombre.");
                    Erroricono.SetError(txtPrecioVenta, "Ingrese un precio.");
                    Erroricono.SetError(txtStock, "Ingrese un stock inicial.");


                }
                else
                {
                    Rpta = NArticulo.Insertar(Convert.ToInt32(cboCategoria.SelectedValue), txtCodigo.Text.Trim(), txtNombre.Text.Trim(), Convert.ToDecimal(txtPrecioVenta.Text), Convert.ToInt32(txtStock.Text), txtDescripcion.Text.Trim(), txtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se inserto de forma correcta el registro");
                        if (txtImagen.Text != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }

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

        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
           

        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);//obteniendo el objeto de tipo celda
                cboCategoria.SelectedValue = Convert.ToString(DgvListado.CurrentRow.Cells["idcategoria"].Value);
                txtCodigo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                txtPrecioVenta.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Precio_Venta"].Value);
                txtStock.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Stock"].Value);
                txtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                string Imagen;
                Imagen = Convert.ToString(DgvListado.CurrentRow.Cells["Imagen"].Value);
                if (Imagen != string.Empty)
                {
                    picImagen.Image = Image.FromFile(this.Directorio + Imagen);// Para la ruta de donde esta la imagen
                    txtImagen.Text = Imagen;

                }
                else
                {
                    picImagen.Image = null;
                    txtImagen.Text = "";

                }
                tabControl1.SelectedIndex = 1;



            }
            catch (Exception ex)
            {

                MessageBox.Show("Seleccione desde la celda nombre." + "|  Error: " + ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtId.Text==string.Empty || cboCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecioVenta.Text == string.Empty || txtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresa algunos datos, seran remarcados.");
                    Erroricono.SetError(cboCategoria, "Seleccione una categoria.");
                    Erroricono.SetError(txtNombre, "Ingrese un nombre.");
                    Erroricono.SetError(txtPrecioVenta, "Ingrese un precio.");
                    Erroricono.SetError(txtStock, "Ingrese un stock inicial.");


                }
                else
                {
                    Rpta = NArticulo.Actualizar(Convert.ToInt32(txtId.Text),Convert.ToInt32(cboCategoria.SelectedValue), txtCodigo.Text.Trim(), this.NombreAnt, txtNombre.Text.Trim(), Convert.ToDecimal(txtPrecioVenta.Text), Convert.ToInt32(txtStock.Text), txtDescripcion.Text.Trim(), txtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se Actualizo de forma correcta el registro");
                        if (txtImagen.Text != string.Empty && this.RutaOrigen != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }

                        this.Listar();
                        tabControl1.SelectedIndex = 0;
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
            tabControl1.SelectedIndex = 0;
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);// instrucciones del datagridview para poder marcar y desmarcar
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSeleccionar.Checked)
            {
                DgvListado.Columns[0].Visible = true;// Para que la columna salga visible 
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas eliminar el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    string Imagen = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Imagen = Convert.ToString(row.Cells[9].Value);
                            Rpta = NArticulo.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se eliminó el registro: " + Convert.ToString(row.Cells[5].Value));
                                File.Delete(this.Directorio + Imagen);
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

        private void BtnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente deseas desactivar el(los) registro(s)?", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NArticulo.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se desactivó el registro: " + Convert.ToString(row.Cells[5].Value));
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

        private void Btnreporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteArticulos Reporte = new Reportes.FrmReporteArticulos();
            Reporte.ShowDialog();
        }
    }
}


