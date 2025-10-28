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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            pnlFiltros = new Panel();
            pnlKPIs = new Panel();
            lblDescKPITotalLiquidado = new Label();
            lblKPITotalLiquidado = new Label();
            lblDescKPIAsistenciasPeriodo = new Label();
            lblKPIAsistenciasPeriodo = new Label();
            lblDescKPIProfesionalesActivos = new Label();
            lblKPIProfesionalesActivos = new Label();
            lblDescKPIClientesActivos = new Label();
            lblKPIClientesActivos = new Label();
            tableLayoutPanelDashboard = new TableLayoutPanel();
            pnlOcupacion = new Panel();
            pnlIngresos = new Panel();
            pnlClientes = new Panel();
            pnlRendimiento = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvClientesFrecuentes).BeginInit();
            pnlFiltros.SuspendLayout();
            pnlKPIs.SuspendLayout();
            tableLayoutPanelDashboard.SuspendLayout();
            pnlOcupacion.SuspendLayout();
            pnlIngresos.SuspendLayout();
            pnlClientes.SuspendLayout();
            pnlRendimiento.SuspendLayout();
            SuspendLayout();
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(65, 14);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(100, 27);
            dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(229, 14);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(100, 27);
            dtpHasta.TabIndex = 1;
            // 
            // btnActualizarDashboard
            // 
            btnActualizarDashboard.Location = new Point(345, 12);
            btnActualizarDashboard.Name = "btnActualizarDashboard";
            btnActualizarDashboard.Size = new Size(100, 28);
            btnActualizarDashboard.TabIndex = 2;
            btnActualizarDashboard.Text = "Actualizar";
            btnActualizarDashboard.UseVisualStyleBackColor = true;
            btnActualizarDashboard.Click += btnActualizarDashboard_Click;
            // 
            // dgvClientesFrecuentes
            // 
            dgvClientesFrecuentes.AllowUserToAddRows = false;
            dgvClientesFrecuentes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvClientesFrecuentes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientesFrecuentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientesFrecuentes.Dock = DockStyle.Fill;
            dgvClientesFrecuentes.Location = new Point(5, 33);
            dgvClientesFrecuentes.Name = "dgvClientesFrecuentes";
            dgvClientesFrecuentes.ReadOnly = true;
            dgvClientesFrecuentes.RowHeadersVisible = false;
            dgvClientesFrecuentes.RowHeadersWidth = 51;
            dgvClientesFrecuentes.Size = new Size(576, 179);
            dgvClientesFrecuentes.TabIndex = 5;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(13, 18);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 7;
            lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(181, 18);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 8;
            lblHasta.Text = "Hasta:";
            // 
            // lblTituloOcupacion
            // 
            lblTituloOcupacion.AutoSize = true;
            lblTituloOcupacion.Dock = DockStyle.Top;
            lblTituloOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloOcupacion.Location = new Point(5, 5);
            lblTituloOcupacion.Name = "lblTituloOcupacion";
            lblTituloOcupacion.Padding = new Padding(0, 0, 0, 8);
            lblTituloOcupacion.Size = new Size(167, 28);
            lblTituloOcupacion.TabIndex = 9;
            lblTituloOcupacion.Text = "Ocupación Actividades";
            // 
            // lblTituloIngresos
            // 
            lblTituloIngresos.AutoSize = true;
            lblTituloIngresos.Dock = DockStyle.Top;
            lblTituloIngresos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloIngresos.Location = new Point(5, 5);
            lblTituloIngresos.Name = "lblTituloIngresos";
            lblTituloIngresos.Padding = new Padding(0, 0, 0, 8);
            lblTituloIngresos.Size = new Size(165, 28);
            lblTituloIngresos.TabIndex = 10;
            lblTituloIngresos.Text = "Liquidaciones por Mes";
            // 
            // lblTituloClientes
            // 
            lblTituloClientes.AutoSize = true;
            lblTituloClientes.Dock = DockStyle.Top;
            lblTituloClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloClientes.Location = new Point(5, 5);
            lblTituloClientes.Name = "lblTituloClientes";
            lblTituloClientes.Padding = new Padding(0, 0, 0, 8);
            lblTituloClientes.Size = new Size(174, 28);
            lblTituloClientes.TabIndex = 11;
            lblTituloClientes.Text = "Top Clientes Frecuentes";
            // 
            // lblTituloRendimiento
            // 
            lblTituloRendimiento.AutoSize = true;
            lblTituloRendimiento.Dock = DockStyle.Top;
            lblTituloRendimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloRendimiento.Location = new Point(5, 5);
            lblTituloRendimiento.Name = "lblTituloRendimiento";
            lblTituloRendimiento.Padding = new Padding(0, 0, 0, 8);
            lblTituloRendimiento.Size = new Size(197, 28);
            lblTituloRendimiento.TabIndex = 12;
            lblTituloRendimiento.Text = "Rendimiento Profesionales";
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(btnActualizarDashboard);
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Location = new Point(0, 0);
            pnlFiltros.Name = "pnlFiltros";
            pnlFiltros.Padding = new Padding(10);
            pnlFiltros.Size = new Size(1184, 55);
            pnlFiltros.TabIndex = 13;
            // 
            // pnlKPIs
            // 
            pnlKPIs.BackColor = SystemColors.ControlLight;
            pnlKPIs.Controls.Add(lblDescKPITotalLiquidado);
            pnlKPIs.Controls.Add(lblKPITotalLiquidado);
            pnlKPIs.Controls.Add(lblDescKPIAsistenciasPeriodo);
            pnlKPIs.Controls.Add(lblKPIAsistenciasPeriodo);
            pnlKPIs.Controls.Add(lblDescKPIProfesionalesActivos);
            pnlKPIs.Controls.Add(lblKPIProfesionalesActivos);
            pnlKPIs.Controls.Add(lblDescKPIClientesActivos);
            pnlKPIs.Controls.Add(lblKPIClientesActivos);
            pnlKPIs.Dock = DockStyle.Top;
            pnlKPIs.Location = new Point(0, 55);
            pnlKPIs.Name = "pnlKPIs";
            pnlKPIs.Size = new Size(1184, 60);
            pnlKPIs.TabIndex = 14;
            // 
            // lblDescKPITotalLiquidado
            // 
            lblDescKPITotalLiquidado.AutoSize = true;
            lblDescKPITotalLiquidado.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescKPITotalLiquidado.Location = new Point(510, 10);
            lblDescKPITotalLiquidado.Name = "lblDescKPITotalLiquidado";
            lblDescKPITotalLiquidado.Size = new Size(171, 20);
            lblDescKPITotalLiquidado.TabIndex = 6;
            lblDescKPITotalLiquidado.Text = "Total Liquidado Período";
            // 
            // lblKPITotalLiquidado
            // 
            lblKPITotalLiquidado.AutoSize = true;
            lblKPITotalLiquidado.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKPITotalLiquidado.Location = new Point(508, 28);
            lblKPITotalLiquidado.Name = "lblKPITotalLiquidado";
            lblKPITotalLiquidado.Size = new Size(77, 32);
            lblKPITotalLiquidado.TabIndex = 7;
            lblKPITotalLiquidado.Text = "$0.00";
            // 
            // lblDescKPIAsistenciasPeriodo
            // 
            lblDescKPIAsistenciasPeriodo.AutoSize = true;
            lblDescKPIAsistenciasPeriodo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescKPIAsistenciasPeriodo.Location = new Point(340, 10);
            lblDescKPIAsistenciasPeriodo.Name = "lblDescKPIAsistenciasPeriodo";
            lblDescKPIAsistenciasPeriodo.Size = new Size(139, 20);
            lblDescKPIAsistenciasPeriodo.TabIndex = 4;
            lblDescKPIAsistenciasPeriodo.Text = "Asistencias Período";
            // 
            // lblKPIAsistenciasPeriodo
            // 
            lblKPIAsistenciasPeriodo.AutoSize = true;
            lblKPIAsistenciasPeriodo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKPIAsistenciasPeriodo.Location = new Point(338, 28);
            lblKPIAsistenciasPeriodo.Name = "lblKPIAsistenciasPeriodo";
            lblKPIAsistenciasPeriodo.Size = new Size(28, 32);
            lblKPIAsistenciasPeriodo.TabIndex = 5;
            lblKPIAsistenciasPeriodo.Text = "0";
            // 
            // lblDescKPIProfesionalesActivos
            // 
            lblDescKPIProfesionalesActivos.AutoSize = true;
            lblDescKPIProfesionalesActivos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblDescKPIProfesionalesActivos.Location = new Point(170, 10);
            lblDescKPIProfesionalesActivos.Name = "lblDescKPIProfesionalesActivos";
            lblDescKPIProfesionalesActivos.Size = new Size(153, 20);
            lblDescKPIProfesionalesActivos.TabIndex = 2;
            lblDescKPIProfesionalesActivos.Text = "Profesionales Activos";
            // 
            // lblKPIProfesionalesActivos
            // 
            lblKPIProfesionalesActivos.AutoSize = true;
            lblKPIProfesionalesActivos.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKPIProfesionalesActivos.Location = new Point(168, 28);
            lblKPIProfesionalesActivos.Name = "lblKPIProfesionalesActivos";
            lblKPIProfesionalesActivos.Size = new Size(28, 32);
            lblKPIProfesionalesActivos.TabIndex = 3;
            lblKPIProfesionalesActivos.Text = "0";
            // 
            // lblDescKPIClientesActivos
            // 
            lblDescKPIClientesActivos.AutoSize = true;
            lblDescKPIClientesActivos.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescKPIClientesActivos.Location = new Point(20, 10);
            lblDescKPIClientesActivos.Name = "lblDescKPIClientesActivos";
            lblDescKPIClientesActivos.Size = new Size(115, 20);
            lblDescKPIClientesActivos.TabIndex = 0;
            lblDescKPIClientesActivos.Text = "Clientes Activos";
            // 
            // lblKPIClientesActivos
            // 
            lblKPIClientesActivos.AutoSize = true;
            lblKPIClientesActivos.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblKPIClientesActivos.Location = new Point(18, 28);
            lblKPIClientesActivos.Name = "lblKPIClientesActivos";
            lblKPIClientesActivos.Size = new Size(28, 32);
            lblKPIClientesActivos.TabIndex = 1;
            lblKPIClientesActivos.Text = "0";
            // 
            // tableLayoutPanelDashboard
            // 
            tableLayoutPanelDashboard.ColumnCount = 2;
            tableLayoutPanelDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDashboard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelDashboard.Controls.Add(pnlOcupacion, 0, 0);
            tableLayoutPanelDashboard.Controls.Add(pnlIngresos, 1, 0);
            tableLayoutPanelDashboard.Controls.Add(pnlClientes, 0, 1);
            tableLayoutPanelDashboard.Controls.Add(pnlRendimiento, 1, 1);
            tableLayoutPanelDashboard.Dock = DockStyle.Fill;
            tableLayoutPanelDashboard.Location = new Point(0, 115);
            tableLayoutPanelDashboard.Name = "tableLayoutPanelDashboard";
            tableLayoutPanelDashboard.RowCount = 2;
            tableLayoutPanelDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDashboard.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelDashboard.Size = new Size(1184, 446);
            tableLayoutPanelDashboard.TabIndex = 15;
            // 
            // pnlOcupacion
            // 
            pnlOcupacion.Controls.Add(lblTituloOcupacion);
            pnlOcupacion.Dock = DockStyle.Fill;
            pnlOcupacion.Location = new Point(3, 3);
            pnlOcupacion.Name = "pnlOcupacion";
            pnlOcupacion.Padding = new Padding(5);
            pnlOcupacion.Size = new Size(586, 217);
            pnlOcupacion.TabIndex = 0;
            // 
            // pnlIngresos
            // 
            pnlIngresos.Controls.Add(lblTituloIngresos);
            pnlIngresos.Dock = DockStyle.Fill;
            pnlIngresos.Location = new Point(595, 3);
            pnlIngresos.Name = "pnlIngresos";
            pnlIngresos.Padding = new Padding(5);
            pnlIngresos.Size = new Size(586, 217);
            pnlIngresos.TabIndex = 1;
            // 
            // pnlClientes
            // 
            pnlClientes.Controls.Add(dgvClientesFrecuentes);
            pnlClientes.Controls.Add(lblTituloClientes);
            pnlClientes.Dock = DockStyle.Fill;
            pnlClientes.Location = new Point(3, 226);
            pnlClientes.Name = "pnlClientes";
            pnlClientes.Padding = new Padding(5);
            pnlClientes.Size = new Size(586, 217);
            pnlClientes.TabIndex = 2;
            // 
            // pnlRendimiento
            // 
            pnlRendimiento.Controls.Add(lblTituloRendimiento);
            pnlRendimiento.Dock = DockStyle.Fill;
            pnlRendimiento.Location = new Point(595, 226);
            pnlRendimiento.Name = "pnlRendimiento";
            pnlRendimiento.Padding = new Padding(5);
            pnlRendimiento.Size = new Size(586, 217);
            pnlRendimiento.TabIndex = 3;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 561);
            Controls.Add(tableLayoutPanelDashboard);
            Controls.Add(pnlKPIs);
            Controls.Add(pnlFiltros);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmDashboard";
            Text = "Dashboard Gerencial - ProGym";
            Load += frmDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientesFrecuentes).EndInit();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlKPIs.ResumeLayout(false);
            pnlKPIs.PerformLayout();
            tableLayoutPanelDashboard.ResumeLayout(false);
            pnlOcupacion.ResumeLayout(false);
            pnlOcupacion.PerformLayout();
            pnlIngresos.ResumeLayout(false);
            pnlIngresos.PerformLayout();
            pnlClientes.ResumeLayout(false);
            pnlClientes.PerformLayout();
            pnlRendimiento.ResumeLayout(false);
            pnlRendimiento.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Panel pnlKPIs;
        private System.Windows.Forms.Label lblDescKPIClientesActivos;
        private System.Windows.Forms.Label lblKPIClientesActivos;
        private System.Windows.Forms.Label lblDescKPIProfesionalesActivos;
        private System.Windows.Forms.Label lblKPIProfesionalesActivos;
        private System.Windows.Forms.Label lblDescKPIAsistenciasPeriodo;
        private System.Windows.Forms.Label lblKPIAsistenciasPeriodo;
        private System.Windows.Forms.Label lblDescKPITotalLiquidado;
        private System.Windows.Forms.Label lblKPITotalLiquidado;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDashboard;
        private System.Windows.Forms.Panel pnlOcupacion;
        private System.Windows.Forms.Panel pnlIngresos;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Panel pnlRendimiento;
    }
}