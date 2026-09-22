using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormAumentos : Form
    {
        // Instancias de negocio (Borré Marca y Categoria porque usamos el atajo en Producto)
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private PersonaNegocio personaNegocio = new PersonaNegocio();

        public FormAumentos()
        {
            InitializeComponent();
        }

        // Al cargar la ventana, le ponemos las opciones fijas al primer combo
        private void FormAumentos_Load(object sender, EventArgs e)
        {
            cmbCriterio.Items.Add("Proveedor");
            cmbCriterio.Items.Add("Marca");
            cmbCriterio.Items.Add("Categoría");
            cmbCriterio.DropDownStyle = ComboBoxStyle.DropDownList; // Para que no escriban texto libre
            cmbElemento.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Cuando eligen "Marca", "Categoría" o "Proveedor" en el primer combo
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedItem == null) return;

            string criterio = cmbCriterio.SelectedItem.ToString();

            // EL TRUCO PRO: Cambiamos el texto del label para que no diga siempre "Producto:"
            lblElemento.Text = "Seleccione " + criterio + ":";

            try
            {
                // Llenamos el segundo combo según lo que eligieron
                if (criterio == "Proveedor")
                {
                    cmbElemento.DataSource = personaNegocio.ObtenerProveedores();
                    cmbElemento.DisplayMember = "razon_social";
                    cmbElemento.ValueMember = "id_proveedor";
                }
                else if (criterio == "Marca")
                {
                    cmbElemento.DataSource = productoNegocio.ObtenerMarcas();
                    cmbElemento.DisplayMember = "nombre";
                    cmbElemento.ValueMember = "id_marca";
                }
                else if (criterio == "Categoría")
                {
                    cmbElemento.DataSource = productoNegocio.ObtenerCategorias();
                    cmbElemento.DisplayMember = "nombre";
                    cmbElemento.ValueMember = "id_categoria";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista: " + ex.Message);
            }
        }

        // El botón Guardar (El que hace la magia en la base de datos)
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validamos que hayan elegido las opciones
            if (cmbCriterio.SelectedItem == null || cmbElemento.SelectedValue == null)
            {
                MessageBox.Show("Por favor seleccione un criterio y un elemento.");
                return;
            }

            DialogResult respuesta = MessageBox.Show($"¿Está seguro de aplicar un aumento del {nudPorcentaje.Value}%?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    // Capturamos los datos del formulario
                    string criterio = cmbCriterio.SelectedItem.ToString();
                    int idElemento = Convert.ToInt32(cmbElemento.SelectedValue);
                    decimal porcentaje = Convert.ToDecimal(nudPorcentaje.Value);

                    // 1. Traducimos la palabra visual a la columna real de tu base de datos
                    string columnaFiltro = "";
                    if (criterio == "Marca") columnaFiltro = "id_marca";
                    else if (criterio == "Categoría") columnaFiltro = "id_categoria";
                    else if (criterio == "Proveedor") columnaFiltro = "id_proveedor";

                    // 2. Llamamos a TU método respetando el orden exacto que armaste en ProductoNegocio
                    productoNegocio.AumentarPreciosMasivo(porcentaje, columnaFiltro, idElemento);

                    MessageBox.Show("¡Precios actualizados con éxito!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Si el porcentaje es 0, va a saltar la excepción que armaste en ProductoNegocio y se muestra acá
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // El botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Simplemente cierra la ventana sin hacer nada
        }

        private void cmbCriterio_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void cmbElemento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}