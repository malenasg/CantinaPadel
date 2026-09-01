using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormRegistroProducto : Form
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        // Si tenés ProveedorNegocio, lo instanciás acá también.

        int idProducto = 0;

        public FormRegistroProducto()
        {
            InitializeComponent();
        }

        public FormRegistroProducto(int idProductoSeleccionado)
        {
            InitializeComponent();
            idProducto = idProductoSeleccionado;
        }

        private void FormRegistroProducto_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (idProducto > 0)
            {
                btnGuardar.Text = "Modificar";
                CargarDatosProducto();
            }
            else
            {
                btnGuardar.Text = "Guardar";
            }
        }

        private void CargarCombos()
        {
            try
            {
                cmbCategoria.DataSource = null;
                cmbCategoria.Items.Clear();

                cmbCategoria.DataSource = categoriaNegocio.ObtenerTodas();
                cmbCategoria.DisplayMember = "nombre";
                cmbCategoria.ValueMember = "id_categoria";
                cmbCategoria.SelectedIndex = -1;

                cmbMarca.DataSource = null;
                cmbMarca.Items.Clear();

                cmbMarca.DataSource = marcaNegocio.ObtenerTodas();
                cmbMarca.DisplayMember = "nombre";
                cmbMarca.ValueMember = "id_marca";
                cmbMarca.SelectedIndex = -1;

                // cmbProveedor.DataSource = proveedorNegocio.ObtenerTodosActivos();
                // cmbProveedor.DisplayMember = "razon_social";
                // cmbProveedor.ValueMember = "id_proveedor";
                // cmbProveedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message);
            }
        }

        private void CargarDatosProducto()
        {
            try
            {
                Producto producto = productoNegocio.ObtenerPorId(idProducto);

                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;

                txtPC.Text = producto.PrecioCompra.ToString();
                txtPV.Text = producto.PrecioVenta.ToString();
                txtStockActual.Text = producto.Stock.ToString();
                txtStockMinimo.Text = producto.StockMinimo.ToString();

                if (producto.IdCategoria.HasValue)
                    cmbCategoria.SelectedValue = producto.IdCategoria.Value;

                if (producto.IdMarca.HasValue)
                    cmbMarca.SelectedValue = producto.IdMarca.Value;

                // if (producto.IdProveedor.HasValue)
                //     cmbProveedor.SelectedValue = producto.IdProveedor.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();

                producto.IdProducto = idProducto;
                producto.Codigo = txtCodigo.Text.Trim();
                producto.Nombre = txtNombre.Text.Trim();
                producto.Descripcion = txtDescripcion.Text.Trim();

                producto.PrecioCompra = string.IsNullOrWhiteSpace(txtPC.Text) ? 0 : Convert.ToDecimal(txtPC.Text);
                producto.PrecioVenta = string.IsNullOrWhiteSpace(txtPV.Text) ? 0 : Convert.ToDecimal(txtPV.Text);
                producto.Stock = string.IsNullOrWhiteSpace(txtStockActual.Text) ? 0 : Convert.ToInt32(txtStockActual.Text);
                producto.StockMinimo = string.IsNullOrWhiteSpace(txtStockMinimo.Text) ? 0 : Convert.ToInt32(txtStockMinimo.Text);

                producto.IdCategoria = cmbCategoria.SelectedValue != null ? Convert.ToInt32(cmbCategoria.SelectedValue) : (int?)null;
                producto.IdMarca = cmbMarca.SelectedValue != null ? Convert.ToInt32(cmbMarca.SelectedValue) : (int?)null;
                // producto.IdProveedor = cmbProveedor.SelectedValue != null ? Convert.ToInt32(cmbProveedor.SelectedValue) : (int?)null;

                if (idProducto == 0)
                {
                    productoNegocio.Insertar(producto);
                    MessageBox.Show("Producto guardado correctamente.");
                }
                else
                {
                    productoNegocio.Modificar(producto);
                    MessageBox.Show("Producto modificado correctamente.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Solo permitir números en Precios (admite la coma decimal)
        private void ValidarIngresoDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            // Solo permite una coma
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        // Solo permitir números enteros en Stock
        private void ValidarIngresoEntero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            FormNuevaCategoria form = new FormNuevaCategoria();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarCombos();
            }
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            FormNuevaMarca form = new FormNuevaMarca();
            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarCombos();
            }
        }
    }
}