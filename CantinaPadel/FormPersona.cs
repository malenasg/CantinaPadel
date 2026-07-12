using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CantinaPadel.Datos;
using CantinaPadel.Negocio;
using CantinaPadel.Entidades;

namespace CantinaPadel
{
    public partial class FormPersona : Form
    {

        PersonaNegocio personaNegocio = new PersonaNegocio();

        int idPersonaSeleccionada = 0;

        public FormPersona()
        {
            InitializeComponent();
        }

        private void FormPersona_Load(object sender, EventArgs e)
        {
            clbTipoPersona.Items.Clear();

            clbTipoPersona.Items.Add("Cliente");
            clbTipoPersona.Items.Add("Empleado");
            clbTipoPersona.Items.Add("Proveedor");

            dtpIngreso.Enabled = false;
        }

        private void CargarPersonas()
        {
            dgvPersonas.DataSource = personaNegocio.Actualizar();
        }

        private void MarcarTipoPersona(string tipo, bool marcar)
        {
            for (int i = 0; i < clbTipoPersona.Items.Count; i++)
            {
                if (clbTipoPersona.Items[i].ToString() == tipo)
                {
                    clbTipoPersona.SetItemChecked(i, marcar);
                    break;
                }
            }
        }

        private void LimpiarFormulario()
        {
            idPersonaSeleccionada = 0;

            txtNombre.Clear();
            txtApellido.Clear();
            txtRazonSocial.Clear();
            txtCuit.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();

            for (int i = 0; i < clbTipoPersona.Items.Count; i++)
            {
                clbTipoPersona.SetItemChecked(i, false);
            }

            dtpIngreso.Value = DateTime.Now;
            dtpIngreso.Enabled = false;

            txtNombre.Focus();
        }
        private void clbTipoPersona_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
                dtpIngreso.Enabled = esEmpleado;
            }));
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPersonaSeleccionada != 0)
                {
                    MessageBox.Show("Ya hay una persona seleccionada. Para cambiar sus datos use el botón Modificar, o presione Nuevo para cargar otra persona.");
                    return;
                }

                Persona persona = new Persona();

                persona.Nombre = txtNombre.Text.Trim();
                persona.Apellido = txtApellido.Text.Trim();
                persona.RazonSocial = txtRazonSocial.Text.Trim();
                persona.Cuit = txtCuit.Text.Trim();
                persona.Telefono = txtTelefono.Text.Trim();
                persona.Email = txtEmail.Text.Trim();
                persona.Direccion = txtDireccion.Text.Trim();

                bool esCliente = clbTipoPersona.CheckedItems.Contains("Cliente");
                bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
                bool esProveedor = clbTipoPersona.CheckedItems.Contains("Proveedor");

                DateTime? fechaIngreso = null;

                if (esEmpleado)
                {
                    fechaIngreso = dtpIngreso.Value;
                }

                personaNegocio.Insertar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);

                MessageBox.Show("Persona guardada correctamente.");

                CargarPersonas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
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
                CargarPersonas();
                txtBuscar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el listado: " + ex.Message);
            }
        }

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    return;
                }

                idPersonaSeleccionada = Convert.ToInt32(dgvPersonas.Rows[e.RowIndex].Cells["ID"].Value);

                DataTable tabla = personaNegocio.ObtenerPorId(idPersonaSeleccionada);

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos de la persona seleccionada.");
                    return;
                }

                DataRow fila = tabla.Rows[0];

                txtNombre.Text = fila["nombre"].ToString();
                txtApellido.Text = fila["apellido"].ToString();
                txtRazonSocial.Text = fila["razon_social"].ToString();
                txtCuit.Text = fila["cuit"].ToString();
                txtTelefono.Text = fila["telefono"].ToString();
                txtEmail.Text = fila["email"].ToString();
                txtDireccion.Text = fila["direccion"].ToString();

                for (int i = 0; i < clbTipoPersona.Items.Count; i++)
                {
                    clbTipoPersona.SetItemChecked(i, false);
                }

                bool esCliente = Convert.ToInt32(fila["es_cliente"]) == 1;
                bool esEmpleado = Convert.ToInt32(fila["es_empleado"]) == 1;
                bool esProveedor = Convert.ToInt32(fila["es_proveedor"]) == 1;

                MarcarTipoPersona("Cliente", esCliente);
                MarcarTipoPersona("Empleado", esEmpleado);
                MarcarTipoPersona("Proveedor", esProveedor);

                if (esEmpleado)
                {
                    dtpIngreso.Enabled = true;

                    if (fila["fecha_ingreso"] != DBNull.Value)
                    {
                        dtpIngreso.Value = Convert.ToDateTime(fila["fecha_ingreso"]);
                    }
                }
                else
                {
                    dtpIngreso.Enabled = false;
                    dtpIngreso.Value = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPersonaSeleccionada == 0)
                {
                    MessageBox.Show("Debe seleccionar una persona del listado.");
                    return;
                }

                Persona persona = new Persona();

                persona.IdPersona = idPersonaSeleccionada;
                persona.Nombre = txtNombre.Text.Trim();
                persona.Apellido = txtApellido.Text.Trim();
                persona.RazonSocial = txtRazonSocial.Text.Trim();
                persona.Cuit = txtCuit.Text.Trim();
                persona.Telefono = txtTelefono.Text.Trim();
                persona.Email = txtEmail.Text.Trim();
                persona.Direccion = txtDireccion.Text.Trim();

                bool esCliente = clbTipoPersona.CheckedItems.Contains("Cliente");
                bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
                bool esProveedor = clbTipoPersona.CheckedItems.Contains("Proveedor");

                DateTime? fechaIngreso = null;

                if (esEmpleado)
                {
                    fechaIngreso = dtpIngreso.Value;
                }

                personaNegocio.Modificar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);

                MessageBox.Show("Persona modificada correctamente.");

                CargarPersonas();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    LimpiarFormulario();
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
    }
}