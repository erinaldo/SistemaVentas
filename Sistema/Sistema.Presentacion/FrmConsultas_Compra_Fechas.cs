﻿using System;
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
    public partial class FrmConsultas_Compra_Fechas : Form
    {
        public FrmConsultas_Compra_Fechas()
        {
            InitializeComponent();
        }
        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = NIngreso.ConsultaFechas(Convert.ToDateTime(DtpFechaInicio.Value), Convert.ToDateTime(DtpFechaFin.Value));
                this.Formato();
                this.Limpiar();
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




            DgvListado.Columns[0].Visible = false;// Para que la columna salga visible 

        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            PanelMostrar.Visible = false;

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmConsultas_Compra_Fechas_Load(object sender, EventArgs e)
        {

        }
    }
}
