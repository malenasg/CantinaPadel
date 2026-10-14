namespace CantinaPadel
{
    partial class FormListadoCanchas
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
            panelSuperior = new Panel();
            lblLinkCanchas = new LinkLabel();
            lblLinkHorarios = new LinkLabel();
            lblTituloHorarios = new Label();
            lblTituloCanchas = new Label();
            panelHorarios = new Panel();
            panelCanchas = new Panel();
            btnNuevaCancha = new Button();
            dgvCanchas = new DataGridView();
            dgvHorarios = new DataGridView();
            btnNuevoHorario = new Button();
            panelSuperior.SuspendLayout();
            panelHorarios.SuspendLayout();
            panelCanchas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHorarios).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(lblLinkHorarios);
            panelSuperior.Controls.Add(lblTituloCanchas);
            panelSuperior.Controls.Add(lblTituloHorarios);
            panelSuperior.Controls.Add(lblLinkCanchas);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(800, 81);
            panelSuperior.TabIndex = 24;
            // 
            // lblLinkCanchas
            // 
            lblLinkCanchas.ActiveLinkColor = Color.Gray;
            lblLinkCanchas.AutoSize = true;
            lblLinkCanchas.Cursor = Cursors.Hand;
            lblLinkCanchas.DisabledLinkColor = Color.Gray;
            lblLinkCanchas.LinkColor = Color.Gray;
            lblLinkCanchas.Location = new Point(101, 64);
            lblLinkCanchas.Name = "lblLinkCanchas";
            lblLinkCanchas.Size = new Size(52, 15);
            lblLinkCanchas.TabIndex = 31;
            lblLinkCanchas.TabStop = true;
            lblLinkCanchas.Text = "Canchas";
            lblLinkCanchas.VisitedLinkColor = Color.Gray;
            // 
            // lblLinkHorarios
            // 
            lblLinkHorarios.ActiveLinkColor = Color.Gray;
            lblLinkHorarios.AutoSize = true;
            lblLinkHorarios.Cursor = Cursors.Hand;
            lblLinkHorarios.DisabledLinkColor = Color.Gray;
            lblLinkHorarios.LinkColor = Color.Gray;
            lblLinkHorarios.Location = new Point(101, 64);
            lblLinkHorarios.Name = "lblLinkHorarios";
            lblLinkHorarios.Size = new Size(52, 15);
            lblLinkHorarios.TabIndex = 29;
            lblLinkHorarios.TabStop = true;
            lblLinkHorarios.Text = "Horarios";
            lblLinkHorarios.VisitedLinkColor = Color.Gray;
            // 
            // lblTituloHorarios
            // 
            lblTituloHorarios.AutoSize = true;
            lblTituloHorarios.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloHorarios.Location = new Point(3, 50);
            lblTituloHorarios.Name = "lblTituloHorarios";
            lblTituloHorarios.Size = new Size(103, 32);
            lblTituloHorarios.TabIndex = 30;
            lblTituloHorarios.Text = "Horarios";
            // 
            // lblTituloCanchas
            // 
            lblTituloCanchas.AutoSize = true;
            lblTituloCanchas.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTituloCanchas.Location = new Point(3, 49);
            lblTituloCanchas.Name = "lblTituloCanchas";
            lblTituloCanchas.Size = new Size(102, 32);
            lblTituloCanchas.TabIndex = 28;
            lblTituloCanchas.Text = "Canchas";
            // 
            // panelHorarios
            // 
            panelHorarios.BackColor = Color.Transparent;
            panelHorarios.Controls.Add(dgvHorarios);
            panelHorarios.Controls.Add(btnNuevoHorario);
            panelHorarios.Dock = DockStyle.Fill;
            panelHorarios.Location = new Point(0, 81);
            panelHorarios.Name = "panelHorarios";
            panelHorarios.Size = new Size(800, 369);
            panelHorarios.TabIndex = 26;
            // 
            // panelCanchas
            // 
            panelCanchas.BackColor = Color.Transparent;
            panelCanchas.Controls.Add(dgvCanchas);
            panelCanchas.Controls.Add(btnNuevaCancha);
            panelCanchas.Dock = DockStyle.Fill;
            panelCanchas.Location = new Point(0, 81);
            panelCanchas.Name = "panelCanchas";
            panelCanchas.Size = new Size(800, 369);
            panelCanchas.TabIndex = 25;
            panelCanchas.Visible = false;
            // 
            // btnNuevaCancha
            // 
            btnNuevaCancha.Location = new Point(687, 6);
            btnNuevaCancha.Name = "btnNuevaCancha";
            btnNuevaCancha.Size = new Size(101, 23);
            btnNuevaCancha.TabIndex = 1;
            btnNuevaCancha.Text = "Nueva cancha";
            btnNuevaCancha.UseVisualStyleBackColor = true;
            // 
            // dgvCanchas
            // 
            dgvCanchas.AllowUserToAddRows = false;
            dgvCanchas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanchas.BackgroundColor = Color.White;
            dgvCanchas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanchas.Location = new Point(12, 9);
            dgvCanchas.Name = "dgvCanchas";
            dgvCanchas.ReadOnly = true;
            dgvCanchas.RowHeadersVisible = false;
            dgvCanchas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanchas.Size = new Size(669, 351);
            dgvCanchas.TabIndex = 3;
            // 
            // dgvHorarios
            // 
            dgvHorarios.AllowUserToAddRows = false;
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHorarios.BackgroundColor = Color.White;
            dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorarios.Location = new Point(12, 10);
            dgvHorarios.Name = "dgvHorarios";
            dgvHorarios.ReadOnly = true;
            dgvHorarios.RowHeadersVisible = false;
            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHorarios.Size = new Size(669, 351);
            dgvHorarios.TabIndex = 5;
            // 
            // btnNuevoHorario
            // 
            btnNuevoHorario.Location = new Point(687, 7);
            btnNuevoHorario.Name = "btnNuevoHorario";
            btnNuevoHorario.Size = new Size(101, 23);
            btnNuevoHorario.TabIndex = 4;
            btnNuevoHorario.Text = "Nuevo horario";
            btnNuevoHorario.UseVisualStyleBackColor = true;
            // 
            // FormListadoCanchas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelCanchas);
            Controls.Add(panelHorarios);
            Controls.Add(panelSuperior);
            Name = "FormListadoCanchas";
            Text = "FormListadoCanchas";
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelHorarios.ResumeLayout(false);
            panelCanchas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCanchas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHorarios).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelSuperior;
        private LinkLabel lblLinkHorarios;
        private Label lblTituloCanchas;
        private Label lblTituloHorarios;
        private Panel panelHorarios;
        private LinkLabel lblLinkCanchas;
        private Panel panelCanchas;
        private Button btnNuevaCancha;
        private DataGridView dgvHorarios;
        private Button btnNuevoHorario;
        private DataGridView dgvCanchas;
    }
}