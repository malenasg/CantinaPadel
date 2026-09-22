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
            lblProducto = new Label();
            cmbProducto = new ComboBox();
            lblCantidad = new Label();
            gbCarrito = new GroupBox();
            lblPrecio = new Label();
            nudCantidad = new NumericUpDown();
            txtPrecio = new TextBox();
            dgvCarrito = new DataGridView();
            btnAgregar = new Button();
            btnGuardar = new Button();
            lblTotal = new Label();
            btnQuitar = new Button();
            button1 = new Button();
            gbDatosCompra.SuspendLayout();
            dbDatosProductos.SuspendLayout();
            gbCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Location = new Point(14, 20);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(64, 15);
            lblProveedor.TabIndex = 0;
            lblProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(98, 17);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(328, 23);
            cmbProveedor.TabIndex = 1;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(98, 46);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(328, 23);
            dtpFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(14, 52);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "Fecha:";
            // 
            // gbDatosCompra
            // 
            gbDatosCompra.Controls.Add(lblFecha);
            gbDatosCompra.Controls.Add(cmbProveedor);
            gbDatosCompra.Controls.Add(dtpFecha);
            gbDatosCompra.Controls.Add(lblProveedor);
            gbDatosCompra.Location = new Point(25, 12);
            gbDatosCompra.Name = "gbDatosCompra";
            gbDatosCompra.Size = new Size(441, 78);
            gbDatosCompra.TabIndex = 5;
            gbDatosCompra.TabStop = false;
            gbDatosCompra.Text = "groupBox1";
            // 
            // dbDatosProductos
            // 
            dbDatosProductos.Controls.Add(button1);
            dbDatosProductos.Controls.Add(txtPrecio);
            dbDatosProductos.Controls.Add(nudCantidad);
            dbDatosProductos.Controls.Add(lblPrecio);
            dbDatosProductos.Controls.Add(lblProducto);
            dbDatosProductos.Controls.Add(cmbProducto);
            dbDatosProductos.Controls.Add(lblCantidad);
            dbDatosProductos.Location = new Point(25, 96);
            dbDatosProductos.Name = "dbDatosProductos";
            dbDatosProductos.Size = new Size(441, 105);
            dbDatosProductos.TabIndex = 6;
            dbDatosProductos.TabStop = false;
            dbDatosProductos.Text = "groupBox2";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(14, 20);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 15);
            lblProducto.TabIndex = 3;
            lblProducto.Text = "Producto:";
            // 
            // cmbProducto
            // 
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(98, 17);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(328, 23);
            cmbProducto.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(14, 48);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad";
            // 
            // gbCarrito
            // 
            gbCarrito.Controls.Add(btnQuitar);
            gbCarrito.Controls.Add(lblTotal);
            gbCarrito.Controls.Add(btnGuardar);
            gbCarrito.Controls.Add(btnAgregar);
            gbCarrito.Controls.Add(dgvCarrito);
            gbCarrito.Location = new Point(25, 207);
            gbCarrito.Name = "gbCarrito";
            gbCarrito.Size = new Size(441, 231);
            gbCarrito.TabIndex = 7;
            gbCarrito.TabStop = false;
            gbCarrito.Text = "groupBox3";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(14, 76);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(52, 15);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio: $";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(98, 46);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(328, 23);
            nudCantidad.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(98, 73);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(291, 23);
            txtPrecio.TabIndex = 5;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(13, 22);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.Size = new Size(417, 143);
            dgvCarrito.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(277, 202);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "+";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(358, 202);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(277, 175);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(35, 15);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "Total:";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(13, 171);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 23);
            btnQuitar.TabIndex = 4;
            btnQuitar.Text = "Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(395, 73);
            button1.Name = "button1";
            button1.Size = new Size(31, 23);
            button1.TabIndex = 6;
            button1.Text = "+";
            button1.TextAlign = ContentAlignment.TopCenter;
            button1.UseVisualStyleBackColor = true;
            // 
            // FormNuevaCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 450);
            Controls.Add(gbCarrito);
            Controls.Add(dbDatosProductos);
            Controls.Add(gbDatosCompra);
            Name = "FormNuevaCompra";
            Text = "FormNuevaCompra";
            gbDatosCompra.ResumeLayout(false);
            gbDatosCompra.PerformLayout();
            dbDatosProductos.ResumeLayout(false);
            dbDatosProductos.PerformLayout();
            gbCarrito.ResumeLayout(false);
            gbCarrito.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
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
        private Button btnAgregar;
        private DataGridView dgvCarrito;
        private Button btnQuitar;
        private Button button1;
    }
}