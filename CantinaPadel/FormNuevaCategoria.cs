using System;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormNuevaCategoria : Form
    {
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

        public FormNuevaCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevaCategoria = new Categoria();
                nuevaCategoria.Nombre = txtNombre.Text.Trim();

                categoriaNegocio.Insertar(nuevaCategoria);

                // Si todo sale bien, cerramos y avisamos al formulario principal que fue un éxito
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}