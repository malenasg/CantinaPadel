namespace CantinaPadel
{
    partial class MenuPrincipal
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
            splitContainer1 = new SplitContainer();
            panelBotones = new Panel();
            btnSalir = new Button();
            btnReportes = new Button();
            btnCanchas = new Button();
            btnProductos = new Button();
            btnPersonas = new Button();
            btnCaja = new Button();
            btnVentas = new Button();
            btnReservas = new Button();
            panelHeader = new Panel();
            btnMenu = new Button();
            lblInfo = new Label();
            lblSubtitulo = new Label();
            lblNombre = new Label();
            panelContenedor = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelBotones.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(64, 0, 0);
            splitContainer1.Panel1.Controls.Add(panelBotones);
            splitContainer1.Panel1.Controls.Add(panelHeader);
            splitContainer1.Panel1.ForeColor = SystemColors.ActiveCaption;
            splitContainer1.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(240, 242, 245);
            splitContainer1.Panel2.Controls.Add(panelContenedor);
            splitContainer1.Size = new Size(984, 561);
            splitContainer1.SplitterDistance = 187;
            splitContainer1.TabIndex = 1;
            // 
            // panelBotones
            // 
            panelBotones.AutoScroll = true;
            panelBotones.BackColor = Color.Transparent;
            panelBotones.Controls.Add(btnSalir);
            panelBotones.Controls.Add(btnReportes);
            panelBotones.Controls.Add(btnCanchas);
            panelBotones.Controls.Add(btnProductos);
            panelBotones.Controls.Add(btnPersonas);
            panelBotones.Controls.Add(btnCaja);
            panelBotones.Controls.Add(btnVentas);
            panelBotones.Controls.Add(btnReservas);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.Location = new Point(0, 100);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(187, 461);
            panelBotones.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.MouseOverBackColor = Color.FromArgb(198, 57, 43);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(0, 421);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(187, 40);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnReportes
            // 
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.White;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 240);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(187, 40);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Reportes";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnCanchas
            // 
            btnCanchas.Dock = DockStyle.Top;
            btnCanchas.FlatAppearance.BorderSize = 0;
            btnCanchas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnCanchas.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnCanchas.FlatStyle = FlatStyle.Flat;
            btnCanchas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCanchas.ForeColor = Color.White;
            btnCanchas.ImageAlign = ContentAlignment.MiddleLeft;
            btnCanchas.Location = new Point(0, 200);
            btnCanchas.Name = "btnCanchas";
            btnCanchas.Size = new Size(187, 40);
            btnCanchas.TabIndex = 5;
            btnCanchas.Text = "Canchas";
            btnCanchas.TextAlign = ContentAlignment.MiddleLeft;
            btnCanchas.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatAppearance.BorderSize = 0;
            btnProductos.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnProductos.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = Color.White;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(0, 160);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(187, 40);
            btnProductos.TabIndex = 4;
            btnProductos.Text = "Productos";
            btnProductos.TextAlign = ContentAlignment.MiddleLeft;
            btnProductos.UseVisualStyleBackColor = true;
            // 
            // btnPersonas
            // 
            btnPersonas.Dock = DockStyle.Top;
            btnPersonas.FlatAppearance.BorderSize = 0;
            btnPersonas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnPersonas.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnPersonas.FlatStyle = FlatStyle.Flat;
            btnPersonas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPersonas.ForeColor = Color.White;
            btnPersonas.ImageAlign = ContentAlignment.MiddleLeft;
            btnPersonas.Location = new Point(0, 120);
            btnPersonas.Name = "btnPersonas";
            btnPersonas.Size = new Size(187, 40);
            btnPersonas.TabIndex = 3;
            btnPersonas.Text = "Personas";
            btnPersonas.TextAlign = ContentAlignment.MiddleLeft;
            btnPersonas.UseVisualStyleBackColor = true;
            btnPersonas.Click += btnPersonas_Click;
            // 
            // btnCaja
            // 
            btnCaja.Dock = DockStyle.Top;
            btnCaja.FlatAppearance.BorderSize = 0;
            btnCaja.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnCaja.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnCaja.FlatStyle = FlatStyle.Flat;
            btnCaja.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCaja.ForeColor = Color.White;
            btnCaja.ImageAlign = ContentAlignment.MiddleLeft;
            btnCaja.Location = new Point(0, 80);
            btnCaja.Name = "btnCaja";
            btnCaja.Size = new Size(187, 40);
            btnCaja.TabIndex = 2;
            btnCaja.Text = "Caja";
            btnCaja.TextAlign = ContentAlignment.MiddleLeft;
            btnCaja.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnVentas.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 0, 0);
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = Color.White;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 40);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(187, 40);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnReservas
            // 
            btnReservas.Dock = DockStyle.Top;
            btnReservas.FlatAppearance.BorderSize = 0;
            btnReservas.FlatStyle = FlatStyle.Flat;
            btnReservas.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReservas.ForeColor = Color.White;
            btnReservas.ImageAlign = ContentAlignment.MiddleLeft;
            btnReservas.Location = new Point(0, 0);
            btnReservas.Name = "btnReservas";
            btnReservas.Size = new Size(187, 40);
            btnReservas.TabIndex = 0;
            btnReservas.Text = "Reservas";
            btnReservas.TextAlign = ContentAlignment.MiddleLeft;
            btnReservas.UseVisualStyleBackColor = true;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(btnMenu);
            panelHeader.Controls.Add(lblInfo);
            panelHeader.Controls.Add(lblSubtitulo);
            panelHeader.Controls.Add(lblNombre);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.MaximumSize = new Size(0, 120);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(187, 100);
            panelHeader.TabIndex = 0;
            // 
            // btnMenu
            // 
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(147, 53);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(40, 40);
            btnMenu.TabIndex = 3;
            btnMenu.Text = "≡";
            btnMenu.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblInfo.ForeColor = Color.FromArgb(180, 180, 185);
            lblInfo.Location = new Point(15, 69);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(118, 15);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "Usuario | Caja abierta";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(15, 42);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(89, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "- CANTINA -";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblNombre.ForeColor = Color.White;
            lblNombre.Location = new Point(15, 13);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(152, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "CLUB DE PÁDEL";
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(793, 561);
            panelContenedor.TabIndex = 0;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(1000, 600);
            Name = "MenuPrincipal";
            SizeGripStyle = SizeGripStyle.Show;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            WindowState = FormWindowState.Maximized;
            Load += MenuPrincipal_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private Panel panelHeader;
        private Label lblSubtitulo;
        private Label lblNombre;
        private Label lblInfo;
        private Button btnMenu;
        private Panel panelBotones;
        private Button btnReservas;
        private Button btnSalir;
        private Button btnReportes;
        private Button btnCanchas;
        private Button btnProductos;
        private Button btnPersonas;
        private Button btnCaja;
        private Button btnVentas;
        private Panel panelContenedor;
    }
}