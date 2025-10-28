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
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFechaAsistencia = new System.Windows.Forms.DateTimePicker();
            this.lblTurno = new System.Windows.Forms.Label();
            this.cmbTurnosDelDia = new System.Windows.Forms.ComboBox();
            this.gbAsistencia = new System.Windows.Forms.GroupBox();
            this.lblInfoCupo = new System.Windows.Forms.Label();
            this.btnGuardarAsistencia = new System.Windows.Forms.Button();
            this.clbClientesInscritos = new System.Windows.Forms.CheckedListBox();
            this.gbAsistencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(12, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(99, 15);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Seleccionar Día:";
            // 
            // dtpFechaAsistencia
            // 
            this.dtpFechaAsistencia.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAsistencia.Location = new System.Drawing.Point(115, 12);
            this.dtpFechaAsistencia.Name = "dtpFechaAsistencia";
            this.dtpFechaAsistencia.Size = new System.Drawing.Size(120, 23);
            this.dtpFechaAsistencia.TabIndex = 1;
           // this.dtpFechaAsistencia.ValueChanged += new System.EventHandler(this.dtpFechaAsistencia_ValueChanged);
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTurno.Location = new System.Drawing.Point(12, 50);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(107, 15);
            this.lblTurno.TabIndex = 2;
            this.lblTurno.Text = "Seleccionar Turno:";
            // 
            // cmbTurnosDelDia
            // 
            this.cmbTurnosDelDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTurnosDelDia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurnosDelDia.FormattingEnabled = true;
            this.cmbTurnosDelDia.Location = new System.Drawing.Point(115, 47);
            this.cmbTurnosDelDia.Name = "cmbTurnosDelDia";
            this.cmbTurnosDelDia.Size = new System.Drawing.Size(457, 23);
            this.cmbTurnosDelDia.TabIndex = 3;
          //  this.cmbTurnosDelDia.SelectedIndexChanged += new System.EventHandler(this.cmbTurnosDelDia_SelectedIndexChanged);
            // 
            // gbAsistencia
            // 
            this.gbAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAsistencia.Controls.Add(this.lblInfoCupo);
            this.gbAsistencia.Controls.Add(this.btnGuardarAsistencia);
            this.gbAsistencia.Controls.Add(this.clbClientesInscritos);
            this.gbAsistencia.Enabled = false; // Inicia deshabilitado
            this.gbAsistencia.Location = new System.Drawing.Point(12, 85);
            this.gbAsistencia.Name = "gbAsistencia";
            this.gbAsistencia.Size = new System.Drawing.Size(560, 364);
            this.gbAsistencia.TabIndex = 4;
            this.gbAsistencia.TabStop = false;
            this.gbAsistencia.Text = "Marcar Asistencia (Presente)";
            // 
            // lblInfoCupo
            // 
            this.lblInfoCupo.AutoSize = true;
            this.lblInfoCupo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblInfoCupo.Location = new System.Drawing.Point(6, 25);
            this.lblInfoCupo.Name = "lblInfoCupo";
            this.lblInfoCupo.Size = new System.Drawing.Size(91, 15);
            this.lblInfoCupo.TabIndex = 2;
            this.lblInfoCupo.Text = "Inscritos: 0 / 0";
            // 
            // btnGuardarAsistencia
            // 
            this.btnGuardarAsistencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarAsistencia.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGuardarAsistencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAsistencia.Location = new System.Drawing.Point(6, 310);
            this.btnGuardarAsistencia.Name = "btnGuardarAsistencia";
            this.btnGuardarAsistencia.Size = new System.Drawing.Size(548, 45);
            this.btnGuardarAsistencia.TabIndex = 1;
            this.btnGuardarAsistencia.Text = "Guardar Asistencia";
            this.btnGuardarAsistencia.UseVisualStyleBackColor = false;
           // this.btnGuardarAsistencia.Click +=btnGuardarAsistencia_Click;
            // 
            // clbClientesInscritos
            // 
            this.clbClientesInscritos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbClientesInscritos.CheckOnClick = true;
            this.clbClientesInscritos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clbClientesInscritos.FormattingEnabled = true;
            this.clbClientesInscritos.Location = new System.Drawing.Point(6, 45);
            this.clbClientesInscritos.Name = "clbClientesInscritos";
            this.clbClientesInscritos.Size = new System.Drawing.Size(548, 264);
            this.clbClientesInscritos.TabIndex = 0;
            // 
            // frmRegistroAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.gbAsistencia);
            this.Controls.Add(this.cmbTurnosDelDia);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.dtpFechaAsistencia);
            this.Controls.Add(this.lblFecha);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "frmRegistroAsistencia";
            this.Text = "Registro de Asistencia";
         //   this.Load += new System.EventHandler(this.frmRegistroAsistencia_Load);
            this.gbAsistencia.ResumeLayout(false);
            this.gbAsistencia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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