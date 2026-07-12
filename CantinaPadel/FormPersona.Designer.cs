namespace CantinaPadel
{
    partial class FormPersona
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvPersonas = new DataGridView();
            btnActualizar = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            qToolStripMenuItem = new ToolStripMenuItem();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtRazonSocial = new TextBox();
            txtCuit = new TextBox();
            gbDatos = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            btnBaja = new Button();
            btnModificar = new Button();
            btnNuevo = new Button();
            lblIngreso = new Label();
            dtpIngreso = new DateTimePicker();
            gbTipo = new GroupBox();
            clbTipoPersona = new CheckedListBox();
            lblDireccion = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblCuit = new Label();
            lblRazSoc = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            txtDireccion = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            gbListado = new GroupBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            contextMenuStrip1.SuspendLayout();
            gbDatos.SuspendLayout();
            gbTipo.SuspendLayout();
            gbListado.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPersonas
            // 
            dgvPersonas.AllowUserToOrderColumns = true;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(401, 37);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.Size = new Size(803, 359);
            dgvPersonas.TabIndex = 1;
            dgvPersonas.CellClick += dgvPersonas_CellClick;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(723, 392);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(94, 23);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { qToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(82, 26);
            // 
            // qToolStripMenuItem
            // 
            qToolStripMenuItem.Name = "qToolStripMenuItem";
            qToolStripMenuItem.Size = new Size(81, 22);
            qToolStripMenuItem.Text = "q";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(119, 26);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(119, 55);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(224, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(119, 84);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(224, 23);
            txtRazonSocial.TabIndex = 2;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(119, 113);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(224, 23);
            txtCuit.TabIndex = 3;
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(btnCancelar);
            gbDatos.Controls.Add(btnGuardar);
            gbDatos.Controls.Add(btnBaja);
            gbDatos.Controls.Add(btnModificar);
            gbDatos.Controls.Add(btnNuevo);
            gbDatos.Controls.Add(lblIngreso);
            gbDatos.Controls.Add(dtpIngreso);
            gbDatos.Controls.Add(gbTipo);
            gbDatos.Controls.Add(lblDireccion);
            gbDatos.Controls.Add(lblEmail);
            gbDatos.Controls.Add(lblTelefono);
            gbDatos.Controls.Add(lblCuit);
            gbDatos.Controls.Add(lblRazSoc);
            gbDatos.Controls.Add(lblApellido);
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Controls.Add(txtDireccion);
            gbDatos.Controls.Add(txtEmail);
            gbDatos.Controls.Add(txtTelefono);
            gbDatos.Controls.Add(txtCuit);
            gbDatos.Controls.Add(txtRazonSocial);
            gbDatos.Controls.Add(txtApellido);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.ForeColor = SystemColors.ControlText;
            gbDatos.Location = new Point(12, 12);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(359, 426);
            gbDatos.TabIndex = 6;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos personales";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(178, 390);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(165, 23);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(9, 390);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(165, 23);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(225, 361);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(118, 23);
            btnBaja.TabIndex = 21;
            btnBaja.Text = "Dar de baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(119, 361);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(100, 23);
            btnModificar.TabIndex = 20;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(9, 361);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(104, 23);
            btnNuevo.TabIndex = 19;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.Location = new Point(9, 235);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(96, 15);
            lblIngreso.TabIndex = 18;
            lblIngreso.Text = "Fecha de ingreso";
            // 
            // dtpIngreso
            // 
            dtpIngreso.CustomFormat = "DD/MM/AAAA";
            dtpIngreso.ImeMode = ImeMode.NoControl;
            dtpIngreso.Location = new Point(119, 229);
            dtpIngreso.Name = "dtpIngreso";
            dtpIngreso.Size = new Size(224, 23);
            dtpIngreso.TabIndex = 17;
            dtpIngreso.Value = new DateTime(2026, 7, 6, 11, 38, 39, 0);
            // 
            // gbTipo
            // 
            gbTipo.Controls.Add(clbTipoPersona);
            gbTipo.Location = new Point(9, 260);
            gbTipo.Name = "gbTipo";
            gbTipo.Size = new Size(334, 88);
            gbTipo.TabIndex = 8;
            gbTipo.TabStop = false;
            gbTipo.Text = "Tipo de persona";
            // 
            // clbTipoPersona
            // 
            clbTipoPersona.AllowDrop = true;
            clbTipoPersona.BackColor = SystemColors.Control;
            clbTipoPersona.BorderStyle = BorderStyle.None;
            clbTipoPersona.FormattingEnabled = true;
            clbTipoPersona.Items.AddRange(new object[] { "Cliente", "Empleado", "Proveedor" });
            clbTipoPersona.Location = new Point(11, 23);
            clbTipoPersona.Name = "clbTipoPersona";
            clbTipoPersona.Size = new Size(120, 54);
            clbTipoPersona.TabIndex = 0;
            clbTipoPersona.ItemCheck += clbTipoPersona_ItemCheck;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(9, 203);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 16;
            lblDireccion.Text = "Dirección";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(9, 174);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(9, 145);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Télefono";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(9, 116);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(62, 15);
            lblCuit.TabIndex = 13;
            lblCuit.Text = "CUIT/CUIL";
            // 
            // lblRazSoc
            // 
            lblRazSoc.AutoSize = true;
            lblRazSoc.Location = new Point(9, 87);
            lblRazSoc.Name = "lblRazSoc";
            lblRazSoc.Size = new Size(72, 15);
            lblRazSoc.TabIndex = 12;
            lblRazSoc.Text = "Razón social";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(9, 58);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 11;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(9, 29);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Nombre";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(119, 200);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(224, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(119, 171);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(224, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(119, 142);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(224, 23);
            txtTelefono.TabIndex = 5;
            // 
            // gbListado
            // 
            gbListado.Controls.Add(txtBuscar);
            gbListado.Controls.Add(btnBuscar);
            gbListado.Controls.Add(btnActualizar);
            gbListado.Location = new Point(387, 12);
            gbListado.Name = "gbListado";
            gbListado.RightToLeft = RightToLeft.No;
            gbListado.Size = new Size(829, 426);
            gbListado.TabIndex = 7;
            gbListado.TabStop = false;
            gbListado.Text = "Listado";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(14, 392);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(597, 23);
            txtBuscar.TabIndex = 8;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(617, 392);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 23);
            btnBuscar.TabIndex = 21;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // FormPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1228, 455);
            Controls.Add(gbDatos);
            Controls.Add(dgvPersonas);
            Controls.Add(gbListado);
            Name = "FormPersona";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulario de registro de personas";
            Load += FormPersona_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            gbTipo.ResumeLayout(false);
            gbListado.ResumeLayout(false);
            gbListado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvPersonas;
        private Button btnActualizar;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem qToolStripMenuItem;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtRazonSocial;
        private TextBox txtCuit;
        private GroupBox gbDatos;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private GroupBox gbListado;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblTelefono;
        private Label lblCuit;
        private Label lblRazSoc;
        private GroupBox gbTipo;
        private Label lblDireccion;
        private Label lblEmail;
        private CheckedListBox clbTipoPersona;
        private Label lblIngreso;
        private DateTimePicker dtpIngreso;
        private Button btnBaja;
        private Button btnModificar;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtBuscar;
        private Button btnBuscar;
    }
}
