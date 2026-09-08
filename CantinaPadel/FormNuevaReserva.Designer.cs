namespace CantinaPadel
{
    partial class FormNuevaReserva
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
            cmbCliente = new ComboBox();
            cmbCancha = new ComboBox();
            cmbHorario = new ComboBox();
            dtpReserva = new DateTimePicker();
            txtPrecio = new TextBox();
            chckTurnoFijo = new CheckBox();
            nudSemanas = new NumericUpDown();
            lblCliente = new Label();
            gbReservas = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            lblSemana = new Label();
            lblPrecio = new Label();
            lblFecha = new Label();
            lblHorario = new Label();
            lblCancha = new Label();
            ((System.ComponentModel.ISupportInitialize)nudSemanas).BeginInit();
            gbReservas.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(76, 29);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(263, 23);
            cmbCliente.TabIndex = 0;
            // 
            // cmbCancha
            // 
            cmbCancha.FormattingEnabled = true;
            cmbCancha.Location = new Point(76, 58);
            cmbCancha.Name = "cmbCancha";
            cmbCancha.Size = new Size(263, 23);
            cmbCancha.TabIndex = 1;
            // 
            // cmbHorario
            // 
            cmbHorario.FormattingEnabled = true;
            cmbHorario.Location = new Point(76, 87);
            cmbHorario.Name = "cmbHorario";
            cmbHorario.Size = new Size(263, 23);
            cmbHorario.TabIndex = 2;
            // 
            // dtpReserva
            // 
            dtpReserva.Location = new Point(75, 116);
            dtpReserva.Name = "dtpReserva";
            dtpReserva.Size = new Size(263, 23);
            dtpReserva.TabIndex = 3;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(75, 148);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(264, 23);
            txtPrecio.TabIndex = 4;
            // 
            // chckTurnoFijo
            // 
            chckTurnoFijo.AutoSize = true;
            chckTurnoFijo.Location = new Point(6, 197);
            chckTurnoFijo.Name = "chckTurnoFijo";
            chckTurnoFijo.Size = new Size(77, 19);
            chckTurnoFijo.TabIndex = 5;
            chckTurnoFijo.Text = "Turno fijo";
            chckTurnoFijo.UseVisualStyleBackColor = true;
            chckTurnoFijo.CheckedChanged += chkTurnoFijo_CheckedChanged;
            // 
            // nudSemanas
            // 
            nudSemanas.Location = new Point(76, 222);
            nudSemanas.Name = "nudSemanas";
            nudSemanas.Size = new Size(263, 23);
            nudSemanas.TabIndex = 6;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 7;
            lblCliente.Text = "Cliente";
            // 
            // gbReservas
            // 
            gbReservas.Controls.Add(btnCancelar);
            gbReservas.Controls.Add(btnGuardar);
            gbReservas.Controls.Add(lblSemana);
            gbReservas.Controls.Add(lblPrecio);
            gbReservas.Controls.Add(lblFecha);
            gbReservas.Controls.Add(lblHorario);
            gbReservas.Controls.Add(lblCancha);
            gbReservas.Controls.Add(lblCliente);
            gbReservas.Controls.Add(nudSemanas);
            gbReservas.Controls.Add(cmbCliente);
            gbReservas.Controls.Add(chckTurnoFijo);
            gbReservas.Controls.Add(cmbCancha);
            gbReservas.Controls.Add(dtpReserva);
            gbReservas.Controls.Add(txtPrecio);
            gbReservas.Controls.Add(cmbHorario);
            gbReservas.Location = new Point(12, 12);
            gbReservas.Name = "gbReservas";
            gbReservas.Size = new Size(351, 297);
            gbReservas.TabIndex = 8;
            gbReservas.TabStop = false;
            gbReservas.Text = "Datos de reserva";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(178, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 23);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(8, 261);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 23);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblSemana
            // 
            lblSemana.AutoSize = true;
            lblSemana.Location = new Point(6, 224);
            lblSemana.Name = "lblSemana";
            lblSemana.Size = new Size(54, 15);
            lblSemana.TabIndex = 12;
            lblSemana.Text = "Semanas";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(6, 151);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 11;
            lblPrecio.Text = "Precio";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(6, 119);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 10;
            lblFecha.Text = "Fecha";
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.Location = new Point(6, 90);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(47, 15);
            lblHorario.TabIndex = 9;
            lblHorario.Text = "Horario";
            // 
            // lblCancha
            // 
            lblCancha.AutoSize = true;
            lblCancha.Location = new Point(6, 61);
            lblCancha.Name = "lblCancha";
            lblCancha.Size = new Size(47, 15);
            lblCancha.TabIndex = 8;
            lblCancha.Text = "Cancha";
            // 
            // FormNuevaReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 321);
            Controls.Add(gbReservas);
            Name = "FormNuevaReserva";
            Text = "FormNuevaReserva";
            Load += FormNuevaReserva_Load;
            ((System.ComponentModel.ISupportInitialize)nudSemanas).EndInit();
            gbReservas.ResumeLayout(false);
            gbReservas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCliente;
        private ComboBox cmbCancha;
        private ComboBox cmbHorario;
        private DateTimePicker dtpReserva;
        private TextBox txtPrecio;
        private CheckBox chckTurnoFijo;
        private NumericUpDown nudSemanas;
        private Label lblCliente;
        private GroupBox gbReservas;
        private Button btnGuardar;
        private Label lblSemana;
        private Label lblPrecio;
        private Label lblFecha;
        private Label lblHorario;
        private Label lblCancha;
        private Button btnCancelar;
    }
}