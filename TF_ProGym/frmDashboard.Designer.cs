namespace CapaPresentacion
{
    partial class frmDashboard
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
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            btnActualizarDashboard = new Button();
            dgvClientesFrecuentes = new DataGridView();
            lblDesde = new Label();
            lblHasta = new Label();
            lblTituloOcupacion = new Label();
            lblTituloIngresos = new Label();
            lblTituloClientes = new Label();
            lblTituloRendimiento = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientesFrecuentes).BeginInit();
            SuspendLayout();
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(63, 16);
            dtpDesde.Margin = new Padding(3, 4, 3, 4);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(114, 27);
            dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(234, 16);
            dtpHasta.Margin = new Padding(3, 4, 3, 4);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(114, 27);
            dtpHasta.TabIndex = 1;
            // 
            // btnActualizarDashboard
            // 
            btnActualizarDashboard.Location = new Point(366, 15);
            btnActualizarDashboard.Margin = new Padding(3, 4, 3, 4);
            btnActualizarDashboard.Name = "btnActualizarDashboard";
            btnActualizarDashboard.Size = new Size(114, 33);
            btnActualizarDashboard.TabIndex = 2;
            btnActualizarDashboard.Text = "Actualizar";
            btnActualizarDashboard.UseVisualStyleBackColor = true;
            // 
            // dgvClientesFrecuentes
            // 
            dgvClientesFrecuentes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvClientesFrecuentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientesFrecuentes.Location = new Point(14, 380);
            dgvClientesFrecuentes.Margin = new Padding(3, 4, 3, 4);
            dgvClientesFrecuentes.Name = "dgvClientesFrecuentes";
            dgvClientesFrecuentes.RowHeadersWidth = 51;
            dgvClientesFrecuentes.RowTemplate.Height = 25;
            dgvClientesFrecuentes.Size = new Size(429, 299);
            dgvClientesFrecuentes.TabIndex = 5;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(14, 21);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 7;
            lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(189, 21);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 8;
            lblHasta.Text = "Hasta:";
            // 
            // lblTituloOcupacion
            // 
            lblTituloOcupacion.AutoSize = true;
            lblTituloOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloOcupacion.Location = new Point(14, 56);
            lblTituloOcupacion.Name = "lblTituloOcupacion";
            lblTituloOcupacion.Size = new Size(137, 20);
            lblTituloOcupacion.TabIndex = 9;
            lblTituloOcupacion.Text = "Ocupación por Día";
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTituloIngresos.AutoSize = true;
            lblTituloIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloIngresos.Location = new Point(992, 56);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Size = new Size(190, 20);
            lblTituloIngresos.TabIndex = 10;
            lblTituloIngresos.Text = "Liquidaciones por Periodo";
            // 
            // lblTituloClientes
            // 
            lblTituloClientes.AutoSize = true;
            lblTituloClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloClientes.Location = new Point(14, 356);
            lblTituloClientes.Name = "lblTituloClientes";
            lblTituloClientes.Size = new Size(174, 20);
            lblTituloClientes.TabIndex = 11;
            lblTituloClientes.Text = "Top Clientes Frecuentes";
            // 
            // lblTituloRendimiento
            // 
            lblTituloRendimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTituloRendimiento.AutoSize = true;
            lblTituloRendimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloRendimiento.Location = new Point(992, 356);
            lblTituloRendimiento.Name = "lblTituloRendimiento";
            lblTituloRendimiento.Size = new Size(197, 20);
            lblTituloRendimiento.TabIndex = 12;
            lblTituloRendimiento.Text = "Rendimiento Profesionales";
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1431, 693);
            Controls.Add(lblTituloRendimiento);
            Controls.Add(lblTituloClientes);
            Controls.Add(lblTituloIngresos);
            Controls.Add(lblTituloOcupacion);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(dgvClientesFrecuentes);
            Controls.Add(btnActualizarDashboard);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDashboard";
            Text = "Dashboard Gerencial";
            Load += frmDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientesFrecuentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnActualizarDashboard;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOcupacion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresos;
        private System.Windows.Forms.DataGridView dgvClientesFrecuentes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRendimientoProf;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblTituloOcupacion;
        private System.Windows.Forms.Label lblTituloIngresos;
        private System.Windows.Forms.Label lblTituloClientes;
        private System.Windows.Forms.Label lblTituloRendimiento;
    }
}