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
            btnAlta = new Button();
            picCodigoBarra = new PictureBox();
            lblGanancia = new Label();
            txtPorcentaje = new TextBox();
            btnNuevaMarca = new Button();
            btnNuevaCategoria = new Button();
            lblStockMinimo = new Label();
            lblStockActual = new Label();
            label1 = new Label();
            lblPC = new Label();
            txtStockMinimo = new TextBox();
            cmbMarca = new ComboBox();
            cmbCategoria = new ComboBox();
            bntCancelar = new Button();
            btnGuardar = new Button();
            lblMarca = new Label();
            lblCategoria = new Label();
            lblCodigo = new Label();
            lblNombre = new Label();
            txtPV = new TextBox();
            txtStockActual = new TextBox();
            txtPC = new TextBox();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            categoriaBindingSource = new BindingSource(components);
            gbDatosGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCodigoBarra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gbDatosGenerales
            // 
            gbDatosGenerales.Controls.Add(btnAlta);
            gbDatosGenerales.Controls.Add(picCodigoBarra);
            gbDatosGenerales.Controls.Add(lblGanancia);
            gbDatosGenerales.Controls.Add(txtPorcentaje);
            gbDatosGenerales.Controls.Add(btnNuevaMarca);
            gbDatosGenerales.Controls.Add(btnNuevaCategoria);
            gbDatosGenerales.Controls.Add(lblStockMinimo);
            gbDatosGenerales.Controls.Add(lblStockActual);
            gbDatosGenerales.Controls.Add(label1);
            gbDatosGenerales.Controls.Add(lblPC);
            gbDatosGenerales.Controls.Add(txtStockMinimo);
            gbDatosGenerales.Controls.Add(cmbMarca);
            gbDatosGenerales.Controls.Add(cmbCategoria);
            gbDatosGenerales.Controls.Add(bntCancelar);
            gbDatosGenerales.Controls.Add(btnGuardar);
            gbDatosGenerales.Controls.Add(lblMarca);
            gbDatosGenerales.Controls.Add(lblCategoria);
            gbDatosGenerales.Controls.Add(lblCodigo);
            gbDatosGenerales.Controls.Add(lblNombre);
            gbDatosGenerales.Controls.Add(txtPV);
            gbDatosGenerales.Controls.Add(txtStockActual);
            gbDatosGenerales.Controls.Add(txtPC);
            gbDatosGenerales.Controls.Add(txtCodigo);
            gbDatosGenerales.Controls.Add(txtNombre);
            gbDatosGenerales.ForeColor = SystemColors.ControlText;
            gbDatosGenerales.Location = new Point(12, 14);
            gbDatosGenerales.Name = "gbDatosGenerales";
            gbDatosGenerales.Size = new Size(568, 225);
            gbDatosGenerales.TabIndex = 8;
            gbDatosGenerales.TabStop = false;
            gbDatosGenerales.Text = "Datos del producto";
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(6, 195);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(97, 23);
            btnAlta.TabIndex = 38;
            btnAlta.Text = "Dar de alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click;
            // 
            // picCodigoBarra
            // 
            picCodigoBarra.Location = new Point(333, 33);
            picCodigoBarra.Name = "picCodigoBarra";
            picCodigoBarra.Size = new Size(186, 42);
            picCodigoBarra.TabIndex = 37;
            picCodigoBarra.TabStop = false;
            // 
            // lblGanancia
            // 
            lblGanancia.AutoSize = true;
            lblGanancia.Location = new Point(382, 90);
            lblGanancia.Name = "lblGanancia";
            lblGanancia.Size = new Size(68, 15);
            lblGanancia.TabIndex = 36;
            lblGanancia.Text = "% ganancia";
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Location = new Point(382, 108);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.Size = new Size(84, 23);
            txtPorcentaje.TabIndex = 35;
            txtPorcentaje.TextChanged += txtPorcentaje_TextChanged;
            txtPorcentaje.KeyPress += ValidarIngresoDecimal;
            // 
            // btnNuevaMarca
            // 
            btnNuevaMarca.Location = new Point(258, 157);
            btnNuevaMarca.Name = "btnNuevaMarca";
            btnNuevaMarca.Size = new Size(23, 23);
            btnNuevaMarca.TabIndex = 34;
            btnNuevaMarca.Text = "+";
            btnNuevaMarca.UseVisualStyleBackColor = true;
            btnNuevaMarca.Click += btnNuevaMarca_Click;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.Location = new Point(258, 109);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(23, 23);
            btnNuevaCategoria.TabIndex = 33;
            btnNuevaCategoria.Text = "+";
            btnNuevaCategoria.UseVisualStyleBackColor = true;
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(427, 138);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 32;
            lblStockMinimo.Text = "Stock mínimo";
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(292, 138);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(71, 15);
            lblStockActual.TabIndex = 31;
            lblStockActual.Text = "Stock actual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(472, 90);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 30;
            label1.Text = "Precio venta";
            // 
            // lblPC
            // 
            lblPC.AutoSize = true;
            lblPC.Location = new Point(292, 90);
            lblPC.Name = "lblPC";
            lblPC.Size = new Size(84, 15);
            lblPC.TabIndex = 29;
            lblPC.Text = "Precio compra";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(427, 157);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(129, 23);
            txtStockMinimo.TabIndex = 28;
            txtStockMinimo.KeyPress += ValidarIngresoEntero;
            // 
            // cmbMarca
            // 
            cmbMarca.FormattingEnabled = true;
            cmbMarca.Location = new Point(86, 156);
            cmbMarca.Name = "cmbMarca";
            cmbMarca.Size = new Size(166, 23);
            cmbMarca.TabIndex = 25;
            cmbMarca.Text = "Seleccione...";
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(86, 109);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(166, 23);
            cmbCategoria.TabIndex = 24;
            // 
            // bntCancelar
            // 
            bntCancelar.Location = new Point(459, 195);
            bntCancelar.Name = "bntCancelar";
            bntCancelar.Size = new Size(97, 23);
            bntCancelar.TabIndex = 23;
            bntCancelar.Text = "Cancelar";
            bntCancelar.UseVisualStyleBackColor = true;
            bntCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(356, 195);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(97, 23);
            btnGuardar.TabIndex = 22;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(9, 161);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 15;
            lblMarca.Text = "Marca";
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(9, 112);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 14;
            lblCategoria.Text = "Categoria";
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(9, 60);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(97, 15);
            lblCodigo.TabIndex = 13;
            lblCodigo.Text = "Código de barras";
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
            txtPV.Location = new Point(472, 108);
            txtPV.Name = "txtPV";
            txtPV.ReadOnly = true;
            txtPV.Size = new Size(84, 23);
            txtPV.TabIndex = 7;
            txtPV.KeyPress += ValidarIngresoDecimal;
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(292, 156);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(129, 23);
            txtStockActual.TabIndex = 6;
            txtStockActual.KeyPress += ValidarIngresoEntero;
            // 
            // txtPC
            // 
            txtPC.Location = new Point(292, 108);
            txtPC.Name = "txtPC";
            txtPC.Size = new Size(84, 23);
            txtPC.TabIndex = 5;
            txtPC.KeyPress += ValidarIngresoDecimal;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(117, 57);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(164, 23);
            txtCodigo.TabIndex = 3;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(117, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(164, 23);
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
            ClientSize = new Size(592, 245);
            Controls.Add(gbDatosGenerales);
            Name = "FormRegistroProducto";
            Text = "FormRegistroProducto";
            Load += FormRegistroProducto_Load;
            gbDatosGenerales.ResumeLayout(false);
            gbDatosGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCodigoBarra).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoriaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbDatosGenerales;
        private Button bntCancelar;
        private Button btnGuardar;
        private Label lblMarca;
        private Label lblCategoria;
        private Label lblCodigo;
        private Label lblNombre;
        private TextBox txtPV;
        private TextBox txtStockActual;
        private TextBox txtPC;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private ComboBox cmbMarca;
        private ComboBox cmbCategoria;
        private TextBox txtStockMinimo;
        private Label lblStockMinimo;
        private Label lblStockActual;
        private Label label1;
        private Label lblPC;
        private BindingSource categoriaBindingSource;
        private Button btnNuevaMarca;
        private Button btnNuevaCategoria;
        private TextBox txtPorcentaje;
        private Label lblGanancia;
        private PictureBox picCodigoBarra;
        private Button btnAlta;
    }
}