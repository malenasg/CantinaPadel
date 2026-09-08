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
            calFecha = new MonthCalendar();
            lblTitulo = new Label();
            panelSuperior = new Panel();
            dgvReservas = new DataGridView();
            panel1 = new Panel();
            btnCancelar = new Button();
            btnNuevo = new Button();
            panel2 = new Panel();
            btnHorarios = new Button();
            btnCanchas = new Button();
            panel3 = new Panel();
            panelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // calFecha
            // 
            calFecha.Location = new Point(21, 12);
            calFecha.Name = "calFecha";
            calFecha.TabIndex = 0;
            calFecha.DateChanged += calFecha_DateChanged;
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
            // dgvReservas
            // 
            dgvReservas.AllowUserToAddRows = false;
            dgvReservas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservas.Dock = DockStyle.Fill;
            dgvReservas.Location = new Point(0, 0);
            dgvReservas.Name = "dgvReservas";
            dgvReservas.ReadOnly = true;
            dgvReservas.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvReservas.Size = new Size(504, 263);
            dgvReservas.TabIndex = 2;
            dgvReservas.CellClick += dgvAgenda_CellClick;
            dgvReservas.CellContentClick += dgvReservas_CellContentClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelar);
            panel1.Controls.Add(btnNuevo);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 344);
            panel1.Name = "panel1";
            panel1.Size = new Size(796, 67);
            panel1.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(658, 35);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar reserva";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(658, 6);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nueva reserva";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevaReserva_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnHorarios);
            panel2.Controls.Add(btnCanchas);
            panel2.Controls.Add(calFecha);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(292, 263);
            panel2.TabIndex = 4;
            // 
            // btnHorarios
            // 
            btnHorarios.Location = new Point(29, 217);
            btnHorarios.Name = "btnHorarios";
            btnHorarios.Size = new Size(103, 23);
            btnHorarios.TabIndex = 2;
            btnHorarios.Text = "CRUD Horarios";
            btnHorarios.UseVisualStyleBackColor = true;
            btnHorarios.Click += btnHorarios_Click;
            // 
            // btnCanchas
            // 
            btnCanchas.Location = new Point(29, 184);
            btnCanchas.Name = "btnCanchas";
            btnCanchas.Size = new Size(103, 23);
            btnCanchas.TabIndex = 1;
            btnCanchas.Text = "CRUD Canchas";
            btnCanchas.UseVisualStyleBackColor = true;
            btnCanchas.Click += btnCanchas_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvReservas);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(292, 81);
            panel3.Name = "panel3";
            panel3.Size = new Size(504, 263);
            panel3.TabIndex = 5;
            // 
            // FormReservas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 411);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelSuperior);
            Name = "FormReservas";
            Text = "FormReservas";
            Load += FormReservas_Load;
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservas).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar calFecha;
        private Label lblTitulo;
        private Panel panelSuperior;
        private DataGridView dgvReservas;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button btnCancelar;
        private Button btnNuevo;
        private Button btnHorarios;
        private Button btnCanchas;
    }
}