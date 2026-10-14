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
                // Traemos TODAS las reservas usando el método de negocio
                todasLasReservas = reservaNegocio.ObtenerReservas();
                FiltrarPorFecha(dtpFechaFiltro.Value.Date); // Filtramos por la fecha seleccionada en el calendario)
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


        private void btnNuevaReserva_Click(object sender, EventArgs e)
        {
            // Abrimos la ventanita pasándole el día seleccionado
            FormNuevaReserva formNueva = new FormNuevaReserva(dtpFechaFiltro.Value.Date);

            // Si el usuario guardó todo bien en la ventanita, recargamos la grilla para que aparezca
            if (formNueva.ShowDialog() == DialogResult.OK)
            {
                CargarGrilla();
            }
        }

        // Seleccionamos la reserva al hacer clic en cualquier parte de la fila
        private void dgvReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReservas.Rows[e.RowIndex];

                // Nos aseguramos de que la celda no esté vacía antes de convertirla
                if (fila.Cells["id_reserva"].Value != DBNull.Value)
                {
                    idReservaSeleccionada = Convert.ToInt32(fila.Cells["id_reserva"].Value);
                }
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

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lo dejamos vacío, ya estamos usando CellClick que es más cómodo para seleccionar filas enteras
        }

        // ¡EL EVENTO CORRECTO! txtBuscarCliente_KeyDown
        private void txtBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            // Verificamos si la tecla que apretó fue el Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Evitamos el sonido de "ding" molesto de Windows
                e.SuppressKeyPress = true;

                if (!string.IsNullOrWhiteSpace(txtBuscarCliente.Text))
                {
                    try
                    {
                        DataTable dtHistorial = reservaNegocio.BuscarPorCliente(txtBuscarCliente.Text);
                        dgvReservas.DataSource = dtHistorial;

                        if (dgvReservas.Columns.Contains("id_reserva"))
                            dgvReservas.Columns["id_reserva"].Visible = false;

                        if (dtHistorial.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron reservas.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Si el texto está vacío y aprieta Enter, vuelve a mostrar las reservas del calendario
                    FiltrarPorFecha(calFecha.SelectionStart);
                }
            }
        }

        private void cmbCanchaFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFecha(dtpFechaFiltro.Value.Date);
            idReservaSeleccionada = null; 
            txtBuscarCliente.Clear(); 
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvReservas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}