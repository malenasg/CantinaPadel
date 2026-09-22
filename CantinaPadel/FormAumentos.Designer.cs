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
            lblTitulo.Location = new Point(14, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Aumentar precio de producto";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(117, 292);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblCriterio
            // 
            lblCriterio.AutoSize = true;
            lblCriterio.Location = new Point(14, 59);
            lblCriterio.Name = "lblCriterio";
            lblCriterio.Size = new Size(120, 20);
            lblCriterio.TabIndex = 2;
            lblCriterio.Text = "Aumentar según:";
            // 
            // lblElemento
            // 
            lblElemento.AutoSize = true;
            lblElemento.Location = new Point(14, 135);
            lblElemento.Name = "lblElemento";
            lblElemento.Size = new Size(75, 20);
            lblElemento.TabIndex = 3;
            lblElemento.Text = "Elemento:";
            // 
            // cmbCriterio
            // 
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Categoria", "Marca", "Proveedor" });
            cmbCriterio.Location = new Point(14, 87);
            cmbCriterio.Margin = new Padding(3, 4, 3, 4);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(281, 28);
            cmbCriterio.TabIndex = 4;
            cmbCriterio.SelectedIndexChanged += cmbCriterio_SelectedIndexChanged;
            // 
            // cmbElemento
            // 
            cmbElemento.FormattingEnabled = true;
            cmbElemento.Location = new Point(14, 159);
            cmbElemento.Margin = new Padding(3, 4, 3, 4);
            cmbElemento.Name = "cmbElemento";
            cmbElemento.Size = new Size(281, 28);
            cmbElemento.TabIndex = 5;
            cmbElemento.SelectedIndexChanged += cmbElemento_SelectedIndexChanged;
            // 
            // lblPorcentaje
            // 
            lblPorcentaje.AutoSize = true;
            lblPorcentaje.Location = new Point(14, 212);
            lblPorcentaje.Name = "lblPorcentaje";
            lblPorcentaje.Size = new Size(165, 20);
            lblPorcentaje.TabIndex = 6;
            lblPorcentaje.Text = "Porcentaje de aumento:";
            // 
            // nudPorcentaje
            // 
            nudPorcentaje.DecimalPlaces = 2;
            nudPorcentaje.Location = new Point(14, 236);
            nudPorcentaje.Margin = new Padding(3, 4, 3, 4);
            nudPorcentaje.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPorcentaje.Name = "nudPorcentaje";
            nudPorcentaje.Size = new Size(281, 27);
            nudPorcentaje.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(209, 292);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormAumentos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 339);
            Controls.Add(btnGuardar);
            Controls.Add(nudPorcentaje);
            Controls.Add(lblPorcentaje);
            Controls.Add(cmbElemento);
            Controls.Add(cmbCriterio);
            Controls.Add(lblElemento);
            Controls.Add(lblCriterio);
            Controls.Add(btnCancelar);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAumentos";
            StartPosition = FormStartPosition.CenterScreen;
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