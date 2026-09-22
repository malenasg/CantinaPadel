using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Acordate de importar tus capas
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormCompras : Form
    {
        // 1. Instanciamos tu capa de negocio
        private CompraNegocio compraNegocio = new CompraNegocio();

        public FormCompras()
        {
            InitializeComponent();
        }

        // 2. Al abrir el formulario, cargamos la grilla
        private void FormCompras_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        // 3. Método para llenar la grilla (lo separamos para poder llamarlo y refrescar la pantalla después de cargar o anular una compra)
        private void CargarGrilla()
        {
            try
            {
                dgvCompras.DataSource = compraNegocio.ObtenerCompras();

                // Opcional: Ocultar la columna del ID si no quieren que se vea
                dgvCompras.Columns["id_compra"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las compras: " + ex.Message);
            }
        }

        // 4. Botón: Nueva Compra
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormNuevaCompra ventanaNueva = new FormNuevaCompra();
            ventanaNueva.ShowDialog();
            // Cuando la ventana se cierra, refrescamos la grilla para ver la nueva compra
            CargarGrilla();
        }

        // 5. Botón: Aumentos Masivos
        private void btnAumentar_Click(object sender, EventArgs e)
        {
            FormAumentos ventanaAumentos = new FormAumentos();
            ventanaAumentos.ShowDialog();
        }

        // 6. Botón: Anular Compra seleccionada
        private void btnAnular_Click(object sender, EventArgs e)
        {
            // Verificamos que haya una fila seleccionada
            if (dgvCompras.SelectedRows.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de anular esta compra? Se restará el stock de los productos ingresados.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        // Agarramos el ID de la primera columna (columna 0) de la fila seleccionada
                        int idCompra = Convert.ToInt32(dgvCompras.SelectedRows[0].Cells[0].Value);

                        compraNegocio.AnularCompra(idCompra); // Tu método del backend
                        MessageBox.Show("Compra anulada y stock revertido correctamente.");

                        CargarGrilla(); // Refrescamos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione toda la fila de la compra que desea anular.");
            }
        }

        // 7. El Doble Clic en la grilla para abrir el ticket con los detalles
        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacen clic en los títulos de las columnas (índice -1), no hacemos nada
            if (e.RowIndex < 0) return;

            // Agarramos el ID de esa fila
            int idCompra = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells[0].Value);

            // Abrimos la ventana de detalle pasándole el ID
            FormDetalleCompra ventanaDetalle = new FormDetalleCompra(idCompra);
            ventanaDetalle.ShowDialog();
        }

        private void dgvCompras_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}