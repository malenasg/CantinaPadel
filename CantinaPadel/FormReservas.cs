using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormReservas : Form
    {
        private ReservaNegocio reservaNegocio = new ReservaNegocio();
        private DataTable todasLasReservas; // Guardamos todo en memoria para filtrar rápido
        private int? idReservaSeleccionada = null;

        public FormReservas()
        {
            InitializeComponent();
        }

        private void FormReservas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            try
            {
                // Traemos TODAS las reservas usando el método de Male
                todasLasReservas = reservaNegocio.ObtenerReservas();
                FiltrarPorFecha(calFecha.SelectionStart); // Filtramos por el día de hoy
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Magia visual: filtramos la grilla según el día que toques en el calendario
        private void FiltrarPorFecha(DateTime fecha)
        {
            if (todasLasReservas != null)
            {
                DataView vista = todasLasReservas.DefaultView;
                // Le decimos que solo muestre las reservas del día seleccionado
                vista.RowFilter = $"fecha = '{fecha.ToString("yyyy-MM-dd")}'";
                dgvReservas.DataSource = vista;
            }
        }

        // Cada vez que el usuario hace clic en otro día del almanaque
        private void calFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            FiltrarPorFecha(calFecha.SelectionStart);
            idReservaSeleccionada = null; // Limpiamos la selección
        }

        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            // Abrimos la ventanita que armamos en el Paso 1, pasándole el día seleccionado
            FormNuevaReserva formNueva = new FormNuevaReserva(calFecha.SelectionStart);

            // Si el usuario guardó todo bien en la ventanita, recargamos la grilla para que aparezca
            if (formNueva.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReservas.Rows[e.RowIndex];
                idReservaSeleccionada = Convert.ToInt32(fila.Cells["id_reserva"].Value);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idReservaSeleccionada == null)
            {
                MessageBox.Show("Seleccioná una reserva de la grilla para cancelarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Seguro que querés cancelar esta reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    reservaNegocio.CancelarReserva(idReservaSeleccionada.Value);
                    MessageBox.Show("Reserva cancelada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla(); // Recargamos para que el estado cambie a "Cancelada"
                    idReservaSeleccionada = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            FormCanchas pantallaCanchas = new FormCanchas();
            pantallaCanchas.ShowDialog();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            FormHorarios pantallaHorarios = new FormHorarios();
            pantallaHorarios.ShowDialog();
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}