namespace CantinaPadel
{
    partial class FormListadoProductos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelPrincipal = new Panel();
            dgvProductos = new DataGridView();
            panelBotones = new Panel();
            button2 = new Button();
            btnGuardar = new Button();
            button4 = new Button();
            btnModificar = new Button();
            btnBaja = new Button();
            btnNuevo = new Button();
            btnActualizar = new Button();
            txtBuscar = new TextBox();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            panelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelBotones.SuspendLayout();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // panelPrincipal
            // 
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.Controls.Add(dgvProductos);
            panelPrincipal.Controls.Add(panelBotones);
            panelPrincipal.Controls.Add(panelSuperior);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(812, 450);
            panelPrincipal.TabIndex = 30;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.Control;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(10, 119);
            dgvProductos.Margin = new Padding(10, 5, 20, 20);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(790, 331);
            dgvProductos.TabIndex = 22;
            dgvProductos.CellClick += dgvProductos_CellClick;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(button2);
            panelBotones.Controls.Add(btnGuardar);
            panelBotones.Controls.Add(button4);
            panelBotones.Controls.Add(btnModificar);
            panelBotones.Controls.Add(btnBaja);
            panelBotones.Controls.Add(btnNuevo);
            panelBotones.Controls.Add(btnActualizar);
            panelBotones.Controls.Add(txtBuscar);
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Location = new Point(0, 81);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(812, 37);
            panelBotones.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(634, 7);
            button2.Name = "button2";
            button2.Size = new Size(80, 23);
            button2.TabIndex = 32;
            button2.Text = "Dar de baja";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnBaja_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuardar.Location = new Point(548, 7);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(80, 23);
            btnGuardar.TabIndex = 30;
            btnGuardar.Text = "Nuevo";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnNuevo_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(720, 7);
            button4.Name = "button4";
            button4.Size = new Size(80, 23);
            button4.TabIndex = 29;
            button4.Text = "Actualizar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnActualizar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.Location = new Point(1424, 7);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(80, 23);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnBaja
            // 
            btnBaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBaja.Location = new Point(1510, 7);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(80, 23);
            btnBaja.TabIndex = 27;
            btnBaja.Text = "Dar de baja";
            btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.Location = new Point(1338, 7);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 23);
            btnNuevo.TabIndex = 25;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(1596, 7);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 23);
            btnActualizar.TabIndex = 23;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnBaja_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(10, 7);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(532, 23);
            txtBuscar.TabIndex = 24;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(812, 81);
            panelSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 49);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(120, 32);
            lblTitulo.TabIndex = 28;
            lblTitulo.Text = "Productos";
            // 
            // FormListadoProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 450);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListadoProductos";
            Text = "FormListadoProductos";
            Load += FormListadoProductos_Load;
            panelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelPrincipal;
        private DataGridView dgvProductos;
        private Panel panelBotones;
        private Button btnModificar;
        private Button btnBaja;
        private Button btnNuevo;
        private Button btnActualizar;
        private TextBox txtBuscar;
        private Panel panelSuperior;
        private Label lblTitulo;
        private Button button2;
        private Button btnGuardar;
        private Button button4;
    }
}