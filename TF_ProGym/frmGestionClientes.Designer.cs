namespace CapaPresentacion
{
    partial class frmGestionClientes
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
            dgvClientes = new DataGridView();
            label1 = new Label();
            txtIdCliente = new TextBox();
            txtDNI = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            chkMembresiaActiva = new CheckBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            txtBuscar = new TextBox();
            label7 = new Label();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 148);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(717, 321);
            dgvClientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(844, 147);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(893, 142);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.Size = new Size(335, 27);
            txtIdCliente.TabIndex = 2;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(893, 203);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(335, 27);
            txtDNI.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(844, 208);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 3;
            label2.Text = "DNI";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(893, 266);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(335, 27);
            txtNombre.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(815, 273);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 5;
            label3.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(893, 327);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(335, 27);
            txtApellido.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(815, 334);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 7;
            label4.Text = "Apellido";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(893, 385);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(335, 27);
            txtEmail.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(815, 392);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 9;
            label5.Text = "Email";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(893, 442);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(335, 27);
            txtTelefono.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(815, 449);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 11;
            label6.Text = "Telefono";
            // 
            // chkMembresiaActiva
            // 
            chkMembresiaActiva.AutoSize = true;
            chkMembresiaActiva.Location = new Point(828, 512);
            chkMembresiaActiva.Name = "chkMembresiaActiva";
            chkMembresiaActiva.Size = new Size(155, 24);
            chkMembresiaActiva.TabIndex = 13;
            chkMembresiaActiva.Text = "Membresia activa?";
            chkMembresiaActiva.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(780, 593);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(116, 39);
            btnNuevo.TabIndex = 14;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(964, 593);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 39);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1147, 593);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 39);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(117, 73);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(335, 27);
            txtBuscar.TabIndex = 18;
           
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 80);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 17;
            label7.Text = "Buscar";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(534, 67);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(116, 39);
            btnBuscar.TabIndex = 19;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // frmGestionClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 743);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label7);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(chkMembresiaActiva);
            Controls.Add(txtTelefono);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtApellido);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(txtDNI);
            Controls.Add(label2);
            Controls.Add(txtIdCliente);
            Controls.Add(label1);
            Controls.Add(dgvClientes);
            Name = "frmGestionClientes";
            Text = "frmGestionClientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Label label1;
        private TextBox txtIdCliente;
        private TextBox txtDNI;
        private Label label2;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtApellido;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtTelefono;
        private Label label6;
        private CheckBox chkMembresiaActiva;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private TextBox txtBuscar;
        private Label label7;
        private Button btnBuscar;
    }
}