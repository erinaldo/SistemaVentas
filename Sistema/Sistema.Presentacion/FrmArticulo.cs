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
using System.Drawing.Imaging;
using System.IO;
namespace Sistema.Presentacion
{
    public partial class FrmArticulo : Form
    {

        private string RutaORigen;// para cargar la ruta de la imagen
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



            DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
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

        private void CargarCategoria()
        {
            try
            {
                cboCategoria.DataSource = NCategoria.Seleccionar();
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files(*.jpg,*.jpeg,*.jpe,*.jfif,*.png)| *.jpg; *.jpeg; *.jpe;*.jfif;*.png";// Para que solo visualize imagenes 
            if (file.ShowDialog()==DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(file.FileName);// Para mostrar la imagen selecionada en el picturebox
                txtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\")+1);//Para obtener el nombre de la imagen con substring
                this.RutaORigen = file.FileName;// para guardar el origen de las fotos
            }
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            panelCodigo.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, txtCodigo.Text, Color.Black, Color.White, 400, 100);
            btnGuardarCodigo.Enabled = true;
        }

        private void TabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BtnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)panelCodigo.BackgroundImage.Clone();// cloanr lo del panel codigo para almacenarlo

            SaveFileDialog Dialoguardar = new SaveFileDialog();
            Dialoguardar.AddExtension = true;// para agregar  extencion 
            Dialoguardar.Filter = "Image PNG(*.PNG)|*.PNG";
            Dialoguardar.ShowDialog();

            if (!string.IsNullOrEmpty(Dialoguardar.FileName))
            {
                imgFinal.Save(Dialoguardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (cboCategoria.Text == string.Empty|| txtNombre.Text== string.Empty ||txtPrecioVenta.Text== string.Empty || txtStock.Text==string.Empty)
                {
                    this.MensajeError("Falta ingresa algunos datos, seran remarcados.");
                    Erroricono.SetError(cboCategoria, "Seleccione una categoria.");
                    Erroricono.SetError(txtNombre, "Ingrese un nombre.");
                    Erroricono.SetError(txtPrecioVenta, "Ingrese un precio.");
                    Erroricono.SetError(txtStock, "Ingrese un stock inicial.");
                        
                   
                }
                else
                {
                    Rpta = NArticulo.Insertar(Convert.ToInt32(cboCategoria.SelectedValue),txtCodigo.Text.Trim(),txtNombre.Text.Trim(),Convert.ToDecimal(txtPrecioVenta.Text),Convert.ToInt32(txtStock.Text),  txtDescripcion.Text.Trim(),txtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se inserto de forma correcta el registro");
                        if (txtImagen.Text != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + txtImagen.Text;
                            File.Copy(this.RutaORigen, this.RutaDestino);
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

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                txtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                cboCategoria.SelectedValue= Convert.ToString(DgvListado.CurrentRow.Cells["idcategoria"].Value);
                txtCodigo.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt= Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text= Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                txtPrecioVenta.Text= Convert.ToString(DgvListado.CurrentRow.Cells["Precio_Venta"].Value);
                txtStock.Text= Convert.ToString(DgvListado.CurrentRow.Cells["Stock"].Value);
                txtDescripcion.Text= Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
                string Imagen;
                Imagen = Convert.ToString(DgvListado.CurrentRow.Cells["Imagen"].Value);
                if (Imagen != string.Empty)
                {
                    picImagen.Image = Image.FromFile(this.Directorio + Imagen);
                    txtImagen.Text = Imagen;

                }else
                {
                    picImagen.Image = null;
                    txtImagen.Text = "";
                }

                



            }
            catch (Exception ex)
            {

                MessageBox.Show("Seleccione desde la celda nombre." + "|  Error: " + ex.Message);
            }
        }
    }
}
