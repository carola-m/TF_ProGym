namespace CapaPresentacion
{
    partial class frmCambiarPassword
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
            this.txtNuevaPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmarPassword = new System.Windows.Forms.TextBox();
            this.btnGuardarCambio = new System.Windows.Forms.Button();
            this.btnCancelarCambio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.chkVerPasswordNueva = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNuevaPassword
            // 
            this.txtNuevaPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNuevaPassword.Location = new System.Drawing.Point(170, 117);
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.PasswordChar = '*';
            this.txtNuevaPassword.Size = new System.Drawing.Size(250, 25);
            this.txtNuevaPassword.TabIndex = 0;
            this.txtNuevaPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNuevaContraseña_KeyPress);
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmarPassword.Location = new System.Drawing.Point(170, 157);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '*';
            this.txtConfirmarPassword.Size = new System.Drawing.Size(250, 25);
            this.txtConfirmarPassword.TabIndex = 1;
            this.txtConfirmarPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmarContraseña_KeyPress);
            // 
            // btnGuardarCambio
            // 
            this.btnGuardarCambio.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardarCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarCambio.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambio.Location = new System.Drawing.Point(170, 230);
            this.btnGuardarCambio.Name = "btnGuardarCambio";
            this.btnGuardarCambio.Size = new System.Drawing.Size(120, 35);
            this.btnGuardarCambio.TabIndex = 2;
            this.btnGuardarCambio.Text = "GUARDAR";
            this.btnGuardarCambio.UseVisualStyleBackColor = false;
            this.btnGuardarCambio.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelarCambio
            // 
            this.btnCancelarCambio.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelarCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCambio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancelarCambio.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarCambio.Location = new System.Drawing.Point(300, 230);
            this.btnCancelarCambio.Name = "btnCancelarCambio";
            this.btnCancelarCambio.Size = new System.Drawing.Size(120, 35);
            this.btnCancelarCambio.TabIndex = 3;
            this.btnCancelarCambio.Text = "CANCELAR";
            this.btnCancelarCambio.UseVisualStyleBackColor = false;
            this.btnCancelarCambio.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nueva Contraseña:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirmar Contraseña:";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::CapaPresentacion.Properties.Resources.Captura_de_pantalla_2025_10_30_223244;
            this.pbLogo.Location = new System.Drawing.Point(150, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 80);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 7;
            this.pbLogo.TabStop = false;
            // 
            // chkVerPasswordNueva
            // 
            this.chkVerPasswordNueva.AutoSize = true;
            this.chkVerPasswordNueva.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkVerPasswordNueva.Location = new System.Drawing.Point(170, 192);
            this.chkVerPasswordNueva.Name = "chkVerPasswordNueva";
            this.chkVerPasswordNueva.Size = new System.Drawing.Size(129, 17);
            this.chkVerPasswordNueva.TabIndex = 8;
            this.chkVerPasswordNueva.Text = "Mostrar contraseña";
            this.chkVerPasswordNueva.UseVisualStyleBackColor = true;
            this.chkVerPasswordNueva.CheckedChanged += new System.EventHandler(this.chkVerPasswordNueva_CheckedChanged);
            // 
            // frmCambiarPassword
            // 
            this.AcceptButton = this.btnGuardarCambio;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelarCambio;
            this.ClientSize = new System.Drawing.Size(434, 301);
            this.Controls.Add(this.chkVerPasswordNueva);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCambio);
            this.Controls.Add(this.btnGuardarCambio);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.txtNuevaPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Contraseña";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNuevaPassword;
        private System.Windows.Forms.TextBox txtConfirmarPassword;
        private System.Windows.Forms.Button btnGuardarCambio;
        private System.Windows.Forms.Button btnCancelarCambio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.CheckBox chkVerPasswordNueva;
    }
}