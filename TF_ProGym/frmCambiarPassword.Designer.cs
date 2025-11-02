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
            txtNuevaPassword = new TextBox();
            txtConfirmarPassword = new TextBox();
            btnGuardarCambio = new Button();
            btnCancelarCambio = new Button();
            label1 = new Label();
            label3 = new Label();
            pbLogo = new PictureBox();
            chkVerPasswordNueva = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Font = new Font("Segoe UI", 9.75F);
            txtNuevaPassword.Location = new Point(208, 120);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.PasswordChar = '*';
            txtNuevaPassword.Size = new Size(250, 29);
            txtNuevaPassword.TabIndex = 0;
            txtNuevaPassword.KeyPress += txtNuevaContraseña_KeyPress;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.Font = new Font("Segoe UI", 9.75F);
            txtConfirmarPassword.Location = new Point(208, 154);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.PasswordChar = '*';
            txtConfirmarPassword.Size = new Size(250, 29);
            txtConfirmarPassword.TabIndex = 1;
            txtConfirmarPassword.KeyPress += txtConfirmarContraseña_KeyPress;
            // 
            // btnGuardarCambio
            // 
            btnGuardarCambio.BackColor = Color.SteelBlue;
            btnGuardarCambio.FlatStyle = FlatStyle.Flat;
            btnGuardarCambio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnGuardarCambio.ForeColor = Color.White;
            btnGuardarCambio.Location = new Point(126, 260);
            btnGuardarCambio.Name = "btnGuardarCambio";
            btnGuardarCambio.Size = new Size(120, 35);
            btnGuardarCambio.TabIndex = 2;
            btnGuardarCambio.Text = "GUARDAR";
            btnGuardarCambio.UseVisualStyleBackColor = false;
            btnGuardarCambio.Click += btnGuardar_Click;
            // 
            // btnCancelarCambio
            // 
            btnCancelarCambio.BackColor = Color.Gainsboro;
            btnCancelarCambio.FlatStyle = FlatStyle.Flat;
            btnCancelarCambio.Font = new Font("Segoe UI", 9.75F);
            btnCancelarCambio.ForeColor = Color.Black;
            btnCancelarCambio.Location = new Point(289, 260);
            btnCancelarCambio.Name = "btnCancelarCambio";
            btnCancelarCambio.Size = new Size(120, 35);
            btnCancelarCambio.TabIndex = 3;
            btnCancelarCambio.Text = "CANCELAR";
            btnCancelarCambio.UseVisualStyleBackColor = false;
            btnCancelarCambio.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(20, 120);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 4;
            label1.Text = "Nueva Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F);
            label3.Location = new Point(12, 160);
            label3.Name = "label3";
            label3.Size = new Size(182, 23);
            label3.TabIndex = 6;
            label3.Text = "Confirmar Contraseña:";
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.Captura_de_pantalla_2025_10_30_223244;
            pbLogo.Location = new Point(182, 21);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(150, 80);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 7;
            pbLogo.TabStop = false;
            // 
            // chkVerPasswordNueva
            // 
            chkVerPasswordNueva.AutoSize = true;
            chkVerPasswordNueva.Font = new Font("Segoe UI", 8.25F);
            chkVerPasswordNueva.Location = new Point(208, 189);
            chkVerPasswordNueva.Name = "chkVerPasswordNueva";
            chkVerPasswordNueva.Size = new Size(151, 23);
            chkVerPasswordNueva.TabIndex = 8;
            chkVerPasswordNueva.Text = "Mostrar contraseña";
            chkVerPasswordNueva.UseVisualStyleBackColor = true;
            chkVerPasswordNueva.CheckedChanged += chkVerPasswordNueva_CheckedChanged;
            // 
            // frmCambiarPassword
            // 
            AcceptButton = btnGuardarCambio;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancelarCambio;
            ClientSize = new Size(526, 366);
            Controls.Add(chkVerPasswordNueva);
            Controls.Add(pbLogo);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnCancelarCambio);
            Controls.Add(btnGuardarCambio);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(txtNuevaPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCambiarPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar Contraseña";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();

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