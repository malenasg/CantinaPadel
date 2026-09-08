using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormCanchas : Form
    {
        private CanchaNegocio canchaNegocio = new CanchaNegocio();
        private int? idCanchaSeleccionada = null; // Guarda el ID cuando tocamos la grilla

        public FormCanchas()
        {
            InitializeComponent();
        }

        private void FormCanchas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                // Asumiendo que tu DataGridView se llama dgvCanchas
                dgvCancha.DataSource = canchaNegocio.ObtenerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cancha cancha = new Cancha
                {
                    Nombre = txtCancha.Text.Trim() // Asumiendo que tu TextBox se llama txtNombreCancha
                };

                canchaNegocio.Insertar(cancha);
                MessageBox.Show("Cancha guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCancha.Clear();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idCanchaSeleccionada == null)
                {
                    MessageBox.Show("Por favor, seleccione una cancha de la lista para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cancha cancha = new Cancha
                {
                    IdCancha = idCanchaSeleccionada.Value,
                    Nombre = txtCancha.Text.Trim(),
                    Estado = "Activa"
                };

                canchaNegocio.Modificar(cancha);
                MessageBox.Show("Cancha actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCancha.Clear();
                idCanchaSeleccionada = null;
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Acordate de enlazar este evento desde el Rayito (Eventos) -> CellClick en tu DataGridView
        private void dgvCanchas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCancha.Rows[e.RowIndex];
                idCanchaSeleccionada = Convert.ToInt32(fila.Cells["id_cancha"].Value);
                txtCancha.Text = fila.Cells["nombre"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idCanchaSeleccionada == null)
                {
                    MessageBox.Show("Por favor, seleccione una cancha de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar (desactivar) esta cancha?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    canchaNegocio.Eliminar(idCanchaSeleccionada.Value);
                    MessageBox.Show("Cancha eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtCancha.Clear();
                    idCanchaSeleccionada = null;
                    CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}