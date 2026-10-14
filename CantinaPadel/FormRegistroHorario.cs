using System;
using System.Windows.Forms;
using CantinaPadel.Negocio;
using CantinaPadel.Entidades;

namespace CantinaPadel
{
    public partial class FormRegistroHorario : Form
    {
        private HorarioNegocio horarioNegocio = new HorarioNegocio();

        public FormRegistroHorario()
        {
            InitializeComponent();
            this.Text = "Nuevo Horario";

            // Configuramos los DateTimePicker para que por defecto muestren una hora redonda
            dtpInicio.Value = DateTime.Today.AddHours(16); // Arranca mostrando las 16:00
            dtpFin.Value = DateTime.Today.AddHours(17).AddMinutes(30); // Arranca mostrando 17:30
        }

        // ACCIÓN: BOTÓN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Extraemos solo la hora (TimeOfDay) de los DateTimePicker
                TimeSpan horaInicio = dtpInicio.Value.TimeOfDay;
                TimeSpan horaFin = dtpFin.Value.TimeOfDay;

                // Validación: La hora de fin tiene que ser MAYOR a la de inicio
                if (horaFin <= horaInicio)
                {
                    MessageBox.Show("La hora de fin debe ser posterior a la hora de inicio.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Armamos el objeto horario para mandarlo a la base de datos
                Horario nuevoHorario = new Horario();
                nuevoHorario.HoraInicio = horaInicio;
                nuevoHorario.HoraFin = horaFin;

                // Llamamos a tu capa de negocio
                horarioNegocio.Insertar(nuevoHorario);

                MessageBox.Show("Horario guardado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerramos la ventanita modal
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar el horario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ACCIÓN: BOTÓN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra sin guardar
        }
    }
}