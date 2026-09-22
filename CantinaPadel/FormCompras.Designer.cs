namespace CantinaPadel
{
    partial class FormCompras
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
            dgvCompras = new DataGridView();
            panelSuperior = new Panel();
            lblTitulo = new Label();
            txtBuscar = new TextBox();
            btnNuevo = new Button();
            btnAnular = new Button();
            panelBotones = new Panel();
            btnAumentar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            panelSuperior.SuspendLayout();
            panelBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = SystemColors.Control;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Location = new Point(9, 122);
            dgvCompras.Margin = new Padding(10, 5, 20, 20);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(775, 283);
            dgvCompras.TabIndex = 25;
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(lblTitulo);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(796, 81);
            panelSuperior.TabIndex = 24;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(3, 49);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(108, 32);
            lblTitulo.TabIndex = 28;
            lblTitulo.Text = "Compras";
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Location = new Point(10, 7);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(403, 23);
            txtBuscar.TabIndex = 24;
            // 
            // btnNuevo
            // 
            btnNuevo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevo.Location = new Point(532, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(80, 23);
            btnNuevo.TabIndex = 25;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAnular
            // 
            btnAnular.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnular.Location = new Point(618, 6);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(80, 23);
            btnAnular.TabIndex = 27;
            btnAnular.Text = "Anular";
            btnAnular.UseVisualStyleBackColor = true;
            btnAnular.Click += btnAnular_Click;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(btnAumentar);
            panelBotones.Controls.Add(txtBuscar);
            panelBotones.Controls.Add(btnAnular);
            panelBotones.Controls.Add(btnNuevo);
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Location = new Point(0, 81);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(796, 37);
            panelBotones.TabIndex = 23;
            // 
            // btnAumentar
            // 
            btnAumentar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAumentar.Location = new Point(704, 7);
            btnAumentar.Name = "btnAumentar";
            btnAumentar.Size = new Size(80, 23);
            btnAumentar.TabIndex = 28;
            btnAumentar.Text = "Aumentar precio";
            btnAumentar.UseVisualStyleBackColor = true;
            btnAumentar.Click += btnAumentar_Click;
            // 
            // FormCompras
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 411);
            Controls.Add(dgvCompras);
            Controls.Add(panelBotones);
            Controls.Add(panelSuperior);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCompras";
            Load += FormCompras_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelBotones.ResumeLayout(false);
            panelBotones.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPersonas;
        private Panel panelSuperior;
        private Label lblTitulo;
        private TextBox txtBuscar;
        private Button btnNuevo;
        private Button btnAnular;
        private Panel panelBotones;
        private DataGridView dgvCompras;
        private Button btnAumentar;
    }
}