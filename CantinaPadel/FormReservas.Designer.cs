namespace CantinaPadel
{
    partial class FormReservas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelSuperior = new Panel();
            panelFiltros = new Panel();
            txtBuscarCliente = new TextBox();
            btnAgregar = new Button();
            btnCancelar = new Button();
            cmbCanchaFiltrar = new ComboBox();
            dtpFechaFiltro = new DateTimePicker();
            panel1 = new Panel();
            dgvReservas = new DataGridView();
            panelSuperior.SuspendLayout();
            panelFiltros.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(3, 49);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(105, 32);
            lblTitulo.TabIndex = 28;
            lblTitulo.Text = "Reservas";
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(796, 81);
            panelSuperior.TabIndex = 1;
            // 
            // panelFiltros
            // 
            panelFiltros.Controls.Add(txtBuscarCliente);
            panelFiltros.Controls.Add(btnAgregar);
            panelFiltros.Controls.Add(btnCancelar);
            panelFiltros.Controls.Add(cmbCanchaFiltrar);
            panelFiltros.Controls.Add(dtpFechaFiltro);
            panelFiltros.Dock = DockStyle.Top;
            panelFiltros.Location = new Point(0, 81);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(796, 39);
            panelFiltros.TabIndex = 5;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(12, 9);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(226, 23);
            txtBuscarCliente.TabIndex = 3;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(629, 8);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnNuevaReserva_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(710, 8);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // cmbCanchaFiltrar
            // 
            cmbCanchaFiltrar.FormattingEnabled = true;
            cmbCanchaFiltrar.Location = new Point(244, 10);
            cmbCanchaFiltrar.Name = "cmbCanchaFiltrar";
            cmbCanchaFiltrar.Size = new Size(121, 23);
            cmbCanchaFiltrar.TabIndex = 1;
            cmbCanchaFiltrar.SelectedIndexChanged += cmbCanchaFiltrar_SelectedIndexChanged;
            // 
            // dtpFechaFiltro
            // 
            dtpFechaFiltro.Format = DateTimePickerFormat.Short;
            dtpFechaFiltro.Location = new Point(371, 10);
            dtpFechaFiltro.Name = "dtpFechaFiltro";
            dtpFechaFiltro.Size = new Size(143, 23);
            dtpFechaFiltro.TabIndex = 0;
            dtpFechaFiltro.ValueChanged += dtpFechaFiltro_ValueChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvReservas);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 291);
            panel1.TabIndex = 6;
            // 
            // dgvReservas
            // 
            dgvReservas.Location = new Point(12, 6);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.Size = new Size(772, 273);
            dgvReservas.TabIndex = 0;
            dgvReservas.CellContentClick += dgvReservas_CellContentClick_1;
            // 
            // FormReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 411);
            Controls.Add(panel1);
            Controls.Add(panelFiltros);
            Controls.Add(panelSuperior);
            Name = "FormReservas";
            Text = "FormReservas";
            Load += FormReservas_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar calFecha;
        private Label lblTitulo;
        private Panel panelSuperior;
        private Panel panelFiltros;
        private TextBox txtBuscarCliente;
        private Button btnAgregar;
        private Button btnCancelar;
        private ComboBox cmbCanchaFiltrar;
        private DateTimePicker dtpFechaFiltro;
        private Panel panel1;
        private DataGridView dgvReservas;
        private Button btnNuevo;

    }
}
