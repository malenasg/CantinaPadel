namespace CantinaPadel
{
    partial class FormAumentos
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
            lblTitulo = new Label();
            btnCancelar = new Button();
            lblCriterio = new Label();
            lblElemento = new Label();
            cmbCriterio = new ComboBox();
            cmbElemento = new ComboBox();
            lblPorcentaje = new Label();
            nudPorcentaje = new NumericUpDown();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(235, 21);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Aumentar precio de producto";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(102, 219);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblCriterio
            // 
            lblCriterio.AutoSize = true;
            lblCriterio.Location = new Point(12, 44);
            lblCriterio.Name = "lblCriterio";
            lblCriterio.Size = new Size(98, 15);
            lblCriterio.TabIndex = 2;
            lblCriterio.Text = "Aumentar según:";
            // 
            // lblElemento
            // 
            lblElemento.AutoSize = true;
            lblElemento.Location = new Point(12, 101);
            lblElemento.Name = "lblElemento";
            lblElemento.Size = new Size(60, 15);
            lblElemento.TabIndex = 3;
            lblElemento.Text = "Elemento:";
            // 
            // cmbCriterio
            // 
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Categoria", "Marca", "Proveedor" });
            cmbCriterio.Location = new Point(12, 65);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(246, 23);
            cmbCriterio.TabIndex = 4;
            // 
            // cmbElemento
            // 
            cmbElemento.FormattingEnabled = true;
            cmbElemento.Location = new Point(12, 119);
            cmbElemento.Name = "cmbElemento";
            cmbElemento.Size = new Size(246, 23);
            cmbElemento.TabIndex = 5;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(12, 159);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(133, 15);
            lblPorcentaje.TabIndex = 6;
            lblPorcentaje.Text = "Porcentaje de aumento:";
            // 
            // nudPorcentaje
            // 
            nudPorcentaje.DecimalPlaces = 2;
            nudPorcentaje.Location = new Point(12, 177);
            nudPorcentaje.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPorcentaje.Name = "nudPorcentaje";
            nudPorcentaje.Size = new Size(246, 23);
            nudPorcentaje.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(183, 219);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FormAumentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(268, 254);
            Controls.Add(btnGuardar);
            Controls.Add(nudPorcentaje);
            Controls.Add(lblPorcentaje);
            Controls.Add(cmbElemento);
            Controls.Add(cmbCriterio);
            Controls.Add(lblElemento);
            Controls.Add(lblCriterio);
            Controls.Add(btnCancelar);
            Controls.Add(lblTitulo);
            Name = "FormAumentos";
            Text = "FormAumentos";
            ((System.ComponentModel.ISupportInitialize)nudPorcentaje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnCancelar;
        private Label lblCriterio;
        private Label lblElemento;
        private ComboBox cmbCriterio;
        private ComboBox cmbElemento;
        private Label lblPorcentaje;
        private NumericUpDown nudPorcentaje;
        private Button btnGuardar;
    }
}