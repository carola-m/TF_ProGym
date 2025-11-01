namespace CapaPresentacion
{
    partial class frmGestionTurnos
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
            this.dtpFechaTurnos = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dgvTurnosDia = new System.Windows.Forms.DataGridView();
            this.gbDetalleTurno = new System.Windows.Forms.GroupBox();
            this.txtIdTurno = new System.Windows.Forms.TextBox();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            this.btnEliminarTurno = new System.Windows.Forms.Button();
            this.btnGuardarTurno = new System.Windows.Forms.Button();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaTurno = new System.Windows.Forms.Label();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.lblProfesional = new System.Windows.Forms.Label();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.lblActividad = new System.Windows.Forms.Label();
            this.gbReservaCliente = new System.Windows.Forms.GroupBox();
            this.lblCupoInfo = new System.Windows.Forms.Label();
            this.btnCancelarReserva = new System.Windows.Forms.Button();
            this.lstClientesInscritos = new System.Windows.Forms.ListBox();
            this.lblInscritos = new System.Windows.Forms.Label();
            this.btnReservarCliente = new System.Windows.Forms.Button();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDia)).BeginInit();
            this.gbDetalleTurno.SuspendLayout();
            this.gbReservaCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFechaTurnos
            // 
            this.dtpFechaTurnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpFechaTurnos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTurnos.Location = new System.Drawing.Point(62, 12);
            this.dtpFechaTurnos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaTurnos.Name = "dtpFechaTurnos";
            this.dtpFechaTurnos.Size = new System.Drawing.Size(114, 23);
            this.dtpFechaTurnos.TabIndex = 0;
            this.dtpFechaTurnos.ValueChanged += new System.EventHandler(this.dtpFechaTurnos_ValueChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(41, 15);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha:";
            // 
            // dgvTurnosDia
            // 
            this.dgvTurnosDia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnosDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosDia.Location = new System.Drawing.Point(12, 45);
            this.dgvTurnosDia.Name = "dgvTurnosDia";
            this.dgvTurnosDia.RowTemplate.Height = 25;
            this.dgvTurnosDia.Size = new System.Drawing.Size(760, 260);
            this.dgvTurnosDia.TabIndex = 2;
            this.dgvTurnosDia.SelectionChanged += new System.EventHandler(this.dgvTurnosDia_SelectionChanged);
            // 
            // gbDetalleTurno
            // 
            this.gbDetalleTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetalleTurno.Controls.Add(this.txtIdTurno);
            this.gbDetalleTurno.Controls.Add(this.btnNuevoTurno);
            this.gbDetalleTurno.Controls.Add(this.btnEliminarTurno);
            this.gbDetalleTurno.Controls.Add(this.btnGuardarTurno);
            this.gbDetalleTurno.Controls.Add(this.dtpHoraFin);
            this.gbDetalleTurno.Controls.Add(this.lblHoraFin);
            this.gbDetalleTurno.Controls.Add(this.dtpFechaFin);
            this.gbDetalleTurno.Controls.Add(this.dtpHoraInicio);
            this.gbDetalleTurno.Controls.Add(this.lblHoraInicio);
            this.gbDetalleTurno.Controls.Add(this.dtpFechaInicio);
            this.gbDetalleTurno.Controls.Add(this.lblFechaTurno);
            this.gbDetalleTurno.Controls.Add(this.cmbProfesional);
            this.gbDetalleTurno.Controls.Add(this.lblProfesional);
            this.gbDetalleTurno.Controls.Add(this.cmbActividad);
            this.gbDetalleTurno.Controls.Add(this.lblActividad);
            this.gbDetalleTurno.Location = new System.Drawing.Point(14, 322);
            this.gbDetalleTurno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDetalleTurno.Name = "gbDetalleTurno";
            this.gbDetalleTurno.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDetalleTurno.Size = new System.Drawing.Size(430, 260);
            this.gbDetalleTurno.TabIndex = 3;
            this.gbDetalleTurno.TabStop = false;
            this.gbDetalleTurno.Text = "Crear / Editar Turno";
            // 
            // txtIdTurno
            // 
            this.txtIdTurno.Location = new System.Drawing.Point(274, 25);
            this.txtIdTurno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtIdTurno.Name = "txtIdTurno";
            this.txtIdTurno.ReadOnly = true;
            this.txtIdTurno.Size = new System.Drawing.Size(50, 23);
            this.txtIdTurno.TabIndex = 14;
            this.txtIdTurno.TabStop = false;
            this.txtIdTurno.Visible = false;
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.Location = new System.Drawing.Point(330, 30);
            this.btnNuevoTurno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(90, 30);
            this.btnNuevoTurno.TabIndex = 13;
            this.btnNuevoTurno.Text = "Nuevo";
            this.btnNuevoTurno.UseVisualStyleBackColor = true;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // btnEliminarTurno
            // 
            this.btnEliminarTurno.Enabled = false;
            this.btnEliminarTurno.Location = new System.Drawing.Point(330, 110);
            this.btnEliminarTurno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEliminarTurno.Name = "btnEliminarTurno";
            this.btnEliminarTurno.Size = new System.Drawing.Size(90, 30);
            this.btnEliminarTurno.TabIndex = 12;
            this.btnEliminarTurno.Text = "Eliminar";
            this.btnEliminarTurno.UseVisualStyleBackColor = true;
            this.btnEliminarTurno.Click += new System.EventHandler(this.btnEliminarTurno_Click);
            // 
            // btnGuardarTurno
            // 
            this.btnGuardarTurno.Location = new System.Drawing.Point(330, 70);
            this.btnGuardarTurno.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardarTurno.Name = "btnGuardarTurno";
            this.btnGuardarTurno.Size = new System.Drawing.Size(90, 30);
            this.btnGuardarTurno.TabIndex = 11;
            this.btnGuardarTurno.Text = "Guardar";
            this.btnGuardarTurno.UseVisualStyleBackColor = true;
            this.btnGuardarTurno.Click += new System.EventHandler(this.btnGuardarTurno_Click);
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(220, 200);
            this.dtpHoraFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.ShowUpDown = true;
            this.dtpHoraFin.Size = new System.Drawing.Size(80, 23);
            this.dtpHoraFin.TabIndex = 10;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.AutoSize = true;
            this.lblHoraFin.Location = new System.Drawing.Point(170, 203);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(46, 15);
            this.lblHoraFin.TabIndex = 9;
            this.lblHoraFin.Text = "Hr. Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(70, 200);
            this.dtpFechaFin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(95, 23);
            this.dtpFechaFin.TabIndex = 8;
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(220, 160);
            this.dtpHoraInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.ShowUpDown = true;
            this.dtpHoraInicio.Size = new System.Drawing.Size(80, 23);
            this.dtpHoraInicio.TabIndex = 7;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.AutoSize = true;
            this.lblHoraInicio.Location = new System.Drawing.Point(170, 163);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(50, 15);
            this.lblHoraInicio.TabIndex = 6;
            this.lblHoraInicio.Text = "Hr. Ini.:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(70, 160);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(95, 23);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // lblFechaTurno
            // 
            this.lblFechaTurno.AutoSize = true;
            this.lblFechaTurno.Location = new System.Drawing.Point(10, 163);
            this.lblFechaTurno.Name = "lblFechaTurno";
            this.lblFechaTurno.Size = new System.Drawing.Size(58, 15);
            this.lblFechaTurno.TabIndex = 4;
            this.lblFechaTurno.Text = "Fecha/Hr:";
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(85, 90);
            this.cmbProfesional.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(215, 23);
            this.cmbProfesional.TabIndex = 3;
            // 
            // lblProfesional
            // 
            this.lblProfesional.AutoSize = true;
            this.lblProfesional.Location = new System.Drawing.Point(10, 93);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(69, 15);
            this.lblProfesional.TabIndex = 2;
            this.lblProfesional.Text = "Profesional:";
            // 
            // cmbActividad
            // 
            this.cmbActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Location = new System.Drawing.Point(85, 50);
            this.cmbActividad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(215, 23);
            this.cmbActividad.TabIndex = 1;
            // 
            // lblActividad
            // 
            this.lblActividad.AutoSize = true;
            this.lblActividad.Location = new System.Drawing.Point(10, 53);
            this.lblActividad.Name = "lblActividad";
            this.lblActividad.Size = new System.Drawing.Size(60, 15);
            this.lblActividad.TabIndex = 0;
            this.lblActividad.Text = "Actividad:";
            // 
            // gbReservaCliente
            // 
            this.gbReservaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)
            | System.Windows.Forms.AnchorStyles.Top)));
            this.gbReservaCliente.Controls.Add(this.lblCupoInfo);
            this.gbReservaCliente.Controls.Add(this.btnCancelarReserva);
            this.gbReservaCliente.Controls.Add(this.lstClientesInscritos);
            this.gbReservaCliente.Controls.Add(this.lblInscritos);
            this.gbReservaCliente.Controls.Add(this.btnReservarCliente);
            this.gbReservaCliente.Controls.Add(this.cmbCliente);
            this.gbReservaCliente.Controls.Add(this.lblCliente);
            this.gbReservaCliente.Enabled = false;
            this.gbReservaCliente.Location = new System.Drawing.Point(460, 322);
            this.gbReservaCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbReservaCliente.Name = "gbReservaCliente";
            this.gbReservaCliente.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbReservaCliente.Size = new System.Drawing.Size(312, 260);
            this.gbReservaCliente.TabIndex = 4;
            this.gbReservaCliente.TabStop = false;
            this.gbReservaCliente.Text = "Reservar Cliente";
            // 
            // lblCupoInfo
            // 
            this.lblCupoInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCupoInfo.AutoSize = true;
            this.lblCupoInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCupoInfo.Location = new System.Drawing.Point(10, 235);
            this.lblCupoInfo.Name = "lblCupoInfo";
            this.lblCupoInfo.Size = new System.Drawing.Size(69, 15);
            this.lblCupoInfo.TabIndex = 6;
            this.lblCupoInfo.Text = "Cupos: 0/0";
            // 
            // btnCancelarReserva
            // 
            this.btnCancelarReserva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarReserva.Location = new System.Drawing.Point(190, 230);
            this.btnCancelarReserva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelarReserva.Name = "btnCancelarReserva";
            this.btnCancelarReserva.Size = new System.Drawing.Size(110, 25);
            this.btnCancelarReserva.TabIndex = 5;
            this.btnCancelarReserva.Text = "Cancelar Res.";
            this.btnCancelarReserva.UseVisualStyleBackColor = true;
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);
            // 
            // lstClientesInscritos
            // 
            this.lstClientesInscritos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClientesInscritos.FormattingEnabled = true;
            this.lstClientesInscritos.ItemHeight = 15;
            this.lstClientesInscritos.Location = new System.Drawing.Point(10, 120);
            this.lstClientesInscritos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstClientesInscritos.Name = "lstClientesInscritos";
            this.lstClientesInscritos.Size = new System.Drawing.Size(290, 109);
            this.lstClientesInscritos.TabIndex = 4;
            // 
            // lblInscritos
            // 
            this.lblInscritos.AutoSize = true;
            this.lblInscritos.Location = new System.Drawing.Point(10, 100);
            this.lblInscritos.Name = "lblInscritos";
            this.lblInscritos.Size = new System.Drawing.Size(102, 15);
            this.lblInscritos.TabIndex = 3;
            this.lblInscritos.Text = "Clientes Inscritos:";
            // 
            // btnReservarCliente
            // 
            this.btnReservarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReservarCliente.Location = new System.Drawing.Point(210, 60);
            this.btnReservarCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReservarCliente.Name = "btnReservarCliente";
            this.btnReservarCliente.Size = new System.Drawing.Size(90, 30);
            this.btnReservarCliente.TabIndex = 2;
            this.btnReservarCliente.Text = "Reservar";
            this.btnReservarCliente.UseVisualStyleBackColor = true;
            this.btnReservarCliente.Click += new System.EventHandler(this.btnReservarCliente_Click);
            // 
            // cmbCliente
            // 
            this.cmbCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(10, 30);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(290, 23);
            this.cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(10, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 15);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Cliente:";
            // 
            // frmGestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 591);
            this.Controls.Add(this.gbReservaCliente);
            this.Controls.Add(this.gbDetalleTurno);
            this.Controls.Add(this.dgvTurnosDia);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFechaTurnos);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 630);
            this.Name = "frmGestionTurnos";
            this.Text = "Gestión de Turnos";
            this.Load += new System.EventHandler(this.frmGestionTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDia)).EndInit();
            this.gbDetalleTurno.ResumeLayout(false);
            this.gbDetalleTurno.PerformLayout();
            this.gbReservaCliente.ResumeLayout(false);
            this.gbReservaCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaTurnos;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DataGridView dgvTurnosDia;
        private System.Windows.Forms.GroupBox gbDetalleTurno;
        private System.Windows.Forms.TextBox txtIdTurno;
        private System.Windows.Forms.Button btnNuevoTurno;
        private System.Windows.Forms.Button btnEliminarTurno;
        private System.Windows.Forms.Button btnGuardarTurno;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
        private System.Windows.Forms.Label lblHoraFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.Label lblHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaTurno;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.Label lblActividad;
        private System.Windows.Forms.GroupBox gbReservaCliente;
        private System.Windows.Forms.Label lblCupoInfo;
        private System.Windows.Forms.Button btnCancelarReserva;
        private System.Windows.Forms.ListBox lstClientesInscritos;
        private System.Windows.Forms.Label lblInscritos;
        private System.Windows.Forms.Button btnReservarCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblCliente;
    }
}