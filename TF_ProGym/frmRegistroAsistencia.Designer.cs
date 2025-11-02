namespace CapaPresentacion
{
    partial class frmRegistroAsistencia
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
            lblFecha = new Label();
            dtpFechaAsistencia = new DateTimePicker();
            lblTurno = new Label();
            cmbTurnosDelDia = new ComboBox();
            gbAsistencia = new GroupBox();
            lblInfoCupo = new Label();
            btnGuardarAsistencia = new Button();
            clbClientesInscritos = new CheckedListBox();
            gbAsistencia.SuspendLayout();
            SuspendLayout();
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(14, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(118, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Seleccionar Día:";
            // 
            // dtpFechaAsistencia
            // 
            dtpFechaAsistencia.Format = DateTimePickerFormat.Short;
            dtpFechaAsistencia.Location = new Point(131, 16);
            dtpFechaAsistencia.Margin = new Padding(3, 4, 3, 4);
            dtpFechaAsistencia.Name = "dtpFechaAsistencia";
            dtpFechaAsistencia.Size = new Size(137, 27);
            dtpFechaAsistencia.TabIndex = 1;
            dtpFechaAsistencia.ValueChanged += dtpFechaAsistencia_ValueChanged;
            // 
            // lblTurno
            // 
            lblTurno.AutoSize = true;
            lblTurno.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTurno.Location = new Point(14, 67);
            lblTurno.Name = "lblTurno";
            lblTurno.Size = new Size(136, 20);
            lblTurno.TabIndex = 2;
            lblTurno.Text = "Seleccionar Turno:";
            // 
            // cmbTurnosDelDia
            // 
            cmbTurnosDelDia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTurnosDelDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTurnosDelDia.FormattingEnabled = true;
            cmbTurnosDelDia.Location = new Point(155, 64);
            cmbTurnosDelDia.Margin = new Padding(3, 4, 3, 4);
            cmbTurnosDelDia.Name = "cmbTurnosDelDia";
            cmbTurnosDelDia.Size = new Size(492, 28);
            cmbTurnosDelDia.TabIndex = 3;
            cmbTurnosDelDia.SelectedIndexChanged += cmbTurnosDelDia_SelectedIndexChanged;
            // 
            // gbAsistencia
            // 
            gbAsistencia.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbAsistencia.Controls.Add(lblInfoCupo);
            gbAsistencia.Controls.Add(btnGuardarAsistencia);
            gbAsistencia.Controls.Add(clbClientesInscritos);
            gbAsistencia.Enabled = false;
            gbAsistencia.Location = new Point(14, 113);
            gbAsistencia.Margin = new Padding(3, 4, 3, 4);
            gbAsistencia.Name = "gbAsistencia";
            gbAsistencia.Padding = new Padding(3, 4, 3, 4);
            gbAsistencia.Size = new Size(640, 485);
            gbAsistencia.TabIndex = 4;
            gbAsistencia.TabStop = false;
            gbAsistencia.Text = "Marcar Asistencia (Presente)";
            // 
            // lblInfoCupo
            // 
            lblInfoCupo.AutoSize = true;
            lblInfoCupo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInfoCupo.Location = new Point(7, 33);
            lblInfoCupo.Name = "lblInfoCupo";
            lblInfoCupo.Size = new Size(110, 20);
            lblInfoCupo.TabIndex = 2;
            lblInfoCupo.Text = "Inscritos: 0 / 0";
            // 
            // btnGuardarAsistencia
            // 
            btnGuardarAsistencia.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardarAsistencia.BackColor = Color.DarkGreen;
            btnGuardarAsistencia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardarAsistencia.ForeColor = Color.White;
            btnGuardarAsistencia.Location = new Point(7, 413);
            btnGuardarAsistencia.Margin = new Padding(3, 4, 3, 4);
            btnGuardarAsistencia.Name = "btnGuardarAsistencia";
            btnGuardarAsistencia.Size = new Size(626, 60);
            btnGuardarAsistencia.TabIndex = 1;
            btnGuardarAsistencia.Text = "Guardar Asistencia";
            btnGuardarAsistencia.UseVisualStyleBackColor = false;
            btnGuardarAsistencia.Click += btnGuardarAsistencia_Click;
            // 
            // clbClientesInscritos
            // 
            clbClientesInscritos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            clbClientesInscritos.CheckOnClick = true;
            clbClientesInscritos.Font = new Font("Segoe UI", 9.75F);
            clbClientesInscritos.FormattingEnabled = true;
            clbClientesInscritos.Location = new Point(7, 60);
            clbClientesInscritos.Margin = new Padding(3, 4, 3, 4);
            clbClientesInscritos.Name = "clbClientesInscritos";
            clbClientesInscritos.Size = new Size(626, 340);
            clbClientesInscritos.TabIndex = 0;
            // 
            // frmRegistroAsistencia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 615);
            Controls.Add(gbAsistencia);
            Controls.Add(cmbTurnosDelDia);
            Controls.Add(lblTurno);
            Controls.Add(dtpFechaAsistencia);
            Controls.Add(lblFecha);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(455, 384);
            Name = "frmRegistroAsistencia";
            Text = "Registro de Asistencia";
            Load += frmRegistroAsistencia_Load;
            gbAsistencia.ResumeLayout(false);
            gbAsistencia.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaAsistencia;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.ComboBox cmbTurnosDelDia;
        private System.Windows.Forms.GroupBox gbAsistencia;
        private System.Windows.Forms.Button btnGuardarAsistencia;
        private System.Windows.Forms.CheckedListBox clbClientesInscritos;
        private System.Windows.Forms.Label lblInfoCupo;
    }
}