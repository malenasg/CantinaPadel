namespace CantinaPadel
{
    partial class FormCanchas
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
            dgvCancha = new DataGridView();
            txtCancha = new TextBox();
            btnGuardar = new Button();
            btnModificar = new Button();
            lblCancha = new Label();
            lblLista = new Label();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCancha).BeginInit();
            SuspendLayout();
            // 
            // dgvCancha
            // 
            dgvCancha.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCancha.Location = new Point(12, 147);
            dgvCancha.Name = "dgvCancha";
            dgvCancha.Size = new Size(383, 175);
            dgvCancha.TabIndex = 0;
            // 
            // txtCancha
            // 
            txtCancha.Location = new Point(12, 63);
            txtCancha.Name = "txtCancha";
            txtCancha.Size = new Size(383, 23);
            txtCancha.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 92);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(141, 92);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(125, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnActualizar_Click;
            // 
            // lblCancha
            // 
            lblCancha.AutoSize = true;
            lblCancha.Location = new Point(12, 37);
            lblCancha.Name = "lblCancha";
            lblCancha.Size = new Size(125, 15);
            lblCancha.TabIndex = 4;
            lblCancha.Text = "Agregar nueva cancha";
            // 
            // lblLista
            // 
            lblLista.AutoSize = true;
            lblLista.Location = new Point(12, 127);
            lblLista.Name = "lblLista";
            lblLista.Size = new Size(91, 15);
            lblLista.TabIndex = 5;
            lblLista.Text = "Canchas activas";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(270, 92);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(125, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // FormCanchas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 334);
            Controls.Add(btnEliminar);
            Controls.Add(lblLista);
            Controls.Add(lblCancha);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(txtCancha);
            Controls.Add(dgvCancha);
            Name = "FormCanchas";
            Text = "Gestión de canchas";
            ((System.ComponentModel.ISupportInitialize)dgvCancha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCancha;
        private TextBox txtCancha;
        private Button btnGuardar;
        private Button btnModificar;
        private Label lblCancha;
        private Label lblLista;
        private Button btnEliminar;
    }
}