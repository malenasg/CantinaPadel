using System;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormNuevaMarca : Form
    {
        private MarcaNegocio marcaNegocio = new MarcaNegocio();

        public FormNuevaMarca()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca nuevaMarca = new Marca();
                nuevaMarca.Nombre = txtNombre.Text.Trim();

                marcaNegocio.Insertar(nuevaMarca);

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