using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CantinaPadel
{
    public partial class FormReservas : Form
    {
        public FormReservas()
        {
            InitializeComponent();
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            FormCanchas test = new FormCanchas();
            test.Show();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            FormHorarios test = new FormHorarios();
            test.Show();
        }
    }
}
