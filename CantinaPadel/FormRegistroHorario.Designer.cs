namespace CantinaPadel
{
    partial class FormRegistroHorario
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
            lblInicio = new Label();
            btnGuardar = new Button();
            lblFin = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Time;
            dtpInicio.Location = new Point(12, 27);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.ShowUpDown = true;
            dtpInicio.Size = new Size(210, 23);
            dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Time;
            dtpFin.Location = new Point(12, 80);
            dtpFin.Name = "dtpFin";
            dtpFin.ShowUpDown = true;
            dtpFin.Size = new Size(210, 23);
            dtpFin.TabIndex = 1;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Location = new Point(12, 9);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(84, 15);
            lblInicio.TabIndex = 2;
            lblInicio.Text = "Hora de inicio:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 109);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(102, 23);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblFin
            // 
            lblFin.AutoSize = true;
            lblFin.Location = new Point(12, 62);
            lblFin.Name = "lblFin";
            lblFin.Size = new Size(69, 15);
            lblFin.TabIndex = 4;
            lblFin.Text = "Hora de fin:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(120, 109);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(102, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormRegistroHorario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 147);
            Controls.Add(btnCancelar);
            Controls.Add(lblFin);
            Controls.Add(btnGuardar);
            Controls.Add(lblInicio);
            Controls.Add(dtpFin);
            Controls.Add(dtpInicio);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormRegistroHorario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistroHorario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpInicio;
        private DateTimePicker dtpFin;
        private Label lblInicio;
        private Button btnGuardar;
        private Label lblFin;
        private Button btnCancelar;
    }
}