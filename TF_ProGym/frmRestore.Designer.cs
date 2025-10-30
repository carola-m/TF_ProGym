namespace CapaPresentacion
{
    partial class frmRestore
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.gbBackups = new System.Windows.Forms.GroupBox();
            this.treeBackups = new System.Windows.Forms.TreeView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.lblAdvertencia = new System.Windows.Forms.Label();
            this.gbBackups.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBackups
            // 
            this.gbBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBackups.Controls.Add(this.treeBackups);
            this.gbBackups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbBackups.Location = new System.Drawing.Point(12, 12);
            this.gbBackups.Name = "gbBackups";
            this.gbBackups.Size = new System.Drawing.Size(460, 390);
            this.gbBackups.TabIndex = 2;
            this.gbBackups.TabStop = false;
            this.gbBackups.Text = "Backups Disponibles (Carpetas)";
            // 
            // treeBackups
            // 
            this.treeBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeBackups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeBackups.Location = new System.Drawing.Point(3, 19);
            this.treeBackups.Name = "treeBackups";
            this.treeBackups.Size = new System.Drawing.Size(454, 368);
            this.treeBackups.TabIndex = 0;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.DarkRed;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(262, 420);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(210, 50);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restaurar Seleccionado";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRecargar
            // 
            this.btnRecargar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRecargar.Location = new System.Drawing.Point(12, 420);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(120, 30);
            this.btnRecargar.TabIndex = 4;
            this.btnRecargar.Text = "Recargar Lista";
            this.btnRecargar.UseVisualStyleBackColor = true;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // lblAdvertencia
            // 
            this.lblAdvertencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdvertencia.AutoSize = true;
            this.lblAdvertencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAdvertencia.ForeColor = System.Drawing.Color.DarkRed;
            this.lblAdvertencia.Location = new System.Drawing.Point(138, 405);
            this.lblAdvertencia.Name = "lblAdvertencia";
            this.lblAdvertencia.Size = new System.Drawing.Size(331, 15);
            this.lblAdvertencia.TabIndex = 5;
            this.lblAdvertencia.Text = "¡ADVERTENCIA! Restaurar sobrescribirá los datos actuales.";
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 481);
            this.Controls.Add(this.lblAdvertencia);
            this.Controls.Add(this.gbBackups);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnRecargar);
            this.Name = "frmRestore";
            this.Text = "Módulo de Restore";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            this.gbBackups.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox gbBackups;
        private System.Windows.Forms.TreeView treeBackups;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Label lblAdvertencia;
    }
}