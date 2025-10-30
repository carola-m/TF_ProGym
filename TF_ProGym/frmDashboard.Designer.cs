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
            // --- INICIO: Definiciones de Gráficos (¡Importante!) ---
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            // --- FIN: Definiciones de Gráficos ---

            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnActualizarDashboard = new System.Windows.Forms.Button();
            this.dgvClientesFrecuentes = new System.Windows.Forms.DataGridView();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblTituloOcupacion = new System.Windows.Forms.Label();
            this.lblTituloIngresos = new System.Windows.Forms.Label();
            this.lblTituloClientes = new System.Windows.Forms.Label();
            this.lblTituloRendimiento = new System.Windows.Forms.Label();
            this.panelKPIClientes = new System.Windows.Forms.Panel();
            this.lblKPIClientesActivos = new System.Windows.Forms.Label();
            this.lblKPIClientesTitulo = new System.Windows.Forms.Label();
            this.panelKPIProfesionales = new System.Windows.Forms.Panel();
            this.lblKPIProfesionalesActivos = new System.Windows.Forms.Label();
            this.lblKPIProfesionalesTitulo = new System.Windows.Forms.Label();
            this.panelKPIAsistencias = new System.Windows.Forms.Panel();
            this.lblKPIAsistenciasPeriodo = new System.Windows.Forms.Label();
            this.lblKPIAsistenciasTitulo = new System.Windows.Forms.Label();
            this.panelKPILiquidado = new System.Windows.Forms.Panel();
            this.lblKPITotalLiquidado = new System.Windows.Forms.Label();
            this.lblKPILiquidadoTitulo = new System.Windows.Forms.Label();

            // --- INICIO: Declaración de Controles de Gráfico ---
            this.chartOcupacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartIngresos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRendimientoProf = new System.Windows.Forms.DataVisualization.Charting.Chart();
            // --- FIN: Declaración de Controles de Gráfico ---

            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesFrecuentes)).BeginInit();
            this.panelKPIClientes.SuspendLayout();
            this.panelKPIProfesionales.SuspendLayout();
            this.panelKPIAsistencias.SuspendLayout();
            this.panelKPILiquidado.SuspendLayout();
            // --- INICIO: Inicialización de Gráficos ---
            ((System.ComponentModel.ISupportInitialize)(this.chartOcupacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimientoProf)).BeginInit();
            // --- FIN: Inicialización de Gráficos ---
            this.SuspendLayout();
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(446, 22);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(114, 27);
            this.dtpDesde.TabIndex = 0;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(623, 22);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(114, 27);
            this.dtpHasta.TabIndex = 1;
            // 
            // btnActualizarDashboard
            // 
            this.btnActualizarDashboard.Location = new System.Drawing.Point(752, 16);
            this.btnActualizarDashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActualizarDashboard.Name = "btnActualizarDashboard";
            this.btnActualizarDashboard.Size = new System.Drawing.Size(114, 33);
            this.btnActualizarDashboard.TabIndex = 2;
            this.btnActualizarDashboard.Text = "Actualizar";
            this.btnActualizarDashboard.UseVisualStyleBackColor = true;
            this.btnActualizarDashboard.Click += new System.EventHandler(this.btnActualizarDashboard_Click);
            // 
            // dgvClientesFrecuentes
            // 
            this.dgvClientesFrecuentes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvClientesFrecuentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesFrecuentes.Location = new System.Drawing.Point(14, 433);
            this.dgvClientesFrecuentes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvClientesFrecuentes.Name = "dgvClientesFrecuentes";
            this.dgvClientesFrecuentes.RowHeadersWidth = 51;
            this.dgvClientesFrecuentes.RowTemplate.Height = 25;
            this.dgvClientesFrecuentes.Size = new System.Drawing.Size(429, 193);
            this.dgvClientesFrecuentes.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(389, 27);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(54, 20);
            this.lblDesde.TabIndex = 7;
            this.lblDesde.Text = "Desde:";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(567, 27);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(50, 20);
            this.lblHasta.TabIndex = 8;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblTituloOcupacion
            // 
            this.lblTituloOcupacion.AutoSize = true;
            this.lblTituloOcupacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloOcupacion.Location = new System.Drawing.Point(14, 136);
            this.lblTituloOcupacion.Name = "lblTituloOcupacion";
            this.lblTituloOcupacion.Size = new System.Drawing.Size(180, 20);
            this.lblTituloOcupacion.TabIndex = 9;
            this.lblTituloOcupacion.Text = "Ocupación por Actividad";
            // 
            // lblTituloIngresos
            // 
            this.lblTituloIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloIngresos.AutoSize = true;
            this.lblTituloIngresos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloIngresos.Location = new System.Drawing.Point(457, 136);
            this.lblTituloIngresos.Name = "lblTituloIngresos";
            this.lblTituloIngresos.Size = new System.Drawing.Size(190, 20);
            this.lblTituloIngresos.TabIndex = 10;
            this.lblTituloIngresos.Text = "Liquidaciones por Periodo";
            // 
            // lblTituloClientes
            // 
            this.lblTituloClientes.AutoSize = true;
            this.lblTituloClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloClientes.Location = new System.Drawing.Point(14, 409);
            this.lblTituloClientes.Name = "lblTituloClientes";
            this.lblTituloClientes.Size = new System.Drawing.Size(174, 20);
            this.lblTituloClientes.TabIndex = 11;
            this.lblTituloClientes.Text = "Top Clientes Frecuentes";
            // 
            // lblTituloRendimiento
            // 
            this.lblTituloRendimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloRendimiento.AutoSize = true;
            this.lblTituloRendimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTituloRendimiento.Location = new System.Drawing.Point(457, 409);
            this.lblTituloRendimiento.Name = "lblTituloRendimiento";
            this.lblTituloRendimiento.Size = new System.Drawing.Size(197, 20);
            this.lblTituloRendimiento.TabIndex = 12;
            this.lblTituloRendimiento.Text = "Rendimiento Profesionales";
            // 
            // panelKPIClientes
            // 
            this.panelKPIClientes.BackColor = System.Drawing.Color.White;
            this.panelKPIClientes.Controls.Add(this.lblKPIClientesActivos);
            this.panelKPIClientes.Controls.Add(this.lblKPIClientesTitulo);
            this.panelKPIClientes.Location = new System.Drawing.Point(14, 60);
            this.panelKPIClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelKPIClientes.Name = "panelKPIClientes";
            this.panelKPIClientes.Size = new System.Drawing.Size(206, 67);
            this.panelKPIClientes.TabIndex = 13;
            // 
            // lblKPIClientesActivos
            // 
            this.lblKPIClientesActivos.AutoSize = true;
            this.lblKPIClientesActivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKPIClientesActivos.Location = new System.Drawing.Point(6, 27);
            this.lblKPIClientesActivos.Name = "lblKPIClientesActivos";
            this.lblKPIClientesActivos.Size = new System.Drawing.Size(24, 28);
            this.lblKPIClientesActivos.TabIndex = 1;
            this.lblKPIClientesActivos.Text = "0";
            // 
            // lblKPIClientesTitulo
            // 
            this.lblKPIClientesTitulo.AutoSize = true;
            this.lblKPIClientesTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKPIClientesTitulo.Location = new System.Drawing.Point(6, 7);
            this.lblKPIClientesTitulo.Name = "lblKPIClientesTitulo";
            this.lblKPIClientesTitulo.Size = new System.Drawing.Size(105, 19);
            this.lblKPIClientesTitulo.TabIndex = 0;
            this.lblKPIClientesTitulo.Text = "Clientes Activos";
            // 
            // panelKPIProfesionales
            // 
            this.panelKPIProfesionales.BackColor = System.Drawing.Color.White;
            this.panelKPIProfesionales.Controls.Add(this.lblKPIProfesionalesActivos);
            this.panelKPIProfesionales.Controls.Add(this.lblKPIProfesionalesTitulo);
            this.panelKPIProfesionales.Location = new System.Drawing.Point(229, 60);
            this.panelKPIProfesionales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelKPIProfesionales.Name = "panelKPIProfesionales";
            this.panelKPIProfesionales.Size = new System.Drawing.Size(206, 67);
            this.panelKPIProfesionales.TabIndex = 14;
            // 
            // lblKPIProfesionalesActivos
            // 
            this.lblKPIProfesionalesActivos.AutoSize = true;
            this.lblKPIProfesionalesActivos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKPIProfesionalesActivos.Location = new System.Drawing.Point(6, 27);
            this.lblKPIProfesionalesActivos.Name = "lblKPIProfesionalesActivos";
            this.lblKPIProfesionalesActivos.Size = new System.Drawing.Size(24, 28);
            this.lblKPIProfesionalesActivos.TabIndex = 1;
            this.lblKPIProfesionalesActivos.Text = "0";
            // 
            // lblKPIProfesionalesTitulo
            // 
            this.lblKPIProfesionalesTitulo.AutoSize = true;
            this.lblKPIProfesionalesTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKPIProfesionalesTitulo.Location = new System.Drawing.Point(6, 7);
            this.lblKPIProfesionalesTitulo.Name = "lblKPIProfesionalesTitulo";
            this.lblKPIProfesionalesTitulo.Size = new System.Drawing.Size(137, 19);
            this.lblKPIProfesionalesTitulo.TabIndex = 0;
            this.lblKPIProfesionalesTitulo.Text = "Profesionales Activos";
            // 
            // panelKPIAsistencias
            // 
            this.panelKPIAsistencias.BackColor = System.Drawing.Color.White;
            this.panelKPIAsistencias.Controls.Add(this.lblKPIAsistenciasPeriodo);
            this.panelKPIAsistencias.Controls.Add(this.lblKPIAsistenciasTitulo);
            this.panelKPIAsistencias.Location = new System.Drawing.Point(446, 60);
            this.panelKPIAsistencias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelKPIAsistencias.Name = "panelKPIAsistencias";
            this.panelKPIAsistencias.Size = new System.Drawing.Size(206, 67);
            this.panelKPIAsistencias.TabIndex = 15;
            // 
            // lblKPIAsistenciasPeriodo
            // 
            this.lblKPIAsistenciasPeriodo.AutoSize = true;
            this.lblKPIAsistenciasPeriodo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKPIAsistenciasPeriodo.Location = new System.Drawing.Point(6, 27);
            this.lblKPIAsistenciasPeriodo.Name = "lblKPIAsistenciasPeriodo";
            this.lblKPIAsistenciasPeriodo.Size = new System.Drawing.Size(24, 28);
            this.lblKPIAsistenciasPeriodo.TabIndex = 1;
            this.lblKPIAsistenciasPeriodo.Text = "0";
            // 
            // lblKPIAsistenciasTitulo
            // 
            this.lblKPIAsistenciasTitulo.AutoSize = true;
            this.lblKPIAsistenciasTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKPIAsistenciasTitulo.Location = new System.Drawing.Point(6, 7);
            this.lblKPIAsistenciasTitulo.Name = "lblKPIAsistenciasTitulo";
            this.lblKPIAsistenciasTitulo.Size = new System.Drawing.Size(133, 19);
            this.lblKPIAsistenciasTitulo.TabIndex = 0;
            this.lblKPIAsistenciasTitulo.Text = "Asistencias (Periodo)";
            // 
            // panelKPILiquidado
            // 
            this.panelKPILiquidado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKPILiquidado.BackColor = System.Drawing.Color.White;
            this.panelKPILiquidado.Controls.Add(this.lblKPITotalLiquidado);
            this.panelKPILiquidado.Controls.Add(this.lblKPILiquidadoTitulo);
            this.panelKPILiquidado.Location = new System.Drawing.Point(680, 60);
            this.panelKPILiquidado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelKPILiquidado.Name = "panelKPILiquidado";
            this.panelKPILiquidado.Size = new System.Drawing.Size(206, 67);
            this.panelKPILiquidado.TabIndex = 16;
            // 
            // lblKPITotalLiquidado
            // 
            this.lblKPITotalLiquidado.AutoSize = true;
            this.lblKPITotalLiquidado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKPITotalLiquidado.Location = new System.Drawing.Point(6, 27);
            this.lblKPITotalLiquidado.Name = "lblKPITotalLiquidado";
            this.lblKPITotalLiquidado.Size = new System.Drawing.Size(36, 28);
            this.lblKPITotalLiquidado.TabIndex = 1;
            this.lblKPITotalLiquidado.Text = "$0";
            // 
            // lblKPILiquidadoTitulo
            // 
            this.lblKPILiquidadoTitulo.AutoSize = true;
            this.lblKPILiquidadoTitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblKPILiquidadoTitulo.Location = new System.Drawing.Point(6, 7);
            this.lblKPILiquidadoTitulo.Name = "lblKPILiquidadoTitulo";
            this.lblKPILiquidadoTitulo.Size = new System.Drawing.Size(136, 19);
            this.lblKPILiquidadoTitulo.TabIndex = 0;
            this.lblKPILiquidadoTitulo.Text = "Total Liquidado (Per.)";
            // 
            // --- INICIO: Definición de Gráficos ---
            // 
            // chartOcupacion
            // 
            this.chartOcupacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartOcupacion.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartOcupacion.Legends.Add(legend1);
            this.chartOcupacion.Location = new System.Drawing.Point(12, 160);
            this.chartOcupacion.Name = "chartOcupacion";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartOcupacion.Series.Add(series1);
            this.chartOcupacion.Size = new System.Drawing.Size(431, 240);
            this.chartOcupacion.TabIndex = 3;
            this.chartOcupacion.Text = "Ocupación por Día";
            // 
            // chartIngresos
            // 
            this.chartIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartIngresos.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartIngresos.Legends.Add(legend2);
            this.chartIngresos.Location = new System.Drawing.Point(457, 160);
            this.chartIngresos.Name = "chartIngresos";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartIngresos.Series.Add(series2);
            this.chartIngresos.Size = new System.Drawing.Size(429, 240);
            this.chartIngresos.TabIndex = 4;
            this.chartIngresos.Text = "Ingresos por Mes";
            // 
            // chartRendimientoProf
            // 
            this.chartRendimientoProf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartRendimientoProf.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartRendimientoProf.Legends.Add(legend3);
            this.chartRendimientoProf.Location = new System.Drawing.Point(457, 433);
            this.chartRendimientoProf.Name = "chartRendimientoProf";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartRendimientoProf.Series.Add(series3);
            this.chartRendimientoProf.Size = new System.Drawing.Size(429, 193);
            this.chartRendimientoProf.TabIndex = 6;
            this.chartRendimientoProf.Text = "Rendimiento Profesionales";
            // --- FIN: Definición de Gráficos ---
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F); // .NET 8
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 641);
            this.Controls.Add(this.panelKPILiquidado);
            this.Controls.Add(this.panelKPIAsistencias);
            this.Controls.Add(this.panelKPIProfesionales);
            this.Controls.Add(this.panelKPIClientes);
            this.Controls.Add(this.lblTituloRendimiento);
            this.Controls.Add(this.lblTituloClientes);
            this.Controls.Add(this.lblTituloIngresos);
            this.Controls.Add(this.lblTituloOcupacion);
            this.Controls.Add(this.lblHasta);
            this.Controls.Add(this.lblDesde);
            this.Controls.Add(this.dgvClientesFrecuentes);
            this.Controls.Add(this.btnActualizarDashboard);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.chartOcupacion); // Añadido
            this.Controls.Add(this.chartIngresos); // Añadido
            this.Controls.Add(this.chartRendimientoProf); // Añadido
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDashboard";
            this.Text = "Dashboard Gerencial";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesFrecuentes)).EndInit();
            this.panelKPIClientes.ResumeLayout(false);
            this.panelKPIClientes.PerformLayout();
            this.panelKPIProfesionales.ResumeLayout(false);
            this.panelKPIProfesionales.PerformLayout();
            this.panelKPIAsistencias.ResumeLayout(false);
            this.panelKPIAsistencias.PerformLayout();
            this.panelKPILiquidado.ResumeLayout(false);
            this.panelKPILiquidado.PerformLayout();
            // --- INICIO: Finalización de Gráficos ---
            ((System.ComponentModel.ISupportInitialize)(this.chartOcupacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimientoProf)).EndInit();
            // --- FIN: Finalización de Gráficos ---
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnActualizarDashboard;
        private System.Windows.Forms.DataGridView dgvClientesFrecuentes;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblTituloOcupacion;
        private System.Windows.Forms.Label lblTituloIngresos;
        private System.Windows.Forms.Label lblTituloClientes;
        private System.Windows.Forms.Label lblTituloRendimiento;
        // --- Variables de KPIs ---
        private System.Windows.Forms.Panel panelKPIClientes;
        private System.Windows.Forms.Label lblKPIClientesActivos;
        private System.Windows.Forms.Label lblKPIClientesTitulo;
        private System.Windows.Forms.Panel panelKPIProfesionales;
        private System.Windows.Forms.Label lblKPIProfesionalesActivos;
        private System.Windows.Forms.Label lblKPIProfesionalesTitulo;
        private System.Windows.Forms.Panel panelKPIAsistencias;
        private System.Windows.Forms.Label lblKPIAsistenciasPeriodo;
        private System.Windows.Forms.Label lblKPIAsistenciasTitulo;
        private System.Windows.Forms.Panel panelKPILiquidado;
        private System.Windows.Forms.Label lblKPITotalLiquidado;
        private System.Windows.Forms.Label lblKPILiquidadoTitulo;
        // --- Variables de Gráficos ---
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOcupacion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIngresos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRendimientoProf;
    }
}