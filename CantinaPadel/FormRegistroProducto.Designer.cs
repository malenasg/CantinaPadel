namespace CantinaPadel
{
    partial class FormRegistroProducto
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
            components = new System.ComponentModel.Container();
            gbDatosGenerales = new GroupBox();
            btnNuevaMarca = new Button();
            btnNuevaCategoria = new Button();
            lblStockMinimo = new Label();
            lblStockActual = new Label();
            label1 = new Label();
            lblPC = new Label();
            txtStockMinimo = new TextBox();
            cmbProveedor = new ComboBox();
            cmbMarca = new ComboBox();
            cmbCategoria = new ComboBox();
            bntCancelar = new Button();
            btnGuardar = new Button();
            lblProveedor = new Label();
            lblMarca = new Label();
            lblCategoria = new Label();
            lblCodigo = new Label();
            lblDescripcion = new Label();
            lblNombre = new Label();
            txtPV = new TextBox();
            txtStockActual = new TextBox();
            txtPC = new TextBox();
            txtCodigo = new TextBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            categoriaBindingSource = new BindingSource(components);
            gbDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gbDatosGenerales
            // 
            gbDatosGenerales.Controls.Add(btnNuevaMarca);
            gbDatosGenerales.Controls.Add(btnNuevaCategoria);
            gbDatosGenerales.Controls.Add(lblStockMinimo);
            gbDatosGenerales.Controls.Add(lblStockActual);
            gbDatosGenerales.Controls.Add(label1);
            gbDatosGenerales.Controls.Add(lblPC);
            gbDatosGenerales.Controls.Add(txtStockMinimo);
            gbDatosGenerales.Controls.Add(cmbProveedor);
            gbDatosGenerales.Controls.Add(cmbMarca);
            gbDatosGenerales.Controls.Add(cmbCategoria);
            gbDatosGenerales.Controls.Add(bntCancelar);
            gbDatosGenerales.Controls.Add(btnGuardar);
            gbDatosGenerales.Controls.Add(lblProveedor);
            gbDatosGenerales.Controls.Add(lblMarca);
            gbDatosGenerales.Controls.Add(lblCategoria);
            gbDatosGenerales.Controls.Add(lblCodigo);
            gbDatosGenerales.Controls.Add(lblDescripcion);
            gbDatosGenerales.Controls.Add(lblNombre);
            gbDatosGenerales.Controls.Add(txtPV);
            gbDatosGenerales.Controls.Add(txtStockActual);
            gbDatosGenerales.Controls.Add(txtPC);
            gbDatosGenerales.Controls.Add(txtCodigo);
            gbDatosGenerales.Controls.Add(txtDescripcion);
            gbDatosGenerales.Controls.Add(txtNombre);
            gbDatosGenerales.ForeColor = SystemColors.ControlText;
            gbDatosGenerales.Location = new Point(12, 14);
            gbDatosGenerales.Name = "gbDatosGenerales";
            gbDatosGenerales.Size = new Size(512, 336);
            gbDatosGenerales.TabIndex = 8;
            gbDatosGenerales.TabStop = false;
            gbDatosGenerales.Text = "Datos del producto";
            // 
            // btnNuevaMarca
            // 
            btnNuevaMarca.Location = new Point(457, 178);
            btnNuevaMarca.Name = "btnNuevaMarca";
            btnNuevaMarca.Size = new Size(43, 23);
            btnNuevaMarca.TabIndex = 34;
            btnNuevaMarca.Text = "+";
            btnNuevaMarca.UseVisualStyleBackColor = true;
            btnNuevaMarca.Click += btnNuevaMarca_Click;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.Location = new Point(457, 147);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(43, 23);
            btnNuevaCategoria.TabIndex = 33;
            btnNuevaCategoria.Text = "+";
            btnNuevaCategoria.UseVisualStyleBackColor = true;
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(270, 275);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 32;
            lblStockMinimo.Text = "Stock mínimo";
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(9, 275);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(71, 15);
            lblStockActual.TabIndex = 31;
            lblStockActual.Text = "Stock actual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 244);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 30;
            label1.Text = "Precio de venta $";
            // 
            // lblPC
            // 
            lblPC.AutoSize = true;
            lblPC.Location = new Point(9, 244);
            lblPC.Name = "lblPC";
            lblPC.Size = new Size(109, 15);
            lblPC.TabIndex = 29;
            lblPC.Text = "Precio de compra $";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(367, 272);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(133, 23);
            txtStockMinimo.TabIndex = 28;
            txtStockMinimo.KeyPress += ValidarIngresoEntero;
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(119, 208);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(332, 23);
            cmbProveedor.TabIndex = 26;
            cmbProveedor.Text = "Seleccione...";
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(119, 178);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(332, 23);
            cmbMarca.TabIndex = 25;
            cmbMarca.Text = "Seleccione...";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(119, 147);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(332, 23);
            cmbCategoria.TabIndex = 24;
            // 
            // bntCancelar
            // 
            bntCancelar.Location = new Point(367, 303);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(133, 23);
            bntCancelar.TabIndex = 23;
            bntCancelar.Text = "Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            bntCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(228, 303);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(133, 23);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(9, 211);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(61, 15);
            lblProveedor.TabIndex = 16;
            lblProveedor.Text = "Proveedor";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(9, 181);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 15;
            lblMarca.Text = "Marca";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(9, 150);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 14;
            lblCategoria.Text = "Categoria";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(9, 119);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(97, 15);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código de barras";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(9, 59);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 11;
            lblDescripcion.Text = "Descripción";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(9, 27);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Nombre";
            // 
            // txtPV
            // 
            txtPV.Location = new Point(367, 241);
            txtPV.Name = "txtPV";
            txtPV.Size = new Size(133, 23);
            txtPV.TabIndex = 7;
            txtPV.KeyPress += ValidarIngresoDecimal;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(119, 272);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(133, 23);
            txtStockActual.TabIndex = 6;
            txtStockActual.KeyPress += ValidarIngresoEntero;
            // 
            // txtPC
            // 
            txtPC.Location = new Point(119, 241);
            txtPC.Name = "txtPC";
            txtPC.Size = new Size(133, 23);
            txtPC.TabIndex = 5;
            txtPC.KeyPress += ValidarIngresoDecimal;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(119, 116);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(332, 23);
            txtCodigo.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(119, 56);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(332, 51);
            txtDescripcion.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(119, 24);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(332, 23);
            txtNombre.TabIndex = 0;
            // 
            // categoriaBindingSource
            // 
            categoriaBindingSource.DataSource = typeof(Entidades.Categoria);
            // 
            // FormRegistroProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 359);
            Controls.Add(gbDatosGenerales);
            Name = "FormRegistroProducto";
            Text = "FormRegistroProducto";
            Load += FormRegistroProducto_Load;
            gbDatosGenerales.ResumeLayout(false);
            gbDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDatosGenerales;
        private Button bntCancelar;
        private Button btnGuardar;
        private Label lblProveedor;
        private Label lblMarca;
        private Label lblCategoria;
        private Label lblCodigo;
        private Label lblDescripcion;
        private Label lblNombre;
        private TextBox txtPV;
        private TextBox txtStockActual;
        private TextBox txtPC;
        private TextBox txtCodigo;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private ComboBox cmbMarca;
        private ComboBox cmbCategoria;
        private ComboBox cmbProveedor;
        private TextBox txtStockMinimo;
        private Label lblStockMinimo;
        private Label lblStockActual;
        private Label label1;
        private Label lblPC;
        private BindingSource categoriaBindingSource;
        private Button btnNuevaMarca;
        private Button btnNuevaCategoria;
    }
}