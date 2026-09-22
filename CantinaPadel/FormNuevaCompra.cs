using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// ¡Importante! Asegurate de tener los using de tus carpetas:
using CantinaPadel.Entidades;
using CantinaPadel.Negocio;

namespace CantinaPadel
{
    public partial class FormNuevaCompra : Form
    {
        // 1. INSTANCIAS DE NEGOCIO Y MEMORIA TEMPORAL
        private CompraNegocio compraNegocio = new CompraNegocio();

        // Acá instanciamos los de sprints anteriores para llenar los desplegables
        // (Si tus clases se llaman distinto, cambiales el nombre acá)
        private PersonaNegocio personaNegocio = new PersonaNegocio();
        private ProductoNegocio productoNegocio = new ProductoNegocio();

        // EL CARRITO: Una lista en memoria y un acumulador de plata
        private List<DetalleCompra> listaCarrito = new List<DetalleCompra>();
        private decimal totalFactura = 0;

        public FormNuevaCompra()
        {
            InitializeComponent();
        }

        // 2. AL ABRIR LA VENTANA: Llenamos los ComboBox
        private void FormNuevaCompra_Load(object sender, EventArgs e)
        {
            try
            {
                // Llenamos el combo de Proveedores (Asumo que tenés un método así en Sprint 2)
                cmbProveedor.DataSource = personaNegocio.ObtenerProveedores();
                cmbProveedor.DisplayMember = "razon_social"; // Lo que ve el usuario
                cmbProveedor.ValueMember = "id_proveedor"; // Lo que guardamos en la BD

                // Llenamos el combo de Productos (Sprint 3)
                cmbProducto.DataSource = productoNegocio.ObtenerProductos();
                cmbProducto.DisplayMember = "nombre";
                cmbProducto.ValueMember = "id_producto";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        // 3. BOTÓN AGREGAR: Mete el producto al carrito temporal
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validamos que hayan ingresado datos coherentes
            if (cmbProducto.SelectedValue == null || nudCantidad.Value <= 0 || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Por favor complete cantidad y precio correctamente.");
                return;
            }

            try
            {
                // Creamos un renglón nuevo (Detalle)
                DetalleCompra detalle = new DetalleCompra();
                detalle.IdProducto = Convert.ToInt32(cmbProducto.SelectedValue);

                // Guardamos el nombre solo para mostrarlo en la grilla visualmente
                // (Si tu clase DetalleCompra no tiene la propiedad NombreProducto, podés omitir esta línea)
                // detalle.NombreProducto = cmbProducto.Text;

                detalle.Cantidad = Convert.ToInt32(nudCantidad.Value);
                detalle.PrecioUnitario = Convert.ToDecimal(txtPrecio.Text);
                detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;

                // Lo metemos a la lista y sumamos la plata
                listaCarrito.Add(detalle);
                totalFactura += detalle.Subtotal;

                ActualizarCarrito();

                // Limpiamos los campitos para cargar el siguiente más rápido
                nudCantidad.Value = 0;
                txtPrecio.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el producto: Revise que el precio sea numérico. " + ex.Message);
            }
        }

        // 4. BOTÓN QUITAR: Por si se equivocaron y quieren borrar un renglón
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                // Agarramos el objeto de la fila seleccionada
                DetalleCompra detalleSeleccionado = (DetalleCompra)dgvCarrito.CurrentRow.DataBoundItem;

                // Restamos la plata de ese producto y lo borramos de la lista
                totalFactura -= detalleSeleccionado.Subtotal;
                listaCarrito.Remove(detalleSeleccionado);

                ActualizarCarrito();
            }
        }

        // Método auxiliar para refrescar la grilla y el label de plata
        private void ActualizarCarrito()
        {
            dgvCarrito.DataSource = null; // Desenlazamos
            dgvCarrito.DataSource = listaCarrito; // Volvemos a enlazar

            lblTotal.Text = "TOTAL: " + totalFactura.ToString("C2"); // Formato plata
        }

        // 5. BOTÓN GUARDAR COMPRA: El que dispara la transacción SQL final
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listaCarrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue productos antes de guardar.");
                return;
            }

            try
            {
                // Armamos el "Paquete" principal (La Cabecera)
                Compra nuevaCompra = new Compra();
                nuevaCompra.IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
                nuevaCompra.Fecha = dtpFecha.Value;
                nuevaCompra.Total = totalFactura;
                nuevaCompra.Estado = "ACTIVA";

                // Le metemos la lista entera de productos adentro
                nuevaCompra.Detalles = listaCarrito;

                // Llamamos a tu método de backend (¡El que tiene la Transacción!)
                compraNegocio.RegistrarCompra(nuevaCompra);

                MessageBox.Show("¡Compra guardada con éxito! El stock ha sido actualizado.");
                this.Close(); // Cerramos la ventana y volvemos al historial
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la factura en la base de datos: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}