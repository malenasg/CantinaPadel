namespace CantinaPadel
{
    partial class FormRegistroCancha
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
            btnCancelar = new Button();
            lblCancha = new Label();
            btnGuardar = new Button();
            txtCancha = new TextBox();
            btnBaja = new Button();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(143, 71);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(125, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblCancha
            // 
            lblCancha.AutoSize = true;
            lblCancha.Location = new Point(12, 16);
            lblCancha.Name = "lblCancha";
            lblCancha.Size = new Size(123, 15);
            lblCancha.TabIndex = 10;
            lblCancha.Text = "Nombre de la cancha:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 71);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(125, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtCancha
            // 
            txtCancha.Location = new Point(12, 42);
            txtCancha.Name = "txtCancha";
            txtCancha.Size = new Size(256, 23);
            txtCancha.TabIndex = 7;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(10, 100);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(125, 23);
            btnBaja.TabIndex = 12;
            btnBaja.Text = "Dar de baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Visible = false;
            // 
            // FormRegistroCancha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 131);
            Controls.Add(btnBaja);
            Controls.Add(btnCancelar);
            Controls.Add(lblCancha);
            Controls.Add(btnGuardar);
            Controls.Add(txtCancha);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormRegistroCancha";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRegistroCancha";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Label lblCancha;
        private Button btnGuardar;
        private TextBox txtCancha;
        private Button btnBaja;
    }
}