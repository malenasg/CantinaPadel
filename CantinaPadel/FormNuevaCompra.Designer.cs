namespace CantinaPadel
{
    partial class FormNuevaCompra
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
            lblProveedor = new Label();
            cmbProveedor = new ComboBox();
            dtpFecha = new DateTimePicker();
            lblFecha = new Label();
            gbDatosCompra = new GroupBox();
            dbDatosProductos = new GroupBox();
            btnAgregar = new Button();
            txtPrecio = new TextBox();
            nudCantidad = new NumericUpDown();
            lblPrecio = new Label();
            lblProducto = new Label();
            cmbProducto = new ComboBox();
            lblCantidad = new Label();
            gbCarrito = new GroupBox();
            btnQuitar = new Button();
            lblTotal = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            dgvCarrito = new DataGridView();
            gbDatosCompra.SuspendLayout();
            dbDatosProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            gbCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(16, 27);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(80, 20);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(112, 23);
            cmbProveedor.Margin = new Padding(3, 4, 3, 4);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(374, 28);
            cmbProveedor.TabIndex = 1;
            cmbProveedor.SelectedIndexChanged += cmbProveedor_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(112, 61);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(374, 27);
            dtpFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(16, 69);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // gbDatosCompra
            // 
            gbDatosCompra.Controls.Add(lblFecha);
            gbDatosCompra.Controls.Add(cmbProveedor);
            gbDatosCompra.Controls.Add(dtpFecha);
            gbDatosCompra.Controls.Add(lblProveedor);
            gbDatosCompra.Location = new Point(29, 16);
            gbDatosCompra.Margin = new Padding(3, 4, 3, 4);
            gbDatosCompra.Name = "gbDatosCompra";
            gbDatosCompra.Padding = new Padding(3, 4, 3, 4);
            gbDatosCompra.Size = new Size(504, 104);
            gbDatosCompra.TabIndex = 5;
            gbDatosCompra.TabStop = false;
            gbDatosCompra.Text = "groupBox1";
            // 
            // dbDatosProductos
            // 
            dbDatosProductos.Controls.Add(btnAgregar);
            dbDatosProductos.Controls.Add(txtPrecio);
            dbDatosProductos.Controls.Add(nudCantidad);
            dbDatosProductos.Controls.Add(lblPrecio);
            dbDatosProductos.Controls.Add(lblProducto);
            dbDatosProductos.Controls.Add(cmbProducto);
            dbDatosProductos.Controls.Add(lblCantidad);
            dbDatosProductos.Location = new Point(29, 128);
            dbDatosProductos.Margin = new Padding(3, 4, 3, 4);
            dbDatosProductos.Name = "dbDatosProductos";
            dbDatosProductos.Padding = new Padding(3, 4, 3, 4);
            dbDatosProductos.Size = new Size(504, 140);
            dbDatosProductos.TabIndex = 6;
            dbDatosProductos.TabStop = false;
            dbDatosProductos.Text = "groupBox2";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(451, 97);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(35, 31);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "+";
            btnAgregar.TextAlign = ContentAlignment.TopCenter;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(112, 97);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(332, 27);
            txtPrecio.TabIndex = 5;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(112, 61);
            nudCantidad.Margin = new Padding(3, 4, 3, 4);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(375, 27);
            nudCantidad.TabIndex = 4;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(16, 101);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(65, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio: $";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(16, 27);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(72, 20);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(112, 23);
            cmbProducto.Margin = new Padding(3, 4, 3, 4);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(374, 28);
            cmbProducto.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(16, 64);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(69, 20);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad";
            // 
            // gbCarrito
            // 
            gbCarrito.Controls.Add(btnQuitar);
            gbCarrito.Controls.Add(lblTotal);
            gbCarrito.Controls.Add(btnGuardar);
            gbCarrito.Controls.Add(btnCancelar);
            gbCarrito.Controls.Add(dgvCarrito);
            gbCarrito.Location = new Point(29, 276);
            gbCarrito.Margin = new Padding(3, 4, 3, 4);
            gbCarrito.Name = "gbCarrito";
            gbCarrito.Padding = new Padding(3, 4, 3, 4);
            gbCarrito.Size = new Size(504, 308);
            gbCarrito.TabIndex = 7;
            gbCarrito.TabStop = false;
            gbCarrito.Text = "groupBox3";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(15, 228);
            btnQuitar.Margin = new Padding(3, 4, 3, 4);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(86, 31);
            btnQuitar.TabIndex = 4;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(317, 233);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(45, 20);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(409, 269);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(317, 269);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(15, 29);
            dgvCarrito.Margin = new Padding(3, 4, 3, 4);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(477, 191);
            dgvCarrito.TabIndex = 0;
            // 
            // FormNuevaCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 600);
            Controls.Add(gbCarrito);
            Controls.Add(dbDatosProductos);
            Controls.Add(gbDatosCompra);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormNuevaCompra";
            Text = "FormNuevaCompra";
            Load += FormNuevaCompra_Load;
            gbDatosCompra.ResumeLayout(false);
            gbDatosCompra.PerformLayout();
            dbDatosProductos.ResumeLayout(false);
            dbDatosProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            gbCarrito.ResumeLayout(false);
            gbCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblProveedor;
        private ComboBox cmbProveedor;
        private DateTimePicker dtpFecha;
        private Label lblFecha;
        private GroupBox gbDatosCompra;
        private GroupBox dbDatosProductos;
        private Label lblProducto;
        private ComboBox cmbProducto;
        private Label lblCantidad;
        private TextBox txtPrecio;
        private NumericUpDown nudCantidad;
        private Label lblPrecio;
        private GroupBox gbCarrito;
        private Label lblTotal;
        private Button btnGuardar;
        private Button btnCancelar;
        private DataGridView dgvCarrito;
        private Button btnQuitar;
        private Button btnAgregar;
    }
}