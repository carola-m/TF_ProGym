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
            dtpFechaTurnos = new DateTimePicker();
            lblFecha = new Label();
            dgvTurnosDia = new DataGridView();
            gbDetalleTurno = new GroupBox();
            txtIdTurno = new TextBox();
            btnNuevoTurno = new Button();
            btnEliminarTurno = new Button();
            btnGuardarTurno = new Button();
            dtpHoraFin = new DateTimePicker();
            lblHoraFin = new Label();
            dtpFechaFin = new DateTimePicker();
            dtpHoraInicio = new DateTimePicker();
            lblHoraInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaTurno = new Label();
            cmbProfesional = new ComboBox();
            lblProfesional = new Label();
            cmbActividad = new ComboBox();
            lblActividad = new Label();
            gbReservaCliente = new GroupBox();
            lblCupoInfo = new Label();
            btnCancelarReserva = new Button();
            lstClientesInscritos = new ListBox();
            lblInscritos = new Label();
            btnReservarCliente = new Button();
            cmbCliente = new ComboBox();
            lblCliente = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDia).BeginInit();
            gbDetalleTurno.SuspendLayout();
            gbReservaCliente.SuspendLayout();
            SuspendLayout();
            // 
            // dtpFechaTurnos
            // 
            dtpFechaTurnos.Format = DateTimePickerFormat.Short;
            dtpFechaTurnos.Location = new Point(66, 16);
            dtpFechaTurnos.Margin = new Padding(3, 4, 3, 4);
            dtpFechaTurnos.Name = "dtpFechaTurnos";
            dtpFechaTurnos.Size = new Size(114, 27);
            dtpFechaTurnos.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(14, 21);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dgvTurnosDia
            // 
            dgvTurnosDia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTurnosDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosDia.Location = new Point(14, 55);
            dgvTurnosDia.Margin = new Padding(3, 4, 3, 4);
            dgvTurnosDia.Name = "dgvTurnosDia";
            dgvTurnosDia.RowHeadersWidth = 51;
            dgvTurnosDia.RowTemplate.Height = 25;
            dgvTurnosDia.Size = new Size(1130, 256);
            dgvTurnosDia.TabIndex = 2;
            // 
            // gbDetalleTurno
            // 
            gbDetalleTurno.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDetalleTurno.Controls.Add(txtIdTurno);
            gbDetalleTurno.Controls.Add(btnNuevoTurno);
            gbDetalleTurno.Controls.Add(btnEliminarTurno);
            gbDetalleTurno.Controls.Add(btnGuardarTurno);
            gbDetalleTurno.Controls.Add(dtpHoraFin);
            gbDetalleTurno.Controls.Add(lblHoraFin);
            gbDetalleTurno.Controls.Add(dtpFechaFin);
            gbDetalleTurno.Controls.Add(dtpHoraInicio);
            gbDetalleTurno.Controls.Add(lblHoraInicio);
            gbDetalleTurno.Controls.Add(dtpFechaInicio);
            gbDetalleTurno.Controls.Add(lblFechaTurno);
            gbDetalleTurno.Controls.Add(cmbProfesional);
            gbDetalleTurno.Controls.Add(lblProfesional);
            gbDetalleTurno.Controls.Add(cmbActividad);
            gbDetalleTurno.Controls.Add(lblActividad);
            gbDetalleTurno.Location = new Point(14, 322);
            gbDetalleTurno.Margin = new Padding(3, 4, 3, 4);
            gbDetalleTurno.Name = "gbDetalleTurno";
            gbDetalleTurno.Padding = new Padding(3, 4, 3, 4);
            gbDetalleTurno.Size = new Size(775, 307);
            gbDetalleTurno.TabIndex = 3;
            gbDetalleTurno.TabStop = false;
            gbDetalleTurno.Text = "Crear / Editar Turno";
            // 
            // txtIdTurno
            // 
            txtIdTurno.Location = new Point(434, 20);
            txtIdTurno.Margin = new Padding(3, 4, 3, 4);
            txtIdTurno.Name = "txtIdTurno";
            txtIdTurno.ReadOnly = true;
            txtIdTurno.Size = new Size(114, 27);
            txtIdTurno.TabIndex = 14;
            txtIdTurno.TabStop = false;
            txtIdTurno.Visible = false;
            // 
            // btnNuevoTurno
            // 
            btnNuevoTurno.Location = new Point(400, 67);
            btnNuevoTurno.Margin = new Padding(3, 4, 3, 4);
            btnNuevoTurno.Name = "btnNuevoTurno";
            btnNuevoTurno.Size = new Size(97, 40);
            btnNuevoTurno.TabIndex = 13;
            btnNuevoTurno.Text = "Nuevo";
            btnNuevoTurno.UseVisualStyleBackColor = true;
            // 
            // btnEliminarTurno
            // 
            btnEliminarTurno.Enabled = false;
            btnEliminarTurno.Location = new Point(400, 173);
            btnEliminarTurno.Margin = new Padding(3, 4, 3, 4);
            btnEliminarTurno.Name = "btnEliminarTurno";
            btnEliminarTurno.Size = new Size(97, 40);
            btnEliminarTurno.TabIndex = 12;
            btnEliminarTurno.Text = "Eliminar";
            btnEliminarTurno.UseVisualStyleBackColor = true;
            // 
            // btnGuardarTurno
            // 
            btnGuardarTurno.Location = new Point(400, 120);
            btnGuardarTurno.Margin = new Padding(3, 4, 3, 4);
            btnGuardarTurno.Name = "btnGuardarTurno";
            btnGuardarTurno.Size = new Size(97, 40);
            btnGuardarTurno.TabIndex = 11;
            btnGuardarTurno.Text = "Guardar";
            btnGuardarTurno.UseVisualStyleBackColor = true;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(274, 200);
            dtpHoraFin.Margin = new Padding(3, 4, 3, 4);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(91, 27);
            dtpHoraFin.TabIndex = 10;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Location = new Point(206, 205);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(68, 20);
            lblHoraFin.TabIndex = 9;
            lblHoraFin.Text = "Hora Fin:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(86, 200);
            dtpFechaFin.Margin = new Padding(3, 4, 3, 4);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(114, 27);
            dtpFechaFin.TabIndex = 8;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(274, 153);
            dtpHoraInicio.Margin = new Padding(3, 4, 3, 4);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(91, 27);
            dtpHoraInicio.TabIndex = 7;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Location = new Point(206, 159);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(68, 20);
            lblHoraInicio.TabIndex = 6;
            lblHoraInicio.Text = "Hora Ini.:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(86, 153);
            dtpFechaInicio.Margin = new Padding(3, 4, 3, 4);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(114, 27);
            dtpFechaInicio.TabIndex = 5;
            // 
            // lblFechaTurno
            // 
            lblFechaTurno.AutoSize = true;
            lblFechaTurno.Location = new Point(11, 159);
            lblFechaTurno.Name = "lblFechaTurno";
            lblFechaTurno.Size = new Size(72, 20);
            lblFechaTurno.TabIndex = 4;
            lblFechaTurno.Text = "Fecha/Hr:";
            // 
            // cmbProfesional
            // 
            cmbProfesional.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfesional.FormattingEnabled = true;
            cmbProfesional.Location = new Point(97, 100);
            cmbProfesional.Margin = new Padding(3, 4, 3, 4);
            cmbProfesional.Name = "cmbProfesional";
            cmbProfesional.Size = new Size(268, 28);
            cmbProfesional.TabIndex = 3;
            // 
            // lblProfesional
            // 
            lblProfesional.AutoSize = true;
            lblProfesional.Location = new Point(11, 104);
            lblProfesional.Name = "lblProfesional";
            lblProfesional.Size = new Size(86, 20);
            lblProfesional.TabIndex = 2;
            lblProfesional.Text = "Profesional:";
            // 
            // cmbActividad
            // 
            cmbActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActividad.FormattingEnabled = true;
            cmbActividad.Location = new Point(97, 53);
            cmbActividad.Margin = new Padding(3, 4, 3, 4);
            cmbActividad.Name = "cmbActividad";
            cmbActividad.Size = new Size(268, 28);
            cmbActividad.TabIndex = 1;
            // 
            // lblActividad
            // 
            lblActividad.AutoSize = true;
            lblActividad.Location = new Point(11, 57);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(75, 20);
            lblActividad.TabIndex = 0;
            lblActividad.Text = "Actividad:";
            // 
            // gbReservaCliente
            // 
            gbReservaCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            gbReservaCliente.Controls.Add(lblCupoInfo);
            gbReservaCliente.Controls.Add(btnCancelarReserva);
            gbReservaCliente.Controls.Add(lstClientesInscritos);
            gbReservaCliente.Controls.Add(lblInscritos);
            gbReservaCliente.Controls.Add(btnReservarCliente);
            gbReservaCliente.Controls.Add(cmbCliente);
            gbReservaCliente.Controls.Add(lblCliente);
            gbReservaCliente.Enabled = false;
            gbReservaCliente.Location = new Point(804, 322);
            gbReservaCliente.Margin = new Padding(3, 4, 3, 4);
            gbReservaCliente.Name = "gbReservaCliente";
            gbReservaCliente.Padding = new Padding(3, 4, 3, 4);
            gbReservaCliente.Size = new Size(339, 307);
            gbReservaCliente.TabIndex = 4;
            gbReservaCliente.TabStop = false;
            gbReservaCliente.Text = "Reservar Cliente";
            // 
            // lblCupoInfo
            // 
            lblCupoInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCupoInfo.AutoSize = true;
            lblCupoInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCupoInfo.Location = new Point(11, 273);
            lblCupoInfo.Name = "lblCupoInfo";
            lblCupoInfo.Size = new Size(85, 20);
            lblCupoInfo.TabIndex = 6;
            lblCupoInfo.Text = "Cupos: 0/0";
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarReserva.Location = new Point(206, 267);
            btnCancelarReserva.Margin = new Padding(3, 4, 3, 4);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(114, 33);
            btnCancelarReserva.TabIndex = 5;
            btnCancelarReserva.Text = "Cancelar Res.";
            btnCancelarReserva.UseVisualStyleBackColor = true;
            // 
            // lstClientesInscritos
            // 
            lstClientesInscritos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstClientesInscritos.FormattingEnabled = true;
            lstClientesInscritos.Location = new Point(11, 160);
            lstClientesInscritos.Margin = new Padding(3, 4, 3, 4);
            lstClientesInscritos.Name = "lstClientesInscritos";
            lstClientesInscritos.Size = new Size(308, 104);
            lstClientesInscritos.TabIndex = 4;
            // 
            // lblInscritos
            // 
            lblInscritos.AutoSize = true;
            lblInscritos.Location = new Point(11, 133);
            lblInscritos.Name = "lblInscritos";
            lblInscritos.Size = new Size(122, 20);
            lblInscritos.TabIndex = 3;
            lblInscritos.Text = "Clientes Inscritos:";
            // 
            // btnReservarCliente
            // 
            btnReservarCliente.Location = new Point(206, 87);
            btnReservarCliente.Margin = new Padding(3, 4, 3, 4);
            btnReservarCliente.Name = "btnReservarCliente";
            btnReservarCliente.Size = new Size(114, 33);
            btnReservarCliente.TabIndex = 2;
            btnReservarCliente.Text = "Reservar";
            btnReservarCliente.UseVisualStyleBackColor = true;
            // 
            // cmbCliente
            // 
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(11, 53);
            cmbCliente.Margin = new Padding(3, 4, 3, 4);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(308, 28);
            cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(11, 27);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(58, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // frmGestionTurnos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 644);
            Controls.Add(gbReservaCliente);
            Controls.Add(gbDetalleTurno);
            Controls.Add(dgvTurnosDia);
            Controls.Add(lblFecha);
            Controls.Add(dtpFechaTurnos);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 691);
            Name = "frmGestionTurnos";
            Text = "Gestión de Turnos";
            Load += frmGestionTurnos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTurnosDia).EndInit();
            gbDetalleTurno.ResumeLayout(false);
            gbDetalleTurno.PerformLayout();
            gbReservaCliente.ResumeLayout(false);
            gbReservaCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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