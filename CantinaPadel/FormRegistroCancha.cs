using System;
using System.Windows.Forms;
using CantinaPadel.Negocio;
using CantinaPadel.Entidades;

namespace CantinaPadel
{
    public partial class FormRegistroCancha : Form
    {
        private CanchaNegocio canchaNegocio = new CanchaNegocio();
        private int idCanchaEditar = 0; // Si es 0, es nueva. Si es > 0, estamos editando.
        private string estadoActual = "";

        // Constructor 1: Se usa para crear una NUEVA cancha
        public FormRegistroCancha()
        {
            InitializeComponent();
            this.Text = "Nueva Cancha";
            btnBaja.Visible = false; // Ocultamos el botón porque la cancha es nueva
        }

        // Constructor 2: Se usa para EDITAR una cancha que ya existe
        public FormRegistroCancha(int idCancha, string nombre, string estado)
        {
            InitializeComponent();
            this.Text = "Modificar Cancha";

            // Guardamos los datos que nos pasaron de la grilla
            idCanchaEditar = idCancha;
            estadoActual = estado;

            // Llenamos el TextBox con el nombre actual
            txtCancha.Text = nombre;

            // Mostramos y configuramos el botón inteligente de Estado
            btnBaja.Visible = true;
            if (estadoActual == "Activa")
            {
                btnBaja.Text = "Dar de Baja";
                // Opcional: ponerle color bordó al botón
                // btnBaja.BackColor = System.Drawing.Color.Maroon;
                // btnBaja.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                btnBaja.Text = "Reactivar Cancha";
                // Opcional: ponerle color negro al botón
                // btnBaja.BackColor = System.Drawing.Color.Black;
                // btnBaja.ForeColor = System.Drawing.Color.White;
            }
        }

        // ACCIÓN: BOTÓN GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Pequeña validación visual
            if (string.IsNullOrWhiteSpace(txtCancha.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para la cancha.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cancha cancha = new Cancha();
                cancha.Nombre = txtCancha.Text;

                if (idCanchaEditar == 0)
                {
                    // Es una cancha nueva
                    canchaNegocio.Insertar(cancha);
                    MessageBox.Show("Cancha guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Es una modificación de una cancha existente
                    cancha.IdCancha = idCanchaEditar;
                    canchaNegocio.Modificar(cancha);
                    MessageBox.Show("Cancha modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close(); // Cerramos la ventanita
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ACCIÓN: BOTÓN DAR DE BAJA / REACTIVAR
        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            try
            {
                // Llamamos al método que armaste en la capa de Negocio
                canchaNegocio.CambiarEstado(idCanchaEditar, estadoActual);
                MessageBox.Show("Estado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ACCIÓN: BOTÓN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Solo cierra la ventana sin hacer nada
        }
    }
}