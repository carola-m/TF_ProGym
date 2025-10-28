namespace CapaPresentacion
{
    partial class frmInicio
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
            panelTitulo = new Panel();
            lblUsuarioLogueado = new Label();
            btnCerrarSesion = new Button();
            lblTituloApp = new Label();
            menuStripPrincipal = new MenuStrip();
            menuGestionClientes = new ToolStripMenuItem();
            menuGestionProfesionales = new ToolStripMenuItem();
            menuGestionActividades = new ToolStripMenuItem();
            menuGestionTurnos = new ToolStripMenuItem();
            subMenuGestionarTurnos = new ToolStripMenuItem();
            subMenuRegistroAsistencia = new ToolStripMenuItem();
            menuLiquidaciones = new ToolStripMenuItem();
            menuDashboard = new ToolStripMenuItem();
            menuSeguridad = new ToolStripMenuItem();
            menuBackupRestore = new ToolStripMenuItem();
            subMenuBackup = new ToolStripMenuItem();
            subMenuRestore = new ToolStripMenuItem();
            subMenuBitacora = new ToolStripMenuItem();
            panelContenedor = new Panel();
            lblTituloFormHijo = new Label();
            panelTitulo.SuspendLayout();
            menuStripPrincipal.SuspendLayout();
            panelContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.Black;
            panelTitulo.Controls.Add(lblUsuarioLogueado);
            panelTitulo.Controls.Add(btnCerrarSesion);
            panelTitulo.Controls.Add(lblTituloApp);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Margin = new Padding(3, 4, 3, 4);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1125, 93);
            panelTitulo.TabIndex = 0;
            // 
            // lblUsuarioLogueado
            // 
            lblUsuarioLogueado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuarioLogueado.AutoSize = true;
            lblUsuarioLogueado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUsuarioLogueado.ForeColor = Color.White;
            lblUsuarioLogueado.Location = new Point(857, 36);
            lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            lblUsuarioLogueado.Size = new Size(75, 23);
            lblUsuarioLogueado.TabIndex = 2;
            lblUsuarioLogueado.Text = "Usuario:";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.DimGray;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.White;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(994, 27);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(114, 40);
            btnCerrarSesion.TabIndex = 1;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblTituloApp
            // 
            lblTituloApp.AutoSize = true;
            lblTituloApp.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            lblTituloApp.ForeColor = Color.White;
            lblTituloApp.Location = new Point(14, 24);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(128, 41);
            lblTituloApp.TabIndex = 0;
            lblTituloApp.Text = "ProGym";
            // 
            // menuStripPrincipal
            // 
            menuStripPrincipal.ImageScalingSize = new Size(20, 20);
            menuStripPrincipal.Items.AddRange(new ToolStripItem[] { menuGestionClientes, menuGestionProfesionales, menuGestionActividades, menuGestionTurnos, menuLiquidaciones, menuDashboard, menuSeguridad, menuBackupRestore });
            menuStripPrincipal.Location = new Point(0, 93);
            menuStripPrincipal.Name = "menuStripPrincipal";
            menuStripPrincipal.Padding = new Padding(7, 3, 0, 3);
            menuStripPrincipal.Size = new Size(1125, 30);
            menuStripPrincipal.TabIndex = 1;
            menuStripPrincipal.Text = "menuStrip1";
            // 
            // menuGestionClientes
            // 
            menuGestionClientes.Name = "menuGestionClientes";
            menuGestionClientes.Size = new Size(142, 24);
            menuGestionClientes.Text = "Gestionar Clientes";
            menuGestionClientes.Click += menuGestionClientes_Click;
            // 
            // menuGestionProfesionales
            // 
            menuGestionProfesionales.Name = "menuGestionProfesionales";
            menuGestionProfesionales.Size = new Size(178, 24);
            menuGestionProfesionales.Text = "Gestionar Profesionales";
            menuGestionProfesionales.Click += menuGestionProfesionales_Click;
            // 
            // menuGestionActividades
            // 
            menuGestionActividades.Name = "menuGestionActividades";
            menuGestionActividades.Size = new Size(167, 24);
            menuGestionActividades.Text = "Gestionar Actividades";
            menuGestionActividades.Click += menuGestionActividades_Click;
            // 
            // menuGestionTurnos
            // 
            menuGestionTurnos.DropDownItems.AddRange(new ToolStripItem[] { subMenuGestionarTurnos, subMenuRegistroAsistencia });
            menuGestionTurnos.Name = "menuGestionTurnos";
            menuGestionTurnos.Size = new Size(148, 24);
            menuGestionTurnos.Text = "Turnos y Asistencia";
            // 
            // subMenuGestionarTurnos
            // 
            subMenuGestionarTurnos.Name = "subMenuGestionarTurnos";
            subMenuGestionarTurnos.Size = new Size(221, 26);
            subMenuGestionarTurnos.Text = "Administrar Turnos";
            subMenuGestionarTurnos.Click += subMenuGestionarTurnos_Click;
            // 
            // subMenuRegistroAsistencia
            // 
            subMenuRegistroAsistencia.Name = "subMenuRegistroAsistencia";
            subMenuRegistroAsistencia.Size = new Size(221, 26);
            subMenuRegistroAsistencia.Text = "Registrar Asistencia";
            subMenuRegistroAsistencia.Click += subMenuRegistroAsistencia_Click;
            // 
            // menuLiquidaciones
            // 
            menuLiquidaciones.Name = "menuLiquidaciones";
            menuLiquidaciones.Size = new Size(114, 24);
            menuLiquidaciones.Text = "Liquidaciones";
            menuLiquidaciones.Click += menuLiquidaciones_Click;
            // 
            // menuDashboard
            // 
            menuDashboard.Name = "menuDashboard";
            menuDashboard.Size = new Size(96, 24);
            menuDashboard.Text = "Dashboard";
            menuDashboard.Click += menuDashboard_Click;
            // 
            // menuSeguridad
            // 
            menuSeguridad.Name = "menuSeguridad";
            menuSeguridad.Size = new Size(91, 24);
            menuSeguridad.Text = "Seguridad";
            menuSeguridad.Click += menuSeguridad_Click;
            // 
            // menuBackupRestore
            // 
            menuBackupRestore.DropDownItems.AddRange(new ToolStripItem[] { subMenuBackup, subMenuRestore, subMenuBitacora });
            menuBackupRestore.Name = "menuBackupRestore";
            menuBackupRestore.Size = new Size(135, 24);
            menuBackupRestore.Text = "Backup / Restore";
            // 
            // subMenuBackup
            // 
            subMenuBackup.Name = "subMenuBackup";
            subMenuBackup.Size = new Size(199, 26);
            subMenuBackup.Text = "Realizar Backup";
            subMenuBackup.Click += subMenuBackup_Click;
            // 
            // subMenuRestore
            // 
            subMenuRestore.Name = "subMenuRestore";
            subMenuRestore.Size = new Size(199, 26);
            subMenuRestore.Text = "Realizar Restore";
            subMenuRestore.Click += subMenuRestore_Click;
            // 
            // subMenuBitacora
            // 
            subMenuBitacora.Name = "subMenuBitacora";
            subMenuBitacora.Size = new Size(199, 26);
            subMenuBitacora.Text = "Ver Bitácora";
            subMenuBitacora.Click += subMenuBitacora_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = SystemColors.ControlLight;
            panelContenedor.Controls.Add(lblTituloFormHijo);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 123);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1125, 625);
            panelContenedor.TabIndex = 2;
            // 
            // lblTituloFormHijo
            // 
            lblTituloFormHijo.AutoSize = true;
            lblTituloFormHijo.BackColor = SystemColors.ControlLight;
            lblTituloFormHijo.Dock = DockStyle.Top;
            lblTituloFormHijo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloFormHijo.Location = new Point(0, 0);
            lblTituloFormHijo.Name = "lblTituloFormHijo";
            lblTituloFormHijo.Padding = new Padding(11, 7, 0, 7);
            lblTituloFormHijo.Size = new Size(129, 42);
            lblTituloFormHijo.TabIndex = 0;
            lblTituloFormHijo.Text = "Bienvenido";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 748);
            Controls.Add(panelContenedor);
            Controls.Add(menuStripPrincipal);
            Controls.Add(panelTitulo);
            MainMenuStrip = menuStripPrincipal;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmInicio";
            Text = "ProGym - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmInicio_FormClosing;
            Load += frmInicio_Load;
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            menuStripPrincipal.ResumeLayout(false);
            menuStripPrincipal.PerformLayout();
            panelContenedor.ResumeLayout(false);
            panelContenedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTituloApp;
        private System.Windows.Forms.Label lblUsuarioLogueado;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuGestionClientes;
        private System.Windows.Forms.ToolStripMenuItem menuGestionProfesionales;
        private System.Windows.Forms.ToolStripMenuItem menuGestionActividades;
        private System.Windows.Forms.ToolStripMenuItem menuGestionTurnos;
        private System.Windows.Forms.ToolStripMenuItem menuLiquidaciones;
        private System.Windows.Forms.ToolStripMenuItem menuDashboard;
        private System.Windows.Forms.ToolStripMenuItem menuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem menuBackupRestore;
        private System.Windows.Forms.ToolStripMenuItem subMenuBackup;
        private System.Windows.Forms.ToolStripMenuItem subMenuRestore;
        private System.Windows.Forms.ToolStripMenuItem subMenuBitacora;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label lblTituloFormHijo;
        // --- Variables añadidas ---
        private System.Windows.Forms.ToolStripMenuItem subMenuGestionarTurnos;
        private System.Windows.Forms.ToolStripMenuItem subMenuRegistroAsistencia;
    }
}