using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CantinaPadel
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormularioEnPanel(Form formulario)
        {
            panelContenedor.Controls.Clear();

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            FormListadoPersonas formListadoPersonas = new FormListadoPersonas();
            AbrirFormularioEnPanel(formListadoPersonas);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormListadoProductos formListadoProductos = new FormListadoProductos();
            AbrirFormularioEnPanel(formListadoProductos);
        }

        private void btnReservas_Click(object sender, EventArgs e)
        {
            FormReservas formReservas = new FormReservas();
            AbrirFormularioEnPanel(formReservas);
        }
    }
}
