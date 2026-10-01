using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;
using ZXing;

namespace CantinaPadel
{
    public partial class FormRegistroProducto : Form
    {
        ProductoNegocio productoNegocio = new ProductoNegocio();
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        MarcaNegocio marcaNegocio = new MarcaNegocio();
        PersonaNegocio personaNegocio = new PersonaNegocio();

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
                txtStockActual.ReadOnly = true;
                btnAlta.Visible = true;
                CargarDatosProducto();
            }
            else
            {
                btnGuardar.Text = "Guardar";
                txtStockActual.ReadOnly = false;
                btnAlta.Visible = false;
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
                txtPC.Text = producto.PrecioCompra.ToString();
                txtPorcentaje.Text = producto.PorcentajeGanancia.ToString();
                txtPV.Text = producto.PrecioVenta.ToString();
                txtStockActual.Text = producto.Stock.ToString();
                txtStockMinimo.Text = producto.StockMinimo.ToString();

                if (producto.IdCategoria.HasValue)
                    cmbCategoria.SelectedValue = producto.IdCategoria.Value;

                if (producto.IdMarca.HasValue)
                    cmbMarca.SelectedValue = producto.IdMarca.Value;

                if (producto.Activo)
                {
                    btnAlta.Text = "Dar de Baja";
                    btnAlta.BackColor = System.Drawing.Color.Maroon; // Bordó para baja
                    btnAlta.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    btnAlta.Text = "Dar de alta";
                    btnAlta.BackColor = System.Drawing.Color.Black; // Negro para alta
                    btnAlta.ForeColor = System.Drawing.Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES VISUALES ---
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return;
            }

            if (cmbMarca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarca.Focus();
                return;
            }

            try
            {
                Producto producto = new Producto();

                producto.IdProducto = idProducto;
                producto.Codigo = txtCodigo.Text.Trim();
                producto.Nombre = txtNombre.Text.Trim();

                producto.PrecioCompra = string.IsNullOrWhiteSpace(txtPC.Text) ? 0 : Convert.ToDecimal(txtPC.Text);
                producto.PorcentajeGanancia = string.IsNullOrWhiteSpace(txtPorcentaje.Text) ? 0 : Convert.ToDecimal(txtPorcentaje.Text);
                producto.PrecioVenta = string.IsNullOrWhiteSpace(txtPV.Text) ? 0 : Convert.ToDecimal(txtPV.Text);
                producto.Stock = string.IsNullOrWhiteSpace(txtStockActual.Text) ? 0 : Convert.ToInt32(txtStockActual.Text);
                producto.StockMinimo = string.IsNullOrWhiteSpace(txtStockMinimo.Text) ? 0 : Convert.ToInt32(txtStockMinimo.Text);

                producto.IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                producto.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);

                if (idProducto == 0)
                {
                    productoNegocio.Insertar(producto);
                    MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    productoNegocio.Modificar(producto);
                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalcularPrecioEnVivo()
        {
            try
            {
                decimal costo = string.IsNullOrWhiteSpace(txtPC.Text) ? 0 : Convert.ToDecimal(txtPC.Text);
                decimal porcentaje = string.IsNullOrWhiteSpace(txtPorcentaje.Text) ? 0 : Convert.ToDecimal(txtPorcentaje.Text);
                decimal ganancia = (costo * porcentaje) / 100;
                decimal precioVentaFinal = costo + ganancia;

                txtPV.Text = Math.Round(precioVentaFinal, 2).ToString();
            }
            catch { }
        }

        private void txtPC_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioEnVivo();
        }

        private void txtPorcentaje_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecioEnVivo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidarIngresoDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

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

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    var writer = new ZXing.Windows.Compatibility.BarcodeWriter()
                    {
                        Format = ZXing.BarcodeFormat.CODE_128
                    };

                    picCodigoBarra.Image = writer.Write(txtCodigo.Text);
                }
                else
                {
                    picCodigoBarra.Image = null;
                }
            }
            catch
            {
                picCodigoBarra.Image = null;
            }
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (idProducto > 0)
            {
                try
                {
                    // Leemos qué dice el botón para saber qué acción ejecutar
                    if (btnAlta.Text == "Dar de Baja")
                    {
                        DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea dar de baja este producto?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (respuesta == DialogResult.Yes)
                        {
                            productoNegocio.DarBaja(idProducto);
                            MessageBox.Show("Producto dado de baja correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK; // Le avisa a la grilla que se actualice
                            this.Close(); // Cierra el formulario
                        }
                    }
                    else
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea volver a dar de alta este producto?", "Confirmar Reactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            productoNegocio.DarAlta(idProducto);
                            MessageBox.Show("Producto dado de alta con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}