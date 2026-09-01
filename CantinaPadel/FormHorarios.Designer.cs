namespace CantinaPadel
{
    partial class FormHorarios
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
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            dgvHorarios = new DataGridView();
            lblInicio = new Label();
            lblFin = new Label();
            lblHorarios = new Label();
            btnGuardar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHorarios).BeginInit();
            SuspendLayout();
            // 
            // dtpInicio
            // 
            dtpInicio.CustomFormat = "HH:mm";
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.Location = new Point(12, 46);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.ShowUpDown = true;
            dtpInicio.Size = new Size(182, 23);
            dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.CustomFormat = "HH:mm";
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.Location = new Point(213, 46);
            dtpFin.Name = "dtpFin";
            dtpFin.ShowUpDown = true;
            dtpFin.Size = new Size(182, 23);
            dtpFin.TabIndex = 1;
            // 
            // dgvHorarios
            // 
            dgvHorarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHorarios.Location = new Point(12, 147);
            dgvHorarios.Name = "dgvHorarios";
            dgvHorarios.Size = new Size(383, 175);
            dgvHorarios.TabIndex = 2;
            dgvHorarios.CellContentClick += dgvHorarios_CellClick;
            dgvHorarios.CellContentDoubleClick += dgvHorarios_CellContentClick;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Location = new Point(12, 28);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(81, 15);
            lblInicio.TabIndex = 3;
            lblInicio.Text = "Hora de inicio";
            // 
            // lblFin
            // 
            lblFin.AutoSize = true;
            lblFin.Location = new Point(213, 28);
            lblFin.Name = "lblFin";
            lblFin.Size = new Size(66, 15);
            lblFin.TabIndex = 4;
            lblFin.Text = "Hora de fin";
            // 
            // lblHorarios
            // 
            lblHorarios.AutoSize = true;
            lblHorarios.Location = new Point(12, 127);
            lblHorarios.Name = "lblHorarios";
            lblHorarios.Size = new Size(194, 15);
            lblHorarios.TabIndex = 5;
            lblHorarios.Text = "Horarios previamente configurados";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 75);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(141, 75);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(125, 23);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(270, 75);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FormHorarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 334);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(lblHorarios);
            Controls.Add(lblFin);
            Controls.Add(lblInicio);
            Controls.Add(dgvHorarios);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            Name = "FormHorarios";
            Text = "FormHorarios";
            Load += FormHorarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHorarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private DataGridView dgvHorarios;
        private Label lblInicio;
        private Label lblFin;
        private Label lblHorarios;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
    }
}