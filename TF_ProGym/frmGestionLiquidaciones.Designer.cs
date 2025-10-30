namespace CapaPresentacion
{
    partial class frmGestionLiquidaciones
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
            this.dgvLiquidaciones = new System.Windows.Forms.DataGridView();
            this.gbCalcular = new System.Windows.Forms.GroupBox();
            this.lblHastaCalc = new System.Windows.Forms.Label();
            this.lblDesdeCalc = new System.Windows.Forms.Label();
            this.btnCalcularLiquidaciones = new System.Windows.Forms.Button();
            this.dtpHastaCalc = new System.Windows.Forms.DateTimePicker();
            this.dtpDesdeCalc = new System.Windows.Forms.DateTimePicker();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.cmbProfesionalFiltro = new System.Windows.Forms.ComboBox();
            this.lblProfFiltro = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiquidaciones)).BeginInit();
            this.gbCalcular.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLiquidaciones
            // 
            this.dgvLiquidaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLiquidaciones.Location = new System.Drawing.Point(12, 160);
            this.dgvLiquidaciones.Name = "dgvLiquidaciones";
            this.dgvLiquidaciones.RowTemplate.Height = 25;
            this.dgvLiquidaciones.Size = new System.Drawing.Size(760, 250);
            this.dgvLiquidaciones.TabIndex = 0;
            // 
            // gbCalcular
            // 
            this.gbCalcular.Controls.Add(this.lblHastaCalc);
            this.gbCalcular.Controls.Add(this.lblDesdeCalc);
            this.gbCalcular.Controls.Add(this.btnCalcularLiquidaciones);
            this.gbCalcular.Controls.Add(this.dtpHastaCalc);
            this.gbCalcular.Controls.Add(this.dtpDesdeCalc);
            this.gbCalcular.Location = new System.Drawing.Point(12, 12);
            this.gbCalcular.Name = "gbCalcular";
            this.gbCalcular.Size = new System.Drawing.Size(200, 140);
            this.gbCalcular.TabIndex = 1;
            this.gbCalcular.TabStop = false;
            this.gbCalcular.Text = "Calcular Nuevas Liquidaciones";
            // 
            // lblHastaCalc
            // 
            this.lblHastaCalc.AutoSize = true;
            this.lblHastaCalc.Location = new System.Drawing.Point(10, 58);
            this.lblHastaCalc.Name = "lblHastaCalc";
            this.lblHastaCalc.Size = new System.Drawing.Size(40, 15);
            this.lblHastaCalc.TabIndex = 4;
            this.lblHastaCalc.Text = "Hasta:";
            // 
            // lblDesdeCalc
            // 
            this.lblDesdeCalc.AutoSize = true;
            this.lblDesdeCalc.Location = new System.Drawing.Point(10, 28);
            this.lblDesdeCalc.Name = "lblDesdeCalc";
            this.lblDesdeCalc.Size = new System.Drawing.Size(42, 15);
            this.lblDesdeCalc.TabIndex = 3;
            this.lblDesdeCalc.Text = "Desde:";
            // 
            // btnCalcularLiquidaciones
            // 
            this.btnCalcularLiquidaciones.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCalcularLiquidaciones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCalcularLiquidaciones.ForeColor = System.Drawing.Color.White;
            this.btnCalcularLiquidaciones.Location = new System.Drawing.Point(10, 90);
            this.btnCalcularLiquidaciones.Name = "btnCalcularLiquidaciones";
            this.btnCalcularLiquidaciones.Size = new System.Drawing.Size(180, 40);
            this.btnCalcularLiquidaciones.TabIndex = 2;
            this.btnCalcularLiquidaciones.Text = "Calcular Periodo";
            this.btnCalcularLiquidaciones.UseVisualStyleBackColor = false;
            this.btnCalcularLiquidaciones.Click += new System.EventHandler(this.btnCalcularLiquidaciones_Click);
            // 
            // dtpHastaCalc
            // 
            this.dtpHastaCalc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaCalc.Location = new System.Drawing.Point(60, 55);
            this.dtpHastaCalc.Name = "dtpHastaCalc";
            this.dtpHastaCalc.Size = new System.Drawing.Size(130, 23);
            this.dtpHastaCalc.TabIndex = 1;
            // 
            // dtpDesdeCalc
            // 
            this.dtpDesdeCalc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeCalc.Location = new System.Drawing.Point(60, 25);
            this.dtpDesdeCalc.Name = "dtpDesdeCalc";
            this.dtpDesdeCalc.Size = new System.Drawing.Size(130, 23);
            this.dtpDesdeCalc.TabIndex = 0;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltros.Controls.Add(this.cmbProfesionalFiltro);
            this.gbFiltros.Controls.Add(this.lblProfFiltro);
            this.gbFiltros.Controls.Add(this.btnBuscar);
            this.gbFiltros.Controls.Add(this.dtpHasta);
            this.gbFiltros.Controls.Add(this.lblHasta);
            this.gbFiltros.Controls.Add(this.dtpDesde);
            this.gbFiltros.Controls.Add(this.lblDesde);
            this.gbFiltros.Location = new System.Drawing.Point(225, 12);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(547, 140);
            this.gbFiltros.TabIndex = 3;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtrar Vista";
            // 
            // cmbProfesionalFiltro
            // 
            this.cmbProfesionalFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesionalFiltro.FormattingEnabled = true;
            this.cmbProfesionalFiltro.Location = new System.Drawing.Point(80, 27);
            this.cmbProfesionalFiltro.Name = "cmbProfesionalFiltro";
            this.cmbProfesionalFiltro.Size = new System.Drawing.Size(200, 23);
            this.cmbProfesionalFiltro.TabIndex = 10;
            // 
            // lblProfFiltro
            // 
            this.lblProfFiltro.AutoSize = true;
            this.lblProfFiltro.Location = new System.Drawing.Point(10, 30);
            this.lblProfFiltro.Name = "lblProfFiltro";
            this.lblProfFiltro.Size = new System.Drawing.Size(69, 15);
            this.lblProfFiltro.TabIndex = 9;
            this.lblProfFiltro.Text = "Profesional:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(440, 95);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 30);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(80, 90);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 23);
            this.dtpHasta.TabIndex = 7;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(10, 93);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(61, 15);
            this.lblHasta.TabIndex = 6;
            this.lblHasta.Text = "Ver Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(80, 60);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(130, 23);
            this.dtpDesde.TabIndex = 5;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(10, 63);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(63, 15);
            this.lblDesde.TabIndex = 4;
            this.lblDesde.Text = "Ver Desde:";
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPDF.Location = new System.Drawing.Point(622, 425);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(150, 35);
            this.btnExportarPDF.TabIndex = 11;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // frmGestionLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.gbFiltros);
            this.Controls.Add(this.gbCalcular);
            this.Controls.Add(this.dgvLiquidaciones);
            this.Name = "frmGestionLiquidaciones";
            this.Text = "Gestión de Liquidaciones";
           this.Load += new System.EventHandler(this.frmGestionLiquidaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLiquidaciones)).EndInit();
            this.gbCalcular.ResumeLayout(false);
            this.gbCalcular.PerformLayout();
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLiquidaciones;
        private System.Windows.Forms.GroupBox gbCalcular;
        private System.Windows.Forms.Button btnCalcularLiquidaciones;
        private System.Windows.Forms.DateTimePicker dtpHastaCalc;
        private System.Windows.Forms.DateTimePicker dtpDesdeCalc;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHastaCalc;
        private System.Windows.Forms.Label lblDesdeCalc;
        private System.Windows.Forms.ComboBox cmbProfesionalFiltro;
        private System.Windows.Forms.Label lblProfFiltro;
        private System.Windows.Forms.Button btnExportarPDF;
    }
}