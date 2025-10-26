namespace CapaPresentacion
{
    partial class frmGestionProfesionales
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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label7 = new Label();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            txtApellido = new TextBox();
            label4 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtDNI = new TextBox();
            label2 = new Label();
            txtIdProfesional = new TextBox();
            label1 = new Label();
            dgvProfesionales = new DataGridView();
            clbActividades = new CheckedListBox();
            lblActividadesAsignables = new Label();
            txtEspecialidad = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProfesionales).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(652, 52);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(116, 39);
            btnBuscar.TabIndex = 39;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(235, 58);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(335, 27);
            txtBuscar.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(157, 65);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 37;
            label7.Text = "Buscar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(454, 593);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 39);
            btnEliminar.TabIndex = 36;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(266, 593);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 39);
            btnGuardar.TabIndex = 35;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(93, 593);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(116, 39);
            btnNuevo.TabIndex = 34;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(1011, 427);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(335, 27);
            txtTelefono.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(933, 434);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 31;
            label6.Text = "Telefono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(1011, 370);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(335, 27);
            txtEmail.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(933, 377);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 29;
            label5.Text = "Email";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(1011, 312);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(335, 27);
            txtApellido.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(933, 319);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 27;
            label4.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(1011, 251);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(335, 27);
            txtNombre.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(933, 258);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 25;
            label3.Text = "Nombre";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(1011, 188);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(335, 27);
            txtDNI.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(962, 193);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 23;
            label2.Text = "DNI";
            // 
            // txtIdProfesional
            // 
            txtIdProfesional.Location = new Point(1011, 127);
            txtIdProfesional.Name = "txtIdProfesional";
            txtIdProfesional.Size = new Size(335, 27);
            txtIdProfesional.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(962, 132);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 21;
            label1.Text = "ID";
            // 
            // dgvProfesionales
            // 
            dgvProfesionales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProfesionales.Location = new Point(130, 133);
            dgvProfesionales.Name = "dgvProfesionales";
            dgvProfesionales.RowHeadersWidth = 51;
            dgvProfesionales.Size = new Size(717, 321);
            dgvProfesionales.TabIndex = 20;
            // 
            // clbActividades
            // 
            clbActividades.FormattingEnabled = true;
            clbActividades.Location = new Point(916, 543);
            clbActividades.Name = "clbActividades";
            clbActividades.Size = new Size(262, 114);
            clbActividades.TabIndex = 40;
            // 
            // lblActividadesAsignables
            // 
            lblActividadesAsignables.AutoSize = true;
            lblActividadesAsignables.Location = new Point(933, 520);
            lblActividadesAsignables.Name = "lblActividadesAsignables";
            lblActividadesAsignables.Size = new Size(160, 20);
            lblActividadesAsignables.TabIndex = 41;
            lblActividadesAsignables.Text = "Actividades asignables";
            // 
            // txtEspecialidad
            // 
            txtEspecialidad.Location = new Point(1011, 476);
            txtEspecialidad.Name = "txtEspecialidad";
            txtEspecialidad.Size = new Size(335, 27);
            txtEspecialidad.TabIndex = 43;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(916, 483);
            label8.Name = "label8";
            label8.Size = new Size(93, 20);
            label8.TabIndex = 42;
            label8.Text = "Especialidad";
            // 
            // frmGestionProfesionales
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1511, 669);
            Controls.Add(txtEspecialidad);
            Controls.Add(label8);
            Controls.Add(lblActividadesAsignables);
            Controls.Add(clbActividades);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label7);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
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
            Controls.Add(txtIdProfesional);
            Controls.Add(label1);
            Controls.Add(dgvProfesionales);
            Name = "frmGestionProfesionales";
            Text = "frmGestionProfesionales";
            Load += frmGestionProfesionales_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProfesionales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label7;
        private Button btnEliminar;
        private Button btnGuardar;
        private Button btnNuevo;
        private TextBox txtTelefono;
        private Label label6;
        private TextBox txtEmail;
        private Label label5;
        private TextBox txtApellido;
        private Label label4;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtDNI;
        private Label label2;
        private TextBox txtIdProfesional;
        private Label label1;
        private DataGridView dgvProfesionales;
        private CheckedListBox clbActividades;
        private Label lblActividadesAsignables;
        private TextBox txtEspecialidad;
        private Label label8;
    }
}