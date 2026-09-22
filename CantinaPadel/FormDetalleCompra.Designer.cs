namespace CantinaPadel
{
    partial class FormDetalleCompra
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
            dgvDetalleCompra = new DataGridView();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).BeginInit();
            SuspendLayout();
            // 
            // dgvDetalleCompra
            // 
            dgvDetalleCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleCompra.Location = new Point(12, 51);
            dgvDetalleCompra.Name = "dgvDetalleCompra";
            dgvDetalleCompra.Size = new Size(541, 387);
            dgvDetalleCompra.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(12, 23);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(152, 21);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Detalle de la compra";
            // 
            // FormDetalleCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 450);
            Controls.Add(lblTitulo);
            Controls.Add(dgvDetalleCompra);
            Name = "FormDetalleCompra";
            Text = "FormDetalleCompra";
            ((System.ComponentModel.ISupportInitialize)dgvDetalleCompra).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDetalleCompra;
        private Label lblTitulo;
    }
}