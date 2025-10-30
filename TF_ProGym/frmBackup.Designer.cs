namespace CapaPresentacion
{
    partial class frmBackup
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
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.btnRealizarBackup = new System.Windows.Forms.Button();
            this.lblHistorial = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBackups
            // 
            this.dgvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(12, 35);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.RowTemplate.Height = 25;
            this.dgvBackups.Size = new System.Drawing.Size(760, 350);
            this.dgvBackups.TabIndex = 0;
            // 
            // btnRealizarBackup
            // 
            this.btnRealizarBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealizarBackup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRealizarBackup.Location = new System.Drawing.Point(12, 400);
            this.btnRealizarBackup.Name = "btnRealizarBackup";
            this.btnRealizarBackup.Size = new System.Drawing.Size(760, 50);
            this.btnRealizarBackup.TabIndex = 1;
            this.btnRealizarBackup.Text = "Realizar Nuevo Backup";
            this.btnRealizarBackup.UseVisualStyleBackColor = true;
            this.btnRealizarBackup.Click += new System.EventHandler(this.btnRealizarBackup_Click);
            // 
            // lblHistorial
            // 
            this.lblHistorial.AutoSize = true;
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHistorial.Location = new System.Drawing.Point(12, 15);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Size = new System.Drawing.Size(124, 15);
            this.lblHistorial.TabIndex = 2;
            this.lblHistorial.Text = "Historial de Backups:";
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.btnRealizarBackup);
            this.Controls.Add(this.dgvBackups);
            this.Name = "frmBackup";
            this.Text = "Módulo de Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnRealizarBackup;
        private System.Windows.Forms.Label lblHistorial;
    }
}