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

            // 1. Cargamos las opciones de Condición Fiscal
            cmbCondicionFiscal.Items.Clear();
            cmbCondicionFiscal.Items.Add("Responsable Inscripto");
            cmbCondicionFiscal.Items.Add("Monotributo");
            cmbCondicionFiscal.Items.Add("Exento");
            cmbCondicionFiscal.Items.Add("Consumidor Final");

            // 2. Ocultamos los paneles al arrancar (en vez de usar .Enabled)
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
                txtCuit.Text = fila["cuit"].ToString(); // CUIT queda en los datos generales
                txtTelefono.Text = fila["telefono"].ToString();
                txtEmail.Text = fila["email"].ToString();
                txtDireccion.Text = fila["direccion"].ToString();

                bool esCliente = Convert.ToInt32(fila["es_cliente"]) == 1;
                bool esEmpleado = Convert.ToInt32(fila["es_empleado"]) == 1;
                bool esProveedor = Convert.ToInt32(fila["es_proveedor"]) == 1;

                MarcarTipoPersona("Cliente", esCliente);
                MarcarTipoPersona("Empleado", esEmpleado);
                MarcarTipoPersona("Proveedor", esProveedor);

                // 3. Mostramos/Ocultamos según lo que viene de la base de datos
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
            try
            {
                Persona persona = new Persona();

                persona.IdPersona = idPersona;
                persona.Nombre = txtNombre.Text.Trim();
                persona.Apellido = txtApellido.Text.Trim();
                persona.Cuit = txtCuit.Text.Trim();
                persona.Telefono = txtTelefono.Text.Trim();
                persona.Email = txtEmail.Text.Trim();
                persona.Direccion = txtDireccion.Text.Trim();

                bool esCliente = clbTipoPersona.CheckedItems.Contains("Cliente");
                bool esEmpleado = clbTipoPersona.CheckedItems.Contains("Empleado");
                bool esProveedor = clbTipoPersona.CheckedItems.Contains("Proveedor");

                // 5. Asignamos los datos extra SOLO si los checkboxes están marcados
                if (esEmpleado)
                {
                    persona.FechaIngreso = dtpIngreso.Value.Date;
                }

                if (esProveedor)
                {
                    persona.RazonSocial = txtRazonSocial.Text.Trim();
                    persona.CondicionFiscal = cmbCondicionFiscal.Text.Trim();
                }

                if (idPersona == 0)
                {
                    // El método Insertar ahora solo recibe 4 parámetros
                    personaNegocio.Insertar(persona, esCliente, esEmpleado, esProveedor);
                    MessageBox.Show("Persona guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    personaNegocio.Modificar(persona, esCliente, esEmpleado, esProveedor);
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

        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void lblIngreso_Click(object sender, EventArgs e) { }
        private void txtRazonSocial_TextChanged(object sender, EventArgs e) { }
        private void panelEmpleado_Paint(object sender, PaintEventArgs e) { }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}