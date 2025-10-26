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
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtNuevaPassword
            // 
            txtNuevaPassword.Location = new Point(184, 58);
            txtNuevaPassword.Name = "txtNuevaPassword";
            txtNuevaPassword.PasswordChar = '*';
            txtNuevaPassword.Size = new Size(269, 27);
            txtNuevaPassword.TabIndex = 0;
            // 
            // txtConfirmarPassword
            // 
            txtConfirmarPassword.ForeColor = SystemColors.Window;
            txtConfirmarPassword.Location = new Point(184, 123);
            txtConfirmarPassword.Name = "txtConfirmarPassword";
            txtConfirmarPassword.PasswordChar = '*';
            txtConfirmarPassword.Size = new Size(269, 27);
            txtConfirmarPassword.TabIndex = 1;
            // 
            // btnGuardarCambio
            // 
            btnGuardarCambio.Location = new Point(106, 216);
            btnGuardarCambio.Name = "btnGuardarCambio";
            btnGuardarCambio.Size = new Size(132, 34);
            btnGuardarCambio.TabIndex = 2;
            btnGuardarCambio.Text = "GUARDAR";
            btnGuardarCambio.UseVisualStyleBackColor = true;
            // 
            // btnCancelarCambio
            // 
            btnCancelarCambio.Location = new Point(294, 218);
            btnCancelarCambio.Name = "btnCancelarCambio";
            btnCancelarCambio.Size = new Size(143, 32);
            btnCancelarCambio.TabIndex = 3;
            btnCancelarCambio.Text = "CANCELAR";
            btnCancelarCambio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 65);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 4;
            label1.Text = "Nueva Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(437, 197);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(153, 20);
            label3.TabIndex = 6;
            label3.Text = "Confirmar Contraseña";
            // 
            // frmCambiarPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelarCambio);
            Controls.Add(btnGuardarCambio);
            Controls.Add(txtConfirmarPassword);
            Controls.Add(txtNuevaPassword);
            Name = "frmCambiarPassword";
            Text = "txtNuevaPassword";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNuevaPassword;
        private TextBox txtConfirmarPassword;
        private Button btnGuardarCambio;
        private Button btnCancelarCambio;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}