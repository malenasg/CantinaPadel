namespace CantinaPadel
{
    partial class FormListadoPersonas
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
            dgvPersonas = new DataGridView();
            btnNuevo = new Button();
            btnActualizar = new Button();
            panelPrincipal = new Panel();
            panelBotones = new Panel();
            btnModificar = new Button();
            btnBaja = new Button();
            txtBuscar = new TextBox();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            panelPrincipal.SuspendLayout();
            panelBotones.SuspendLayout();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPersonas
            // 
            dgvPersonas.AllowUserToAddRows = false;
            dgvPersonas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvPersonas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPersonas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPersonas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonas.BackgroundColor = SystemColors.Control;
            dgvPersonas.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvPersonas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(10, 118);
            dgvPersonas.Margin = new Padding(10, 5, 20, 20);
            dgvPersonas.MultiSelect = false;
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.ReadOnly = true;
            dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonas.Size = new Size(792, 324);
            dgvPersonas.TabIndex = 22;
            dgvPersonas.CellClick += dgvPersonas_CellClick;
            dgvPersonas.CellContentClick += dgvPersonas_CellContentClick;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.Location = new Point(464, 7);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 23);
            btnNuevo.TabIndex = 25;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(722, 7);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 23);
            btnActualizar.TabIndex = 23;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // panelPrincipal
            // 
            panelPrincipal.AutoSize = true;
            panelPrincipal.BackColor = Color.White;
            panelPrincipal.Controls.Add(dgvPersonas);
            panelPrincipal.Controls.Add(panelBotones);
            panelPrincipal.Controls.Add(panelSuperior);
            panelPrincipal.Dock = DockStyle.Fill;
            panelPrincipal.Location = new Point(0, 0);
            panelPrincipal.Name = "panelPrincipal";
            panelPrincipal.Size = new Size(812, 450);
            panelPrincipal.TabIndex = 29;
            // 
            // panelBotones
            // 
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
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnModificar.Location = new Point(550, 7);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(80, 23);
            btnModificar.TabIndex = 26;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnBaja
            // 
            btnBaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBaja.Location = new Point(636, 7);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(80, 23);
            btnBaja.TabIndex = 27;
            btnBaja.Text = "Dar de baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(10, 7);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(448, 23);
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
            lblTitulo.Location = new Point(3, 49);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(107, 32);
            lblTitulo.TabIndex = 28;
            lblTitulo.Text = "Personas";
            // 
            // FormListadoPersonas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(812, 450);
            Controls.Add(panelPrincipal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormListadoPersonas";
            StartPosition = FormStartPosition.Manual;
            Text = "FormListadoPersonas";
            Load += FormListadoPersonas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            panelPrincipal.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPersonas;
        private Button btnNuevo;
        private Button btnActualizar;
        private Panel panelPrincipal;
        private Panel panelSuperior;
        private Panel panelBotones;
        private TextBox txtBuscar;
        private Label lblTitulo;
        private Button btnModificar;
        private Button btnBaja;
    }
}