using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormRegistroPersona : Form
    {

        PersonaNegocio personaNegocio = new PersonaNegocio();

        int idPersona = 0;

        public FormRegistroPersona()
        {
            InitializeComponent();
        }

        public FormRegistroPersona(int idPersonaSeleccionada)
        {
            InitializeComponent();
            idPersona = idPersonaSeleccionada;
        }

        private void FormRegistroPersona_Load(object sender, EventArgs e)
        {
            clbTipoPersona.Items.Clear();

            clbTipoPersona.Items.Add("Cliente");
            clbTipoPersona.Items.Add("Empleado");
            clbTipoPersona.Items.Add("Proveedor");

            dtpIngreso.Enabled = false;

            if (idPersona > 0)
            {
                btnModificar.Text = "Modificar";
                CargarDatosPersona();
            }
            else
            {
                btnModificar.Text = "Guardar";
            }
        }

        private void CargarDatosPersona()
        {
            try
            {
                DataTable tabla = personaNegocio.ObtenerPorId(idPersona);

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

        private void clbTipoPersona_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
                dtpIngreso.Enabled = esEmpleado;
            }));
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Persona persona = new Persona();

                persona.IdPersona = idPersona;
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

                if (idPersona == 0)
                {
                    personaNegocio.Insertar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);
                    MessageBox.Show("Persona guardada correctamente.");
                }
                else
                {
                    personaNegocio.Modificar(persona, esCliente, esEmpleado, esProveedor, fechaIngreso);
                    MessageBox.Show("Persona modificada correctamente.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
