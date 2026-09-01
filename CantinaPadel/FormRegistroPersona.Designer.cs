namespace CantinaPadel
{
    partial class FormRegistroPersona
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
            gbDatos = new GroupBox();
            btnCancelar = new Button();
            gbTipo = new GroupBox();
            clbTipoPersona = new CheckedListBox();
            btnModificar = new Button();
            lblDireccion = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblCuit = new Label();
            lblApellido = new Label();
            lblNombre = new Label();
            txtDireccion = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtCuit = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            panelEmpleado = new Panel();
            lblIngreso = new Label();
            dtpIngreso = new DateTimePicker();
            panelProveedor = new Panel();
            lblCondicionFiscal = new Label();
            lblRazSoc = new Label();
            txtRazonSocial = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            cmbCondicionFiscal = new ComboBox();
            gbDatos.SuspendLayout();
            gbTipo.SuspendLayout();
            panelEmpleado.SuspendLayout();
            panelProveedor.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(btnCancelar);
            gbDatos.Controls.Add(gbTipo);
            gbDatos.Controls.Add(btnModificar);
            gbDatos.Controls.Add(lblDireccion);
            gbDatos.Controls.Add(lblEmail);
            gbDatos.Controls.Add(lblTelefono);
            gbDatos.Controls.Add(lblCuit);
            gbDatos.Controls.Add(lblApellido);
            gbDatos.Controls.Add(lblNombre);
            gbDatos.Controls.Add(txtDireccion);
            gbDatos.Controls.Add(txtEmail);
            gbDatos.Controls.Add(txtTelefono);
            gbDatos.Controls.Add(txtCuit);
            gbDatos.Controls.Add(txtApellido);
            gbDatos.Controls.Add(txtNombre);
            gbDatos.ForeColor = SystemColors.ControlText;
            gbDatos.Location = new Point(12, 12);
            gbDatos.Name = "gbDatos";
            gbDatos.Size = new Size(351, 424);
            gbDatos.TabIndex = 7;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos personales";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(178, 395);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(165, 23);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // gbTipo
            // 
            gbTipo.Controls.Add(clbTipoPersona);
            gbTipo.Location = new Point(9, 22);
            gbTipo.Name = "gbTipo";
            gbTipo.Size = new Size(334, 85);
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
            // btnModificar
            // 
            btnModificar.Location = new Point(7, 395);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(165, 23);
            btnModificar.TabIndex = 22;
            btnModificar.Text = "Guardar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(9, 269);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 16;
            lblDireccion.Text = "Dirección";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(7, 240);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(9, 211);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Télefono";
            // 
            // lblCuit
            // 
            lblCuit.AutoSize = true;
            lblCuit.Location = new Point(9, 182);
            lblCuit.Name = "lblCuit";
            lblCuit.Size = new Size(62, 15);
            lblCuit.TabIndex = 13;
            lblCuit.Text = "CUIT/CUIL";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(9, 149);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 11;
            lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(9, 120);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Nombre";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(119, 266);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(224, 23);
            txtDireccion.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(119, 237);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(224, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(119, 208);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(224, 23);
            txtTelefono.TabIndex = 5;
            // 
            // txtCuit
            // 
            txtCuit.Location = new Point(119, 179);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(224, 23);
            txtCuit.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(119, 146);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(224, 23);
            txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(119, 117);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 23);
            txtNombre.TabIndex = 0;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // panelEmpleado
            // 
            panelEmpleado.Controls.Add(lblIngreso);
            panelEmpleado.Controls.Add(dtpIngreso);
            panelEmpleado.Location = new Point(3, 64);
            panelEmpleado.Name = "panelEmpleado";
            panelEmpleado.Size = new Size(343, 34);
            panelEmpleado.TabIndex = 25;
            panelEmpleado.Paint += panelEmpleado_Paint;
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.Location = new Point(4, 9);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(96, 15);
            lblIngreso.TabIndex = 18;
            lblIngreso.Text = "Fecha de ingreso";
            lblIngreso.Click += lblIngreso_Click;
            // 
            // dtpIngreso
            // 
            dtpIngreso.CustomFormat = "DD/MM/AAAA";
            dtpIngreso.ImeMode = ImeMode.NoControl;
            dtpIngreso.Location = new Point(116, 3);
            dtpIngreso.Name = "dtpIngreso";
            dtpIngreso.Size = new Size(224, 23);
            dtpIngreso.TabIndex = 17;
            dtpIngreso.Value = new DateTime(2026, 7, 6, 11, 38, 39, 0);
            // 
            // panelProveedor
            // 
            panelProveedor.Controls.Add(cmbCondicionFiscal);
            panelProveedor.Controls.Add(lblCondicionFiscal);
            panelProveedor.Controls.Add(lblRazSoc);
            panelProveedor.Controls.Add(txtRazonSocial);
            panelProveedor.Location = new Point(3, 3);
            panelProveedor.Name = "panelProveedor";
            panelProveedor.Size = new Size(343, 55);
            panelProveedor.TabIndex = 24;
            // 
            // lblCondicionFiscal
            // 
            lblCondicionFiscal.AutoSize = true;
            lblCondicionFiscal.Location = new Point(4, 32);
            lblCondicionFiscal.Name = "lblCondicionFiscal";
            lblCondicionFiscal.Size = new Size(92, 15);
            lblCondicionFiscal.TabIndex = 14;
            lblCondicionFiscal.Text = "Condición fiscal";
            // 
            // lblRazSoc
            // 
            lblRazSoc.AutoSize = true;
            lblRazSoc.Location = new Point(6, 6);
            lblRazSoc.Name = "lblRazSoc";
            lblRazSoc.Size = new Size(72, 15);
            lblRazSoc.TabIndex = 12;
            lblRazSoc.Text = "Razón social";
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(116, 3);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(224, 23);
            txtRazonSocial.TabIndex = 2;
            txtRazonSocial.TextChanged += txtRazonSocial_TextChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panelProveedor);
            flowLayoutPanel1.Controls.Add(panelEmpleado);
            flowLayoutPanel1.Location = new Point(12, 301);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(351, 100);
            flowLayoutPanel1.TabIndex = 26;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // cmbCondicionFiscal
            // 
            cmbCondicionFiscal.FormattingEnabled = true;
            cmbCondicionFiscal.Location = new Point(116, 29);
            cmbCondicionFiscal.Name = "cmbCondicionFiscal";
            cmbCondicionFiscal.Size = new Size(224, 23);
            cmbCondicionFiscal.TabIndex = 16;
            // 
            // FormRegistroPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 448);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gbDatos);
            Name = "FormRegistroPersona";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistroPersona";
            Load += FormRegistroPersona_Load;
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            gbTipo.ResumeLayout(false);
            panelEmpleado.ResumeLayout(false);
            panelEmpleado.PerformLayout();
            panelProveedor.ResumeLayout(false);
            panelProveedor.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDatos;
        private Button btnCancelar;
        private Button btnModificar;
        private Label lblIngreso;
        private DateTimePicker dtpIngreso;
        private GroupBox gbTipo;
        private CheckedListBox clbTipoPersona;
        private Label lblDireccion;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblCuit;
        private Label lblRazSoc;
        private Label lblApellido;
        private Label lblNombre;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtCuit;
        private TextBox txtRazonSocial;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private Panel panelEmpleado;
        private Panel panelProveedor;
        private Label lblCondicionFiscal;
        private FlowLayoutPanel flowLayoutPanel1;
        private ComboBox cmbCondicionFiscal;
    }
}