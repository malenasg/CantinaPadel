using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormHorarios : Form
    {
        private HorarioNegocio horarioNegocio = new HorarioNegocio();
        private int? idHorarioSeleccionado = null;

        public FormHorarios()
        {
            InitializeComponent();
        }

        private void FormHorarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                dgvHorarios.DataSource = horarioNegocio.ObtenerTodos();
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
                Horario horario = new Horario
                {
                    // Usamos .TimeOfDay para extraer solo la hora del DateTimePicker
                    HoraInicio = dtpInicio.Value.TimeOfDay,
                    HoraFin = dtpFin.Value.TimeOfDay
                };

                horarioNegocio.Insertar(horario);
                MessageBox.Show("Horario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarControles();
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
                if (idHorarioSeleccionado == null)
                {
                    MessageBox.Show("Por favor, seleccione un horario de la lista para actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Horario horario = new Horario
                {
                    IdHorario = idHorarioSeleccionado.Value,
                    HoraInicio = dtpInicio.Value.TimeOfDay,
                    HoraFin = dtpFin.Value.TimeOfDay
                };

                horarioNegocio.Modificar(horario);
                MessageBox.Show("Horario actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarControles();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idHorarioSeleccionado == null)
                {
                    MessageBox.Show("Por favor, seleccione un horario de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar este horario definitivamente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    horarioNegocio.Eliminar(idHorarioSeleccionado.Value);
                    MessageBox.Show("Horario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarControles();
                    CargarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvHorarios.Rows[e.RowIndex];
                idHorarioSeleccionado = Convert.ToInt32(fila.Cells["id_horario"].Value);

                // MySQL devuelve un TimeSpan para campos tipo TIME. 
                // Le sumamos ese tiempo al día de hoy para que el DateTimePicker lo pueda leer.
                TimeSpan inicio = (TimeSpan)fila.Cells["hora_inicio"].Value;
                TimeSpan fin = (TimeSpan)fila.Cells["hora_fin"].Value;

                dtpInicio.Value = DateTime.Today.Add(inicio);
                dtpFin.Value = DateTime.Today.Add(fin);
            }
        }

        private void LimpiarControles()
        {
            idHorarioSeleccionado = null;
            // Reiniciamos los controles a valores por defecto (ej. 18:00 y 19:30)
            dtpInicio.Value = DateTime.Today.AddHours(18);
            dtpFin.Value = DateTime.Today.AddHours(19).AddMinutes(30);
        }

        private void dgvHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}