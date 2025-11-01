namespace CapaPresentacion
{
    partial class frmBitacora
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
            dgvBitacora = new DataGridView();
            btnRecargar = new Button();
            gbFiltros = new GroupBox();
            btnFiltrar = new Button();
            dtpHasta = new DateTimePicker();
            lblHasta = new Label();
            dtpDesde = new DateTimePicker();
            lblDesde = new Label();
            rbRestores = new RadioButton();
            rbBackups = new RadioButton();
            rbTodos = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).BeginInit();
            gbFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBitacora
            // 
            dgvBitacora.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBitacora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBitacora.Location = new Point(14, 100);
            dgvBitacora.Margin = new Padding(3, 4, 3, 4);
            dgvBitacora.Name = "dgvBitacora";
            dgvBitacora.RowHeadersWidth = 51;
            dgvBitacora.RowTemplate.Height = 25;
            dgvBitacora.Size = new Size(869, 473);
            dgvBitacora.TabIndex = 0;
            // 
            // btnRecargar
            // 
            btnRecargar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRecargar.Location = new Point(14, 587);
            btnRecargar.Margin = new Padding(3, 4, 3, 4);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(137, 40);
            btnRecargar.TabIndex = 1;
            btnRecargar.Text = "Recargar Lista";
            btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // gbFiltros
            // 
            gbFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFiltros.Controls.Add(btnFiltrar);
            gbFiltros.Controls.Add(dtpHasta);
            gbFiltros.Controls.Add(lblHasta);
            gbFiltros.Controls.Add(dtpDesde);
            gbFiltros.Controls.Add(lblDesde);
            gbFiltros.Controls.Add(rbRestores);
            gbFiltros.Controls.Add(rbBackups);
            gbFiltros.Controls.Add(rbTodos);
            gbFiltros.Location = new Point(14, 7);
            gbFiltros.Margin = new Padding(3, 4, 3, 4);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Padding = new Padding(3, 4, 3, 4);
            gbFiltros.Size = new Size(869, 85);
            gbFiltros.TabIndex = 2;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros";
            // 
            // btnFiltrar
            // 
            btnFiltrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFiltrar.Location = new Point(766, 33);
            btnFiltrar.Margin = new Padding(3, 4, 3, 4);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(86, 33);
            btnFiltrar.TabIndex = 7;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(594, 35);
            dtpHasta.Margin = new Padding(3, 4, 3, 4);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(114, 27);
            dtpHasta.TabIndex = 6;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(543, 40);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(50, 20);
            lblHasta.TabIndex = 5;
            lblHasta.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(417, 35);
            dtpDesde.Margin = new Padding(3, 4, 3, 4);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(114, 27);
            dtpDesde.TabIndex = 4;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(360, 40);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(54, 20);
            lblDesde.TabIndex = 3;
            lblDesde.Text = "Desde:";
            // 
            // rbRestores
            // 
            rbRestores.AutoSize = true;
            rbRestores.Location = new Point(206, 37);
            rbRestores.Margin = new Padding(3, 4, 3, 4);
            rbRestores.Name = "rbRestores";
            rbRestores.Size = new Size(120, 24);
            rbRestores.TabIndex = 2;
            rbRestores.Text = "Solo Restores";
            rbRestores.UseVisualStyleBackColor = true;
            // 
            // rbBackups
            // 
            rbBackups.AutoSize = true;
            rbBackups.Location = new Point(91, 37);
            rbBackups.Margin = new Padding(3, 4, 3, 4);
            rbBackups.Name = "rbBackups";
            rbBackups.Size = new Size(118, 24);
            rbBackups.TabIndex = 1;
            rbBackups.Text = "Solo Backups";
            rbBackups.UseVisualStyleBackColor = true;
            // 
            // rbTodos
            // 
            rbTodos.AutoSize = true;
            rbTodos.Checked = true;
            rbTodos.Location = new Point(17, 37);
            rbTodos.Margin = new Padding(3, 4, 3, 4);
            rbTodos.Name = "rbTodos";
            rbTodos.Size = new Size(70, 24);
            rbTodos.TabIndex = 0;
            rbTodos.TabStop = true;
            rbTodos.Text = "Todos";
            rbTodos.UseVisualStyleBackColor = true;
            // 
            // frmBitacora
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 641);
            Controls.Add(gbFiltros);
            Controls.Add(btnRecargar);
            Controls.Add(dgvBitacora);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmBitacora";
            Text = "Bitácora de Eventos";
            Load += frmBitacora_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBitacora).EndInit();
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.RadioButton rbRestores;
        private System.Windows.Forms.RadioButton rbBackups;
        private System.Windows.Forms.RadioButton rbTodos;
    }
}