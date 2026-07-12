using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormListadoPersonas : Form
    {

        PersonaNegocio personaNegocio = new PersonaNegocio();
        int idPersonaSeleccionada = 0;

        public FormListadoPersonas()
        {
            InitializeComponent();
        }

        private void FormListadoPersonas_Load(object sender, EventArgs e)
        {
            CargarPersonas();

            btnModificar.Enabled = false;
            btnBaja.Enabled = false;
        }

        private void CargarPersonas()
        {
            dgvPersonas.DataSource = personaNegocio.Actualizar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPersonas.DataSource = personaNegocio.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                txtBuscar.Clear();
                CargarPersonas();

                idPersonaSeleccionada = 0;
                btnModificar.Enabled = false;
                btnBaja.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el listado: " + ex.Message);
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            idPersonaSeleccionada = Convert.ToInt32(dgvPersonas.Rows[e.RowIndex].Cells["ID"].Value);

            btnModificar.Enabled = true;
            btnBaja.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormRegistroPersona form = new FormRegistroPersona();

            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarPersonas();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPersonaSeleccionada == 0)
                {
                    MessageBox.Show("Debe seleccionar una persona del listado.");
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro que desea dar de baja esta persona?",
                    "Confirmar baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    personaNegocio.DarBaja(idPersonaSeleccionada);

                    MessageBox.Show("Persona dada de baja correctamente.");

                    CargarPersonas();

                    idPersonaSeleccionada = 0;
                    btnModificar.Enabled = false;
                    btnBaja.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idPersonaSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una persona del listado.");
                return;
            }

            FormRegistroPersona form = new FormRegistroPersona(idPersonaSeleccionada);

            if (form.ShowDialog() == DialogResult.OK)
            {
                CargarPersonas();

                idPersonaSeleccionada = 0;
                btnModificar.Enabled = false;
                btnBaja.Enabled = false;
            }
        }
    }
}
