namespace CapaPresentacion
{
    partial class frmInicio
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
            panelTitulo = new Panel();
            pbLogo = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            menuStripPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.Black;
            panelTitulo.Controls.Add(pbLogo);
            panelTitulo.Controls.Add(lblUsuarioLogueado);
            panelTitulo.Controls.Add(btnCerrarSesion);
            panelTitulo.Controls.Add(lblTituloApp);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Margin = new Padding(3, 5, 3, 5);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(1286, 124);
            panelTitulo.TabIndex = 0;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.Captura_de_pantalla_2025_10_30_223244;
            pbLogo.Location = new Point(17, 23);
            pbLogo.Margin = new Padding(3, 4, 3, 4);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(143, 83);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 3;
            pbLogo.TabStop = false;
            // 
            // lblUsuarioLogueado
            // 
            lblUsuarioLogueado.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuarioLogueado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblUsuarioLogueado.ForeColor = Color.White;
            lblUsuarioLogueado.Location = new Point(914, 48);
            lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            lblUsuarioLogueado.Size = new Size(215, 31);
            lblUsuarioLogueado.TabIndex = 2;
            lblUsuarioLogueado.Text = "Usuario:";
            lblUsuarioLogueado.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.IndianRed;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1136, 36);
            btnCerrarSesion.Margin = new Padding(3, 5, 3, 5);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(130, 53);
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
            lblTituloApp.Location = new Point(166, 39);
            lblTituloApp.Name = "lblTituloApp";
            lblTituloApp.Size = new Size(0, 41);
            lblTituloApp.TabIndex = 0;
            // 
            // menuStripPrincipal
            // 
            menuStripPrincipal.Font = new Font("Segoe UI", 9.75F);
            menuStripPrincipal.ImageScalingSize = new Size(20, 20);
            menuStripPrincipal.Items.AddRange(new ToolStripItem[] { menuGestionClientes, menuGestionProfesionales, menuGestionActividades, menuGestionTurnos, menuLiquidaciones, menuDashboard, menuSeguridad, menuBackupRestore });
            menuStripPrincipal.Location = new Point(0, 124);
            menuStripPrincipal.Name = "menuStripPrincipal";
            menuStripPrincipal.Padding = new Padding(8, 4, 0, 4);
            menuStripPrincipal.Size = new Size(1286, 35);
            menuStripPrincipal.TabIndex = 1;
            menuStripPrincipal.Text = "menuStrip1";
            // 
            // menuGestionClientes
            // 
            menuGestionClientes.Name = "menuGestionClientes";
            menuGestionClientes.Size = new Size(162, 27);
            menuGestionClientes.Text = "Gestionar Clientes";
            menuGestionClientes.Click += menuGestionClientes_Click;
            // 
            // menuGestionProfesionales
            // 
            menuGestionProfesionales.Name = "menuGestionProfesionales";
            menuGestionProfesionales.Size = new Size(202, 27);
            menuGestionProfesionales.Text = "Gestionar Profesionales";
            menuGestionProfesionales.Click += menuGestionProfesionales_Click;
            // 
            // menuGestionActividades
            // 
            menuGestionActividades.Name = "menuGestionActividades";
            menuGestionActividades.Size = new Size(188, 27);
            menuGestionActividades.Text = "Gestionar Actividades";
            menuGestionActividades.Click += menuGestionActividades_Click;
            // 
            // menuGestionTurnos
            // 
            menuGestionTurnos.DropDownItems.AddRange(new ToolStripItem[] { subMenuGestionarTurnos, subMenuRegistroAsistencia });
            menuGestionTurnos.Name = "menuGestionTurnos";
            menuGestionTurnos.Size = new Size(169, 27);
            menuGestionTurnos.Text = "Turnos y Asistencia";
            // 
            // subMenuGestionarTurnos
            // 
            subMenuGestionarTurnos.Name = "subMenuGestionarTurnos";
            subMenuGestionarTurnos.Size = new Size(241, 28);
            subMenuGestionarTurnos.Text = "Administrar Turnos";
            subMenuGestionarTurnos.Click += subMenuGestionarTurnos_Click;
            // 
            // subMenuRegistroAsistencia
            // 
            subMenuRegistroAsistencia.Name = "subMenuRegistroAsistencia";
            subMenuRegistroAsistencia.Size = new Size(241, 28);
            subMenuRegistroAsistencia.Text = "Registrar Asistencia";
            subMenuRegistroAsistencia.Click += subMenuRegistroAsistencia_Click;
            // 
            // menuLiquidaciones
            // 
            menuLiquidaciones.Name = "menuLiquidaciones";
            menuLiquidaciones.Size = new Size(127, 27);
            menuLiquidaciones.Text = "Liquidaciones";
            menuLiquidaciones.Click += menuLiquidaciones_Click;
            // 
            // menuDashboard
            // 
            menuDashboard.Name = "menuDashboard";
            menuDashboard.Size = new Size(107, 27);
            menuDashboard.Text = "Dashboard";
            menuDashboard.Click += menuDashboard_Click;
            // 
            // menuSeguridad
            // 
            menuSeguridad.Name = "menuSeguridad";
            menuSeguridad.Size = new Size(101, 27);
            menuSeguridad.Text = "Seguridad";
            menuSeguridad.Click += menuSeguridad_Click;
            // 
            // menuBackupRestore
            // 
            menuBackupRestore.DropDownItems.AddRange(new ToolStripItem[] { subMenuBackup, subMenuRestore, subMenuBitacora });
            menuBackupRestore.Name = "menuBackupRestore";
            menuBackupRestore.Size = new Size(153, 27);
            menuBackupRestore.Text = "Backup / Restore";
            // 
            // subMenuBackup
            // 
            subMenuBackup.Name = "subMenuBackup";
            subMenuBackup.Size = new Size(215, 28);
            subMenuBackup.Text = "Realizar Backup";
            subMenuBackup.Click += subMenuBackup_Click;
            // 
            // subMenuRestore
            // 
            subMenuRestore.Name = "subMenuRestore";
            subMenuRestore.Size = new Size(215, 28);
            subMenuRestore.Text = "Realizar Restore";
            subMenuRestore.Click += subMenuRestore_Click;
            // 
            // subMenuBitacora
            // 
            subMenuBitacora.Name = "subMenuBitacora";
            subMenuBitacora.Size = new Size(215, 28);
            subMenuBitacora.Text = "Ver Bitácora";
            subMenuBitacora.Click += subMenuBitacora_Click;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = SystemColors.ControlLight;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 205);
            panelContenedor.Margin = new Padding(3, 5, 3, 5);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1286, 792);
            panelContenedor.TabIndex = 2;
            // 
            // lblTituloFormHijo
            // 
            lblTituloFormHijo.AutoSize = true;
            lblTituloFormHijo.BackColor = SystemColors.Control;
            lblTituloFormHijo.Dock = DockStyle.Top;
            lblTituloFormHijo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTituloFormHijo.Location = new Point(0, 159);
            lblTituloFormHijo.Name = "lblTituloFormHijo";
            lblTituloFormHijo.Padding = new Padding(13, 9, 0, 9);
            lblTituloFormHijo.Size = new Size(131, 46);
            lblTituloFormHijo.TabIndex = 3;
            lblTituloFormHijo.Text = "Bienvenido";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 997);
            Controls.Add(panelContenedor);
            Controls.Add(lblTituloFormHijo);
            Controls.Add(menuStripPrincipal);
            Controls.Add(panelTitulo);
            MainMenuStrip = menuStripPrincipal;
            Margin = new Padding(3, 5, 3, 5);
            Name = "frmInicio";
            Text = "ProGym - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmInicio_FormClosing;
            Load += frmInicio_Load;
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            menuStripPrincipal.ResumeLayout(false);
            menuStripPrincipal.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem subMenuGestionarTurnos;
        private System.Windows.Forms.ToolStripMenuItem subMenuRegistroAsistencia;
        private PictureBox pbLogo;
    }
}