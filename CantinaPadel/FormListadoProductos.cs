using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormListadoProductos : Form
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();
        int idProductoSeleccionado = 0;

        public FormListadoProductos()
        {
            InitializeComponent();
        }

        private void FormListadoProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

            // Deshabilitamos los botones hasta que el usuario haga clic en un producto
            btnModificar.Enabled = false;
        }

        private void CargarProductos()
        {
            try
            {
                dgvProductos.DataSource = productoNegocio.Actualizar();
                dgvProductos.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la grilla: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Búsqueda en tiempo real por código, nombre, categoría o marca
                dgvProductos.DataSource = productoNegocio.Buscar(txtBuscar.Text);

                // Reseteamos la selección
                idProductoSeleccionado = 0;
                btnModificar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Por si hace clic en los títulos de las columnas

            // Capturamos el ID de la columna oculta o visible (asegurate que la columna se llame "ID" en tu consulta SQL)
            idProductoSeleccionado = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells["ID"].Value);

            btnModificar.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistroProducto form = new FormRegistroProducto();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0) return;

            FormRegistroProducto form = new FormRegistroProducto(idProductoSeleccionado);
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarProductos();

                idProductoSeleccionado = 0;
                btnModificar.Enabled = false;
            }
        }


        private void btnAumentar_Click(object sender, EventArgs e)
        {
            FormAumentos ventanaAumentos = new FormAumentos();
            ventanaAumentos.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear(); // Esto va a disparar automáticamente el TextChanged y recargar la grilla
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}