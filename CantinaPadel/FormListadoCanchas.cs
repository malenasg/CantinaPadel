using System;
using System.Data;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormListadoCanchas : Form
    {
        // Instanciamos las capas de negocio
        private CanchaNegocio canchaNegocio = new CanchaNegocio();
        private HorarioNegocio horarioNegocio = new HorarioNegocio();

        public FormListadoCanchas()
        {
            InitializeComponent();
        }

        // 1. EVENTO LOAD (Cuando se abre la pantalla por primera vez)
        private void FormListadoCanchas_Load(object sender, EventArgs e)
        {
            // Mostramos la vista de Canchas por defecto
            MostrarVistaCanchas();

            // Cargamos los datos de la base de datos a las grillas
            CargarGrillaCanchas();
            CargarGrillaHorarios();
        }

        // --- MÉTODOS DE NAVEGACIÓN (VISUAL) ---

        private void MostrarVistaCanchas()
        {
            // Títulos y links
            lblTituloCanchas.Visible = true;
            lblLinkHorarios.Visible = true;
            lblTituloHorarios.Visible = false;
            lblLinkCanchas.Visible = false;

            // Paneles
            panelCanchas.Visible = true;
            panelHorarios.Visible = false;
        }

        private void MostrarVistaHorarios()
        {
            // Títulos y links
            lblTituloHorarios.Visible = true;
            lblLinkCanchas.Visible = true;
            lblTituloCanchas.Visible = false;
            lblLinkHorarios.Visible = false;

            // Paneles
            panelHorarios.Visible = true;
            panelCanchas.Visible = false;
        }

        // Eventos Clic de los links (Asegurate de enlazar estos eventos en el diseñador)
        private void lblLinkHorarios_Click(object sender, EventArgs e)
        {
            MostrarVistaHorarios();
        }

        private void lblLinkCanchas_Click(object sender, EventArgs e)
        {
            MostrarVistaCanchas();
        }


        // --- MÉTODOS PARA CARGAR DATOS ---

        private void CargarGrillaCanchas()
        {
            try
            {
                dgvCanchas.DataSource = canchaNegocio.ObtenerTodas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar canchas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillaHorarios()
        {
            try
            {
                dgvHorarios.DataSource = horarioNegocio.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar horarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // --- ACCIONES DE BOTONES (CANCHAS) ---

        // Botón rojo "+ Nueva Cancha"
        private void btnNuevaCancha_Click(object sender, EventArgs e)
        {
            // Usamos el constructor vacío (es una cancha nueva)
            FormRegistroCancha formNueva = new FormRegistroCancha();
            formNueva.ShowDialog();

            // Cuando la ventanita modal se cierra, recargamos la grilla para ver la nueva cancha
            CargarGrillaCanchas();
        }

        // Clic en el botón "Editar" adentro de la grilla
        private void dgvCanchas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no hayan hecho clic en los títulos de las columnas (RowIndex >= 0)
            // y que la columna clickeada sea exactamente el botón "btnEditar"
            if (e.RowIndex >= 0 && dgvCanchas.Columns[e.ColumnIndex].Name == "btnEditar")
            {
                // Extraemos los datos de la fila seleccionada
                int idCancha = Convert.ToInt32(dgvCanchas.Rows[e.RowIndex].Cells["id_cancha"].Value);
                string nombre = dgvCanchas.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string estado = dgvCanchas.Rows[e.RowIndex].Cells["estado"].Value.ToString();

                // Usamos el constructor con parámetros (estamos editando)
                FormRegistroCancha formEditar = new FormRegistroCancha(idCancha, nombre, estado);
                formEditar.ShowDialog();

                // Recargamos la grilla al cerrar para reflejar si le cambiaron el nombre o la dieron de baja
                CargarGrillaCanchas();
            }
        }


        // --- ACCIONES DE BOTONES (HORARIOS) ---

        // Botón rojo "+ Nuevo Horario"
        private void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            // Acá llamaremos al FormRegistroHorario cuando lo creemos
            FormRegistroHorario formNuevoH = new FormRegistroHorario();
            formNuevoH.ShowDialog();
            CargarGrillaHorarios();
        }
    }
}