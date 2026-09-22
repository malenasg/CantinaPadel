using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CantinaPadel.Negocio; // Importamos tu capa de negocio

namespace CantinaPadel
{
    public partial class FormDetalleCompra : Form
    {
        // 1. Instanciamos la capa de negocio
        private CompraNegocio compraNegocio = new CompraNegocio();

        // Variable para guardar el ID que nos mandan desde la otra pantalla
        private int idCompraSeleccionada;

        // 2. Modificamos el constructor para que obligatoriamente reciba un int (el ID)
        public FormDetalleCompra(int idRecibido)
        {
            InitializeComponent();
            this.idCompraSeleccionada = idRecibido; // Guardamos el ID que llegó
        }

        // 3. Al cargar la ventanita, vamos a la base de datos a buscar los renglones
        private void FormDetalleCompra_Load(object sender, EventArgs e)
        {
            try
            {
                // Cambiamos el texto del label si Naiara lo agregó
                // lblTitulo.Text = "Detalle de la Factura N° " + idCompraSeleccionada;

                // Llenamos la grilla con tu método del backend
                dgvDetalleCompra.DataSource = compraNegocio.ObtenerDetallesPorCompra(idCompraSeleccionada);

                // Formato visual opcional desde código (para que la plata se vea como plata)
                if (dgvDetalleCompra.Columns.Contains("precio_unitario"))
                    dgvDetalleCompra.Columns["precio_unitario"].DefaultCellStyle.Format = "C2"; // C2 = Formato Moneda

                if (dgvDetalleCompra.Columns.Contains("subtotal"))
                    dgvDetalleCompra.Columns["subtotal"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles: " + ex.Message);
            }
        }
    }
}