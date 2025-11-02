namespace CapaPresentacion
{
    partial class frmGestionTurnos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            dtpFechaTurnos.Font = new Font("Segoe UI", 9.75F);
            dtpFechaTurnos.Format = DateTimePickerFormat.Short;
            dtpFechaTurnos.Location = new Point(71, 16);
            dtpFechaTurnos.Margin = new Padding(3, 5, 3, 5);
            dtpFechaTurnos.Name = "dtpFechaTurnos";
            dtpFechaTurnos.Size = new Size(130, 29);
            dtpFechaTurnos.TabIndex = 0;
            dtpFechaTurnos.ValueChanged += dtpFechaTurnos_ValueChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(14, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 20);
            lblFecha.TabIndex = 1;
            lblFecha.Text = "Fecha:";
            // 
            // dgvTurnosDia
            // 
            dgvTurnosDia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvTurnosDia.BackgroundColor = Color.White;
            dgvTurnosDia.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTurnosDia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTurnosDia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurnosDia.Location = new Point(14, 60);
            dgvTurnosDia.Margin = new Padding(3, 4, 3, 4);
            dgvTurnosDia.Name = "dgvTurnosDia";
            dgvTurnosDia.RowHeadersWidth = 51;
            dgvTurnosDia.RowTemplate.Height = 25;
            dgvTurnosDia.Size = new Size(869, 347);
            dgvTurnosDia.TabIndex = 2;
            dgvTurnosDia.SelectionChanged += dgvTurnosDia_SelectionChanged;
            // 
            // gbDetalleTurno
            // 
            gbDetalleTurno.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
            gbDetalleTurno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            gbDetalleTurno.Location = new Point(16, 429);
            gbDetalleTurno.Margin = new Padding(3, 5, 3, 5);
            gbDetalleTurno.Name = "gbDetalleTurno";
            gbDetalleTurno.Padding = new Padding(3, 5, 3, 5);
            gbDetalleTurno.Size = new Size(491, 347);
            gbDetalleTurno.TabIndex = 3;
            gbDetalleTurno.TabStop = false;
            gbDetalleTurno.Text = "Crear / Editar Turno";
            // 
            // txtIdTurno
            // 
            txtIdTurno.Font = new Font("Segoe UI", 9.75F);
            txtIdTurno.Location = new Point(313, 33);
            txtIdTurno.Margin = new Padding(3, 5, 3, 5);
            txtIdTurno.Name = "txtIdTurno";
            txtIdTurno.ReadOnly = true;
            txtIdTurno.Size = new Size(57, 29);
            txtIdTurno.TabIndex = 14;
            txtIdTurno.TabStop = false;
            txtIdTurno.Visible = false;
            // 
            // btnNuevoTurno
            // 
            btnNuevoTurno.BackColor = Color.Gainsboro;
            btnNuevoTurno.FlatAppearance.BorderSize = 0;
            btnNuevoTurno.FlatStyle = FlatStyle.Flat;
            btnNuevoTurno.Font = new Font("Segoe UI", 9.75F);
            btnNuevoTurno.ForeColor = Color.Black;
            btnNuevoTurno.Location = new Point(377, 40);
            btnNuevoTurno.Margin = new Padding(3, 5, 3, 5);
            btnNuevoTurno.Name = "btnNuevoTurno";
            btnNuevoTurno.Size = new Size(103, 40);
            btnNuevoTurno.TabIndex = 13;
            btnNuevoTurno.Text = "Nuevo";
            btnNuevoTurno.UseVisualStyleBackColor = false;
            btnNuevoTurno.Click += btnNuevoTurno_Click;
            // 
            // btnEliminarTurno
            // 
            btnEliminarTurno.BackColor = Color.IndianRed;
            btnEliminarTurno.Enabled = false;
            btnEliminarTurno.FlatAppearance.BorderSize = 0;
            btnEliminarTurno.FlatStyle = FlatStyle.Flat;
            btnEliminarTurno.Font = new Font("Segoe UI", 9.75F);
            btnEliminarTurno.ForeColor = Color.White;
            btnEliminarTurno.Location = new Point(377, 147);
            btnEliminarTurno.Margin = new Padding(3, 5, 3, 5);
            btnEliminarTurno.Name = "btnEliminarTurno";
            btnEliminarTurno.Size = new Size(103, 40);
            btnEliminarTurno.TabIndex = 12;
            btnEliminarTurno.Text = "Eliminar";
            btnEliminarTurno.UseVisualStyleBackColor = false;
            btnEliminarTurno.Click += btnEliminarTurno_Click;
            // 
            // btnGuardarTurno
            // 
            btnGuardarTurno.BackColor = Color.SteelBlue;
            btnGuardarTurno.FlatAppearance.BorderSize = 0;
            btnGuardarTurno.FlatStyle = FlatStyle.Flat;
            btnGuardarTurno.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnGuardarTurno.ForeColor = Color.White;
            btnGuardarTurno.Location = new Point(377, 93);
            btnGuardarTurno.Margin = new Padding(3, 5, 3, 5);
            btnGuardarTurno.Name = "btnGuardarTurno";
            btnGuardarTurno.Size = new Size(103, 40);
            btnGuardarTurno.TabIndex = 11;
            btnGuardarTurno.Text = "Guardar";
            btnGuardarTurno.UseVisualStyleBackColor = false;
            btnGuardarTurno.Click += btnGuardarTurno_Click;
            // 
            // dtpHoraFin
            // 
            dtpHoraFin.Font = new Font("Segoe UI", 9.75F);
            dtpHoraFin.Format = DateTimePickerFormat.Time;
            dtpHoraFin.Location = new Point(251, 267);
            dtpHoraFin.Margin = new Padding(3, 5, 3, 5);
            dtpHoraFin.Name = "dtpHoraFin";
            dtpHoraFin.ShowUpDown = true;
            dtpHoraFin.Size = new Size(91, 29);
            dtpHoraFin.TabIndex = 10;
            // 
            // lblHoraFin
            // 
            lblHoraFin.AutoSize = true;
            lblHoraFin.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblHoraFin.Location = new Point(194, 271);
            lblHoraFin.Name = "lblHoraFin";
            lblHoraFin.Size = new Size(58, 20);
            lblHoraFin.TabIndex = 9;
            lblHoraFin.Text = "Hr. Fin:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Font = new Font("Segoe UI", 9.75F);
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(80, 267);
            dtpFechaFin.Margin = new Padding(3, 5, 3, 5);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(108, 29);
            dtpFechaFin.TabIndex = 8;
            // 
            // dtpHoraInicio
            // 
            dtpHoraInicio.Font = new Font("Segoe UI", 9.75F);
            dtpHoraInicio.Format = DateTimePickerFormat.Time;
            dtpHoraInicio.Location = new Point(251, 213);
            dtpHoraInicio.Margin = new Padding(3, 5, 3, 5);
            dtpHoraInicio.Name = "dtpHoraInicio";
            dtpHoraInicio.ShowUpDown = true;
            dtpHoraInicio.Size = new Size(91, 29);
            dtpHoraInicio.TabIndex = 7;
            // 
            // lblHoraInicio
            // 
            lblHoraInicio.AutoSize = true;
            lblHoraInicio.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblHoraInicio.Location = new Point(194, 217);
            lblHoraInicio.Name = "lblHoraInicio";
            lblHoraInicio.Size = new Size(58, 20);
            lblHoraInicio.TabIndex = 6;
            lblHoraInicio.Text = "Hr. Ini.:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Font = new Font("Segoe UI", 9.75F);
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(80, 213);
            dtpFechaInicio.Margin = new Padding(3, 5, 3, 5);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(108, 29);
            dtpFechaInicio.TabIndex = 5;
            // 
            // lblFechaTurno
            // 
            lblFechaTurno.AutoSize = true;
            lblFechaTurno.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFechaTurno.Location = new Point(11, 217);
            lblFechaTurno.Name = "lblFechaTurno";
            lblFechaTurno.Size = new Size(77, 20);
            lblFechaTurno.TabIndex = 4;
            lblFechaTurno.Text = "Fecha/Hr:";
            // 
            // cmbProfesional
            // 
            cmbProfesional.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProfesional.Font = new Font("Segoe UI", 9.75F);
            cmbProfesional.FormattingEnabled = true;
            cmbProfesional.Location = new Point(97, 120);
            cmbProfesional.Margin = new Padding(3, 5, 3, 5);
            cmbProfesional.Name = "cmbProfesional";
            cmbProfesional.Size = new Size(245, 29);
            cmbProfesional.TabIndex = 3;
            // 
            // lblProfesional
            // 
            lblProfesional.AutoSize = true;
            lblProfesional.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblProfesional.Location = new Point(11, 124);
            lblProfesional.Name = "lblProfesional";
            lblProfesional.Size = new Size(90, 20);
            lblProfesional.TabIndex = 2;
            lblProfesional.Text = "Profesional:";
            // 
            // cmbActividad
            // 
            cmbActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActividad.Font = new Font("Segoe UI", 9.75F);
            cmbActividad.FormattingEnabled = true;
            cmbActividad.Location = new Point(97, 67);
            cmbActividad.Margin = new Padding(3, 5, 3, 5);
            cmbActividad.Name = "cmbActividad";
            cmbActividad.Size = new Size(245, 29);
            cmbActividad.TabIndex = 1;
            // 
            // lblActividad
            // 
            lblActividad.AutoSize = true;
            lblActividad.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblActividad.Location = new Point(11, 71);
            lblActividad.Name = "lblActividad";
            lblActividad.Size = new Size(77, 20);
            lblActividad.TabIndex = 0;
            lblActividad.Text = "Actividad:";
            // 
            // gbReservaCliente
            // 
            gbReservaCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbReservaCliente.Controls.Add(lblCupoInfo);
            gbReservaCliente.Controls.Add(btnCancelarReserva);
            gbReservaCliente.Controls.Add(lstClientesInscritos);
            gbReservaCliente.Controls.Add(lblInscritos);
            gbReservaCliente.Controls.Add(btnReservarCliente);
            gbReservaCliente.Controls.Add(cmbCliente);
            gbReservaCliente.Controls.Add(lblCliente);
            gbReservaCliente.Enabled = false;
            gbReservaCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            gbReservaCliente.Location = new Point(526, 429);
            gbReservaCliente.Margin = new Padding(3, 5, 3, 5);
            gbReservaCliente.Name = "gbReservaCliente";
            gbReservaCliente.Padding = new Padding(3, 5, 3, 5);
            gbReservaCliente.Size = new Size(357, 347);
            gbReservaCliente.TabIndex = 4;
            gbReservaCliente.TabStop = false;
            gbReservaCliente.Text = "Reservar Cliente";
            // 
            // lblCupoInfo
            // 
            lblCupoInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblCupoInfo.AutoSize = true;
            lblCupoInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCupoInfo.Location = new Point(6, 282);
            lblCupoInfo.Name = "lblCupoInfo";
            lblCupoInfo.Size = new Size(85, 20);
            lblCupoInfo.TabIndex = 6;
            lblCupoInfo.Text = "Cupos: 0/0";
            // 
            // btnCancelarReserva
            // 
            btnCancelarReserva.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelarReserva.BackColor = Color.IndianRed;
            btnCancelarReserva.FlatAppearance.BorderSize = 0;
            btnCancelarReserva.FlatStyle = FlatStyle.Flat;
            btnCancelarReserva.Font = new Font("Segoe UI", 9.75F);
            btnCancelarReserva.ForeColor = Color.White;
            btnCancelarReserva.Location = new Point(217, 287);
            btnCancelarReserva.Margin = new Padding(3, 5, 3, 5);
            btnCancelarReserva.Name = "btnCancelarReserva";
            btnCancelarReserva.Size = new Size(126, 33);
            btnCancelarReserva.TabIndex = 5;
            btnCancelarReserva.Text = "Cancelar Res.";
            btnCancelarReserva.UseVisualStyleBackColor = false;
            btnCancelarReserva.Click += btnCancelarReserva_Click;
            // 
            // lstClientesInscritos
            // 
            lstClientesInscritos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstClientesInscritos.Font = new Font("Segoe UI", 9.75F);
            lstClientesInscritos.FormattingEnabled = true;
            lstClientesInscritos.ItemHeight = 21;
            lstClientesInscritos.Location = new Point(6, 147);
            lstClientesInscritos.Margin = new Padding(3, 5, 3, 5);
            lstClientesInscritos.Name = "lstClientesInscritos";
            lstClientesInscritos.Size = new Size(331, 130);
            lstClientesInscritos.TabIndex = 4;
            // 
            // lblInscritos
            // 
            lblInscritos.AutoSize = true;
            lblInscritos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblInscritos.Location = new Point(6, 124);
            lblInscritos.Name = "lblInscritos";
            lblInscritos.Size = new Size(126, 20);
            lblInscritos.TabIndex = 3;
            lblInscritos.Text = "Clientes Inscritos:";
            // 
            // btnReservarCliente
            // 
            btnReservarCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReservarCliente.BackColor = Color.SteelBlue;
            btnReservarCliente.FlatAppearance.BorderSize = 0;
            btnReservarCliente.FlatStyle = FlatStyle.Flat;
            btnReservarCliente.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnReservarCliente.ForeColor = Color.White;
            btnReservarCliente.Location = new Point(240, 80);
            btnReservarCliente.Margin = new Padding(3, 5, 3, 5);
            btnReservarCliente.Name = "btnReservarCliente";
            btnReservarCliente.Size = new Size(103, 40);
            btnReservarCliente.TabIndex = 2;
            btnReservarCliente.Text = "Reservar";
            btnReservarCliente.UseVisualStyleBackColor = false;
            btnReservarCliente.Click += btnReservarCliente_Click;
            // 
            // cmbCliente
            // 
            cmbCliente.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Font = new Font("Segoe UI", 9.75F);
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(11, 40);
            cmbCliente.Margin = new Padding(3, 5, 3, 5);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(331, 29);
            cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblCliente.Location = new Point(11, 20);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(60, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // frmGestionTurnos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(896, 788);
            Controls.Add(gbReservaCliente);
            Controls.Add(gbDetalleTurno);
            Controls.Add(dgvTurnosDia);
            Controls.Add(lblFecha);
            Controls.Add(dtpFechaTurnos);
            Margin = new Padding(3, 5, 3, 5);
            MinimumSize = new Size(912, 824);
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