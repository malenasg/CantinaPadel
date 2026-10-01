using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormAumentos : Form
    {
        private ProductoNegocio productoNegocio = new ProductoNegocio();
        private PersonaNegocio personaNegocio = new PersonaNegocio();

        public FormAumentos()
        {
            InitializeComponent();
        }

        private void FormAumentos_Load(object sender, EventArgs e)
        {
            // Configuramos los estilos primero
            cmbCriterio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbElemento.DropDownStyle = ComboBoxStyle.DropDownList;

            // Cargamos las opciones fijas del primer combo
            cmbCriterio.Items.Clear();
            cmbCriterio.Items.Add("Proveedor");
            cmbCriterio.Items.Add("Marca");
            cmbCriterio.Items.Add("Categoría");

            // Seleccionamos el primero por defecto para que dispare la carga del segundo combo
            if (cmbCriterio.Items.Count > 0)
            {
                cmbCriterio.SelectedIndex = 0;
            }
        }

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedItem == null) return;

            string criterio = cmbCriterio.SelectedItem.ToString();
            lblElemento.Text = "Seleccione " + criterio + ":";

            try
            {
                if (criterio == "Proveedor")
                {
                    cmbElemento.DataSource = null;
                    cmbElemento.DataSource = personaNegocio.ObtenerProveedores();
                    cmbElemento.DisplayMember = "razon_social";
                    cmbElemento.ValueMember = "id_proveedor";
                }
                else if (criterio == "Marca")
                {
                    cmbElemento.DataSource = null;
                    cmbElemento.DataSource = productoNegocio.ObtenerMarcas();
                    cmbElemento.DisplayMember = "nombre";
                    cmbElemento.ValueMember = "id_marca";
                }
                else if (criterio == "Categoría")
                {
                    cmbElemento.DataSource = null;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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
                    string criterio = cmbCriterio.SelectedItem.ToString();
                    int idElemento = Convert.ToInt32(cmbElemento.SelectedValue);
                    decimal porcentaje = Convert.ToDecimal(nudPorcentaje.Value);

                    string columnaFiltro = "";
                    if (criterio == "Marca") columnaFiltro = "id_marca";
                    else if (criterio == "Categoría") columnaFiltro = "id_categoria";
                    else if (criterio == "Proveedor") columnaFiltro = "id_proveedor";

                    productoNegocio.AumentarPreciosMasivo(porcentaje, columnaFiltro, idElemento);

                    MessageBox.Show("¡Precios actualizados con éxito!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}