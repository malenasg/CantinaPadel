using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormNuevaReserva : Form
    {
        // Traemos las reglas de negocio de los Sprints anteriores
        private ReservaNegocio reservaNegocio = new ReservaNegocio();
        private CanchaNegocio canchaNegocio = new CanchaNegocio();
        private HorarioNegocio horarioNegocio = new HorarioNegocio();
        // Asumiendo que tenés una clase para los clientes del Sprint 3
        // private PersonaNegocio personaNegocio = new PersonaNegocio(); 

        public FormNuevaReserva(DateTime fechaSeleccionada)
        {
            InitializeComponent();
            // Recibimos la fecha que el administrador tocó en el calendario
            dtpReserva.Value = fechaSeleccionada;
        }

        private void FormNuevaReserva_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Cargar lista de Clientes (Sprint 3)
                // Instanciamos la clase de Negocio que maneja a las personas
                PersonaNegocio personaNegocio = new PersonaNegocio();
                cmbCliente.DataSource = personaNegocio.ObtenerTodas();
                // DisplayMember: Lo que lee el usuario en la pantallita
                cmbCliente.DisplayMember = "nombre";
                // ValueMember: El ID real que se guarda en la tabla Reserva de forma oculta
                cmbCliente.ValueMember = "id_persona";

                // 2. Cargar lista de Canchas (Sprint 4)
                CanchaNegocio canchaNegocio = new CanchaNegocio();
                cmbCancha.DataSource = canchaNegocio.ObtenerTodas();
                cmbCancha.DisplayMember = "nombre";
                cmbCancha.ValueMember = "id_cancha";

                // 3. Cargar lista de Horarios (Sprint 4)
                HorarioNegocio horarioNegocio = new HorarioNegocio();
                cmbHorario.DataSource = horarioNegocio.ObtenerTodos();
                cmbHorario.DisplayMember = "hora_inicio";
                cmbHorario.ValueMember = "id_horario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas desplegables: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este evento hace que el selector de semanas aparezca o desaparezca mágicamente
        private void chkTurnoFijo_CheckedChanged(object sender, EventArgs e)
        {
            nudSemanas.Visible = chckTurnoFijo.Checked;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Armamos la reserva con lo que elegiste en los controles
                Reserva nuevaReserva = new Reserva
                {
                    IdCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                    IdCancha = Convert.ToInt32(cmbCancha.SelectedValue),
                    IdHorario = Convert.ToInt32(cmbHorario.SelectedValue),
                    Fecha = dtpReserva.Value.Date,
                    Precio = Convert.ToDecimal(txtPrecio.Text),
                    TipoReserva = chckTurnoFijo.Checked ? "Fija" : "Diaria"
                };

                // 2. Aplicamos tu lógica de decisión
                if (chckTurnoFijo.Checked)
                {
                    int semanas = Convert.ToInt32(nudSemanas.Value);
                    if (semanas < 2) throw new Exception("Un turno fijo debe ser de al menos 2 semanas.");

                    reservaNegocio.RegistrarTurnoFijo(nuevaReserva, semanas);
                    MessageBox.Show("¡Turno fijo registrado por " + semanas + " semanas!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    reservaNegocio.RegistrarReserva(nuevaReserva);
                    MessageBox.Show("Reserva diaria guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cerramos la ventanita
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Si Malena detecta que la cancha está ocupada, el error salta acá
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
