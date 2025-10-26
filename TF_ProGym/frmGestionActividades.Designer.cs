namespace CapaPresentacion
{
    partial class frmGestionActividades
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
            chkMembresiaActiva = new CheckBox();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtTarifaTurno = new TextBox();
            label5 = new Label();
            txtDescripcionActividad = new TextBox();
            label4 = new Label();
            txtNombreActividad = new TextBox();
            label3 = new Label();
            txtIdActividad = new TextBox();
            label1 = new Label();
            dgvActividades = new DataGridView();
            numCupoMaximo = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCupoMaximo).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(658, 96);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(116, 39);
            btnBuscar.TabIndex = 39;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(241, 102);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(335, 27);
            txtBuscar.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(163, 109);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 37;
            label7.Text = "Buscar";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1271, 622);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 39);
            btnEliminar.TabIndex = 36;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1088, 622);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 39);
            btnGuardar.TabIndex = 35;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(904, 622);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(116, 39);
            btnNuevo.TabIndex = 34;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // chkMembresiaActiva
            // 
            chkMembresiaActiva.AutoSize = true;
            chkMembresiaActiva.Location = new Point(952, 541);
            chkMembresiaActiva.Name = "chkMembresiaActiva";
            chkMembresiaActiva.Size = new Size(155, 24);
            chkMembresiaActiva.TabIndex = 33;
            chkMembresiaActiva.Text = "Membresia activa?";
            chkMembresiaActiva.UseVisualStyleBackColor = true;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(1017, 471);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(335, 27);
            txtTelefono.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(939, 478);
            label6.Name = "label6";
            label6.Size = new Size(67, 20);
            label6.TabIndex = 31;
            label6.Text = "Telefono";
            // 
            // txtTarifaTurno
            // 
            txtTarifaTurno.Location = new Point(1017, 414);
            txtTarifaTurno.Name = "txtTarifaTurno";
            txtTarifaTurno.Size = new Size(335, 27);
            txtTarifaTurno.TabIndex = 30;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(939, 421);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 29;
            label5.Text = "Tarifa";
            // 
            // txtDescripcionActividad
            // 
            txtDescripcionActividad.Location = new Point(1043, 287);
            txtDescripcionActividad.Name = "txtDescripcionActividad";
            txtDescripcionActividad.Size = new Size(335, 27);
            txtDescripcionActividad.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(933, 290);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 27;
            label4.Text = "Descripcion";
            // 
            // txtNombreActividad
            // 
            txtNombreActividad.Location = new Point(1026, 236);
            txtNombreActividad.Name = "txtNombreActividad";
            txtNombreActividad.Size = new Size(335, 27);
            txtNombreActividad.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(942, 236);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 25;
            label3.Text = "Nombre";
            // 
            // txtIdActividad
            // 
            txtIdActividad.Location = new Point(1017, 171);
            txtIdActividad.Name = "txtIdActividad";
            txtIdActividad.Size = new Size(335, 27);
            txtIdActividad.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(968, 176);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 21;
            label1.Text = "ID";
            // 
            // dgvActividades
            // 
            dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActividades.Location = new Point(136, 177);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.RowHeadersWidth = 51;
            dgvActividades.Size = new Size(717, 321);
            dgvActividades.TabIndex = 20;
            // 
            // numCupoMaximo
            // 
            numCupoMaximo.Location = new Point(1068, 344);
            numCupoMaximo.Name = "numCupoMaximo";
            numCupoMaximo.Size = new Size(48, 27);
            numCupoMaximo.TabIndex = 40;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(933, 351);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 41;
            label2.Text = "Cupo Maximo";
            // 
            // frmGestionActividades
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 756);
            Controls.Add(label2);
            Controls.Add(numCupoMaximo);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label7);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(chkMembresiaActiva);
            Controls.Add(txtTelefono);
            Controls.Add(label6);
            Controls.Add(txtTarifaTurno);
            Controls.Add(label5);
            Controls.Add(txtDescripcionActividad);
            Controls.Add(label4);
            Controls.Add(txtNombreActividad);
            Controls.Add(label3);
            Controls.Add(txtIdActividad);
            Controls.Add(label1);
            Controls.Add(dgvActividades);
            Name = "frmGestionActividades";
            Text = "frmGestionActividades";
            Load += frmGestionActividades_Load;
            ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCupoMaximo).EndInit();
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
        private CheckBox chkMembresiaActiva;
        private TextBox txtTelefono;
        private Label label6;
        private TextBox txtTarifaTurno;
        private Label label5;
        private TextBox txtDescripcionActividad;
        private Label label4;
        private TextBox txtNombreActividad;
        private Label label3;
        private TextBox txtIdActividad;
        private Label label1;
        private DataGridView dgvActividades;
        private NumericUpDown numCupoMaximo;
        private Label label2;
    }
}