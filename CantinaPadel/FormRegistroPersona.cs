using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
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

            cmbCondicionFiscal.Items.Clear();
            cmbCondicionFiscal.Items.Add("Consumidor Final");
            cmbCondicionFiscal.Items.Add("Exento");
            cmbCondicionFiscal.Items.Add("Monotributo");
            cmbCondicionFiscal.Items.Add("Responsable Inscripto");

            panelEmpleado.Visible = false;
            panelProveedor.Visible = false;

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
                mtbCuit.Text = fila["cuit"].ToString();
                mtbTelefono.Text = fila["telefono"].ToString();
                txtEmail.Text = fila["email"].ToString();
                txtDireccion.Text = fila["direccion"].ToString();

                // ---> LÓGICA DEL CHECKBOX "VOLVER A ACTIVAR" <---
                bool estaActivo = Convert.ToBoolean(fila["activo"]);
                if (estaActivo)
                {
                    chkActivar.Visible = false;
                }
                else
                {
                    chkActivar.Visible = true;
                    chkActivar.Checked = false;
                }
                // ------------------------------------------------

                bool esCliente = Convert.ToInt32(fila["es_cliente"]) == 1;
                bool esEmpleado = Convert.ToInt32(fila["es_empleado"]) == 1;
                bool esProveedor = Convert.ToInt32(fila["es_proveedor"]) == 1;

                MarcarTipoPersona("Cliente", esCliente);
                MarcarTipoPersona("Empleado", esEmpleado);
                MarcarTipoPersona("Proveedor", esProveedor);

                if (esEmpleado)
                {
                    panelEmpleado.Visible = true;
                    if (fila["fecha_ingreso"] != DBNull.Value)
                    {
                        dtpIngreso.Value = Convert.ToDateTime(fila["fecha_ingreso"]);
                    }
                }
                else
                {
                    panelEmpleado.Visible = false;
                    dtpIngreso.Value = DateTime.Now;
                }

                if (esProveedor)
                {
                    panelProveedor.Visible = true;
                    txtRazonSocial.Text = fila["razon_social"].ToString();
                    cmbCondicionFiscal.Text = fila["condicion_fiscal"].ToString();
                }
                else
                {
                    panelProveedor.Visible = false;
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
                bool esProveedor = clbTipoPersona.CheckedItems.Contains("Proveedor");

                // 4. Magia de los paneles: mostramos u ocultamos
                panelEmpleado.Visible = esEmpleado;
                panelProveedor.Visible = esProveedor;
            }));
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool esCliente = clbTipoPersona.CheckedItems.Contains("Cliente");
            bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
            bool esProveedor = clbTipoPersona.CheckedItems.Contains("Proveedor");

            if (!esCliente && !esEmpleado && !esProveedor)
            {
                MessageBox.Show("Debe tildar al menos un tipo de persona (Cliente, Empleado o Proveedor).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El Nombre no puede contener números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombre.Focus();
                return;
            }

            if (esCliente || esEmpleado)
            {
                if (string.IsNullOrWhiteSpace(txtApellido.Text))
                {
                    MessageBox.Show("El campo Apellido es obligatorio para clientes y empleados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }
                if (txtApellido.Text.Any(char.IsDigit))
                {
                    MessageBox.Show("El Apellido no puede contener números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtApellido.Focus();
                    return;
                }
            }

            if (esProveedor)
            {
                if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
                {
                    MessageBox.Show("La Razón Social es obligatoria para registrar un proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRazonSocial.Focus();
                    return;
                }
                if (cmbCondicionFiscal.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbCondicionFiscal.Text))
                {
                    MessageBox.Show("Debe seleccionar la Condición Fiscal del proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCondicionFiscal.Focus();
                    return;
                }
            }
            // --- FIN DE VALIDACIONES VISUALES ---

            try
            {
                Persona persona = new Persona();
                persona.IdPersona = idPersona;
                persona.Nombre = txtNombre.Text.Trim();
                persona.Apellido = txtApellido.Text.Trim();

                // CORRECCIÓN: Limpiamos las máscaras vacías
                string cuitLimpio = mtbCuit.Text.Replace("-", "").Replace(" ", "");
                persona.Cuit = string.IsNullOrEmpty(cuitLimpio) ? "" : mtbCuit.Text.Trim();
                string telLimpio = mtbTelefono.Text.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", "");
                persona.Telefono = string.IsNullOrEmpty(telLimpio) ? "" : mtbTelefono.Text.Trim();

                persona.Email = txtEmail.Text.Trim();
                persona.Direccion = txtDireccion.Text.Trim();

                if (esEmpleado) persona.FechaIngreso = dtpIngreso.Value.Date;

                if (esProveedor)
                {
                    persona.RazonSocial = txtRazonSocial.Text.Trim();
                    persona.CondicionFiscal = cmbCondicionFiscal.Text.Trim();
                }

                if (idPersona == 0)
                {
                    personaNegocio.Insertar(persona, esCliente, esEmpleado, esProveedor);
                    MessageBox.Show("Persona guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    personaNegocio.Modificar(persona, esCliente, esEmpleado, esProveedor);

                    // ---> LÓGICA DE REACTIVACIÓN <---
                    if (chkActivar.Visible && chkActivar.Checked)
                    {
                        personaNegocio.DarAlta(idPersona); // Llama al método que creaste en la Capa de Negocio
                    }

                    MessageBox.Show("Persona modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}